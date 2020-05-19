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

        public GastoController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.Gasto.ToList();
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
                    Gasto Gasto = new Gasto
                    {
                        Fecha = tipo.Fecha,
                        Factura = tipo.Factura,
                        Proveedor = tipo.Proveedor,
                        Monto = tipo.Monto,
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.Gasto.Add(Gasto);
                    _context.SaveChanges();
                    TempData["msj"] = "Elemento agregado";
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
                    Gasto Gasto = new Gasto
                    {
                        IdGasto = tipo.IdGasto,
                        Fecha = tipo.Fecha,
                        Factura = tipo.Factura,
                        Proveedor = tipo.Proveedor,
                        Monto = tipo.Monto,
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.Gasto.Update(Gasto);
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
