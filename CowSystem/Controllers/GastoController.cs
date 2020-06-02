using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CowSystem.Models;
using CowSystem.Data;
using CowSystem.Code;
using System.Globalization;

namespace CowSystem.Controllers
{
    public class GastoController : Controller
    {
        #region Context
        private readonly ApplicationDbContext _context;
        private int IdEmpresa = Utilitaries.IdEmpresa;
        public GastoController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.Gasto.Where(x=>x.IdEmpresa == IdEmpresa).ToList();
            List<GastoViewModel> List = new List<GastoViewModel>();
            foreach (var item in Types)
            {
                GastoViewModel type = new GastoViewModel
                {
                    IdGasto = item.IdGasto,
                    FechaString = item.Fecha.ToShortDateString(),
                    Factura = item.Factura,
                    Proveedor = item.Proveedor,
                    MontoString = item.Monto.ToString("C", CultureInfo.CreateSpecificCulture("es-CR")),
                    Descripcion = item.Descripcion,
                    UltimaActualizacion = Utilitaries.getRelativeTime(item.UltimaActualizacion)
                };
                List.Add(type);
            }
            return View(List);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GastoViewModel tipo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    Gasto gasto = new Gasto
                    {
                        IdEmpresa = IdEmpresa,
                        Fecha = tipo.Fecha,
                        Factura = tipo.Factura,
                        Proveedor = tipo.Proveedor,
                        Monto = tipo.Monto,
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.Gasto.Add(gasto);
                    _context.SaveChanges();
                    TempData["msj"] = "Elemento agregado";

                    //agregar historial
                    var terneros = _context.Ganado.Select(x=> new { IdGanado = x.IdGanado, IdEmpresa = x.IdEmpresa, FechaNacimiento = x.FechaNacimiento, Tipo = x.Tipo}).Where(x => x.FechaNacimiento <= gasto.Fecha && x.IdEmpresa == IdEmpresa && (x.Tipo == 2 || x.Tipo == 3)).ToList();
                    int totalTerneros = terneros.Count;
                    double monto = gasto.Monto / totalTerneros;
                    foreach (var item in terneros)
                    {
                        HistorialFinanciero historial = new HistorialFinanciero
                        {
                            IdEmpresa = IdEmpresa,
                            IdGasto = gasto.IdGasto,
                            IdGanado = item.IdGanado,
                            IdTipoBalance = 1,
                            Monto = monto,
                            UltimaActualizacion = DateTime.Now
                        };
                        _context.HistorialFinanciero.Add(historial);
                        _context.SaveChanges();

                        Bitacora bitacora = new Bitacora
                        {
                            IdEmpresa = IdEmpresa,
                            IdGanado = item.IdGanado,
                            IdAccion = 6,
                            IdHistorial = historial.IdHistorial,
                            Url = "/Gasto/Details/" + gasto.IdGasto,
                            IdUsuario = 0,//CAMBIAR!!!!!!!!!!!!!!!!!!!!!!!!!!
                            FechaRegistro = DateTime.Now
                        };
                        _context.Bitacora.Add(bitacora);
                        _context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    TempData["err"] = e.InnerException.ToString();
                }
            }
            else
            {
                TempData["err"] = "Formulario incompleto";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            Gasto Gasto = _context.Gasto.Find(id);

            if (Gasto != null)
            {
                GastoViewModel tipo = new GastoViewModel
                {
                    IdGasto = Gasto.IdGasto,
                    Fecha = Gasto.Fecha,
                    Factura = Gasto.Factura,
                    Proveedor = Gasto.Proveedor,
                    Monto = Gasto.Monto,
                    Descripcion = Gasto.Descripcion,
                    UltimaActualizacion = Utilitaries.getRelativeTime(Gasto.UltimaActualizacion)
                };
                return View(tipo);
            }
            else
            {
                TempData["err"] = "No se encontro el elemento";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(GastoViewModel tipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Gasto gasto = _context.Gasto.Find(tipo.IdGasto);
                    gasto.Fecha = tipo.Fecha;
                    gasto.Factura = tipo.Factura;
                    gasto.Proveedor = tipo.Proveedor;
                    gasto.Descripcion = tipo.Descripcion;
                    gasto.UltimaActualizacion = DateTime.Now;
                    

                    if (gasto.Monto !=tipo.Monto)
                    {
                        var terneros = _context.Ganado.Select(x => new { IdGanado = x.IdGanado, IdEmpresa = x.IdEmpresa, FechaNacimiento = x.FechaNacimiento, Tipo = x.Tipo }).Where(x => x.FechaNacimiento <= gasto.Fecha && x.IdEmpresa==IdEmpresa && (x.Tipo == 2 || x.Tipo == 3)).ToList();
                        int totalTerneros = terneros.Count;
                        double monto = tipo.Monto / totalTerneros;
                        var historial = _context.HistorialFinanciero.Where(x => x.IdGasto == tipo.IdGasto).ToList();
                        foreach (var item in historial)
                        {
                            item.Monto = monto;
                            _context.HistorialFinanciero.Update(item);
                            _context.SaveChanges();
                        }
                    }
                    gasto.Monto = tipo.Monto;
                    _context.Gasto.Update(gasto);
                    _context.SaveChanges();
                    TempData["msj"] = "Elemento modificado";
                }
                catch (Exception e)
                {
                    TempData["err"] = e.InnerException.ToString();
                }

                return RedirectToAction("Index");
            }
            else
            {
                TempData["err"] = "Error al rellenar el formulario";
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            Gasto Gasto = _context.Gasto.Find(id);

            if (Gasto != null)
            {
                try
                {
                    var historial = _context.HistorialFinanciero.Where(x => x.IdGasto == id).ToList();
                    foreach (var item in historial)
                    {
                        var bitacora = _context.Bitacora.Where(x => x.IdHistorial == item.IdHistorial).FirstOrDefault();
                        _context.Bitacora.Remove(bitacora);
                        _context.HistorialFinanciero.Remove(item);
                        _context.SaveChanges();
                    }
                    _context.Gasto.Remove(Gasto);
                    _context.SaveChanges();
                    TempData["msj"] = "Elemento eliminado";
                }
                catch (Exception e)
                {
                    TempData["err"] = e.InnerException.ToString();
                }
            }
            else
            {
                TempData["err"] = "No se encontro el elemento";

            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
