using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Data.Entity.Migrations;
using PentaFinances.Models;
using PentaFinances.ViewModels;
using PentaFinances.Managers;
using  PentaFinances.Utils;
using System.IO;

namespace PentaFinances.Controllers
{
    public class ComprasController : Controller
    {
        //
        // GET: /Compras/
        PentaFinComprasContext _db = new PentaFinComprasContext();
        Utilities _util = new Utilities();
        ComprasManager _manager = new ComprasManager();
        PentaFinComprasContext _mdl = new PentaFinComprasContext();
        private readonly Messenger _messenger = new Messenger();
        string correoadmincompras = "igomiciaga@neikos.com.mx";
        string correoAdmin = "jgarcia@pentafon.com";
        //string correoadmincompras = "psalinas@pentafon.com";
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult Index()
        {
            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA PARA LEVANTAR UNA SOLICITUD (SOLICITANTE)
        public ActionResult LevantamientoSolicitudes()
        {
            //LISTAS
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");
            ViewBag.ListaSolicitante = new SelectList(_util.LstSolicitante(), "Value", "Text");
            ViewBag.ListaMailSol = new SelectList(_util.LstMailSol(), "Value", "Text");
            
            //LISTA DE CAMPAÑAS
            ViewBag.ListaCampanas =
                new SelectList(_db.CatalogoCampanas.Where(a => a.Estatus == true).OrderBy(a=>a.Campana), "Id",
                    "Campana");
            
            //LISTA DE DEPARTAMENTOS
            ViewBag.ListaDeptos = 
                new SelectList(_db.CatalogoDepartamentos.Where(a=>a.Estatus == true).OrderBy(a=>a.Departamento), "Id", "Departamento");

            //SE OBTIENE EL USUARIO Y SU CORREO
            string user = User.Identity.Name;
            ApUsuarios solicitante = _db.ApUsuarios.Find(user);

            SolicitudesDetalles solicitud = new SolicitudesDetalles(){};

            if (solicitante != null)
            {
                var depto = _db.CatalogoDepartamentos.Find(solicitante.DepartamentoId);
                
                solicitud.Solicitante = solicitante.Nombre;
                solicitud.EmailSolicitante = solicitante.Correo;
                solicitud.UsuarioFinal = solicitante.Nombre;
                solicitud.EmailUsuarioFinal = solicitante.Correo;
                solicitud.DepartamentoId = solicitante.DepartamentoId;
                ViewBag.Depto = depto.Departamento;
            }

            //ENCUESTAS DE SATISFACCION PENDIENTES
            //------------------------------------
            int cont = 0;
            string fecha = "15/07/2022";
            DateTime fecha2 = Convert.ToDateTime(fecha);
            List<string> folio = new List<string>();

            var RgistrosTerminados = _db.SeguimientoSolicitudesDetalles.Where(a => a.Solicitante == solicitante.Nombre && a.EstadoSolicitudId == 7 
            && a.FechaRegistro >= fecha2).ToList();

           foreach(var j in RgistrosTerminados)
            {
                var RegistrosEncuesta = _db.EncuestaSatPentaFinances.Where(a => a.Folio == j.Folio).FirstOrDefault();
                if (RegistrosEncuesta == null) {
                 cont ++;
                 folio.Add(Convert.ToString(j.Folio));
                }
            }
            if (cont > 0)
            {
                ViewBag.EncuestaPendientes = 1;
                ViewBag.Folios = folio;
            }
            //----------------------------------------

            return View(solicitud);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        /// <summary>
        /// GUARDA LOS DATOS DE LA SOLICITUD DE COMPRA
        /// </summary>
        /// <param name="solicitud">PARAMETRO DONDE VIENEN LOS DATOS DESDE LA VISTA LEVAANTAMIENTOsOLICITUDES</param>
        /// <returns> SI SE GUARDA EL REGISTRO RETURNA EL FOLIO CON LA PANTALLA DE SUCCES, DE LO CONTRAIO
        /// RETORNA LA PANTALLA DE ERROR
        /// </returns>
        [HttpPost]
        public ActionResult GuardaSolicitud(SolicitudesDetalles solicitud)
        {
            string user = User.Identity.Name;
            solicitud.UsuarioUltimaActualizacion = user;

            ResultLevantaSolicitudVm result = _manager.SetLevantaSolicitud(solicitud);
            
            if (result.Resultado=="Exito")
            {
                var strfolio = result.Folio;
                return RedirectToAction("Success", "Compras", new { folio = strfolio });
                
                //return RedirectToAction("Comprobante", "docs", new { folio = strfolio });
            }

            return RedirectToAction("Error","Compras");
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult ListadoSolicitudes()
        {
            var lista = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                .Where(a => a.Estatus && a.EstadoSolicitudId != 3).ToList();

            return View(lista);

            //return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult _SeguimientoSolicitudes(int folio)
        {
            ViewBag.EstadoSolicitado = new SelectList(_util.LstEstadoSolicitud(), "Value", "Text");

            SeguimientoSolicitudesDetalles solicitud = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);
            CatalogoCampanas campana = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == solicitud.CampanaId);
            CatalogoDepartamentos depto = _db.CatalogoDepartamentos.FirstOrDefault(a=>a.Id==solicitud.DepartamentoId);

            ViewBag.Campana = (campana == null) ? "No Definido" : campana.Campana;
            ViewBag.Depto = (depto==null) ? "No Definido" : depto.Departamento;

            string user = User.Identity.Name;
            solicitud.UsuarioUltimaActualizacion = user;

            return PartialView(solicitud);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult GuardaSeguimiento(SeguimientoSolicitudesDetalles seguimiento)
        {
            string result = _manager.SetSeguimientoSolicitud(seguimiento);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA DE ADMINISTRACIÓN DE SOLICITUDES (LISTADO)
        public ActionResult EditarProveedores()
        {
            var user = User.Identity.Name;
            if (user != "")
            {
                List<ConsultaSolicitudesVm> solicitudes = _db.Database.SqlQuery<ConsultaSolicitudesVm>("dbo.stpd_GetConsultaSolicitudesCompraDetalles")
                .Where(a => a.Estatus).ToList();

                List<tbl_AprobacionSolicitud> solAprobadas = _db.tbl_AprobacionSolicitud.Where(x => x.Estatus == true).ToList();
                string semaforo;
                solicitudes.ForEach(x =>
                {
                    if (x.EstadoSolicitudId == 1 && x.Estatus == true)
                    {
                        tbl_AprobacionSolicitud temp = solAprobadas.Where(r => r.Folio == x.Folio && r.Estatus == true).FirstOrDefault();
                        if (temp != null)
                        {
                            TimeSpan? timeSpan = (DateTime.Now - temp.FAprobacion);
                            TimeSpan nonNullableTS = timeSpan.Value;
                            double? horas_sla = 48 - nonNullableTS.TotalHours;

                            // Calculo Semafaro
                            if (horas_sla >= 24)
                            {
                                semaforo = "semaforo-verde";
                            }
                            else if (horas_sla < 24 && horas_sla > 1)
                            {
                                semaforo = "semaforo-amarillo";
                            }
                            else
                            {
                                semaforo = "semaforo-rojo";
                            }
                            x.semaforo = semaforo;
                        }

                    }

                });
                return View(solicitudes);
            }else
            {
                return RedirectToAction("Home", "App");
            }
                
            //return View(lista);

            //return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA AGREGAR/EDITAR PROVEEDORES DE UNA SOLICITUD (PARTIALVIEW PARA MODAL)
        public ActionResult _AgregarProveedores(int folio)
        {
            SeguimientoSolicitudesDetalles datos = _db.SeguimientoSolicitudesDetalles.Find(folio);
            ViewBag.Recurrente = "NO";


            //Listado de proveedores 
            ViewBag.CatProveedores = _db.proveedores.Where(a => a.Activo).OrderBy(x => x.Nombre).ToList();
            //----------------------------------------------------
            if (datos.EstadoSolicitudId == 8 || datos.EstadoSolicitudId == 13 || datos.EstadoSolicitudId == 14 ||
                datos.EstadoSolicitudId == 15 || datos.EstadoSolicitudId == 16)
                ViewBag.ProveedorAprobado = 1;
            else
                ViewBag.ProveedorAprobado = 0;
            //----------------------------------------------------
            AgregarProveedoresVm solicitud = new AgregarProveedoresVm()
            {
                Folio = folio,
                Solicitante = datos.Solicitante,
                EmailSolicitante = datos.EmailSolicitante,
                CampanaId = datos.CampanaId,
                DepartamentoId = datos.DepartamentoId,
                UsuarioFinal = datos.UsuarioFinal,
                EmailUsuarioFinal = datos.EmailUsuarioFinal,
                DetalledeSolicitud = datos.DetalledeSolicitud,
                Tiposolicitud = datos.TipoSolicitud,
            };

            //----------------------------------------------------
            SeguimientoSolicitudesDetallesVm info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio==folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
                ViewBag.EstadoId = info.EstadoSolicitudId;
            }

            //----------------------------------------------------
            ProveedoresAgregadosSolicitudesDetalles fechaactualizacion = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio==folio);

            if (fechaactualizacion != null)
                solicitud.FechaUltimaActualizacion = fechaactualizacion.FechaUltimaActualizacion;

            //----------------------------------------------------
            ProveedoresAgregadosSolicitudesDetalles proveedora = _db.ProveedoresAgregadosSolicitudesDetalles
                .FirstOrDefault(a => a.Folio==folio && a.TipoProveedor == "A");



            if (proveedora != null)
            {
                bool credito = !(proveedora.PermiteCredito == null);

                solicitud.IdProveedorA = proveedora.Id;
                solicitud.ProveedorA = proveedora.Proveedor;
                solicitud.AsignadoA = proveedora.Asignado;
                solicitud.DescripcionA = proveedora.Descripcion;
                solicitud.PrecioA = proveedora.Precio;
                solicitud.TipoMonedaA = proveedora.TipoMoneda;
                solicitud.TiempoEntregaA = proveedora.TiempoEntrega;
                solicitud.DocumentoCotizacionA = proveedora.DocumentoCotizacion;
                solicitud.PermiteCreditoA = proveedora.PermiteCredito;
                solicitud.IvaA = proveedora.Iva;
                solicitud.IncluyeIva = proveedora.IncluyeIva;
                solicitud.PorcentajeAnticipoA = proveedora.Anticipo;
                solicitud.ComentarioAnticipoA = proveedora.ComentarioAnticipo;
                solicitud.idProveedorGnrlA = proveedora.IdProveedor;
            }//SECCION PREVEEDOR RECURRENTE
            else {

                if (datos.Recurrente == "SI") {
                    ViewBag.Recurrente = "SI";
                    int foliorec = datos.Folio;

                    tbl_ProveedorRecurrenteCompras infoprovrec = _db.tbl_ProveedorRecurrenteCompras.Where(a => a.Folio == foliorec).FirstOrDefault();

                    if (infoprovrec != null) {

                        //solicitud.IdProveedorA = proveedora.Id;
                        solicitud.ProveedorA = infoprovrec.Proveedor;
                        solicitud.AsignadoA = true;
                        solicitud.DescripcionA = infoprovrec.Descripcion;
                        solicitud.PrecioA = infoprovrec.Precio;
                        solicitud.TipoMonedaA = infoprovrec.TipoMoneda;
                        //solicitud.TiempoEntregaA = infoprovrec.TiempoEntrega.ToString();
                        //solicitud.DocumentoCotizacionA = infoprovrec.DocumentoCotizacion;
                        //solicitud.PermiteCreditoA = infoprovrec.PermiteCredito;
                        //solicitud.IvaA = infoprovrec.Iva;

                    }

                }
            }
            //FIN SECCION PREVEEDOR RECURRENTE

            //----------------------------------------------------
            var proveedorb = _db.ProveedoresAgregadosSolicitudesDetalles
                .FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");

            if (proveedorb != null)
            {
                bool credito = !(proveedorb.PermiteCredito == null);

                solicitud.IdProveedorB = proveedorb.Id;
                solicitud.ProveedorB = proveedorb.Proveedor;
                solicitud.AsignadoB = proveedorb.Asignado;
                solicitud.DescripcionB = proveedorb.Descripcion;
                solicitud.PrecioB = proveedorb.Precio;
                solicitud.TiempoEntregaB = proveedorb.TiempoEntrega;
                solicitud.DocumentoCotizacionB = proveedorb.DocumentoCotizacion;
                solicitud.PermiteCreditoB = proveedorb.PermiteCredito;
                solicitud.IvaB = proveedorb.Iva;
                solicitud.IncluyeIvaB = proveedorb.IncluyeIva;
                solicitud.PorcentajeAnticipoB = proveedorb.Anticipo;
                solicitud.ComentarioAnticipoB = proveedorb.ComentarioAnticipo;
                solicitud.idProveedorGnrlB = proveedorb.IdProveedor;
            }

            //----------------------------------------------------
            var proveedorc = _db.ProveedoresAgregadosSolicitudesDetalles
                .FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            if (proveedorc != null)
            {
                bool credito = !(proveedorc.PermiteCredito == null);

                solicitud.IdProveedorC = proveedorc.Id;
                solicitud.ProveedorC = proveedorc.Proveedor;
                solicitud.AsignadoC = proveedorc.Asignado;
                solicitud.DescripcionC = proveedorc.Descripcion;
                solicitud.PrecioC = proveedorc.Precio;
                solicitud.TiempoEntregaC = proveedorc.TiempoEntrega;
                solicitud.DocumentoCotizacionC = proveedorc.DocumentoCotizacion;
                solicitud.PermiteCreditoC = proveedorc.PermiteCredito;
                solicitud.IvaC = proveedorc.Iva;
                solicitud.IncluyeIvaC = proveedorc.IncluyeIva;
                solicitud.PorcentajeAnticipoC = proveedorc.Anticipo;
                solicitud.ComentarioAnticipoC = proveedorc.ComentarioAnticipo;
                solicitud.idProveedorGnrlC = proveedorc.IdProveedor;
            }

            return PartialView(solicitud);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //GUARDA LOS DATOS DE LOS PROVEEDORES DE UNA SOLICITUD
        [HttpPost]
        public JsonResult SaveProveedores(AgregarProveedoresVm vm)
        {
            var user = User.Identity.Name;
            vm.UsuarioUltimaActualizacion = user;

            var result = _manager.SetProveedores(vm);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult AsignarProveedores()
        {
            var solicitudes = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                .Where(a => a.EstadoSolicitudId != 3 && a.EstadoSolicitudId >= 4 && a.Estatus == true).ToList();

            return View(solicitudes);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult _AsignacionProvCompras (int folio)
        {
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");

            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a=> a.Folio ==folio && a.TipoProveedor=="A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm(){};

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.IvaA = datosprova.Iva;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.IvaB = datosprovb.Iva;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.IvaC = datosprovc.Iva;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            return PartialView(solicitud);
            
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //ASIGNACIÓN DE PROVEEDOR (APROBAR O RECHAZAR SOLICITUD)
        [HttpPost]
        public JsonResult GuardaAsignacionProveedor(AgregarProveedoresVm vm, string aprobacion)
        {
            var user = User.Identity.Name;
            vm.UsuarioUltimaActualizacion = user;
            var estadoid =0;
            
            //Roles: AprobadorDirFin, AprobadorDirGral, AprobadorPresidencia
            
            //APROBADA POR
            if (aprobacion == "1")
            {
                if (User.IsInRole("Aprobador")) estadoid = 13;
                if (User.IsInRole("AprobadorDirFin")) estadoid = 14;
                if (User.IsInRole("AprobadorDirGral")) estadoid = 15;
                if (User.IsInRole("AprobadorPresidencia")) estadoid = 16;
            }

            //RECHAZADA POR
            if (aprobacion == "2")
            {
                if (User.IsInRole("Aprobador")) estadoid = 17;
                if (User.IsInRole("AprobadorDirFin")) estadoid = 18;
                if (User.IsInRole("AprobadorDirGral")) estadoid = 19;
                if (User.IsInRole("AprobadorPresidencia")) estadoid = 20;
            }

            var result = _manager.SetAsignaProveedor(vm, aprobacion, estadoid);

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA Solicitudes para Agregarles Forma de Pago
        public ActionResult AgregarFormadePago()
        {
            var solicitudes = _db.Database.SqlQuery<FormaPagoVm>("dbo.stpd_GetPagoComprasDetalles")
                .Where(a => a.EstadoSolicitudId == 13 || a.EstadoSolicitudId == 14 || a.EstadoSolicitudId == 15 || a.EstadoSolicitudId == 16 || a.EstadoSolicitudId == 6).ToList();

            return View(solicitudes);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //ASIGNAR FORMA DE PAGO A UNA COMPRA (PARTIALVIEW PARA MODAL)
        public ActionResult _FormaPagoCompra(int folio)
        {
            ViewBag.ListaFormaPago =
                new SelectList(_db.CatalogoFormasPago.Where(a => a.Estatus == true), "Id",
                    "FormaPago");

            ViewBag.ListaBancos =
                new SelectList(_db.CatalogoBancos.Where(a => a.Estatus == true).OrderBy(a=>a.Banco), "Id", "Banco");

            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");

            var datos = _db.Database.SqlQuery<FormaPagoVm>("dbo.stpd_GetPagoComprasDetalles").FirstOrDefault(a => a.Folio==folio);

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            var datosprov =
                _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.Asignado == true );

            if (datosprov != null)
            {
                ViewBag.Subtotal = datosprov.Precio;
                ViewBag.TipoMoneda = datosprov.TipoMoneda;
                ViewBag.Iva = datosprov.Iva;
               
            }

            datos.Files = new List<FilesPagosCompras>();
            datos.Files =  _db.FilesPagosCompras.Where(x => x.Folio == folio && x.estatus == true).ToList();

            return PartialView(datos);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //GUARDA LA FORMA DE PAGO DE UNA SOLICITUD DE COMPRA
        [HttpPost]
        public JsonResult SaveFormaPago(FormaPagoVm vm)
        {
            
            var user = User.Identity.Name;
            if (user != null)
            {
                vm.UsuarioUltimaActualizacionFp = user;
            }
            

            var result = _manager.SetPagosCompras(vm);
            return Json(result, JsonRequestBehavior.AllowGet);
            //return Json("Exito", JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA PARA APROBAR O RECHAZAR UNA COMPRA (LISTADO)
        //UNICAMENTE PARA GERENCIA Y PRESIDENCIA 
        public ActionResult AprobarRechazarCompras()
        {
            //Roles: Aprobador, AprobadorDirFin, AprobadorDirGral, AprobadorPresidencia
            if (User.IsInRole("Developer"))
            {
                var solicitudesdev = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                    .Where(a => a.Estatus == true).ToList();

                return View(solicitudesdev);
            }

            //if (User.IsInRole("AprobadorDirFin"))
            //{
            //    var solicitudesdev = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
            //        .Where(a => a.Estatus == true).ToList();

            //    return View(solicitudesdev);
            //}

            var estadoid =0;

            if (User.IsInRole("Aprobador"))
            {
                estadoid = 9;

                var solicitudesgerente = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                    .Where(a => a.EstadoSolicitudId == estadoid && a.Estatus == true).ToList();

                return View(solicitudesgerente);
                
            }
            if (User.IsInRole("AprobadorDirFin"))
            {
                estadoid = 10;

                var solicitudesdirfin = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                    .Where(a => a.EstadoSolicitudId == 9|| a.EstadoSolicitudId==10 && a.Estatus == true).ToList();

                return View(solicitudesdirfin);
            }
            if (User.IsInRole("AprobadorDirGral"))
            {
                estadoid = 11;
                var solicitudesdirgral = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                    .Where(a => a.EstadoSolicitudId == 9 || a.EstadoSolicitudId == 10 || a.EstadoSolicitudId == 11 && a.Estatus == true).ToList();

                return View(solicitudesdirgral);
            }
            if (User.IsInRole("AprobadorPresidencia"))
            {
            estadoid = 12;
                var solicitudesdirgral = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                    .Where(a => a.EstadoSolicitudId == 9 || a.EstadoSolicitudId == 10 || a.EstadoSolicitudId == 11 || a.EstadoSolicitudId ==12  && a.Estatus == true).ToList();

                return View(solicitudesdirgral);
            }

            var solicitudes = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
                .Where(a => a.EstadoSolicitudId == estadoid && a.Estatus == true).ToList();

            //var solicitudes = _db.Database.SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles")
            //    .Where(a => a.EstadoSolicitudId == 9 || a.EstadoSolicitudId == 10 || a.EstadoSolicitudId == 11 || a.EstadoSolicitudId == 12 && a.Estatus == true).ToList();
                //.Where(a => a.EstadoSolicitudId != 3 && a.EstadoSolicitudId >= 4 && a.Estatus == true).ToList();

            return View(solicitudes);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //ASIGNAR FORMA DE PAGO A UNA COMPRA (PARTIALVIEW PARA MODAL)
        public ActionResult _FormaPagoCompraAgregada(int folio)
        {
            /*ViewBag.ListaFormaPago =
                new SelectList(_db.CatalogoFormasPago.Where(a => a.Estatus == true), "Id",
                    "FormaPago");

            ViewBag.ListaBancos =
                new SelectList(_db.CatalogoBancos.Where(a => a.Estatus == true), "Id", "Banco");

            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");*/

            var datos = _db.Database.SqlQuery<FormaPagoVm>("dbo.stpd_GetPagoComprasDetalles").FirstOrDefault(a => a.Folio == folio);

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            var moneda =
                _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Id == datos.ProveedorAsignadoId);

            if (moneda != null)
            {
                ViewBag.Precio = moneda.Precio;
                ViewBag.Moneda = moneda.TipoMoneda;
                ViewBag.Iva = moneda.Iva;
            }

            datos.Files = new List<FilesPagosCompras>();
            datos.Files = _db.FilesPagosCompras.Where(x => x.Folio == folio && x.estatus == true).ToList();

            return PartialView(datos);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA SOLICITUD APROBADA POR GERENCIA (PARTIALVIEW PARA MODAL)
        //VISTA QUE SOLO MUESTRA LOS DETALLES DE LA SOLICITUD
        public ActionResult _SolicitudAprobadaGerencia(int folio)
        {
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");

            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.DocumentoCotizacionA = datosprova.DocumentoCotizacion;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.IvaA = datosprova.Iva;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.DocumentoCotizacionB = datosprovb.DocumentoCotizacion;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.IvaB = datosprovb.Iva;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.DocumentoCotizacionC = datosprovc.DocumentoCotizacion;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.IvaC = datosprovc.Iva;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            return PartialView(solicitud);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA SOLICITUD APROBADA POR GERENCIA (PARTIALVIEW PARA MODAL)
        //VISTA QUE SOLO MUESTRA LOS DETALLES DE LA SOLICITUD
        public ActionResult _CancelarFolio(int folio)
        {
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");

            SeguimientoSolicitudesDetalles datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            return PartialView(datossol);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //GUARDA LA FORMA DE PAGO DE UNA SOLICITUD DE COMPRA
        [HttpPost]
        public JsonResult SaveCancelaFolio(SeguimientoSolicitudesDetalles vm)
        {
            var user = User.Identity.Name;
            vm.UsuarioUltimaActualizacion = user;

            var result = _manager.SetCancelaFolio(vm);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA PARA CONSULTAR SOLICITUDES (LISTADO)
        public ActionResult ConsultarSolicitudesCompras()
        {
            var user = User.Identity.Name;
            ViewBag.User = user;
            //if (user != "mgonzalez")
            //user.ToUpper() != "MBARRIOS"
            //user.ToUpper() != "MGONZALEZ" 
            //user.ToUpper() != "RPADILLA"
            if (user.ToUpper() != "MGONZALEZ" && user.ToUpper() != "MBARRIOS"  && user.ToUpper() != "IGOMICIAGA" && user.ToUpper() != "JRODRIGUEZ" && user.ToUpper() != "JGARCIAF" && user.ToUpper() != "RPADILLA")
                //Rol: AprobadorDirGral
                //Rol: AprobadorPresidencia
                {
                if (User.IsInRole("Solicitante"))
                {
                    if (User.IsInRole("AprobadorDirFin"))
                    {
                        var solicitudesdirfin = _db.Database.SqlQuery<ConsultaSolicitudesVm>("dbo.stpd_GetConsultaSolicitudesCompraDetalles").ToList();

                        return View(solicitudesdirfin);
                    }

                    if (User.IsInRole("AprobadorDirGral"))
                    {
                        var solicitudesdirfin = _db.Database.SqlQuery<ConsultaSolicitudesVm>("dbo.stpd_GetConsultaSolicitudesCompraDetalles").ToList();

                        return View(solicitudesdirfin);
                    }

                    if (User.IsInRole("AprobadorPresidencia"))
                    {
                        var solicitudesdirfin = _db.Database.SqlQuery<ConsultaSolicitudesVm>("dbo.stpd_GetConsultaSolicitudesCompraDetalles").ToList();

                        return View(solicitudesdirfin);
                    }

                    var nombre = _db.Database.SqlQuery<string>("SELECT Nombre FROM dbo.tbl_AppUsuarios " +
                                                               "WHERE Usuario={0}", user).FirstOrDefault();

                    var solicitudesusuaio = _db.Database.SqlQuery<ConsultaSolicitudesVm>("dbo.stpd_GetConsultaFoliosSolicitante @NOMBRESOLICITANTE= {0}", nombre).ToList();

                    return View(solicitudesusuaio);
                }
            }
           
            var solicitudes = _db.Database.SqlQuery<ConsultaSolicitudesVm>("dbo.stpd_GetConsultaSolicitudesCompraDetalles").ToList();

            return View(solicitudes);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA SOLICITUD APROBADA POR GERENCIA (PARTIALVIEW PARA MODAL)
        //VISTA QUE SOLO MUESTRA LOS DETALLES DE LA SOLICITUD
        public ActionResult _ConsultaDetalleFolio(int folio)
        {
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");

            SeguimientoSolicitudesDetalles datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datos = _db.Database.SqlQuery<ConsultaFolioDetallesVm>("dbo.stpd_GetConsultaFolioDetalles").FirstOrDefault(a => a.Folio == folio && a.Asignado==true);

            if (datos != null)
            {
                ViewBag.Campana = datos.Campana;
                ViewBag.Depto = datos.Departamento;

                var estsolicitud = _db.Database
                    .SqlQuery<string>("SELECT EstadoSolicitud FROM dbo.cat_EstadosSolicitud " +
                                      "WHERE EstadoSolicitudId = " + datos.EstadoSolicitudId).FirstOrDefault();

                ViewBag.EstadoSolicitud = estsolicitud;
                return PartialView(datos);
            }
            else
            {
                var datosin = _db.Database.SqlQuery<ConsultaFolioDetallesVm>("dbo.stpd_GetConsultaFolioDetalles").FirstOrDefault(a => a.Folio == folio);
                return PartialView(datosin);
            }

            return PartialView(datos);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //FINALIZACIÓN DEL FOLIO
        [HttpPost]
        public JsonResult SaveFinalizaFolio(string folio)
        {
            var user = User.Identity.Name;
            
            var result = _manager.SetFinalizaFolio(folio, user);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult EncuestaSolicitanteProveedor()
        {
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");
            ViewBag.Calificacion = new SelectList(_util.LstCalificacion(), "Value", "Text");

            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult EncuestaComprasSolicitudes()
        {
            ViewBag.ListaSiNo = new SelectList(_util.LstSiNo(), "Value", "Text");
            ViewBag.Calificacion = new SelectList(_util.LstCalificacion(), "Value", "Text");

            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PANTALLA QUE SE MUESTRA CUANDO UN PROCESO ES EXITOSO
        public ActionResult Success(string folio)
        {
            ViewBag.Folio = "";
            if (!string.IsNullOrEmpty(folio)) {

                ViewBag.Folio = folio;
            }

            return View();

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PANTALLA QUE SE MUESTRA CUANDO OCURRE UN ERROR
        public ActionResult Error()
        {
            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //FINALIZACIÓN DEL FOLIO
        [HttpPost]
        public JsonResult SaveNuevoBanco(string banco)
        {
            var user = User.Identity.Name;
            var idbanco = 0;
            
            //var result = _manager.SetFinalizaFolio(folio, user);
            try
            {
                CatalogoBancos newbank = new CatalogoBancos()
                {
                    //Id=0,
                    Banco = banco,
                    Estatus = true
                };
                
                _db.CatalogoBancos.Add(newbank);
                _db.SaveChanges();

                idbanco = newbank.Id;
            }
            catch (Exception e)
            {
                idbanco = 0;
            }

            return Json(idbanco, JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //VISTA PARA EDITAR BANCOS
        public ActionResult _EditarBancos()
        {
            ViewBag.ListaBancos =
                new SelectList(_db.CatalogoBancos.Where(a => a.Estatus == true), "Id", "Banco");

            CatalogoBancos banco = new CatalogoBancos();

            return PartialView(banco);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult ResumenSubtotales()
        {
            var fecha = DateTime.Now;
            var mes = fecha.Month;
            var anio = fecha.Year;

            ViewBag.ListaMeses = new SelectList(_util.LstMeses(), "Value", "Text",mes);
            ViewBag.ListaAnios = new SelectList(_util.LstAnios(), "Value", "Text",anio);

            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult GetCampanas(int? nmes, int? nanio)
        {
            //QUERY QUE CALCULA SUBTOTALES
            var campa = _db.Database.SqlQuery<SubtotalesComprasVm>("dbo.GET_SUBTOTALES_COMPRAS_MES @Mes={0}, @Anio={1}"
                         ,nmes,nanio).ToList();

            var result = campa;
            
            return Json(result, JsonRequestBehavior.AllowGet);
            //return Json("True", JsonRequestBehavior.AllowGet);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        /// <summary>
        /// Metodo utilizado para la aceptacion o rechazo de la compra
        /// </summary>
        /// <param name="folio">Folio del ticekt</param>
        /// <returns></returns>
        public ActionResult AvisoAprobacionSolicitud(int? folio)
        {
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.IvaA = datosprova.Iva;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.IvaB = datosprovb.Iva;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.IvaC = datosprovc.Iva;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            if (datossol.EstadoSolicitudId == 22)
            {
                var resut = _manager.SetAprobacionDirectores(datossol.Folio);
            }

            if (datossol.EstadoSolicitudId == 24)
            {
                datossol.EstadoSolicitudId = 1;
                //_db.SaveChanges();
               
                var aprobacion = _db.tbl_AprobacionSolicitud.Where(x => x.Folio == datossol.Folio).FirstOrDefault();
                if (aprobacion != null)
                {
                    aprobacion.FAprobacion = DateTime.Now;
                }
                else {
                    aprobacion = new tbl_AprobacionSolicitud();
                    aprobacion.EstadoSolicitudId = datossol.EstadoSolicitudId;
                    aprobacion.Estatus = true;
                    aprobacion.FAprobacion = DateTime.Now;
                    aprobacion.Folio = datossol.Folio;
                    _db.tbl_AprobacionSolicitud.Add(aprobacion);
                }
                _db.SaveChanges();

                var campana = "";
                var infocampana = _db.CatalogoCampanas.Find(solicitud.CampanaId);
                if (infocampana != null)
                {
                    campana = infocampana.Campana;
                }

                var depto = "";
                var infodepto = _db.CatalogoDepartamentos.Find(solicitud.DepartamentoId);
                if (infodepto != null)
                {
                    depto = infodepto.Departamento;
                }

                var cajachica = "";
                if (datossol.DepartamentoId == 2)
                {
                    if (datossol.CajaChica == true)
                    {
                        cajachica = "<b>CAJA CHICA : </b>" + "SI" + "<br/>";
                    }
                    else
                    {
                        cajachica = "<b>CAJA CHICA : </b>" + "NO" + "<br/>";
                    }
                }
                else { cajachica = "<br/>"; }


                #region CONFIGURACION CORREOS
                var cc = new List<string> {//CORREO ACTIVO  
                };
                                
                var apruebadirectivo = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
                var infodirector = _db.CatalogoDirectores.Where(a => a.Id == apruebadirectivo.DirectorId).FirstOrDefault();

                #endregion
                #region CORREOS ACTIVOS
                var cc2 = new List<string> { "jgarcia@pentafon.com", datossol.EmailSolicitante };

                if (solicitud.Solicitante == "ORSON MONTERO")
                    cc2.Add("agutierrez@pentafon.com");
                #endregion


                #region ENVIO DE CORREO
                string strmsjap = string.Format("LA PRESOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE APROBADA<br/><br/>" +
                    "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                    "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                    "<b>UNIDAD: </b>" + datossol.Unidad + "<br/>" +
                    "<b>MARCA: </b>" + datossol.Marca + "<br/>" +
                    "<b>MODELO: </b>" + datossol.Modelo + "<br/><br/>" +
                    "<b>NO. FACTURA: </b>" + datossol.NoFactura + "<br/><br/>" +
                    "<b>COSTO TOTAL FACTURA: </b>" + datossol.CostoTotalFactura +" "+ datossol.TipoMonedaFactura+ "<br/><br/>" +
                    //"<b>OBJETIVO DE LA SOLICITUD : </b>" + solicitud.ObjetivodeSolicitud + "<br/><br/>" +
                    //"<b>BENEFICIO CUANTITATIVO : </b>" + datossol.BeneficioCuantitativo + "<br/><br/>" +
                    //"<b>BENEFICIO CUALITATIVO : </b>" + datossol.BeneficioCualitativo + "<br/><br/>" +
                    //"<b>RETORNO DE INVERSIÓN : </b>" + datossol.RetornoInversion + "<br/><br/>" +
                    ////"<b>MOTIVO : </b>" + solicitud.Impacto + "<br/><br/>" +
                    "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>");


                _messenger.SendMail("COMPRAS", "PRESOLICITUD APROBADA "
                , strmsjap
                , infodirector.Correo, cc2);

                var contenido = "SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO: " + "<b>" + datossol.Folio + "<b>";
                string strmsj = string.Format("SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO " + datossol.Folio + "<br/><br/>" +
                                           "<b>SOLICITANTE: </b>" + datossol.Solicitante + "<br/>" +
                                           "<b>CAMPAÑA: </b>" + campana + "<br/>" +
                                           "<b>DEPARTAMENTO: </b>" + depto + "<br/><br/>" +
                                           "<b>DETALLE DE LA SOLICITUD: </b>" + datossol.DetalledeSolicitud + ".<br/><br/>" +
                                           "<b>UNIDAD: </b>" + datossol.Unidad + "<br/>" +
                                           "<b>MARCA: </b>" + datossol.Marca + "<br/>" +
                                           "<b>MODELO: </b>" + datossol.Modelo + "<br/><br/>" +                                           
                                           "<b>PROVEEDOR SUGERIDO : </b>" + datossol.NombreProveedorSugerido + "<br/><br/>" +
                                           "<b>NO. FACTURA: </b>" + datossol.NoFactura + "<br/><br/>" +
                                           "<b>COSTO TOTAL FACTURA: </b>" + datossol.CostoTotalFactura + " " + datossol.TipoMonedaFactura + "<br/><br/>" +
                                           "<b>OBSERVACIONES : </b>" + datossol.Observaciones + "<br/><br/>"
                                           + cajachica);

                _messenger.SendMail("COMPRAS", "NUEVA SOLICITUD DE COMPRA"
                    , strmsj, correoadmincompras, cc);
                #endregion

            }

            return View(solicitud);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult AvisoRechazoSolicitud(int? folio)
        {
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.IvaA = datosprova.Iva;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.IvaB = datosprovb.Iva;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.IvaC = datosprovc.Iva;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            return View(solicitud);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PANTALLA AVISO APROBACIÓN O RECHAZO (MANUEL, FILI, FAJER SANTOVENA)
        public ActionResult AvisoAprobacionRechazoDirectivos(int? folio, string aprobacion)
        {
            if(aprobacion == null)
            {
                var url = Request.Url.ToString();
                if (url.Contains("aprobacion=1")) { aprobacion = "1"; }
                if (url.Contains("aprobacion=2")) { aprobacion = "2"; }
            }

            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            List<ProveedoresAgregadosSolicitudesDetalles> datosprovedoor = 
                _db.ProveedoresAgregadosSolicitudesDetalles.Where(a => a.Folio == folio).ToList();


            var datosprova = datosprovedoor.FirstOrDefault(a=> a.TipoProveedor == "A");
            var datosprovb = datosprovedoor.FirstOrDefault(a=> a.TipoProveedor == "B");
            var datosprovc = datosprovedoor.FirstOrDefault(a=> a.TipoProveedor == "C");

            var nivelesperaaprobacion = 0;

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
                nivelesperaaprobacion = datossol.EstadoSolicitudId;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.IvaA = datosprova.Iva;
                solicitud.PorcentajeAnticipoA = datosprova.Anticipo;
                solicitud.idProveedorGnrlA = datosprova.IdProveedor;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.IvaB = datosprovb.Iva;
                solicitud.PorcentajeAnticipoB = datosprovb.Anticipo;
                solicitud.idProveedorGnrlB = datosprovb.IdProveedor;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.IvaC = datosprovc.Iva;
                solicitud.PorcentajeAnticipoC = datosprovc.Anticipo;
                solicitud.idProveedorGnrlC = datosprovc.IdProveedor;
            }


            var user = User.Identity.Name;
            solicitud.UsuarioUltimaActualizacion = user;
            var estadoid = 0;

            //Roles: AprobadorDirFin, AprobadorDirGral, AprobadorPresidencia

            var tipoclase = "bordesapr";
            var tipoclasetop = "bordetopapr";

            //APROBADA POR
            if (aprobacion == "1")
            {
                var infoctrlval = _db.CtrlValidacionesDireccion.Where(a => a.Folio == folio).FirstOrDefault();

                if (infoctrlval != null) {

                    if (infoctrlval.EstadoSolicitudId == 9) {
                        infoctrlval.ValidaGerencia = true;
                        infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
                    }
                    if (infoctrlval.EstadoSolicitudId == 10) {
                        infoctrlval.ValidaDirFinanzas = true;
                        infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
                    }
                    if (infoctrlval.EstadoSolicitudId == 11) {//--
                        infoctrlval.ValidaDirGeneral = true;
                        infoctrlval.UsuarioValidaRechaza = "fmondragon";
                    }
                    if (infoctrlval.EstadoSolicitudId == 12) {//--
                        infoctrlval.ValidaPresidencia = true;
                        infoctrlval.UsuarioValidaRechaza = "afajer";
                    }

                    infoctrlval.AprobadoRechazado = 1;
                    infoctrlval.FechaValidacionRechazo = DateTime.Now;

                    _db.CtrlValidacionesDireccion.AddOrUpdate(infoctrlval);
                    _db.SaveChanges();
                }

                if (nivelesperaaprobacion == 9) estadoid = 13;
                if (nivelesperaaprobacion == 10) estadoid = 14;
                if (nivelesperaaprobacion == 11) estadoid = 15;//--
                if (nivelesperaaprobacion == 12) estadoid = 16;//--

                if (datossol.EstadoSolicitudId == 9 || datossol.EstadoSolicitudId == 10 ||
                    datossol.EstadoSolicitudId == 11 || datossol.EstadoSolicitudId == 12)
                {
                    var result = _manager.SetAsignaProveedor(solicitud, aprobacion, estadoid);
                }

                if(datossol.TipoSolicitud != null) {
                    if (datossol.TipoSolicitud == "PRODUCTO")
                    {
                        var dataMail = _mdl.envioMailActivosNuevos.Where(a => a.Folio == folio).FirstOrDefault();
                        if (dataMail == null) { 
                        var cc = new List<string> { correoAdmin, "rpadilla@pentafon.com" };
                        

                        string strmsjActivoFijo = string.Format("Hola, buen día. <br/> LLegara producto con las siguiente especificaciones: </b><br/><br/>" +
                                                           "<b>FOLIO: </b> " + folio+ "<br/>"+
                                                           "<b>DETALLE DE LA SOLICITUD: </b>" + datossol.DetalledeSolicitud + ".<br/>" +                                                           
                                                           "<b>PROVEEDOR: </b>" + datossol.NombreProveedorSugerido + "<br/>" +
                                                           "<b>UNIDAD: </b>" + datossol.Unidad + "<br/>" +
                                                           "<b>MARCA: </b>" + datossol.Marca + "<br/><br/>" +
                                                           "Saludos.");

                            _messenger.SendMail("ACTIVOS NUEVOS", ""
                                        , strmsjActivoFijo
                                        , "rmacias@pentafon.com", cc);

                            envioMailActivosNuevos mailActivos = new envioMailActivosNuevos();
                        mailActivos.FechaRegistro = DateTime.Now;
                        mailActivos.Folio = (int)folio;
                        _mdl.envioMailActivosNuevos.Add(mailActivos);
                        _mdl.SaveChanges();
}

                    }
                }
            }

            //RECHAZADA POR
            if (aprobacion == "2")
            {
                var infoctrlval = _db.CtrlValidacionesDireccion.Where(a => a.Folio == folio).FirstOrDefault();

                if (infoctrlval != null)
                {

                    if (infoctrlval.EstadoSolicitudId == 9)
                    {
                        infoctrlval.ValidaGerencia = false;
                        infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
                    }
                    if (infoctrlval.EstadoSolicitudId == 10)
                    {
                        infoctrlval.ValidaDirFinanzas = false;
                        infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
                    }
                    if (infoctrlval.EstadoSolicitudId == 11)
                    {
                        infoctrlval.ValidaDirGeneral = false;
                        infoctrlval.UsuarioValidaRechaza = "fmondragon";
                    }
                    if (infoctrlval.EstadoSolicitudId == 12)
                    {
                        infoctrlval.ValidaPresidencia = false;
                        infoctrlval.UsuarioValidaRechaza = "afajer";
                    }

                    infoctrlval.AprobadoRechazado = 0;
                    infoctrlval.FechaValidacionRechazo = DateTime.Now;

                    _db.CtrlValidacionesDireccion.AddOrUpdate(infoctrlval);
                    _db.SaveChanges();
                }

                if (nivelesperaaprobacion == 9) estadoid = 17;
                if (nivelesperaaprobacion == 10) estadoid = 18;
                if (nivelesperaaprobacion == 11) estadoid = 19;
                if (nivelesperaaprobacion == 12) estadoid = 20;

                tipoclase = "bordesrec";
                tipoclasetop = "bordetoprec";
            }

            ViewBag.Espera = aprobacion;
            ViewBag.TipoClase = tipoclase;
            ViewBag.TipoClaseTop = tipoclasetop;

            //****var result = _manager.SetAsignaProveedor(solicitud, aprobacion, estadoid);

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            return View(solicitud);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult GuardaMotivoRechazo(int folio, int nivelrechazo, string motivorechazo) 
        {
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);
            var estadoid = 0;
            
            //RECHAZO DE DIRECTORES
            if(nivelrechazo == 0){
                estadoid = 23;
                var result = _manager.SetRechazoDirectores(folio, "2", estadoid, motivorechazo, nivelrechazo);
            }

            //RECHAZO DE DIRECTiVOS
            if (nivelrechazo == 1)
            {
                if (datossol.EstadoSolicitudId == 9) estadoid = 17;
                if (datossol.EstadoSolicitudId == 10) estadoid = 18;
                if (datossol.EstadoSolicitudId == 11) estadoid = 19;
                if (datossol.EstadoSolicitudId == 12) estadoid = 20;
                var result = _manager.SetRechazoDirectores(folio, "2", estadoid, motivorechazo, nivelrechazo);
            }
           
            return Json("True", JsonRequestBehavior.AllowGet); 
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult CompleteFolio(int idfolio)
        {
            string usuario = User.Identity.Name;
            string result = _manager.SaveCompleteFolio(idfolio, usuario);

            //FINALIZA EXITOSO
            if (result == "SI")
            {
               

                SeguimientoSolicitudesDetalles datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == idfolio);
                
                    string linkaprobacion = "https://appext2.pentafon.com/Pentafinances/Compras/EncuestaSat?Folio=" + datossol.Folio;
                

                List<string> cc = new List<string>
                {//CORREO ACTIVO  
                };
                cc.Add("psalinas@pentafon.com");
                string correo2 = datossol.EmailSolicitante;
                string strmsj = string.Format("Hola, buen dia " + datossol.Solicitante +
                        "</br>Esta encuesta busca obtener informacion acerca de la calidad del servicio. <br/><br/>" +
                        "Favor de contestar la encuesta que se generó con los siguientes datos: </br>" +
                        "</br><b>&nbsp;&nbsp;&nbsp;- Folio:  </b> " + datossol.Folio +
                        "</br><b>&nbsp;&nbsp;&nbsp;- Proveedor: </b>" + datossol.NombreProveedorSugerido +
                        "</br><b>&nbsp;&nbsp;&nbsp;- Detalle de la compra: </b>" + datossol.DetalledeSolicitud + "</br></br>" +
                        "Es importante conocer tus comentarios y poder mejorar nuestro proceso.</br>" +
                        "Ve al link siguiente: " +
                        "<a href=" + linkaprobacion + ">Encuesta</a>"+
                        "<br>Quedo atento a tus comentarios muchas gracias.</br> " +
                        "Saludos!");


                _messenger.SendMail("ENCUESTA DE SATISFACCIÓN FOLIO: " + idfolio, "ENCUESTA DE SATISFACCION"
                    , strmsj, correo2, cc);

                return Json("True", JsonRequestBehavior.AllowGet);
            }

            //ERROR AL FINALIZAR
            if (result == "NO")
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }

            return Json("True", JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult AvisoAprobacionSolicitudCascada(int? folio)
        {
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.IvaA = datosprova.Iva;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.IvaB = datosprovb.Iva;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.IvaC = datosprovc.Iva;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            var infoctrlval = _db.CtrlValidacionesDireccion.Where(a => a.Folio == folio).FirstOrDefault();

            if (infoctrlval != null) {

                infoctrlval.ValidaGerencia = true;

                _db.CtrlValidacionesDireccion.AddOrUpdate(infoctrlval);
                _db.SaveChanges();
            }

            var resut = _manager.SetAprobacionDirectores(datossol.Folio);

            return View(solicitud);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult AvisoRechazoSolicitudCascada(int? folio)
        {
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

            var solicitud = new AgregarProveedoresVm() { };

            if (datossol != null)
            {
                solicitud.Folio = datossol.Folio;
                solicitud.Solicitante = datossol.Solicitante;
                solicitud.EmailSolicitante = datossol.EmailSolicitante;
                solicitud.CampanaId = datossol.CampanaId;
                solicitud.DepartamentoId = datossol.DepartamentoId;
                solicitud.UsuarioFinal = datossol.UsuarioFinal;
                solicitud.EmailUsuarioFinal = datossol.EmailUsuarioFinal;
                solicitud.DetalledeSolicitud = datossol.DetalledeSolicitud;
                solicitud.Observaciones = datossol.Observaciones;
            }

            if (datosprova != null)
            {
                solicitud.ProveedorA = datosprova.Proveedor;
                solicitud.DescripcionA = datosprova.Descripcion;
                solicitud.PrecioA = datosprova.Precio;
                solicitud.TipoMonedaA = datosprova.TipoMoneda;
                solicitud.TiempoEntregaA = datosprova.TiempoEntrega;
                solicitud.AsignadoA = datosprova.Asignado;
                solicitud.IvaA = datosprova.Iva;
            }

            if (datosprovb != null)
            {
                solicitud.ProveedorB = datosprovb.Proveedor;
                solicitud.DescripcionB = datosprovb.Descripcion;
                solicitud.PrecioB = datosprovb.Precio;
                solicitud.TipoMonedaB = datosprovb.TipoMoneda;
                solicitud.TiempoEntregaB = datosprovb.TiempoEntrega;
                solicitud.AsignadoB = datosprovb.Asignado;
                solicitud.IvaB = datosprovb.Iva;
            }

            if (datosprovc != null)
            {
                solicitud.ProveedorC = datosprovc.Proveedor;
                solicitud.DescripcionC = datosprovc.Descripcion;
                solicitud.PrecioC = datosprovc.Precio;
                solicitud.TipoMonedaC = datosprovc.TipoMoneda;
                solicitud.TiempoEntregaC = datosprovc.TiempoEntrega;
                solicitud.AsignadoC = datosprovc.Asignado;
                solicitud.IvaC = datosprovc.Iva;
            }

            var info = _db.Database
                .SqlQuery<SeguimientoSolicitudesDetallesVm>("dbo.stpd_GetComprasDetalles").FirstOrDefault(a => a.Folio == folio && a.Estatus);

            if (info != null)
            {
                ViewBag.Campana = info.Campana;
                ViewBag.Depto = info.Departamento;
            }

            return View(solicitud);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult GuardaMotivoRechazoCascada(int folio, int nivelrechazo, string motivorechazo)
        {
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);
            
            var estadoid = 0;

            estadoid = 17; //RECHAZADO POR GERENCIA (FILTRO CASCADA)

            var result = _manager.SetRechazoDirectores(folio, "2", estadoid, motivorechazo, nivelrechazo);

            var infoctrlval = _db.CtrlValidacionesDireccion.Where(a => a.Folio == folio).FirstOrDefault();

            infoctrlval.ValidaGerencia = false;
            infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
            infoctrlval.AprobadoRechazado = 0;
            infoctrlval.FechaValidacionRechazo = DateTime.Now;

            _db.CtrlValidacionesDireccion.AddOrUpdate(infoctrlval);
            _db.SaveChanges();

                //RECHAZO DE DIRECTORES
                //if (nivelrechazo == 0)
                //{
                //    estadoid = 23;
                //    var result = _manager.SetRechazoDirectores(folio, "2", estadoid, motivorechazo, nivelrechazo);
                //}

                //RECHAZO DE DIRECTiVOS
                //if (nivelrechazo == 1)
                //{
                //    if (datossol.EstadoSolicitudId == 9) estadoid = 17;
                //    if (datossol.EstadoSolicitudId == 10) estadoid = 18;
                //    if (datossol.EstadoSolicitudId == 11) estadoid = 19;
                //    if (datossol.EstadoSolicitudId == 12) estadoid = 20;
                //    var result = _manager.SetRechazoDirectores(folio, "2", estadoid, motivorechazo, nivelrechazo);
                //}

                return Json("True", JsonRequestBehavior.AllowGet);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //SendEmail()
        public JsonResult _SendEmail(int idfolio)
        {
            
            var solicitud = _db.SeguimientoSolicitudesDetalles.Where(x => x.Folio == idfolio).FirstOrDefault();
            var apruebadirectivo = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
            
            string strmsjre = "";
            var _cc = new List<string> { }; 
            var cc = new List<string> {};
            string correodirector = "";
            var linkaprobacion = "";
            var linkrechazo = "";
            var botoncorreoaprobacion = "";
            var botoncorreorechazo = "";
            string cajachica;
            //
            try
            {
                var datosProv = _db.ProveedoresAgregadosSolicitudesDetalles.Where(x => x.Folio == idfolio).ToList();

                if (datosProv.Count > 0)
                {
                    _manager.SetProveedoresResend(idfolio);
                }
                #region ENVIO DE CORREO

                if (solicitud.DepartamentoId == 2)
                {

                    if (solicitud.CajaChica == true)
                    {
                        cajachica = "<b>CAJA CHICA : </b>" + "SI" + "<br/>";
                    }
                    else
                    {
                        cajachica = "<b>CAJA CHICA : </b>" + "NO" + "<br/>";
                    }
                }
                else { cajachica = "<br/>"; }

                //CORREO
                var campana = "";
                var infocampana = _db.CatalogoCampanas.Find(solicitud.CampanaId);
                if (infocampana != null)
                {
                    campana = infocampana.Campana;
                }
                var depto = "";
                var infodepto = _db.CatalogoDepartamentos.Find(solicitud.DepartamentoId);
                if (infodepto != null)
                {
                    depto = infodepto.Departamento;
                }

                if (solicitud.EstadoSolicitudId == 24)
                {

                    var infodirector = _db.CatalogoDirectores.Where(a => a.Id == apruebadirectivo.DirectorId).FirstOrDefault();
                    if (infodirector != null)
                    {
                        linkaprobacion = "https://appext2.pentafon.com/Pentafinances/Compras/AvisoAprobacionSolicitud?folio=" + solicitud.Folio.ToString();
                        linkrechazo = "https://appext2.pentafon.com/Pentafinances/Compras/AvisoRechazoSolicitud?folio=" + solicitud.Folio.ToString();
                        botoncorreoaprobacion = "<a href='" + linkaprobacion + "' target='_blank'><div><h4>Aprobar Solicitud</h4></div></a>";
                        botoncorreorechazo = "<a href='" + linkrechazo + "' target='_blank'><div><h4>Rechazar Solicitud</h4></div></a>";
                        // var correodirector = "";

                        correodirector = infodirector.Correo;
                        #region MENSAJE CON ENLACES DE APROBACION; string strmsjToApprove
                        string strmsjToApprove = string.Format("LA PRESOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA DE APROBACIÓN PARA COMENZAR EL SEGUIMIENTO<br/><br/>" +
                        "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                        "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                        "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                        "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                        "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" + 
                        "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                        "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                        //"<b>OBJETIVO DE LA SOLICITUD : </b>" + solicitud.ObjetivodeSolicitud + "<br/><br/>" +
                        //"<b>BENEFICIO CUANTITATIVO : </b>" + solicitud.BeneficioCuantitativo + "<br/><br/>" +
                        //"<b>BENEFICIO CUALITATIVO : </b>" + solicitud.BeneficioCualitativo + "<br/><br/>" +
                        //"<b>RETORNO DE INVERSIÓN : </b>" + solicitud.RetornoInversion + "<br/><br/>" +
                        //"<b>MOTIVO : </b>" + solicitud.Impacto + "<br/><br/>" +
                        "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                        "<table style='width: 100%;'><tr><td style='width: 33%;'>" + botoncorreoaprobacion + "</td><td style='width: 33%;'>" + botoncorreorechazo + "</td></tr></table>");
                        #endregion

                        #region MENSAJE INFORMATIVO; string strmsjPreSolicitud
                        string strmsjPreSolicitud = string.Format("LA PRESOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA DE APROBACIÓN PARA COMENZAR EL SEGUIMIENTO<br/><br/>" +
                        "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                        "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                        "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                        "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                        "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                        "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                        "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                        //"<b>OBJETIVO DE LA SOLICITUD : </b>" + solicitud.ObjetivodeSolicitud + "<br/><br/>" +
                        //"<b>BENEFICIO CUANTITATIVO : </b>" + solicitud.BeneficioCuantitativo + "<br/><br/>" +
                        //"<b>BENEFICIO CUALITATIVO : </b>" + solicitud.BeneficioCualitativo + "<br/><br/>" +
                        //"<b>RETORNO DE INVERSIÓN : </b>" + solicitud.RetornoInversion + "<br/><br/>" +
                        //"<b>MOTIVO : </b>" + solicitud.Impacto + "<br/><br/>" +
                        "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>");
                        #endregion

                        _messenger.SendMailToApprove("COMPRAS", "PRESOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                          , strmsjToApprove
                          , correodirector);


                        _messenger.SendMail("COMPRAS", "INFORMATIVO | PRESOLICITUD DE COMPRA"
                          , strmsjPreSolicitud
                          , solicitud.EmailSolicitante, _cc);

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        _messenger.SendMail("COMPRAS", "INFORMATIVO | PRESOLICITUD DE COMPRA"
                        , "EL CORREO DE DIRECTOR NO ESTA CONFIGURADO CORRECTAMENTE, AVISAR AL EQUIPO DE DESARROLLO"
                        , solicitud.EmailSolicitante, _cc);
                        return Json(true, JsonRequestBehavior.AllowGet);

                    }


                }

                if (solicitud.EstadoSolicitudId == 1 || solicitud.EstadoSolicitudId == 11 || solicitud.EstadoSolicitudId == 12 && apruebadirectivo.NivelId != 2)
                {
                   

                    #region CORREOS ACTIVOS
                    #endregion
                    var contenido = "SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO: " + "<b>" + solicitud.Folio + "<b>";
                    string strmsj = string.Format("SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO " + solicitud.Folio + "<br/><br/>" +
                                               "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/>" +
                                               "<b>CAMPAÑA: </b>" + campana + "<br/>" +
                                               "<b>DEPARTAMENTO: </b>" + depto + "<br/><br/>" +
                                               "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                               "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                               "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                               "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                               "<b>PROVEEDOR SUGERIDO : </b>" + solicitud.NombreProveedorSugerido + "<br/><br/>" +
                                               "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                               "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                                               "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>"
                                               + cajachica);


                    _messenger.SendMail("COMPRAS", "INFORMATIVO | PRE - SOLICITUD DE COMPRA"
                        , strmsj, solicitud.EmailSolicitante, _cc);



                    #endregion
                }
                
                else if (solicitud.EstadoSolicitudId != 24 && apruebadirectivo.NivelId != 1)
                {
                    var contenido = "SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO: " + "<b>" + solicitud.Folio + "<b>";
                    string strmsj = string.Format("SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO " + solicitud.Folio + "<br/><br/>" +
                                               "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/>" +
                                               "<b>CAMPAÑA: </b>" + campana + "<br/>" +
                                               "<b>DEPARTAMENTO: </b>" + depto + "<br/><br/>" +
                                               "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                               "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                               "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                               "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                               "<b>PROVEEDOR SUGERIDO : </b>" + solicitud.NombreProveedorSugerido + "<br/><br/>" +
                                               "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                               "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                                               "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>"
                                               + cajachica);

                    _messenger.SendMail("COMPRAS", "INFORMATIVO | NUEVA SOLICITUD DE COMPRA"
                        , strmsj, solicitud.EmailSolicitante, _cc);

                }
            }
            catch (Exception ex) { 
            
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public ActionResult EncuestaSat()
        {
            EncuestaSatPentaFinances vm = new EncuestaSatPentaFinances();


            string user = User.Identity.Name;
            if (user.ToUpper() == "JGARCIAF" || user.ToUpper() == "DFUENTES")
            {
                ViewBag.user = true;
            }
            else
            {
                ViewBag.user = false;
            }

            string folio = Request["Folio"];
            vm.Folio = Convert.ToInt32(folio);

            EncuestaSatPentaFinances encuesta = _db.EncuestaSatPentaFinances.Where(a => a.Folio == vm.Folio).FirstOrDefault();
            var Compra = _db.SeguimientoSolicitudesDetalles.Where(a => a.Folio == vm.Folio).FirstOrDefault();
            var proveedor = _db.ProveedoresAgregadosSolicitudesDetalles.Where(a => a.Folio == vm.Folio && a.Asignado).FirstOrDefault();

            ViewBag.DetalleCompra = Compra.DetalledeSolicitud;
            if (proveedor != null) 
            ViewBag.Proveedor = proveedor.Proveedor;
            else
                ViewBag.Proveedor = "";
            ViewBag.Tipo = Compra.TipoSolicitud;
            if (encuesta != null)
            {
                vm = encuesta;                
                ViewBag.Estatus = true;
            }
            else
            {
                ViewBag.Estatus = false;
            }
            return View(vm);
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        [HttpPost]
        public ActionResult SaveEncuestaSat(EncuestaSatPentaFinances vm)
        {                                   

            try
            {
                _manager.SetEncuestaSat(vm);
                return RedirectToAction("Success2", "Compras");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Compras");
            }
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult Success2(string folio)
        {
           
            return View();

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -        
        public ActionResult EvaluacionProveedores()
        {
            var user = User.Identity.Name;
            var fecha = DateTime.Now.AddMonths(-1);
            int mes = DateTime.Now.Month;
            int año = DateTime.Now.Year;
            DateTime primerDia = new DateTime(año, mes-1, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);


            if (user != "")
            {
                //ViewBag.proveedores = new SelectList(_db.ProveedoresAgregadosSolicitudesDetalles.Where
                //    (x => x.FechaRegistro >= primerDia && x.FechaRegistro <= ultimoDia).Select(x => x.Proveedor).Distinct(), "Proveedor");

                ViewBag.proveedores = new SelectList(string.Empty, "Value", "Text");

                return View();
            }
            else
            {
                return RedirectToAction("Home", "App");
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public JsonResult GET_Proveedores(int Anio, int Mes)
        {
            try
            {           
                var data = _db.ProveedoresAgregadosSolicitudesDetalles.Where(x => x.FechaRegistro.Month == Mes && x.FechaRegistro.Year == Anio && x.Proveedor != null).Select(x => new { x.IdProveedor, x.Proveedor}).Distinct().ToList();

                //var data = new SelectList(_db.ProveedoresAgregadosSolicitudesDetalles.Where
                //  (x => x.FechaRegistro.Month == Mes && x.FechaRegistro.Year == Anio && x.Proveedor != null).Select(x => x.Proveedor).Distinct(), "Proveedor");

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
        [HttpPost]
        public ActionResult SaveEvaluacionProveedores(EvaluacionProveedores vm)
        {
            try
            {
                _manager.SetEvaluacionProveedor(vm); 
                return RedirectToAction("EvaluacionProveedores", "Compras");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Compras");
            }
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
        public JsonResult _SearchEvaluacion(string proveedor,int mes, string anio)
        {
            EvaluacionProveedores vm = new EvaluacionProveedores();
            var result = _db.EvaluacionProveedores.Where(x => x.proveedor == proveedor && x.Mes == mes && x.Anio == anio).FirstOrDefault();

           
                return Json(result, JsonRequestBehavior.AllowGet);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
        public JsonResult Reporte()
        {
            String toPath = Path.Combine(Server.MapPath("~/Content/"));
            _manager.GetReport(toPath);
            var result = "";

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
        public JsonResult SaveCatProveedor(string nomEmpresa, string nomProveedor, string nomPeriocidad )
        {
            var result = _manager.SetCatProveedores(nomEmpresa,nomProveedor,nomPeriocidad);
            
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }


}

