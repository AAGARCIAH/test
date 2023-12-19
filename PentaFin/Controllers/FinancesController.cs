using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PentaFinances.Dtos;
using PentaFinances.Managers;
using PentaFinances.Models;
using PentaFinances.Utils;

namespace PentaFinances.Controllers
{
    public class FinancesController : Controller
    {
        //
        // GET: /Finances/
        Utilities _util = new Utilities();

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
        
        RhContext _rh = new RhContext();
        IngresoManager _manager = new IngresoManager();
        CostoManager _managerCosto = new CostoManager();
        IngresoTotalManager _managerIngTotal = new IngresoTotalManager();
        PtfStageIndicadoresContext _ptf = new PtfStageIndicadoresContext();
        PentaFinContext _db = new PentaFinContext();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
        public ActionResult Ingreso (string mes, string an)
        {
                string yer = an;
                return View(new { mes = mes, an = yer });       
            
            
            //string yer = an;
            //return View(new { mes = mes, an = yer });        
            
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult _IngresosGenerales()
        {
            int mes = Request["mes"] == null ? DateTime.Now.Month : int.Parse(Request["mes"].ToString());
            int an = Request["an"] == null ? DateTime.Now.Year : int.Parse(Request["an"].ToString());

            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text", mes);
            ViewBag.Anios = new SelectList(_util.LstAnios(), "Value", "Text", an);


            var ingresos = new List<IngresosDto>();

            var campanas = _ptf.Campanas.Where(a => a.activo == true).ToList();

            foreach (var campana in campanas)
            {
                var dto = new IngresosDto
                {
                    Campana = campana
                };

                var bi =
                    _db.Database.SqlQuery<IngresoBi>("dbo.sp_GetBiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();
                var op =
                    _db.Database.SqlQuery<IngresoOp>("dbo.sp_GetOpDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",campana.idCampana, mes, an)
                        .FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<IngresoCi>("dbo.sp_GetCiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                if (op == null)
                {
                    dto.Ingreso = new IngresoGeneralesDto();
                }
                else
                {
                   var ing = new IngresoGeneralesDto
                {
                    DiasServicio = new GenericDto{ Bi = bi.DiasServicio, Op = op.DiasServicio, Ci = ci.DiasServicio},
                    HorasServicio = new GenericDto { Bi = bi.HorasServicio, Op = op.HorasServicio, Ci = ci.HorasServicio },
                    LlamadasAcd = new GenericDto { Bi = bi.LlamadasAcd, Op = op.LlamadasAcd, Ci = ci.LlamadasAcd },
                    LlamadasIvr = new GenericDto { Bi = bi.LlamadasIvr, Op = op.LlamadasIvr, Ci = ci.LlamadasIvr },
                    LlamadasEntrada = new GenericDto { Bi = bi.LlamadasEntrada, Op = op.LlamadasEntrada, Ci = ci.LlamadasEntrada },
                    LlamadasContestadas = new GenericDto { Bi = bi.LlamadasContestadas, Op = op.LlamadasContestadas, Ci = ci.LlamadasContestadas },
                    LlamadasFacturables = new GenericDto { Bi = bi.LlamadasFacturables, Op = op.LlamadasFacturables, Ci = ci.LlamadasFacturables },
                    LlamadasSalida = new GenericDto { Bi = bi.LlamadasSalida, Op = op.LlamadasSalida, Ci = ci.LlamadasSalida },
                    Chat = new GenericDto { Bi = bi.Chat, Op = op.Chat, Ci = ci.Chat },
                    Sms = new GenericDto { Bi = bi.Sms, Op = op.Sms, Ci = ci.Sms },
                    Email = new GenericDto { Bi = bi.Email, Op = op.Email, Ci = ci.Email },
                    NivelServicio = new GenericDto { Bi = bi.NivelServicio, Op = op.NivelServicio, Ci = ci.NivelServicio },
                    Abandono = new GenericDto { Bi = bi.Abandono, Op = op.Abandono, Ci = ci.Abandono },
                    Asa = new GenericDto { Bi = bi.Asa, Op = op.Asa, Ci = ci.Asa },
                    Aht = new GenericDto { Bi = bi.Aht, Op = op.Aht, Ci = ci.Aht },
                    Sph = new GenericDto { Bi = bi.Sph, Op = op.Sph, Ci = ci.Sph },
                    MinutosEntrada = new GenericDto { Bi = bi.MinutosEntrada, Op = op.MinutosEntrada, Ci = ci.MinutosEntrada },
                    MinutosSalidaFijo = new GenericDto { Bi = bi.MinutosSalidaFijo, Op = op.MinutosSalidaFijo, Ci = ci.MinutosSalidaFijo },
                    MinutosSalidaCelular = new GenericDto { Bi = bi.MinutosSalidaCelular, Op = op.MinutosSalidaCelular, Ci = ci.MinutosSalidaCelular },
                    Ocupacion = new GenericDto { Bi = bi.Ocupacion, Op = op.Ocupacion, Ci = ci.Ocupacion },
                    Adherencia = new GenericDto { Bi = bi.Adherencia, Op = op.Adherencia, Ci = ci.Adherencia },
                    Ausentismo = new GenericDto { Bi = bi.Ausentismo, Op = op.Ausentismo, Ci = ci.Ausentismo },
                    Rotacion = new GenericDto { Bi = bi.Rotacion, Op = op.Rotacion, Ci = ci.Rotacion },
                    HorasConexion = new GenericDto { Bi = bi.HorasConexion, Op = op.HorasConexion, Ci = ci.HorasConexion },
                    HorasPagadas = new GenericDto { Bi = bi.HorasPagadas, Op = op.HorasPagadas, Ci = ci.HorasPagadas }
                }; 
                    dto.Ingreso = ing;
                }
                
                
                ingresos.Add(dto);
            }
            return PartialView(ingresos);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult _IndicadoresEspecificos()
        {
            int mes = Request["mes"] == null ? DateTime.Now.Month : int.Parse(Request["mes"].ToString());
            int an = Request["an"] == null ? DateTime.Now.Year : int.Parse(Request["an"].ToString());

            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text", mes);
            ViewBag.Anios = new SelectList(_util.LstAnios(), "Value", "Text", an);

            var indicadores = new List<IngresosIndEspDto>();

            var campanas = _ptf.Campanas.Where(a=>a.activo == true).ToList();

            foreach (var campana in campanas)
            {
                var dto = new IngresosIndEspDto
                {
                    Campana = campana
                };

                var bi =
                    _db.Database.SqlQuery<IndicadoresEspecificosOp>("dbo.sp_GetIndEspecificosBiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();
                var op =
                    _db.Database.SqlQuery<IndicadoresEspecificosOp>("dbo.sp_GetIndEspecificosOpDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<IndicadoresEspecificosCi>("dbo.sp_GetIndEspecificosCiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                if (op == null)
                {
                    dto.Indicadores = new IndicadoresEspecificosDto();
                }
                else
                {
                    var ing = new IndicadoresEspecificosDto
                    {
                        Asignacion = new GenericDto { Bi = bi.Asignacion, Op = op.Asignacion, Ci = ci.Asignacion },
                        PorcAsignacion = new GenericDto { Bi = bi.PorcAsignacion, Op = op.PorcAsignacion, Ci = ci.PorcAsignacion },
                        PorcHonorarios = new GenericDto { Bi = bi.PorcHonorarios, Op = op.PorcHonorarios, Ci = ci.PorcHonorarios },
                        PorcRecuperacion = new GenericDto { Bi = bi.PorcRecuperacion, Op = op.PorcRecuperacion, Ci = ci.PorcRecuperacion },
                        PorcConversion = new GenericDto { Bi = bi.PorcConversion, Op = op.PorcConversion, Ci = ci.PorcConversion },
                        Pedidos = new GenericDto { Bi = bi.Pedidos, Op = op.Pedidos, Ci = ci.Pedidos },
                        VentasUpsell = new GenericDto { Bi = bi.VentasUpsell, Op = op.VentasUpsell, Ci = ci.VentasUpsell },
                        UpsellPromedio = new GenericDto { Bi = bi.UpsellPromedio, Op = op.UpsellPromedio, Ci = ci.UpsellPromedio },
                        Ventas = new GenericDto { Bi = bi.Ventas, Op = op.Ventas, Ci = ci.Ventas },
                        PorcValidacion = new GenericDto { Bi = bi.PorcValidacion, Op = op.PorcValidacion, Ci = ci.PorcValidacion },
                        PorcActivacion = new GenericDto { Bi = bi.PorcActivacion, Op = op.PorcActivacion, Ci = ci.PorcActivacion },
                    };
                    
                    dto.Indicadores = ing;
                }

                indicadores.Add(dto);
            }
            return PartialView(indicadores);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult _EstacionesEspecializadas()
        {
            int mes = Request["mes"] == null ? DateTime.Now.Month : int.Parse(Request["mes"].ToString());
            int an = Request["an"] == null ? DateTime.Now.Year : int.Parse(Request["an"].ToString());

            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text", mes);
            ViewBag.Anios = new SelectList(_util.LstAnios(), "Value", "Text", an);

            var estaciones = new List<IngresosEstEspDto>();

            var campanas = _ptf.Campanas.Where(a=>a.activo == true).ToList();

            foreach (var campana in campanas)
            {
                var dto = new IngresosEstEspDto
                {
                    Campana = campana
                };

                var bi =
                   _db.Database.SqlQuery<EstacionesEspecializadasBi>("dbo.sp_GetEstEspecializadasBiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}", campana.idCampana, mes, an)
                       .FirstOrDefault();

                var op =
                    _db.Database.SqlQuery<EstacionesEspecializadasOp>("dbo.sp_GetEstEspecializadasOpDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<EstacionesEspecializadasCi>("dbo.sp_GetEstEspecializadasCiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                if (op == null)
                {
                    dto.Estaciones = new EstacionesEspecializadasDto();
                }
                else
                {
                    var ing = new EstacionesEspecializadasDto
                    {
                        Nafin = new GenericDto { Bi = bi.Nafin, Op = op.Nafin, Ci = ci.Nafin },
                        Proveedor = new GenericDto { Bi = bi.Proveedor, Op = op.Proveedor, Ci = ci.Proveedor },
                        Vip = new GenericDto { Bi = bi.Vip, Op = op.Vip, Ci = ci.Vip },
                        Credito = new GenericDto { Bi = bi.Credito, Op = op.Credito, Ci = ci.Credito },
                        KioscoVirtual = new GenericDto { Bi = bi.KioscoVirtual, Op = op.KioscoVirtual, Ci = ci.KioscoVirtual },
                        Operativa = new GenericDto { Bi = bi.Operativa, Op = op.Operativa, Ci = ci.Operativa },
                        Especializada = new GenericDto { Bi = bi.Especializada, Op = op.Especializada, Ci = ci.Especializada },
                        SinDelantal = new GenericDto { Bi = bi.SinDelantal, Op = op.SinDelantal, Ci = ci.SinDelantal },
                        ServicioImpresionEscaner = new GenericDto { Bi = bi.ServicioImpresionEscaner, Op = op.ServicioImpresionEscaner, Ci = ci.ServicioImpresionEscaner },

                    };

                    dto.Estaciones = ing;
                }

                estaciones.Add(dto);
            }
            return PartialView(estaciones);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public ActionResult _IngresosGenerales(List<IngresosDto> ingresos, string MesDropDownList, string AnioDropDownList)
        {
            int mont = Int32.Parse(MesDropDownList);
            int anio = Int32.Parse(AnioDropDownList);

            _manager.SetIngresoByList(ingresos, mont, anio);
           
            return RedirectToAction("Ingreso", "Finances", new { mes = mont, an = anio, pagina = 1 });
           
            
           
        }
       
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     

        [HttpPost]
        public ActionResult _IndicadoresEspecificos(List<IngresosIndEspDto> ingresos, string MesDropDownList, string AnioDropDownList)
        {
            int mont = Int32.Parse(MesDropDownList);
            int anio = Int32.Parse(AnioDropDownList);

            _manager.SetIndEspecificosByList(ingresos, mont, anio);

            return RedirectToAction("Ingreso", "Finances", new { mes = mont, an = anio, pagina = 2 });



        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    

        [HttpPost]
        public ActionResult _EstacionesEspecializadas(List<IngresosEstEspDto> ingresos, string MesDropDownList, string AnioDropDownList)
        {
            int mont = Int32.Parse(MesDropDownList);
            int anio = Int32.Parse(AnioDropDownList);

            _manager.SetEstEspecializadasByList(ingresos, mont, anio);

            return RedirectToAction("Ingreso", "Finances", new { mes = mont, an = anio, pagina = 3 });



        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    
        public ActionResult Precio()
        {
            return View();

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public ActionResult _Precios()
        {
            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text");


            var precios = new List<PrecioDto>();

            var campanas = _ptf.Campanas.Where(a => a.activo == true).ToList();
            foreach (var campana in campanas)
            {
                var dto = new PrecioDto
                {
                    Campana = campana
                };
                var op =
                    _db.Database.SqlQuery<PrecioOp>("dbo.sp_GetPrecioOpDetById @idCampana = {0}, @Mes = {1}", campana.idCampana, DateTime.Now.Month)
                        .FirstOrDefault();
                if (op == null)
                {
                    dto.Precios = new PreciosDto();
                }
                else
                {
                    var price = new PreciosDto
                    {
                        Fijo = new GenericDto { Op = op.Fijo },
                        Persona = new GenericDto { Op = op.Persona },
                        EstacionEspecializada = new GenericDto { Op = op.EstacionEspecializada },
                        Hora = new GenericDto { Op = op.Hora },
                        Minuto = new GenericDto { Op = op.Minuto },
                        LlamadaEntrada = new GenericDto { Op = op.LlamadaEntrada },
                        LlamadaSalida = new GenericDto { Op = op.LlamadaSalida },
                        Chat = new GenericDto { Op = op.Chat },
                        SMS = new GenericDto { Op = op.SMS },
                        Email = new GenericDto { Op = op.Email },
                        Venta = new GenericDto { Op = op.Venta },
                        TicketVenta = new GenericDto { Op = op.TicketVenta },
                        MinutosEntrada = new GenericDto { Op = op.MinutosEntrada },
                        MinutosSalidaFijo = new GenericDto { Op = op.MinutosSalidaFijo },
                        MinutosSalidaCelular = new GenericDto { Op = op.MinutosSalidaCelular },
                        KioscoVirtual = new GenericDto { Op = op.KioscoVirtual },
                        ServicioImpresiónyEscaner = new GenericDto { Op = op.ServicioImpresiónyEscaner },
                     
                    };
                    dto.Precios = price;
                }


                precios.Add(dto);
            }
            return PartialView(precios);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        [HttpPost]
        public ActionResult Precio(List<PrecioDto> precios)
        {
            _manager.SetPrecioByList(precios, DateTime.Now.Month);
            return View();
        }

        //Sección de Costos
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  

        public ActionResult Costo(string mes, string an)
        {
            string yer = an;
            return View(new { mes = mes, an=yer });

        }
       
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //public ActionResult _PersonalCantidad()
        //{
        //    ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text");

        //    var indicadores = new List<CostoDto>();
        //    var campanas = _ptf.Campanas.Where(a => a.activo == true).ToList();
        //    foreach (var campana in campanas)
        //    {
        //        var dto = new CostoDto
        //        {
        //            Campana = campana
        //        };
        //        indicadores.Add(dto);
        //    }
        //    return PartialView(indicadores);
        //}
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public ActionResult _CostosDirectos()
        {
            int mes = Request["mes"] == null ? DateTime.Now.Month : int.Parse(Request["mes"].ToString());
            int an = Request["an"] == null ? DateTime.Now.Year : int.Parse(Request["an"].ToString());
                                   
            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text", mes.ToString());
            ViewBag.Anios = new SelectList(_util.LstAnios(), "Value", "Text", an);

            var costos = new List<CostosDirectosDto>();
            
            var campanas = _ptf.Campanas.Where(a => a.activo == true).ToList();
            
            foreach (var campana in campanas)
            {
                var dto = new CostosDirectosDto
                {
                    Campana = campana
                };
                var pt =
                    _db.Database.SqlQuery<CostosDirectosPt>("dbo.sp_GetCostosDirectosPtDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var fr =
                    _db.Database.SqlQuery<CostosDirectosFr>("dbo.sp_GetCostosDirectosFrDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<CostosDirectosCi>("dbo.sp_GetCostosDirectosCiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var re =
                    _db.Database.SqlQuery<CostosDirectosRe>("dbo.sp_GetCostosDirectosReDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();


                if (pt == null)
                {
                    dto.CostosDirectos = new CostosDirectosPtDto();

                }

                else
               
                {
                   
                    var costosDirectosPt = new CostosDirectosPtDto
                    {
                        Gerencial = new GenericDto { Pt = pt.Gerencial, Fr = fr.Gerencial, Ci= ci.Gerencial, Re = re.Gerencial },
                        Operacion = new GenericDto { Pt = pt.Operacion, Fr = fr.Operacion, Ci = ci.Operacion, Re = re.Operacion },
                        NominaEspecial = new GenericDto { Pt = pt.NominaEspecial, Fr = fr.NominaEspecial, Ci = ci.NominaEspecial, Re = re.NominaEspecial },
                        RentaEquipoComputo = new GenericDto { Pt = pt.RentaEquipoComputo, Fr = fr.RentaEquipoComputo, Ci = ci.RentaEquipoComputo, Re = re.RentaEquipoComputo },
                        ServiciosOutsourcing = new GenericDto { Pt = pt.ServiciosOutsourcing, Fr = fr.ServiciosOutsourcing, Ci = ci.ServiciosOutsourcing, Re = re.ServiciosOutsourcing },
                        ServiciosMaquilados = new GenericDto { Pt = pt.ServiciosMaquilados, Fr = fr.ServiciosMaquilados, Ci = ci.ServiciosMaquilados, Re = re.ServiciosMaquilados },
                        SegurosyFianzasCuotas_Suscripciones = new GenericDto { Pt = pt.SegurosyFianzasCuotas_Suscripciones, Fr = fr.SegurosyFianzasCuotas_Suscripciones, Ci = ci.SegurosyFianzasCuotas_Suscripciones, Re = re.SegurosyFianzasCuotas_Suscripciones },
                        Directo = new GenericDto { Pt = pt.Directo, Fr = fr.Directo, Ci = ci.Directo, Re = re.Directo },
                        Otros = new GenericDto { Pt = pt.Otros, Fr = fr.Otros, Ci = ci.Otros, Re = re.Otros },
                        Licencias = new GenericDto { Pt = pt.Licencias, Fr = fr.Licencias, Ci = ci.Licencias, Re = re.Licencias },
                        AplicativoCitasSNE = new GenericDto { Pt = pt.AplicativoCitasSNE, Fr = fr.AplicativoCitasSNE, Ci = ci.AplicativoCitasSNE, Re = re.AplicativoCitasSNE },

                                              
                    };

                    dto.CostosDirectos = costosDirectosPt;
                }

               
               
                costos.Add(dto);

          }
            return PartialView(costos);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        
        [HttpPost]
        public ActionResult _CostosDirectos(List<CostosDirectosDto> costos, string MesDropDownList, string AnioDropDownList)
        {
           
                 int mont = Int32.Parse(MesDropDownList);
                 int anio = Int32.Parse(AnioDropDownList);

                 _managerCosto.SetCostosDirectosByList(costos, mont, anio);

                return RedirectToAction("Costo", "Finances", new {mes=mont, an=anio, pagina=1});
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        
        [HttpPost]
        public ActionResult _CostosIndirectos(List<CostosIndirectosDto> costosind, string MesDropDownList, string AnioDropDownList)
        {
            int mont = Int32.Parse(MesDropDownList);
            int anio = Int32.Parse(AnioDropDownList);

            _managerCosto.SetCostosIndirectosByList(costosind, mont, anio);

            return RedirectToAction("Costo", "Finances", new { mes = mont, an = anio, pagina= 2 });
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public ActionResult _CostosIndirectos()
        {
            int mes = Request["mes"] == null ? DateTime.Now.Month : int.Parse(Request["mes"].ToString());
            int an = Request["an"] == null ? DateTime.Now.Year : int.Parse(Request["an"].ToString());

            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text", mes.ToString());
            ViewBag.Anios = new SelectList(_util.LstAnios(), "Value", "Text", an);

            var costos = new List<CostosIndirectosDto>();

            var campanas = _ptf.Campanas.Where(a => a.activo == true).ToList();

            foreach (var campana in campanas)
            {
                var dto = new CostosIndirectosDto
                {
                    Campana = campana
                };
                var pt =
                    _db.Database.SqlQuery<CostosIndirectosPt>("dbo.sp_GetCostosIndirectosPtDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var fr =
                    _db.Database.SqlQuery<CostosIndirectosFr>("dbo.sp_GetCostosIndirectosFrDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<CostosIndirectosCi>("dbo.sp_GetCostosIndirectosCiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();

                var re =
                    _db.Database.SqlQuery<CostosIndirectosRe>("dbo.sp_GetCostosIndirectosReDetById @idCampana = {0}, @Mes = {1}, @Year = {2}", campana.idCampana, mes, an)
                        .FirstOrDefault();


                if (pt == null)
                {
                    dto.CostosIndirectos = new CostosIndirectosStrDto();

                }

                else
                {

                    var costosIndirectosStr = new CostosIndirectosStrDto
                    {
                        Gerencial = new GenericDto { Pt = pt.Gerencial, Fr = fr.Gerencial, Ci = ci.Gerencial, Re = re.Gerencial },
                        Operacion = new GenericDto { Pt = pt.Operacion, Fr = fr.Operacion, Ci = ci.Operacion, Re = re.Operacion },
                        Depreciaciones = new GenericDto { Pt = pt.Depreciaciones, Fr= fr.Depreciaciones, Ci=ci.Depreciaciones, Re=re.Depreciaciones },
                        AmortizacionesLicencias = new GenericDto { Pt=pt.AmortizacionesLicencias, Fr=fr.AmortizacionesLicencias, Ci=ci.AmortizacionesLicencias, Re=re.AmortizacionesLicencias },
                        AmortizacionesServiciosMantenimiento = new GenericDto { Pt=pt.AmortizacionesServiciosMantenimiento, Fr= fr.AmortizacionesServiciosMantenimiento, Ci= ci.AmortizacionesServiciosMantenimiento, Re=re.AmortizacionesServiciosMantenimiento },
                        EquipoOficina = new GenericDto { Pt=pt.EquipoOficina, Fr=fr.EquipoOficina, Ci=ci.EquipoOficina, Re=re.EquipoOficina},
                        CompraEquipoComputo = new GenericDto { Pt=pt.CompraEquipoComputo, Fr=fr.CompraEquipoComputo, Ci=ci.CompraEquipoComputo, Re=re.CompraEquipoComputo },
                        MantenimientoEquipoComputo = new GenericDto { Pt=pt.MantenimientoEquipoComputo, Fr=fr.MantenimientoEquipoComputo, Ci=ci.MantenimientoEquipoComputo, Re=re.MantenimientoEquipoComputo },
                        Firewall_Dominio = new GenericDto { Pt=pt.Firewall_Dominio, Fr=fr.Firewall_Dominio, Ci=ci.Firewall_Dominio, Re=re.Firewall_Dominio },
                        Diademas = new GenericDto { Pt=pt.Diademas, Fr=fr.Diademas, Ci=ci.Diademas, Re=re.Diademas },
                        Renta = new GenericDto { Pt=pt.Renta, Fr=fr.Renta, Ci=ci.Renta ,Re=re.Renta },
                        Luz = new GenericDto { Pt=pt.Luz, Fr=fr.Luz, Ci=ci.Luz, Re=re.Luz },
                        Agua = new GenericDto { Pt=pt.Agua, Fr=fr.Agua, Ci=ci.Agua, Re=re.Agua },
                        Vigilancia = new GenericDto { Pt=pt.Vigilancia, Fr=fr.Vigilancia, Ci=ci.Vigilancia, Re=re.Vigilancia },
                        Limpieza = new GenericDto { Pt=pt.Limpieza, Fr=fr.Limpieza, Ci=ci.Limpieza, Re=re.Limpieza },
                        Edificio = new GenericDto { Pt=pt.Edificio, Fr=fr.Edificio, Ci=ci.Edificio, Re=re.Edificio },
                        ServAudFiscal = new GenericDto { Pt=pt.ServAudFiscal, Fr=fr.ServAudFiscal, Ci=ci.ServAudFiscal, Re=re.ServAudFiscal},
                        ServDeLegal = new GenericDto { Pt = pt.ServDeLegal, Fr = fr.ServDeLegal, Ci = ci.ServDeLegal, Re = re.ServDeLegal },
                        servContables = new GenericDto { Pt = pt.servContables, Fr = fr.servContables, Ci = ci.servContables, Re = re.servContables },
                        ServdeAdministrativos = new GenericDto { Pt = pt.ServdeAdministrativos, Fr = fr.ServdeAdministrativos, Ci = ci.ServdeAdministrativos, Re = re.ServdeAdministrativos },
                        Corporativo = new GenericDto { Pt = pt.Corporativo, Fr = fr.Corporativo, Ci = ci.Corporativo, Re = re.Corporativo },
                        Papeleria = new GenericDto { Pt = pt.Papeleria, Fr = fr.Papeleria, Ci = ci.Papeleria, Re = re.Papeleria },
                        Diversos = new GenericDto { Pt = pt.Diversos, Fr = fr.Diversos, Ci = ci.Diversos, Re = re.Diversos },
                        Nodeducibles = new GenericDto { Pt = pt.Nodeducibles, Fr = fr.Nodeducibles, Ci = ci.Nodeducibles, Re = re.Nodeducibles },
                        IncentivosEmpleados = new GenericDto { Pt = pt.IncentivosEmpleados, Fr = fr.IncentivosEmpleados, Ci = ci.IncentivosEmpleados, Re = re.IncentivosEmpleados },
                        Pasajes = new GenericDto { Pt = pt.Pasajes, Fr = fr.Pasajes, Ci = ci.Pasajes, Re = re.Pasajes },
                        Despensa = new GenericDto { Pt = pt.Despensa, Fr = fr.Despensa, Ci = ci.Despensa, Re = re.Despensa },
                        Alimentos_Consumos_Gastosviaje = new GenericDto { Pt = pt.Alimentos_Consumos_Gastosviaje, Fr = fr.Alimentos_Consumos_Gastosviaje, Ci = ci.Alimentos_Consumos_Gastosviaje, Re = re.Alimentos_Consumos_Gastosviaje },
                        SMS_Carteo = new GenericDto { Pt = pt.SMS_Carteo, Fr = fr.SMS_Carteo, Ci = ci.SMS_Carteo, Re = re.SMS_Carteo },
                        BaseDatos = new GenericDto { Pt = pt.BaseDatos, Fr = fr.BaseDatos, Ci = ci.BaseDatos, Re = re.BaseDatos },
                        CertificacionPCI = new GenericDto { Pt = pt.CertificacionPCI, Fr = fr.CertificacionPCI, Ci = ci.CertificacionPCI, Re = re.CertificacionPCI },
                        Indirecto = new GenericDto { Pt = pt.Indirecto, Fr = fr.Indirecto, Ci = ci.Indirecto, Re = re.Indirecto },
                        OCC = new GenericDto { Pt = pt.OCC, Fr = fr.OCC, Ci = ci.OCC, Re = re.OCC },
                        Cursos = new GenericDto { Pt = pt.Cursos, Fr = fr.Cursos, Ci = ci.Cursos, Re = re.Cursos },
                        PacketLincencias_servidores_implementaciones = new GenericDto { Pt = pt.PacketLincencias_servidores_implementaciones, Fr = fr.PacketLincencias_servidores_implementaciones, Ci = ci.PacketLincencias_servidores_implementaciones, Re = re.PacketLincencias_servidores_implementaciones },
                        Comisiones = new GenericDto { Pt = pt.Comisiones, Fr = fr.Comisiones, Ci = ci.Comisiones, Re = re.Comisiones },
                        PerdidaUtilidadCambiaria = new GenericDto { Pt = pt.PerdidaUtilidadCambiaria, Fr = fr.PerdidaUtilidadCambiaria, Ci = ci.PerdidaUtilidadCambiaria, Re = re.PerdidaUtilidadCambiaria },
                        Otrosgastos_Ingresos = new GenericDto { Pt = pt.Otrosgastos_Ingresos, Fr = fr.Otrosgastos_Ingresos, Ci = ci.Otrosgastos_Ingresos, Re = re.Otrosgastos_Ingresos },
                        InteresesPagados_Ganados = new GenericDto { Pt = pt.InteresesPagados_Ganados, Fr = fr.InteresesPagados_Ganados, Ci = ci.InteresesPagados_Ganados, Re = re.InteresesPagados_Ganados },
                        RentadeUPS = new GenericDto { Pt = pt.RentadeUPS, Fr = fr.RentadeUPS, Ci = ci.RentadeUPS, Re = re.RentadeUPS },
                        RentadePlanta = new GenericDto { Pt = pt.RentadePlanta, Fr = fr.RentadePlanta, Ci = ci.RentadePlanta, Re = re.RentadePlanta },   
                        


                    };

                    dto.CostosIndirectos = costosIndirectosStr;
                }



                costos.Add(dto);

            }
            return PartialView(costos);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //Sección de Ingresos Totales
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  

        public ActionResult IngresoTotal(string mes, string an)
        {
            string yer = an;
            return View(new { mes = mes, an = yer });

        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public ActionResult _IngresosTotales()
        {
            int mes = Request["mes"] == null ? DateTime.Now.Month : int.Parse(Request["mes"].ToString());
            int an = Request["an"] == null ? DateTime.Now.Year : int.Parse(Request["an"].ToString());

            ViewBag.Meses = new SelectList(_util.LstMeses(), "Value", "Text", mes);
            ViewBag.Anios = new SelectList(_util.LstAnios(), "Value", "Text", an);

            var ingresostotales = new List<IngresoTotDto>();

            var dto = new IngresoTotDto();
               
                var pt =
                    _db.Database.SqlQuery<IngresosTotPt>("dbo.sp_GetIngresoTotalPtDetById @Mes = {0}, @RegYear = {1}", mes, an)
                        .FirstOrDefault();

                var fr =
                    _db.Database.SqlQuery<IngresosTotFr>("dbo.sp_GetIngresoTotalFrDetById @Mes = {0}, @RegYear = {1}", mes, an)
                        .FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<IngresosTotCi>("dbo.sp_GetIngresoTotalCiDetById @Mes = {0}, @RegYear = {1}", mes, an)
                        .FirstOrDefault();

                var re =
                    _db.Database.SqlQuery<IngresosTotRe>("dbo.sp_GetIngresoTotalReDetById @Mes = {0}, @RegYear = {1}", mes, an)
                        .FirstOrDefault();


                if (pt == null)
                {
                    dto.IngresosTotales = new IngresosTotalesStr();

                }

                else
                {

                    var ingresosTotalesStr = new IngresosTotalesStr
                    {
                        IngresosTotales = new GenericDto { Pt = pt.IngresosTotales, Fr = fr.IngresosTotales, Ci = ci.IngresosTotales, Re = re.IngresosTotales },
                    };

                    dto.IngresosTotales = ingresosTotalesStr;
                }



                ingresostotales.Add(dto);

            
            return PartialView(ingresostotales);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        [HttpPost]
        public ActionResult _IngresosTotales(List<IngresoTotDto> ingtotales, string MesDropDownList, string AnioDropDownList)
        {
            int mont = Int32.Parse(MesDropDownList);
            int anio = Int32.Parse(AnioDropDownList);

            _managerIngTotal.SetIngresoTotalByList(ingtotales, mont, anio);

            return RedirectToAction("IngresoTotal", "Finances", new { mes = mont, an = anio, pagina = 2 });
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


    }
}
