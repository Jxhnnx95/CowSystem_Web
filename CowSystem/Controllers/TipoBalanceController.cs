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
    public class TipoBalanceController : Controller
    {
        #region Context
        private readonly ApplicationDbContext _context;

        public TipoBalanceController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.TipoBalance.ToList();
            List<TipoBalanceViewModel> List = new List<TipoBalanceViewModel>();
            foreach (var item in Types)
            {
                TipoBalanceViewModel type = new TipoBalanceViewModel
                {
                    IdTipoBalance = item.IdTipoBalance,
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
        public IActionResult Create(TipoBalanceViewModel tipo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    TipoBalance TipoBalance = new TipoBalance
                    {
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.TipoBalance.Add(TipoBalance);
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
            TipoBalance TipoBalance = _context.TipoBalance.Find(id);

            if (TipoBalance != null)
            {
                TipoBalanceViewModel tipo = new TipoBalanceViewModel
                {
                    IdTipoBalance = TipoBalance.IdTipoBalance,
                    Descripcion = TipoBalance.Descripcion,
                    UltimaActualizacion = Utilitaries.getRelativeTime(TipoBalance.UltimaActualizacion)
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
        public IActionResult Edit(TipoBalanceViewModel tipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoBalance TipoBalance = new TipoBalance
                    {
                        IdTipoBalance = tipo.IdTipoBalance,
                        Descripcion = tipo.Descripcion,
                        UltimaActualizacion = DateTime.Now
                    };
                    _context.TipoBalance.Update(TipoBalance);
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
            TipoBalance TipoBalance = _context.TipoBalance.Find(id);

            if (TipoBalance != null)
            {
                try
                {
                    _context.TipoBalance.Remove(TipoBalance);
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
