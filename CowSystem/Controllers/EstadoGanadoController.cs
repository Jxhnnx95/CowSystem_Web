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
    public class EstadoGanadoController : Controller
    {
        #region Context
        private readonly ApplicationDbContext _context;

        public EstadoGanadoController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.EstadoGanado.ToList();
            List<EstadoGanadoViewModel> List = new List<EstadoGanadoViewModel>();
            foreach (var item in Types)
            {
                EstadoGanadoViewModel type = new EstadoGanadoViewModel
                {
                    IdEstadoGanado = item.IdEstadoGanado,
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
        public IActionResult Create(EstadoGanadoViewModel Estado)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    EstadoGanado EstadoGanado = new EstadoGanado
                    {
                        Descripcion = Estado.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.EstadoGanado.Add(EstadoGanado);
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
            EstadoGanado EstadoGanado = _context.EstadoGanado.Find(id);

            if (EstadoGanado != null)
            {
                EstadoGanadoViewModel Estado = new EstadoGanadoViewModel
                {
                    IdEstadoGanado = EstadoGanado.IdEstadoGanado,
                    Descripcion = EstadoGanado.Descripcion,
                    UltimaActualizacion = Utilitaries.getRelativeTime(EstadoGanado.UltimaActualizacion)
                };
                return View(Estado);
            }
            else
            {
                TempData["err"] = "No se encontro el elemento";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(EstadoGanadoViewModel Estado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EstadoGanado EstadoGanado = new EstadoGanado
                    {
                        IdEstadoGanado = Estado.IdEstadoGanado,
                        Descripcion = Estado.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.EstadoGanado.Update(EstadoGanado);
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
            EstadoGanado EstadoGanado = _context.EstadoGanado.Find(id);

            if (EstadoGanado != null)
            {
                try
                {
                    _context.EstadoGanado.Remove(EstadoGanado);
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
