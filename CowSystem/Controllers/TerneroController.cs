using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CowSystem.Models;
using CowSystem.Data;
using CowSystem.Code;

namespace CowSystem.Controllers
{
    public class TerneroController : Controller
    {
        #region Context
        private readonly ApplicationDbContext _context;

        public TerneroController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.Ganado.Where(x=> x.Tipo == 2 || x.Tipo==3).ToList().OrderBy(x=>x.Tipo).OrderBy(x=>x.Estado);
            List<TerneroViewModel> List = new List<TerneroViewModel>();
            foreach (var item in Types)
            {
                TerneroViewModel type = new TerneroViewModel
                {
                    IdGanado = item.IdGanado,
                    Codigo = item.Codigo,
                    Tipo = item.Tipo,
                    TipoString = item.TipoNavigation.Descripcion,
                    UltimaActualizacion = item.UltimaActualizacion==null?"Error":Utilitaries.getRelativeTime(item.UltimaActualizacion.Value)
                };
                List.Add(type);
            }
            return View(List);
        }
        #endregion
        /*
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoGanadoViewModel tipo)
        {
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
            TipoGanado tipoGanado = _context.TipoGanado.Find(id);

            if (tipoGanado != null)
            {
                TipoGanadoViewModel tipo = new TipoGanadoViewModel
                {
                    IdTipoGanado = tipoGanado.IdTipoGanado,
                    Descripcion = tipoGanado.Descripcion,
                    UltimaActualizacion = Utilitaries.getRelativeTime(tipoGanado.UltimaActualizacion)
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
            TipoGanado tipoGanado = _context.TipoGanado.Find(id);

            if (tipoGanado != null)
            {
                try
                {
                    _context.TipoGanado.Remove(tipoGanado);
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
        #endregion*/
    }
}
