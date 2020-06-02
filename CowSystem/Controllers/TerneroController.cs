using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CowSystem.Models;
using CowSystem.Data;
using CowSystem.Code;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Table;

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

        private double getValor(int id) {
            var historial = _context.HistorialFinanciero
                .Select(x => new { IdGanado = x.IdGanado, IdTipoBalance = x.IdTipoBalance, Monto = x.Monto })
                .Where(x => x.IdGanado == id && (x.IdTipoBalance == 1 || x.IdTipoBalance == 2))
                .ToList();
            double positivos = historial.Count!=0?historial.Where(x => x.IdTipoBalance == 1).Sum(x => x.Monto):0;
            double negativos = historial.Count!=0?historial.Where(x => x.IdTipoBalance == 2).Sum(x => x.Monto):0;
            return positivos - negativos;
        }
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
                    ValorString = Utilitaries.ConvertToColon(item.Valor.Value + getValor(item.IdGanado)),
                    UltimaActualizacion = item.UltimaActualizacion==null?"Error":Utilitaries.getRelativeTime(item.UltimaActualizacion.Value)
                };
                List.Add(type);
            }
            return View(List);
        }

        public IActionResult Export()
        {
            var terneros = _context.Ganado.Where(x => x.IdEmpresa == IdEmpresa && (x.Tipo == 2 || x.Tipo == 3)).ToList().OrderBy(x => x.Tipo).OrderBy(x => x.Estado);
            byte[] fileContents;

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Terneros");

            //AGREGAR IMAGEN 
            int rowIndex = 0;
            int colIndex = 0;
            int Height = 250;
            int Width = 70;
            Image img = Image.FromFile("D:\\logo.png");
            ExcelPicture pic = Sheet.Drawings.AddPicture("Logo", img);
            pic.SetPosition(rowIndex, 0, colIndex, 0);
            pic.SetSize(Height, Width);
            Sheet.View.ShowGridLines = false;

            //AGREGAR TITULOS DEL DOCUMENTO
            Sheet.Cells["A5"].Value = "Lista de Terneros";
            Sheet.Cells["A6"].Value = "Fecha al "+ DateTime.Now.ToString("dd-mm-yyyy");
            Sheet.Cells["A5:A6"].Style.Font.Bold = true;
            Sheet.Cells["A5:A6"].Style.Font.Size = 14;
            
            //AGREGAR TITULOS DE LA TABLA
            Sheet.Cells["A8"].Value = "Identificador";
            Sheet.Cells["B8"].Value = "Sexo";
            Sheet.Cells["C8"].Value = "Estado";
            Sheet.Cells["D8"].Value = "Edad";
            Sheet.Cells["E8"].Value = "Fecha Nacimiento";
            Sheet.Cells["E:E"].Style.Numberformat.Format = "dd-mm-yyyy";
            Sheet.Cells["F8"].Value = "Valor Inicial";
            Sheet.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";
            Sheet.Cells["G8"].Value = "Valor Actual";
            Sheet.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";
            Sheet.Cells["H8"].Value = "Peso";
            Sheet.Cells["I8"].Value = "Madre";
            Sheet.Cells["J8"].Value = "Padre";

            int row = 9; //donde inicia el contenido

            //AGREGAR CONTENIDO A LA TABLA
            foreach (var item in terneros)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.Codigo;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.TipoNavigation.Descripcion.Equals("Ternero Macho") ? "Macho" : "Hembra";
                Sheet.Cells[string.Format("C{0}", row)].Value = item.EstadoNavigation.Descripcion;
                Sheet.Cells[string.Format("D{0}", row)].Value = Utilitaries.GetDifferenceDate(DateTime.Now, item.FechaNacimiento.Value);
                Sheet.Cells[string.Format("E{0}", row)].Value = item.FechaNacimiento;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Valor;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.Valor + getValor(item.IdGanado);
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Peso==null?"":item.Peso+" kg";
                Sheet.Cells[string.Format("I{0}", row)].Value = item.IdMadre == null ? "" : _context.Ganado.Find(item.IdMadre.Value).Codigo;
                Sheet.Cells[string.Format("J{0}", row)].Value = item.IdMadre == null ? "" : _context.Ganado.Find(item.IdPadre.Value).Codigo;
                row++;
            }

            //GENERAR TABLA
            int firstRow = 8;
            int lastRow = Sheet.Dimension.End.Row;
            int firstColumn = 1;
            int lastColumn = Sheet.Dimension.End.Column;
            ExcelRange rg = Sheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "Table1";
            ExcelTable tab = Sheet.Tables.Add(rg, tableName);
            tab.TableStyle = TableStyles.Medium14;

            //GENERAR EXCEL
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            fileContents = Ep.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Lista Terneros "+DateTime.Now+".xlsx"
            );
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
                        ValorString = Utilitaries.ConvertToColon(ternero.Valor.Value+getValor(id)),
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
                        IdEmpresa = IdEmpresa,
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

                        Bitacora bitacora = new Bitacora
                        {
                            IdEmpresa = IdEmpresa,
                            IdUsuario = 0, //CAMBIAR!!!!!!!!!!!!!!!!!!!!!!
                            IdGanado = ganado.IdGanado,
                            IdAccion = 1,
                            FechaRegistro = DateTime.Now
                        };
                        _context.Bitacora.Add(bitacora);
                        _context.SaveChanges();
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
                    Bitacora bitacora = new Bitacora
                    {
                        IdEmpresa = IdEmpresa,
                        IdUsuario = 0, //CAMBIAR!!!!!!!!!!!!!!!!!!!!!!
                        IdGanado = ganado.IdGanado,
                        IdAccion = 2,
                        FechaRegistro = DateTime.Now
                    };
                    _context.Bitacora.Add(bitacora);
                    _context.SaveChanges();
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
                    Bitacora bitacora = new Bitacora
                    {
                        IdEmpresa = IdEmpresa,
                        IdUsuario = 0, //CAMBIAR!!!!!!!!!!!!!!!!!!!!!!
                        IdGanado = ganado.IdGanado,
                        IdAccion = 3,
                        FechaRegistro = DateTime.Now
                    };
                    _context.Bitacora.Add(bitacora);
                    _context.SaveChanges();
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
