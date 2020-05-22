using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CowSystem.Models;
using CowSystem.Data;
using CowSystem.Code;
using Microsoft.EntityFrameworkCore;

namespace CowSystem.Controllers
{
    public class BitacoraController : Controller
    {
        #region Context
        private readonly ApplicationDbContext _context;

        public BitacoraController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.Bitacora.ToList();
            List<BitacoraViewModel> List = new List<BitacoraViewModel>();
            foreach (var item in Types)
            {
                BitacoraViewModel type = new BitacoraViewModel
                {
                    IdRegistro = item.IdRegistro,
                    Ganado = item.GanadoNavigation.Codigo,
                    GanadoURL = item.GanadoNavigation.Tipo == 2 ? "/Ternero/Details/" + item.GanadoNavigation.IdGanado : item.GanadoNavigation.Tipo == 3 ? "/Ternero/Details/" + item.GanadoNavigation.IdGanado : item.GanadoNavigation.Tipo == 4 ? "/Vaca/Details/" + item.GanadoNavigation.IdGanado : "/Toro/Details/" + item.GanadoNavigation.IdGanado,
                    TipoBalance = item.AccionNavigation.Descripcion,
                    Gasto = item.HistorialNavigation.Monto.ToString(),
                    GastoURL = "/Gasto/Details/"+item.HistorialNavigation.IdGasto,
                    Usuario = "Falta usuario!",
                    FechaRegistro = item.FechaRegistro.ToShortDateString()
                };
                List.Add(type);
            }
            return View(List);
        }
        #endregion

        #region Create
        /*public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BitacoraViewModel tipo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    Bitacora Bitacora = new Bitacora
                    {
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.Bitacora.Add(Bitacora);
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
        }*/
        #endregion

        #region Edit
        /*
    public IActionResult Edit(int id)
    {
        Bitacora Bitacora = _context.Bitacora.Find(id);

        if (Bitacora != null)
        {
            BitacoraViewModel tipo = new BitacoraViewModel
            {
                IdBitacora = Bitacora.IdBitacora,
                Descripcion = Bitacora.Descripcion,
                UltimaActualizacion = Utilitaries.getRelativeTime(Bitacora.UltimaActualizacion)
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
    public IActionResult Edit(BitacoraViewModel tipo)
    {
        if (ModelState.IsValid)
        {
            try
            {
                Bitacora Bitacora = new Bitacora
                {
                    IdBitacora = tipo.IdBitacora,
                    Descripcion = tipo.Descripcion,
                    UltimaActualizacion = DateTime.Now
                };
                _context.Bitacora.Update(Bitacora);
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
    }*/
        #endregion

        #region Delete
        public IActionResult DeleteAll() {
            try
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE Bitacora");
                _context.SaveChanges();
                TempData["msj"] = "Elementos eliminados";
            }
            catch (Exception e)
            {
                TempData["err"] = e.InnerException.ToString();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Bitacora Bitacora = _context.Bitacora.Find(id);

            if (Bitacora != null)
            {
                try
                {
                    _context.Bitacora.Remove(Bitacora);
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
