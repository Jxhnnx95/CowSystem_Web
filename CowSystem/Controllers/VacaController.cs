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
using DataTablesParser;

namespace CowSystem.Controllers
{
    public class VacaController : Controller
    {
        #region Context
        private readonly ApplicationDbContext _context;
        private int IdEmpresa = Utilitaries.IdEmpresa;
        public VacaController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult Index()
        {
            var Types = _context.Ganado.Where(x => x.IdEmpresa == IdEmpresa && x.Tipo == 4).ToList().OrderBy(x => x.Tipo).OrderBy(x => x.FechaNacimiento);
            List<VacaViewModel> List = new List<VacaViewModel>();
            foreach (var item in Types)
            {
                VacaViewModel type = new VacaViewModel
                {
                    IdGanado = item.IdGanado,
                    Codigo = item.Codigo,
                    EstadoString = item.EstadoNavigation.Descripcion,
                    PartosString = item.Partos +" partos",
                    EdadString = Utilitaries.GetDifferenceDate(DateTime.Now, item.FechaNacimiento.Value),
                    ValorString = Utilitaries.ConvertToColon(item.Valor.Value),
                    UltimaActualizacion = item.UltimaActualizacion == null ? "Error" : Utilitaries.getRelativeTime(item.UltimaActualizacion.Value)
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
                Ganado vaca = _context.Ganado.Find(id);
                if (vaca != null)
                {
                    VacaViewModel vacaViewModel = new VacaViewModel {
                        IdGanado = vaca.IdGanado,
                        Codigo = vaca.Codigo,
                        PartosString = vaca.Partos + " partos",
                        EstadoString = vaca.EstadoNavigation.Descripcion,
                        FechaNacimientoString = vaca.FechaNacimiento.Value.ToShortDateString(),
                        FechaIngresoString = vaca.FechaIngreso.Value.ToShortDateString(),
                        FechaSalidaString = vaca.FechaSalida == null ? " - " : vaca.FechaSalida.Value.ToShortDateString(),
                        PesoString = vaca.Peso == null ? " - " : vaca.Peso + " KG",
                        ValorPesoString = vaca.ValorPeso == null ? " - " : Utilitaries.ConvertToColon(vaca.ValorPeso.Value),
                        ValorString = Utilitaries.ConvertToColon(vaca.Valor.Value),
                        EdadString = Utilitaries.GetDifferenceDate(DateTime.Now, vaca.FechaNacimiento.Value),
                        MadreUrl = vaca.IdMadre == null?"#":"/Vaca/Details/"+vaca.IdMadre.Value,
                        MadreString = vaca.IdMadre==null?" - ":_context.Ganado.Find(vaca.IdMadre.Value).Codigo,
                        PadreUrl = vaca.IdPadre == null?"#":"/Toro/Details/"+vaca.IdPadre.Value,
                        PadreString = vaca.IdPadre==null?" - ":_context.Ganado.Find(vaca.IdPadre.Value).Codigo,
                        UltimaActualizacion = vaca.UltimaActualizacion == null ? "Error" : Utilitaries.getRelativeTime(vaca.UltimaActualizacion.Value)
                    };
                    var bitacora = _context.Bitacora.Where(x => x.IdGanado == vacaViewModel.IdGanado).ToList();
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
                    vacaViewModel.EventList = eventList;
                    return View(vacaViewModel);
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
            VacaViewModel vacaView = new VacaViewModel
            {
                VacasList = _context.Ganado.Where(x => x.Tipo == 4 && (x.Estado==2 || x.Estado==4)).ToList(),
                TorosList = _context.Ganado.Where(x => x.Tipo == 5 && (x.Estado==2 || x.Estado==4)).ToList()                
            };
                return View(vacaView);
            }
            
            [HttpPost]
            public IActionResult Create(VacaViewModel ganadoView)
            {
                if (ModelState.IsValid)
                {

                    try
                    {
                    Ganado ganado = new Ganado
                    {
                        IdEmpresa = IdEmpresa,
                        Codigo = ganadoView.Codigo,
                        Tipo = 4,
                        Estado = 2,
                        FechaIngreso = DateTime.Now,
                        FechaNacimiento = ganadoView.FechaNacimiento,
                        Peso = ganadoView.Peso,
                        Valor = ganadoView.Valor,
                        ValorPeso = ganadoView.ValorPeso,
                        IdMadre = ganadoView.IdMadre != 0 ? ganadoView.IdMadre : null,
                        IdPadre = ganadoView.IdPadre != 0 ? ganadoView.IdPadre : null,
                        Partos = ganadoView.Partos,
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

                if (ganado != null && ganado.Tipo == 4)
                {
                    VacaViewModel ganadoView = new VacaViewModel
                    {
                        VacasList = _context.Ganado.Where(x => x.Tipo == 4 && (x.Estado == 2 || x.Estado == 4)).ToList(),
                        TorosList = _context.Ganado.Where(x => x.Tipo == 5 && (x.Estado == 2 || x.Estado == 4)).ToList(),
                        IdGanado = ganado.IdGanado,
                        Codigo = ganado.Codigo,
                        Partos = ganado.Partos,
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
            public IActionResult Edit(VacaViewModel ganadoView)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                    Ganado ganado = _context.Ganado.Find(ganadoView.IdGanado);

                    ganado.Codigo = ganadoView.Codigo;
                    ganado.Tipo = ganadoView.Partos;
                    ganado.Partos = ganadoView.Partos;
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
