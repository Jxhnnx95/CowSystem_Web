using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CowSystem.Models;
using CowSystem.Data;

namespace CowSystem.Controllers
{
    public class TipoGanadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoGanadoController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            var Types = _context.TipoGanado.ToList();
            List<TipoGanadoViewModel> List = new List<TipoGanadoViewModel>();
            foreach (var item in Types)
            {
                TipoGanadoViewModel type = new TipoGanadoViewModel {
                    IdTipoGanado = item.IdTipoGanado,
                    Descripcion = item.Descripcion,
                    UltimaActualizacion = item.UltimaActualizacion
                };
                List.Add(type);
            }
            return View(List);
        }

        
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoGanadoViewModel tipo) {
            string msj;
            if (ModelState.IsValid)
            {

                try
                {
                    TipoGanado tipoGanado = new TipoGanado
                    {
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.TipoGanado.Add(tipoGanado);
                    _context.SaveChanges();
                    msj = "Todo Bien";
                }
                catch (Exception e)
                {
                    msj = "Error " + e.InnerException;
                }
            }
            else {
                msj = "Formulario incompleto";
            }
            TempData["msj"] = msj;
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) {
            TipoGanado tipoGanado = _context.TipoGanado.Find(id);

            if (tipoGanado != null)
            {
                TipoGanadoViewModel tipo = new TipoGanadoViewModel
                {
                    IdTipoGanado = tipoGanado.IdTipoGanado,
                    Descripcion = tipoGanado.Descripcion,
                    UltimaActualizacion = tipoGanado.UltimaActualizacion
                };
                return View(tipo);
            }
            else {
                TempData["msj"] = "No se encontro el elemento";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(TipoGanadoViewModel tipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoGanado tipoGanado = new TipoGanado
                    {
                        IdTipoGanado = tipo.IdTipoGanado,
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.TipoGanado.Update(tipoGanado);
                    _context.SaveChanges();
                    TempData["msj"] = "Todo Bien";
                }
                catch (Exception e)
                {
                    TempData["msj"] = "Error " + e.InnerException;
                }

                return RedirectToAction("Index");
            }
            else {
                TempData["msj"] = "Error al rellenar el formulario";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id) {
            TipoGanado tipoGanado = _context.TipoGanado.Find(id);

            if (tipoGanado != null)
            {
                try
                {
                    _context.TipoGanado.Remove(tipoGanado);
                    _context.SaveChanges();
                    TempData["msj"] = "Eliminado";
                }
                catch (Exception e)
                {
                    TempData["msj"] = "Error " + e.InnerException;
                }
            }
            else
            {
                TempData["msj"] = "No se encontro el elemento";
                
            }
            return RedirectToAction("Index");
        }
    }
}
