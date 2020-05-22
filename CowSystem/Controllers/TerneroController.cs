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
        private int IdEmpresa = Utilitaries.IdEmpresa;
        public TerneroController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.Ganado.Where(x=> x.IdEmpresa == IdEmpresa && (x.Tipo == 2 || x.Tipo==3)).ToList().OrderBy(x=>x.Tipo).OrderBy(x=>x.Estado);
            List<TerneroViewModel> List = new List<TerneroViewModel>();
            foreach (var item in Types)
            {
                TerneroViewModel type = new TerneroViewModel
                {
                    IdGanado = item.IdGanado,
                    Codigo = item.Codigo,
                    TipoString = item.TipoNavigation.Descripcion.Equals("Ternero Macho") ? "Macho" : "Hembra",
                    EstadoString = item.EstadoNavigation.Descripcion,
                    EdadString = Utilitaries.GetDifferenceDate(DateTime.Now, item.FechaNacimiento.Value),
                    ValorString = Utilitaries.ConvertToColon(item.Valor.Value),
                    UltimaActualizacion = item.UltimaActualizacion==null?"Error":Utilitaries.getRelativeTime(item.UltimaActualizacion.Value)
                };
                List.Add(type);
            }
            return View(List);
        }
        #endregion
        #region Details
        public IActionResult Details(int id)
        {
            try
            {
                Ganado ternero = _context.Ganado.Find(id);
                if (ternero != null)
                {
                    TerneroViewModel terneroViewModel = new TerneroViewModel {
                        IdGanado = ternero.IdGanado,
                        Codigo = ternero.Codigo,
                        TipoString = ternero.TipoNavigation.Descripcion.Equals("Ternero Macho") ? "Macho" : "Hembra",
                        EstadoString = ternero.EstadoNavigation.Descripcion,
                        FechaNacimientoString = ternero.FechaNacimiento.Value.ToShortDateString(),
                        FechaIngresoString = ternero.FechaIngreso.Value.ToShortDateString(),
                        FechaSalidaString = ternero.FechaSalida == null ? " - " : ternero.FechaSalida.Value.ToShortDateString(),
                        PesoString = ternero.Peso == null ? " - " : ternero.Peso + " KG",
                        ValorPesoString = ternero.ValorPeso == null ? " - " : Utilitaries.ConvertToColon(ternero.ValorPeso.Value),
                        ValorString = Utilitaries.ConvertToColon(ternero.Valor.Value),
                        EdadString = Utilitaries.GetDifferenceDate(DateTime.Now, ternero.FechaNacimiento.Value),
                        MadreUrl = ternero.IdMadre == null?"#":"/Vaca/Details/"+ternero.IdMadre.Value,
                        MadreString = ternero.IdMadre==null?" - ":_context.Ganado.Find(ternero.IdMadre.Value).Codigo,
                        PadreUrl = ternero.IdPadre == null?"#":"/Toro/Details/"+ternero.IdPadre.Value,
                        PadreString = ternero.IdPadre==null?" - ":_context.Ganado.Find(ternero.IdPadre.Value).Codigo,
                        UltimaActualizacion = ternero.UltimaActualizacion == null ? "Error" : Utilitaries.getRelativeTime(ternero.UltimaActualizacion.Value)
                    };
                    var bitacora = _context.Bitacora.Where(x => x.IdGanado == terneroViewModel.IdGanado).ToList();
                    List<Evento> eventList = new List<Evento>();
                    foreach (var x in bitacora)
                    {
                        Evento evento = new Evento
                        {
                            Description = x.IdHistorial != null? x.AccionNavigation.Descripcion +" "+Utilitaries.ConvertToColon(x.HistorialNavigation.Monto) +" el " + x.FechaRegistro.ToShortDateString() : x.AccionNavigation.Descripcion +" el " + x.FechaRegistro.ToShortDateString(),
                            Url = x.Url == null ? "#" : x.Url
                        };
                        eventList.Add(evento);
                    }
                    terneroViewModel.EventList = eventList;
                    return View(terneroViewModel);
                }
                else {
                    TempData["err"] = "No se encontró el elemento";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["err"] = e.InnerException.ToString();
                return RedirectToAction("Index");
            }

        }
            #endregion
            
            #region Create
            public IActionResult Create()
            {
            TerneroViewModel terneroView = new TerneroViewModel
            {
                TipoGanadoList = _context.TipoGanado.Where(x => x.IdTipoGanado == 2 || x.IdTipoGanado == 3).ToList(),
                VacasList = _context.Ganado.Where(x => x.Tipo == 4 && (x.Estado==2 || x.Estado==4)).ToList(),
                TorosList = _context.Ganado.Where(x => x.Tipo == 5 && (x.Estado==2 || x.Estado==4)).ToList()
                                
            };
                return View(terneroView);
            }
            
            [HttpPost]
            public IActionResult Create(TerneroViewModel ganadoView)
            {
                if (ModelState.IsValid)
                {

                    try
                    {
                    Ganado ganado = new Ganado
                    {
                        Codigo = ganadoView.Codigo,
                        Tipo = ganadoView.Tipo,
                        Estado = 1,
                        FechaIngreso = DateTime.Now,
                        FechaNacimiento = ganadoView.FechaNacimiento,
                        Peso = ganadoView.Peso,
                        Valor = ganadoView.Valor,
                        ValorPeso = ganadoView.ValorPeso,
                        IdMadre = ganadoView.IdMadre != 0 ? ganadoView.IdMadre : null,
                        IdPadre = ganadoView.IdPadre != 0 ? ganadoView.IdPadre : null,
                        UltimaActualizacion = DateTime.Now
                        };
                        _context.Ganado.Add(ganado);
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
                Ganado ganado = _context.Ganado.Find(id);

                if (ganado != null && (ganado.Tipo == 2 || ganado.Tipo == 3))
                {
                    TerneroViewModel ganadoView = new TerneroViewModel
                    {
                        TipoGanadoList = _context.TipoGanado.Where(x => x.IdTipoGanado == 2 || x.IdTipoGanado == 3).ToList(),
                        VacasList = _context.Ganado.Where(x => x.Tipo == 4 && (x.Estado == 2 || x.Estado == 4)).ToList(),
                        TorosList = _context.Ganado.Where(x => x.Tipo == 5 && (x.Estado == 2 || x.Estado == 4)).ToList(),
                        IdGanado = ganado.IdGanado,
                        Codigo = ganado.Codigo,
                        Tipo =  ganado.Tipo,
                        FechaNacimiento = ganado.FechaNacimiento,
                        Peso = ganado.Peso,
                        Valor = ganado.Valor,
                        ValorPeso = ganado.ValorPeso,
                        IdMadre = ganado.IdMadre,
                        IdPadre = ganado.IdPadre
                    };
                    return View(ganadoView);
                }
                else
                {
                    TempData["err"] = "No se encontro el elemento";
                    return RedirectToAction("Index");
                }
            }
            [HttpPost]
            public IActionResult Edit(TerneroViewModel ganadoView)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                    Ganado ganado = _context.Ganado.Find(ganadoView.IdGanado);

                    ganado.Codigo = ganadoView.Codigo;
                    ganado.Tipo = ganadoView.Tipo;
                    ganado.FechaNacimiento = ganadoView.FechaNacimiento;
                    ganado.Peso = ganadoView.Peso;
                    ganado.Valor = ganadoView.Valor;
                    ganado.ValorPeso = ganadoView.ValorPeso;
                    ganado.IdMadre = ganadoView.IdMadre != 0 ? ganadoView.IdMadre : null;
                    ganado.IdPadre = ganadoView.IdPadre != 0 ? ganadoView.IdPadre : null;
                    ganado.UltimaActualizacion = DateTime.Now;
                        
                        _context.Ganado.Update(ganado);
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
                Ganado ganado = _context.Ganado.Find(id);

                if (ganado != null)
                {
                    try
                    {
                        _context.Ganado.Remove(ganado);
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
