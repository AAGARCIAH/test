using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PentaFinances.Models;
using PentaFinances.Utils;
using PentaFinances.ViewModels;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace PentaFinances.Managers
{
    public class ComprasManager
    {
        PentaFinComprasContext _db = new PentaFinComprasContext();
        private readonly Messenger _messenger = new Messenger();

        string correoadmincompras = "igomiciaga@neikos.com.mx";
        string correodirfinanzas = "igomiciaga@neikos.com.mx";
        string correodirgral = "fmondragon@pentafon.com";
        string correopresidencia = "afajer@neikos.com.mx";
        string correoadmin = "jrojo@pentafoncc.com";

        //string correoadmincompras = "psalinas@pentafon.com";
        //string correodirfinanzas = "dnava@pentafon.com";
        //string correodirgral = "operez@pentafon.com";
        //string correopresidencia = "dfuentes@pentafon.com";
        //string correoadmin = "aagarcia@pentafoncc.com";

        ////- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public void SetComprobante(tbl_ComprobantePago comprobante)
        {
            tbl_ComprobantePago datos = new tbl_ComprobantePago
            {
                Folio = comprobante.Folio,
                Comprobante = comprobante.Comprobante,
                FechaRegistro = DateTime.Now
            };
            _db.tbl_ComprobantePago.Add(comprobante);
            _db.SaveChanges();
        }
        public ResultLevantaSolicitudVm SetLevantaSolicitud(SolicitudesDetalles solicitud)
        {
            var fecha = DateTime.Now;
            var error = "Error";
            var marca = "";
            var modelo = "";
            var proveedor = "";
            var observaciones = "";
            var cajachica = "";
            var resultado = new ResultLevantaSolicitudVm();
            string validaCorreo = "";


            #region VALIDACIONES DE LA SOLICITUD
            var detalle = solicitud.DetalledeSolicitud.Replace("\r\n", string.Empty);
            var unidad = solicitud.Unidad.Replace("\r\n", string.Empty);
            if (solicitud.Marca != null)
            {
                marca = solicitud.Marca.Replace("\r\n", string.Empty);
            }
            if (solicitud.Modelo != null)
            {
                modelo = solicitud.Modelo.Replace("\r\n", string.Empty);
            }

            var bencuantitativo = "";
            var bencualitativo = "";
            var retinversion = "";

            if (solicitud.NombreProveedorSugerido != null)
            {
                proveedor = solicitud.NombreProveedorSugerido.Replace("\r\n", string.Empty);
            }

            if (solicitud.Observaciones != null)
            {
                observaciones = solicitud.Observaciones.Replace("\r\n", string.Empty);
            }


            var recurrente = "";

            if (solicitud.Recurrente_TEMP == true)
            {
                recurrente = "SI";
            }
            #endregion

            try
            {

                #region GUARDADOS EN TABLAS; SOLICITUDES Y COMPRAS
                //GUARDA REGISTRO DE LA SOLICITUD EN LA TABLA DE SOLICITUDES (SOLICITANTE)
                //SE GUARDA CON ESTATUS TRUE
                var registro = new SolicitudesDetalles()
                {
                    //Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = detalle,
                    Unidad = unidad,
                    Marca = solicitud.Marca == null ? "N/A" : marca,
                    Modelo = solicitud.Modelo == null ? "N/A" : modelo,
                    //ObjetivodeSolicitud = objetivo,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = proveedor,
                    Observaciones = observaciones,
                    Estatus = true,
                    FechaRegistro = fecha,
                    //Datos De Usuario
                    UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    //Actualización Campo Caja Chica
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = bencuantitativo,
                    BeneficioCualitativo = bencualitativo,
                    RetornoInversion = retinversion,
                    Recurrente = recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura
                };

                _db.SolicitudesDetalles.Add(registro);
                _db.SaveChanges();


                //GUARDA REGISTRO DE LA SOLICITUD EN LA TABLA DE COMPRAS (COMPRAS)
                //SE GUARDA CON ESTATUS TRUE
                var seguimiento = new SeguimientoSolicitudesDetalles()
                {
                    Folio = registro.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = detalle,
                    Unidad = unidad,
                    Marca = solicitud.Marca == null ? "N/A" : marca,
                    Modelo = solicitud.Modelo == null ? "N/A" : modelo,
                    //ObjetivodeSolicitud = objetivo,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = proveedor,
                    EstadoSolicitudId = 1,
                    Observaciones = observaciones,
                    MotivoRechazo = null,
                    Estatus = true,
                    FechaRegistro = fecha,
                    //Datos De Usuario
                    UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    //Actualización Campo Caja Chica
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = bencuantitativo,
                    BeneficioCualitativo = bencualitativo,
                    RetornoInversion = retinversion,
                    Recurrente = recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura
                };

                _db.SeguimientoSolicitudesDetalles.Add(seguimiento);
                _db.SaveChanges();
                #endregion

                //-------------------------------------------

                #region CONFIGURACION PROVEEDOR RECURRENTE
                //NUEVA SECCIÓN PROVEEDOR RECURRENTE
                //==================================
                if (solicitud.Recurrente_TEMP == true)
                {

                    var idfolio = seguimiento.Folio;

                    var provrecurrente = new tbl_ProveedorRecurrenteCompras();

                    provrecurrente.Folio = idfolio;
                    provrecurrente.Proveedor = solicitud.ProveedorR;
                    provrecurrente.Descripcion = solicitud.DescripcionR;
                    provrecurrente.Precio = solicitud.Precio;
                    provrecurrente.TipoMoneda = solicitud.TipoMoneda;
                    provrecurrente.FechaRegistro = DateTime.Now;

                    _db.tbl_ProveedorRecurrenteCompras.Add(provrecurrente);
                    _db.SaveChanges();

                }
                //==================================
                #endregion

                //-------------------------------------------

                #region BUSQUEDA DE LA INFO DE LA CAMAPAÑA Y DEPARTAMENTO DE LA SOLICITUD
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
                #endregion

                //-------------------------------------------

                #region SI SE ANEXA COMPROBANTE EN FORMATO PDF 
                tbl_ComprobantePago datos = new tbl_ComprobantePago
                {
                    Folio = seguimiento.Folio,
                    Comprobante = solicitud.Comprobante,
                    FechaRegistro = DateTime.Now
                };
                _db.tbl_ComprobantePago.Add(datos);
                _db.SaveChanges();
                #endregion

                #region ENVIA CORREO DE NOTIFICACIÓN 
                try
                {
                    int _resultado = seguimiento.Folio;
                    //SE ACTUALIZA EL ESTADO DE SOLICITUD DEPENDIENDO EL NIVEL DE APROBACIÓN 
                    SeguimientoSolicitudesDetalles solicitudDetail = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == _resultado);
                    CatalogoCampanas campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == solicitud.CampanaId);
                    ApUsuarios apruebadirectivo = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();

                    string linkaprobacion = "";
                    string linkrechazo = "";
                    string botoncorreoaprobacion = "";
                    string botoncorreorechazo = "";

                    if (apruebadirectivo.NivelId == 1 && seguimiento.EstadoSolicitudId == 1)
                    {
                        seguimiento.EstadoSolicitudId = 24;
                        _db.SaveChanges();

                        linkaprobacion = "https://appext2.pentafon.com/PentaFinances/Compras/AvisoAprobacionSolicitud?folio=" + _resultado.ToString();
                        linkrechazo = "https://appext2.pentafon.com/PentaFinances/Compras/AvisoRechazoSolicitud?folio=" + _resultado.ToString();
                        botoncorreoaprobacion = "<a href='" + linkaprobacion + "' target='_blank'><div><h4>Aprobar Solicitud</h4></div></a>";
                        botoncorreorechazo = "<a href='" + linkrechazo + "' target='_blank'><div><h4>Rechazar Solicitud</h4></div></a>";
                        var correodirector = "";

                        if (apruebadirectivo != null)
                        {
                            var _cc = new List<string> { "jgarcia@pentafon.com" };
                            var infodirector = _db.CatalogoDirectores.Where(a => a.Id == apruebadirectivo.DirectorId).FirstOrDefault();
                            if (solicitud.Solicitante == "ORSON MONTERO")
                                _cc.Add("sramirez@pentafon.com");

                            if (infodirector != null)
                            {

                                correodirector = infodirector.Correo;

                                #region MENSAJE CON ENLACES DE APROBACION; string strmsjToApprove
                                string strmsjToApprove = string.Format("LA PRESOLICITUD DE COMPRA CON FOLIO: " + _resultado +
                                    " ESTA EN ESPERA DE APROBACIÓN PARA COMENZAR EL SEGUIMIENTO<br/><br/>" +
                                "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                                "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                "<table style='width: 100%;'><tr><td style='width: 33%;'>" + botoncorreoaprobacion + "</td><td style='width: 33%;'>" + botoncorreorechazo + "</td></tr></table>");
                                #endregion

                                #region MENSAJE INFORMATIVO; string strmsjPreSolicitud
                                string strmsjPreSolicitud = string.Format("LA PRESOLICITUD DE COMPRA CON FOLIO: " + _resultado + " ESTA EN ESPERA DE APROBACIÓN PARA COMENZAR EL SEGUIMIENTO<br/><br/>" +
                                "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +

                                "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>");
                                #endregion

                                validaCorreo = _messenger.SendMailToApprove("COMPRAS", "PRESOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsjToApprove
                                , infodirector.Correo);

                                validaCorreo = _messenger.SendMail("COMPRAS", "INFORMATIVO | PRESOLICITUD DE COMPRA"
                                  , strmsjPreSolicitud
                                  , solicitud.EmailSolicitante, _cc);
                            }

                            else
                            {
                                validaCorreo = _messenger.SendMail("COMPRAS", "INFORMATIVO | PRESOLICITUD DE COMPRA"
                                 , "EL CORREO DE DIRECTOR NO ESTA CONFIGURADO CORRECTAMENTE, AVISAR AL EQUIPO DE DESARROLLO"
                                 , solicitud.EmailSolicitante, _cc);
                            }

                        }
                    }
                    if (seguimiento.EstadoSolicitudId != 24 && apruebadirectivo.NivelId != 1)
                    {
                        var _cc = new List<string> { "jgarcia@pentafon.com" };
                        //CORREO
                        var contenido = "SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO: " + "<b>" + seguimiento.Folio + "<b>";
                        string strmsj = string.Format("SE HA LEVANTADO UNA SOLICITUD DE COMPRA CON FOLIO " + seguimiento.Folio + "<br/><br/>" +
                                                   "<b>SOLICITANTE: </b>" + seguimiento.Solicitante + "<br/>" +
                                                   "<b>CAMPAÑA: </b>" + campana + "<br/>" +
                                                   "<b>DEPARTAMENTO: </b>" + depto + "<br/><br/>" +
                                                   "<b>DETALLE DE LA SOLICITUD: </b>" + seguimiento.DetalledeSolicitud + ".<br/><br/>" +
                                                   "<b>UNIDAD: </b>" + seguimiento.Unidad + "<br/>" +
                                                   "<b>MARCA: </b>" + seguimiento.Marca + "<br/>" +
                                                   "<b>MODELO: </b>" + seguimiento.Modelo + "<br/><br/>" +
                                                   "<b>PROVEEDOR SUGERIDO : </b>" + seguimiento.NombreProveedorSugerido + "<br/><br/>" +
                                                   "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                                                   "<b>OBSERVACIONES : </b>" + seguimiento.Observaciones + "<br/><br/>"
                                                   + cajachica);


                        _messenger.SendMail("COMPRAS", "INFORMATIVO | NUEVA SOLICITUD DE COMPRA"
                            , strmsj, solicitud.EmailSolicitante, _cc);
                    }


                    #region ¿ES CAJA CHICA?
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
                    #endregion

                }
                #endregion
                catch (Exception e)
                {
                    //error = "Error";
                    resultado.Resultado = e.InnerException.ToString();
                    return resultado;
                }

                #region REGRESO DE FOLIO GENERADO A LA VISTA
                resultado.Resultado = "Exito";
                resultado.Folio = registro.Folio.ToString();
                return resultado;
                #endregion


            }
            catch (Exception ex)
            {
                resultado.Resultado = ex.InnerException.ToString();
                return resultado;
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string SetSeguimientoSolicitud(SeguimientoSolicitudesDetalles solicitud)
        {
            var fecha = DateTime.Now;

            try
            {
                #region ACTUALIZA LAS TABLAS; ComprasDetalles y SolicitudesdeCompra (SI LA SOLICITUD ES RECHAZADA O NO)
                if (solicitud.EstadoSolicitudId != 3) //SI ES DIFERENTE A SOLICITUD RECHAZADA
                {

                    var seguimiento = new SeguimientoSolicitudesDetalles()
                    {
                        Folio = solicitud.Folio,
                        Solicitante = solicitud.Solicitante,
                        EmailSolicitante = solicitud.EmailSolicitante,
                        CampanaId = solicitud.CampanaId,
                        DepartamentoId = solicitud.DepartamentoId,
                        UsuarioFinal = solicitud.UsuarioFinal,
                        EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                        DetalledeSolicitud = solicitud.DetalledeSolicitud,
                        Unidad = solicitud.Unidad,
                        Marca = solicitud.Marca,
                        Modelo = solicitud.Modelo,
                        ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                        PosibleProveedor = solicitud.PosibleProveedor,
                        NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                        EstadoSolicitudId = solicitud.EstadoSolicitudId,
                        MotivoRechazo = solicitud.MotivoRechazo,
                        Observaciones = solicitud.Observaciones,
                        FechaRegistro = solicitud.FechaRegistro,
                        Estatus = true,
                        //Datos De Usuario
                        UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        //Actulización Caja chica
                        CajaChica = solicitud.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                        BeneficioCualitativo = solicitud.BeneficioCualitativo,
                        RetornoInversion = solicitud.RetornoInversion,
                        Recurrente = solicitud.Recurrente,
                        TipoSolicitud = solicitud.TipoSolicitud,
                        CostoTotalFactura = solicitud.CostoTotalFactura,
                        TipoMonedaFactura = solicitud.TipoMonedaFactura,
                        NoFactura = solicitud.NoFactura
                    };

                    _db.SeguimientoSolicitudesDetalles.AddOrUpdate(seguimiento);
                    _db.SaveChanges();

                    var registro = new SolicitudesDetalles()
                    {
                        Folio = solicitud.Folio,
                        Solicitante = solicitud.Solicitante,
                        EmailSolicitante = solicitud.EmailSolicitante,
                        CampanaId = solicitud.CampanaId,
                        DepartamentoId = solicitud.DepartamentoId,
                        UsuarioFinal = solicitud.UsuarioFinal,
                        EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                        DetalledeSolicitud = solicitud.DetalledeSolicitud,
                        Unidad = solicitud.Unidad,
                        Marca = solicitud.Marca,
                        Modelo = solicitud.Modelo,
                        ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                        Impacto = solicitud.Impacto,
                        PosibleProveedor = solicitud.PosibleProveedor,
                        NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                        Observaciones = solicitud.Observaciones,
                        FechaRegistro = solicitud.FechaRegistro,
                        Estatus = true,
                        //Datos De Usuario
                        //UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                        //FechaUltimaActualizacion = fecha
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                        BeneficioCualitativo = solicitud.BeneficioCualitativo,
                        RetornoInversion = solicitud.RetornoInversion,
                        Recurrente = solicitud.Recurrente,
                        TipoSolicitud = solicitud.TipoSolicitud,
                        CostoTotalFactura = solicitud.CostoTotalFactura,
                        TipoMonedaFactura = solicitud.TipoMonedaFactura,
                        NoFactura = solicitud.NoFactura
                    };

                    _db.SolicitudesDetalles.AddOrUpdate(registro);
                    _db.SaveChanges();
                }
                else
                {
                    var seguimiento = new SeguimientoSolicitudesDetalles()
                    {
                        Folio = solicitud.Folio,
                        Solicitante = solicitud.Solicitante,
                        EmailSolicitante = solicitud.EmailSolicitante,
                        CampanaId = solicitud.CampanaId,
                        DepartamentoId = solicitud.DepartamentoId,
                        UsuarioFinal = solicitud.UsuarioFinal,
                        EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                        DetalledeSolicitud = solicitud.DetalledeSolicitud,
                        Unidad = solicitud.Unidad,
                        Marca = solicitud.Marca,
                        Modelo = solicitud.Modelo,
                        ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                        PosibleProveedor = solicitud.PosibleProveedor,
                        NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                        EstadoSolicitudId = solicitud.EstadoSolicitudId,
                        MotivoRechazo = solicitud.MotivoRechazo,
                        Observaciones = solicitud.Observaciones,
                        FechaRegistro = solicitud.FechaRegistro,
                        Estatus = false,
                        //Datos De Usuario
                        UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = solicitud.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                        BeneficioCualitativo = solicitud.BeneficioCualitativo,
                        RetornoInversion = solicitud.RetornoInversion,
                        Recurrente = solicitud.Recurrente,
                        TipoSolicitud = solicitud.TipoSolicitud,
                        CostoTotalFactura = solicitud.CostoTotalFactura,
                        TipoMonedaFactura = solicitud.TipoMonedaFactura,
                        NoFactura = solicitud.NoFactura
                    };

                    _db.SeguimientoSolicitudesDetalles.AddOrUpdate(seguimiento);
                    _db.SaveChanges();

                    var registro = new SolicitudesDetalles()
                    {
                        Folio = solicitud.Folio,
                        Solicitante = solicitud.Solicitante,
                        EmailSolicitante = solicitud.EmailSolicitante,
                        CampanaId = solicitud.CampanaId,
                        DepartamentoId = solicitud.DepartamentoId,
                        UsuarioFinal = solicitud.UsuarioFinal,
                        EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                        DetalledeSolicitud = solicitud.DetalledeSolicitud,
                        Unidad = solicitud.Unidad,
                        Marca = solicitud.Marca,
                        Modelo = solicitud.Modelo,
                        ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                        Impacto = solicitud.Impacto,
                        PosibleProveedor = solicitud.PosibleProveedor,
                        NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                        Observaciones = solicitud.Observaciones,
                        FechaRegistro = solicitud.FechaRegistro,
                        Estatus = false,
                        //Datos De Usuario
                        //UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = solicitud.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                        BeneficioCualitativo = solicitud.BeneficioCualitativo,
                        RetornoInversion = solicitud.RetornoInversion,
                        Recurrente = solicitud.Recurrente,
                        TipoSolicitud = solicitud.TipoSolicitud,
                        CostoTotalFactura = solicitud.CostoTotalFactura,
                        TipoMonedaFactura = solicitud.TipoMonedaFactura,
                        NoFactura = solicitud.NoFactura
                    };

                    _db.SolicitudesDetalles.AddOrUpdate(registro);
                    _db.SaveChanges();
                }
                #endregion
                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //GUARDAR LOS DATOS DE LOS PROVEEDORES DE UNA SOLICITUD
        public string SetProveedores(AgregarProveedoresVm vm)
        {
            var fecha = DateTime.Now;
            var nivelaprobacion = 0;
            var infoprovcorreo = "";
            var infosubtotalcorreo = "";
            var infomonedacorreo = "";
            var infoivacorreo = "";
            var infotiempoentregacorreo = "";
            var infocreditocorreo = "";
            var infotiempocredcorreo = "";
            var anticipoProveedor = "";
            var comentarioAnticipo = "";
            var solicitud = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == vm.Folio);
            var campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == solicitud.CampanaId);

            try
            {

                #region ACTUALIZA DATOS PROVEEDORES 
                //DATOS PROVEEDOR A
                var proveedora = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "A");
                var nomProveedorA = _db.proveedores.FirstOrDefault(a => a.Id == vm.idProveedorGnrlA);

                if (proveedora != null)
                {

                    var actualizaA = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = proveedora.Id,
                        Folio = proveedora.Folio,
                        Proveedor = nomProveedorA.Nombre,
                        TipoProveedor = proveedora.TipoProveedor,
                        Descripcion = vm.DescripcionA,
                        Precio = vm.PrecioA,
                        TiempoEntrega = vm.TiempoEntregaA,
                        DocumentoCotizacion = proveedora.DocumentoCotizacion,
                        Asignado = vm.AsignadoA,
                        Observaciones = vm.Observaciones,
                        FechaRegistro = proveedora.FechaRegistro,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = vm.PermiteCreditoA,
                        TiempoCredito = vm.TiempoCreditoA,
                        TipoMoneda = nomProveedorA.Nombre != null ? vm.TipoMonedaA : null,
                        Iva = vm.IvaA,
                        IncluyeIva = vm.IncluyeIva,
                        Anticipo = vm.PorcentajeAnticipoA,
                        ComentarioAnticipo = vm.ComentarioAnticipoA,
                        IdProveedor = vm.idProveedorGnrlA

                    };
                    _db.ProveedoresAgregadosSolicitudesDetalles.AddOrUpdate(actualizaA);
                    _db.SaveChanges();
                }
                else
                {
                    var provedorA = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = 0,
                        Folio = vm.Folio,
                        Proveedor = nomProveedorA.Nombre,
                        TipoProveedor = "A",
                        Descripcion = vm.DescripcionA,
                        Precio = vm.PrecioA,
                        TiempoEntrega = vm.TiempoEntregaA,
                        DocumentoCotizacion = vm.DocumentoCotizacionA,
                        Asignado = vm.AsignadoA,
                        Observaciones = vm.Observaciones,
                        FechaRegistro = fecha,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = vm.PermiteCreditoA,
                        TiempoCredito = vm.TiempoCreditoA,
                        TipoMoneda = nomProveedorA.Nombre != null ? vm.TipoMonedaA : null,
                        Iva = vm.IvaA,
                        IncluyeIva = vm.IncluyeIva,
                        Anticipo = vm.PorcentajeAnticipoA,
                        ComentarioAnticipo = vm.ComentarioAnticipoA,
                        IdProveedor = vm.idProveedorGnrlA
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.Add(provedorA);
                    _db.SaveChanges();
                }


                //DATOS PROVEEDOR B
                var proveedorb = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "B");
                var nomProveedorB = _db.proveedores.FirstOrDefault(a => a.Id == vm.idProveedorGnrlB);
                var nomProveedorB2 = "";
                if (nomProveedorB != null)
                    nomProveedorB2 = nomProveedorB.Nombre;

                if (proveedorb != null)
                {
                    var actualizaB = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = proveedorb.Id,
                        Folio = proveedorb.Folio,
                        Proveedor = nomProveedorB2,
                        TipoProveedor = proveedorb.TipoProveedor,
                        Descripcion = vm.DescripcionB,
                        Precio = vm.PrecioB,
                        TiempoEntrega = vm.TiempoEntregaB,
                        DocumentoCotizacion = proveedorb.DocumentoCotizacion,
                        Asignado = vm.AsignadoB,
                        Observaciones = vm.Observaciones,
                        FechaRegistro = proveedorb.FechaRegistro,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = vm.PermiteCreditoB,
                        TiempoCredito = vm.TiempoCreditoB,
                        TipoMoneda = nomProveedorB2 != null ? vm.TipoMonedaB : null,
                        Iva = vm.IvaB,
                        IncluyeIva = vm.IncluyeIvaB,
                        Anticipo = vm.PorcentajeAnticipoB,
                        ComentarioAnticipo = vm.ComentarioAnticipoB,
                        IdProveedor = vm.idProveedorGnrlB
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.AddOrUpdate(actualizaB);
                    _db.SaveChanges();
                }
                else
                {
                    var provedorB = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = 0,
                        Folio = vm.Folio,
                        Proveedor = nomProveedorB2,
                        TipoProveedor = "B",
                        Descripcion = vm.DescripcionB,
                        Precio = vm.PrecioB,
                        TiempoEntrega = vm.TiempoEntregaB,
                        DocumentoCotizacion = vm.DocumentoCotizacionB,
                        Asignado = vm.AsignadoB,
                        Observaciones = vm.Observaciones,
                        FechaRegistro = fecha,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = vm.PermiteCreditoB,
                        TiempoCredito = vm.TiempoCreditoB,
                        TipoMoneda = nomProveedorB2 != null ? vm.TipoMonedaB : null,
                        Iva = vm.IvaB,
                        IncluyeIva = vm.IncluyeIvaB,
                        Anticipo = vm.PorcentajeAnticipoB,
                        ComentarioAnticipo = vm.ComentarioAnticipoB,
                        IdProveedor = vm.idProveedorGnrlB
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.Add(provedorB);
                    _db.SaveChanges();
                }

                //DATOS PROVEEDOR C
                var proveedorc = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "C");
                var nomProveedorC = _db.proveedores.FirstOrDefault(a => a.Id == vm.idProveedorGnrlC);
                var nomProveedorC2 = "";
                if (nomProveedorC != null)
                    nomProveedorC2 = nomProveedorC.Nombre;

                if (proveedorc != null)
                {
                    var actualizaC = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = proveedorc.Id,
                        Folio = proveedorc.Folio,
                        Proveedor = nomProveedorC2,
                        TipoProveedor = proveedorc.TipoProveedor,
                        Descripcion = vm.DescripcionC,
                        Precio = vm.PrecioC,
                        TiempoEntrega = vm.TiempoEntregaC,
                        DocumentoCotizacion = proveedorc.DocumentoCotizacion,
                        Asignado = vm.AsignadoC,
                        Observaciones = vm.Observaciones,
                        FechaRegistro = proveedorc.FechaRegistro,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = vm.PermiteCreditoC,
                        TiempoCredito = vm.TiempoCreditoC,
                        TipoMoneda = nomProveedorC2 != null ? vm.TipoMonedaC : null,
                        Iva = vm.IvaC,
                        IncluyeIva = vm.IncluyeIvaC,
                        Anticipo = vm.PorcentajeAnticipoC,
                        ComentarioAnticipo = vm.ComentarioAnticipoC,
                        IdProveedor = vm.idProveedorGnrlC
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.AddOrUpdate(actualizaC);
                    _db.SaveChanges();
                }
                else
                {
                    var provedorC = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = 0,
                        Folio = vm.Folio,
                        Proveedor = nomProveedorC2,
                        TipoProveedor = "C",
                        Descripcion = vm.DescripcionC,
                        Precio = vm.PrecioC,
                        TiempoEntrega = vm.TiempoEntregaC,
                        DocumentoCotizacion = vm.DocumentoCotizacionC,
                        Asignado = vm.AsignadoC,
                        Observaciones = vm.Observaciones,
                        FechaRegistro = fecha,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = vm.PermiteCreditoC,
                        TiempoCredito = vm.TiempoCreditoC,
                        TipoMoneda = nomProveedorC2 != null ? vm.TipoMonedaC : null,
                        Iva = vm.IvaC,
                        IncluyeIva = vm.IncluyeIvaC,
                        Anticipo = vm.PorcentajeAnticipoC,
                        ComentarioAnticipo = vm.ComentarioAnticipoC,
                        IdProveedor = vm.idProveedorGnrlC
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.Add(provedorC);
                    _db.SaveChanges();
                }

                #endregion

                #region CONFIGURACION TIPO DE APROBACION; (NivelAprobacion : Cantidad); 9 <= 10 000 , 10 <= 50000, 11 <= 100 000

                //VALIDAR NIVEL DE APROBACIÓN
                if (vm.AsignadoA == true)
                {
                    //VALIDAR TIPO DE MONEDA MXN
                    if (vm.TipoMonedaA == "MXN")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioA <= 10000) nivelaprobacion = 9;
                        if (vm.PrecioA > 10000 && vm.PrecioA <= 50000) nivelaprobacion = 10;
                        if (vm.PrecioA > 50000 && vm.PrecioA <= 100000) nivelaprobacion = 11;
                        if (vm.PrecioA > 100000) nivelaprobacion = 12;
                        infomonedacorreo = "MXN";
                    }

                    //VALIDAR TIPO DE MONEDA USD
                    if (vm.TipoMonedaA == "USD")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioA <= 480) nivelaprobacion = 9;
                        if (vm.PrecioA > 480 && vm.PrecioA <= 2380) nivelaprobacion = 10;
                        if (vm.PrecioA > 2380 && vm.PrecioA <= 4760) nivelaprobacion = 11;
                        if (vm.PrecioA > 4760) nivelaprobacion = 12;
                        infomonedacorreo = "USD";
                    }

                    var dataProveedor = _db.proveedores.Where(x => x.Id == vm.idProveedorGnrlA).FirstOrDefault();
                    infoprovcorreo = dataProveedor.Nombre;
                    infosubtotalcorreo = vm.PrecioA.ToString();
                    infoivacorreo = vm.IvaA.ToString();
                    infotiempoentregacorreo = vm.TiempoEntregaA;
                    infocreditocorreo = vm.PermiteCreditoA ? "SI" : "NO";
                    infotiempocredcorreo = vm.TiempoCreditoA.ToString();
                    anticipoProveedor = vm.PorcentajeAnticipoA.ToString();
                    comentarioAnticipo = vm.ComentarioAnticipoA;
                }
                if (vm.AsignadoB == true)
                {
                    //VALIDAR TIPO DE MONEDA MXN
                    if (vm.TipoMonedaB == "MXN")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioB <= 10000) nivelaprobacion = 9;
                        if (vm.PrecioB > 10000 && vm.PrecioB <= 50000) nivelaprobacion = 10;
                        if (vm.PrecioB > 50000 && vm.PrecioB <= 100000) nivelaprobacion = 11;
                        if (vm.PrecioB > 100000) nivelaprobacion = 12;
                        infomonedacorreo = "MXN";
                    }

                    //VALIDAR TIPO DE MONEDA USD
                    if (vm.TipoMonedaB == "USD")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioB <= 480) nivelaprobacion = 9;
                        if (vm.PrecioB > 480 && vm.PrecioB <= 2380) nivelaprobacion = 10;
                        if (vm.PrecioB > 2380 && vm.PrecioB <= 4760) nivelaprobacion = 11;
                        if (vm.PrecioB > 4760) nivelaprobacion = 12;
                        infomonedacorreo = "USD";
                    }

                    var dataProveedor = _db.proveedores.Where(x => x.Id == vm.idProveedorGnrlB).FirstOrDefault();
                    infoprovcorreo = dataProveedor.Nombre;
                    infosubtotalcorreo = vm.PrecioB.ToString();
                    infoivacorreo = vm.IvaB.ToString();
                    infotiempoentregacorreo = vm.TiempoEntregaB;
                    infocreditocorreo = vm.PermiteCreditoB ? "SI" : "NO";
                    infotiempocredcorreo = vm.TiempoCreditoB.ToString();
                    anticipoProveedor = vm.PorcentajeAnticipoB.ToString();
                    comentarioAnticipo = vm.ComentarioAnticipoB;
                }
                if (vm.AsignadoC == true)
                {
                    //VALIDAR TIPO DE MONEDA MXN
                    if (vm.TipoMonedaC == "MXN")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioC <= 10000) nivelaprobacion = 9;
                        if (vm.PrecioC > 10000 && vm.PrecioC <= 50000) nivelaprobacion = 10;
                        if (vm.PrecioC > 50000 && vm.PrecioC <= 100000) nivelaprobacion = 11;
                        if (vm.PrecioC > 100000) nivelaprobacion = 12;
                        infomonedacorreo = "MXN";
                    }

                    //VALIDAR TIPO DE MONEDA USD
                    if (vm.TipoMonedaC == "USD")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioC <= 480) nivelaprobacion = 9;
                        if (vm.PrecioC > 480 && vm.PrecioC <= 2380) nivelaprobacion = 10;
                        if (vm.PrecioC > 2380 && vm.PrecioC <= 4760) nivelaprobacion = 11;
                        if (vm.PrecioC > 4760) nivelaprobacion = 12;
                        infomonedacorreo = "USD";
                    }

                    var dataProveedor = _db.proveedores.Where(x => x.Id == vm.idProveedorGnrlB).FirstOrDefault();
                    infoprovcorreo = dataProveedor.Nombre;
                    infosubtotalcorreo = vm.PrecioC.ToString();
                    infoivacorreo = vm.IvaC.ToString();
                    infotiempoentregacorreo = vm.TiempoEntregaC;
                    infocreditocorreo = vm.PermiteCreditoC ? "SI" : "NO";
                    infotiempocredcorreo = vm.TiempoCreditoC.ToString();
                    anticipoProveedor = vm.PorcentajeAnticipoC.ToString();
                    comentarioAnticipo = vm.ComentarioAnticipoC;

                }

                #endregion

                //SE ACTUALIZA EL ESTADO DE SOLICITUD DEPENDIENDO EL NIVEL DE APROBACIÓN 
                solicitud = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == vm.Folio);

                var apruebadirectivo = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
                var linkaprobacion = "";
                var linkrechazo = "";
                var botoncorreoaprobacion = "";
                var botoncorreorechazo = "";

                /*VALIDACION NIVEL APROBACION A DIRECTIVOS*/
                if (apruebadirectivo != null)
                {
                    linkaprobacion = "https://appext2.pentafon.com/Pentafinances/Compras/AvisoAprobacionRechazoDirectivos?folio=" + vm.Folio.ToString() + "&aprobacion=1";
                    linkrechazo = "https://appext2.pentafon.com/Pentafinances/Compras/AvisoAprobacionRechazoDirectivos?folio=" + vm.Folio.ToString() + "&aprobacion=2";
                    botoncorreoaprobacion = "<a href='" + linkaprobacion + "' target='_blank'><div><h4>Aprobar Solicitud</h4></div></a>";
                    botoncorreorechazo = "<a href='" + linkrechazo + "' target='_blank'><div><h4>Rechazar Solicitud</h4></div></a>";

                    var ctrlvalidaciones = new CtrlValidacionesDireccion();

                    ctrlvalidaciones.Folio = solicitud.Folio;
                    ctrlvalidaciones.ValidaGerencia = false;
                    ctrlvalidaciones.ValidaDirFinanzas = false;
                    ctrlvalidaciones.ValidaDirGeneral = false;
                    ctrlvalidaciones.ValidaPresidencia = false;
                    ctrlvalidaciones.EnvioMailGerencia = false;
                    ctrlvalidaciones.EnvioMailDirFinanzas = false;
                    ctrlvalidaciones.EnvioMailDirGeneral = false;
                    ctrlvalidaciones.EnvioMailPresidencia = false;
                    ctrlvalidaciones.EstadoSolicitudId = nivelaprobacion;
                    ctrlvalidaciones.FechaRegistro = DateTime.Now;

                    if (nivelaprobacion == 9)
                    {
                        ctrlvalidaciones.ValidaGerencia = true;
                        ctrlvalidaciones.EnvioMailGerencia = true;
                    }
                    if (nivelaprobacion == 10)
                    {
                        ctrlvalidaciones.ValidaDirFinanzas = true;
                        ctrlvalidaciones.EnvioMailDirFinanzas = true;
                    }
                    if (nivelaprobacion == 11)
                    {
                        ctrlvalidaciones.ValidaGerencia = true;
                        ctrlvalidaciones.EnvioMailGerencia = true;
                        ctrlvalidaciones.ValidaDirGeneral = true;
                        ctrlvalidaciones.EnvioMailDirGeneral = false;


                    }
                    if (nivelaprobacion == 12)
                    {
                        ctrlvalidaciones.ValidaGerencia = true;
                        ctrlvalidaciones.EnvioMailGerencia = true;
                        ctrlvalidaciones.ValidaPresidencia = true;
                        ctrlvalidaciones.EnvioMailPresidencia = false;
                    }

                    _db.CtrlValidacionesDireccion.Add(ctrlvalidaciones);
                    _db.SaveChanges();

                }
                /*VALIDACION NIVEL APROBACION A DIRECTIVOS*/

                var actualizaestado = new SeguimientoSolicitudesDetalles()
                {
                    Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = solicitud.DetalledeSolicitud,
                    Unidad = solicitud.Unidad,
                    Marca = solicitud.Marca,
                    Modelo = solicitud.Modelo,
                    ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                    //EstadoSolicitudId = 5,
                    EstadoSolicitudId = nivelaprobacion,
                    MotivoRechazo = solicitud.MotivoRechazo,
                    Observaciones = solicitud.Observaciones,
                    Estatus = solicitud.Estatus,
                    FechaRegistro = solicitud.FechaRegistro,
                    UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    //Actualización Campo Caja Chica
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                    BeneficioCualitativo = solicitud.BeneficioCualitativo,
                    RetornoInversion = solicitud.RetornoInversion,
                    Recurrente = solicitud.Recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura
                };

                _db.SeguimientoSolicitudesDetalles.AddOrUpdate(actualizaestado);
                _db.SaveChanges();

                //FIN DE ACTUALIZACIÓN ESTADO DE SOLICITUD

                try
                {
                    #region CORREOS ACTIVOS
                    var cc = new List<string> { };
                    if (solicitud.Solicitante == "ORSON MONTERO")
                        cc.Add("agutierrez@pentafon.com");
                    #endregion

                    //CORREOS DE APROBACION 
                    string strmsjToApprove = "";
                    string strmsj = "";

                    if (vm.Actualizar != 1)
                    {
                        strmsj = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA APROBACIÓN<br/><br/>" +
                                                          "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                          "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                          "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                          "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                          "<b>MARCA: </b>" + solicitud.Marca + "<br/>" + "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                               "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +

                                                          "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                          "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                          "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                          "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                          "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                          "<b>ANTICIPO : </b>" + anticipoProveedor + "%<br/>" +
                                                          "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                          "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                          "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>"
                                                          );


                        strmsjToApprove = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA APROBACIÓN<br/><br/>" +
                                                          "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                          "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                          "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                          "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                          "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                          "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                               "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                          "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                          "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                          "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                          "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                          "<b>ANTICIPO : </b>" + anticipoProveedor + "%<br/>" +
                                                          "<b>COMENTARIO : </b>" + comentarioAnticipo + "%<br/>" +
                                                          "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                          "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                          "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>" +
                                                          "<table style='width: 100%;'><tr><td style='width: 33%;'>" + botoncorreoaprobacion + "</td><td style='width: 33%;'>" + botoncorreorechazo + "</td></tr></table>");

                    }
                    else
                    {
                        strmsjToApprove = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE ACTUALIZADA<br/><br/>" +
                                                          "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                          "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                          "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                          "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                          "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                          "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                               "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +

                                                          "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                          "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                          "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                          "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                          "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                          "<b>ANTICIPO : </b>" + anticipoProveedor + "<br/>" +
                                                          "<b>COMENTARIO : </b>" + comentarioAnticipo + "%<br/>" +
                                                          "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                          "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                          "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>" +
                                                          "<table style='width: 100%;'><tr><td style='width: 33%;'>" + botoncorreoaprobacion + "</td><td style='width: 33%;'>" + botoncorreorechazo + "</td></tr></table>");
                    }

                    var correodirector = "";
                    var infosolicitante = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
                    if (infosolicitante != null)
                    {
                        var infodirector = _db.CatalogoDirectores.Where(a => a.Id == infosolicitante.DirectorId).FirstOrDefault();
                        if (infodirector != null)
                        {
                            correodirector = infodirector.Correo;
                            if (infosolicitante.DirectorId != 27)
                            {
                                cc.Add(correodirector);
                            }
                        }
                    }

                    if (nivelaprobacion == 9)//MANUEL GONZALEZ
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(vm.Folio, "1");
                        }
                        else
                        {
                            if (vm.Actualizar != 1)
                            {
                                _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsj,
                                "cuentasporpagar@pentafon.com", cc);

                                //MENSAJE CON LINK DE APROBACION / RECHAZO
                                _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                    , strmsjToApprove
                                    , correoadmincompras);
                            }
                            else
                            {
                                _messenger.SendMailToApprove("COMPRAS", "LOS DATOS DEL PROVEEDOR FUERON ACTUALIZADOS"
                                    , strmsjToApprove
                                    , correoadmincompras);
                            }

                        }
                    }

                    if (nivelaprobacion == 10)//RRESENDIZ/JSANTOVENA
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(vm.Folio, "1");
                        }
                        else
                        {

                            if (vm.Actualizar != 1)
                            {
                                _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                    , strmsj
                                    , correoadmincompras, cc);

                                //MENSAJE CON LINK DE APROBACION/RECHAZO 
                                _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsjToApprove
                                , correodirfinanzas);
                            }
                            else
                            {
                                _messenger.SendMailToApprove("COMPRAS", "ACTUALIZACION DATOS DEL PROVEEDOR"
                                , strmsjToApprove
                                , correodirfinanzas);
                            }
                        }
                    }

                    if (nivelaprobacion == 11)//FMONDRAGON
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(vm.Folio, "1");
                        }
                        else
                        {
                            if (vm.Actualizar != 1)
                            {
                                _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                    , strmsj
                                    , "jgarcia@pentafon.com", cc);


                                //MENSAJE CON LINK DE APROBACION/RECHAZO 

                                _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsjToApprove
                                , correodirgral);
                            }
                            else
                            {
                                _messenger.SendMailToApprove("COMPRAS", "ACTUALIZACION DATOS DEL PROVEEDOR"
                               , strmsjToApprove
                               , correodirgral);
                            }
                        }
                    }

                    if (nivelaprobacion == 12)//AFAJER
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(vm.Folio, "1");
                        }
                        else
                        {
                            if (vm.Actualizar != 1)
                            {
                                _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                    , strmsj
                                    , "jgarcia@pentafon.com", cc);


                                //MENSAJE CON LINK DE APROBACION/RECHAZO 

                                _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsjToApprove
                                , correopresidencia);
                            }
                            else
                            {
                                _messenger.SendMailToApprove("COMPRAS", "ACTUALIZACION DATOS DEL PROVEEDOR"
                               , strmsjToApprove
                               , correopresidencia);
                            }
                        }
                    }

                    if (nivelaprobacion == 22)//DIRECTOR DE ÁREA
                    {
                        if (infosolicitante != null)
                        {
                            var infodirector = _db.CatalogoDirectores.Where(a => a.Id == infosolicitante.DirectorId).FirstOrDefault();
                            if (infodirector != null)
                            {
                                correodirector = infodirector.Correo;
                            }
                            else
                            {
                                correodirector = correoadmincompras;
                            }
                        }
                        else
                        {
                            correodirector = correoadmincompras;
                        }
                        if (vm.Actualizar != 1)
                        {
                            _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO DIRECTORES"
                                , strmsj
                                , correodirector, cc);
                        }
                        else
                        {
                            _messenger.SendMail("COMPRAS", "ACTUALIZACION DATOS DEL PROVEEDOR"
                                , strmsj
                                , correodirector, cc);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PROCESO DE ASIGNACIÓN Y APROBACIÓN O RECHAZO DE UNA SOLICITUD (GERENCIA Y PRESIDENCIA)
        public string SetAsignaProveedor(AgregarProveedoresVm vm, string aprobacion, int estadoid)
        {
            var nivelaprobacion = 0;
            var fecha = DateTime.Now;

            var infoprovcorreo = "";
            var infosubtotalcorreo = "";
            var infomonedacorreo = "";
            var infoivacorreo = "";
            var infotiempoentregacorreo = "";
            var infocreditocorreo = "";
            var infotiempocredcorreo = "";
            var infoAnticipo = "";
            var infoComentarioProv = "";

            try
            {
                //DATOS PROVEEDORES
                var proveedora = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "A");

                if (proveedora != null)
                {
                    var actualizaA = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = proveedora.Id,
                        Folio = proveedora.Folio,
                        Proveedor = proveedora.Proveedor,
                        TipoProveedor = proveedora.TipoProveedor,
                        Descripcion = proveedora.Descripcion,
                        Precio = proveedora.Precio,
                        TiempoEntrega = proveedora.TiempoEntrega,
                        DocumentoCotizacion = proveedora.DocumentoCotizacion,
                        Asignado = vm.AsignadoA,
                        Observaciones = proveedora.Observaciones,
                        FechaRegistro = proveedora.FechaRegistro,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = proveedora.PermiteCredito,
                        TiempoCredito = proveedora.TiempoCredito,
                        TipoMoneda = proveedora.TipoMoneda,
                        Anticipo = proveedora.Anticipo,
                        ComentarioAnticipo = proveedora.ComentarioAnticipo,
                        Iva = proveedora.Iva,
                        IdProveedor = proveedora.IdProveedor
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.AddOrUpdate(actualizaA);
                    _db.SaveChanges();
                }

                var proveedorb = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "B");

                if (proveedorb != null)
                {
                    var actualizaB = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = proveedorb.Id,
                        Folio = proveedorb.Folio,
                        Proveedor = proveedorb.Proveedor,
                        TipoProveedor = proveedorb.TipoProveedor,
                        Descripcion = proveedorb.Descripcion,
                        Precio = proveedorb.Precio,
                        TiempoEntrega = proveedorb.TiempoEntrega,
                        DocumentoCotizacion = proveedorb.DocumentoCotizacion,
                        Asignado = vm.AsignadoB,
                        Observaciones = proveedorb.Observaciones,
                        FechaRegistro = proveedorb.FechaRegistro,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = proveedorb.PermiteCredito,
                        TiempoCredito = proveedorb.TiempoCredito,
                        TipoMoneda = proveedorb.TipoMoneda,
                        Anticipo = proveedorb.Anticipo,
                        ComentarioAnticipo = proveedorb.ComentarioAnticipo,
                        Iva = proveedorb.Iva,
                        IdProveedor = proveedorb.IdProveedor
                    };
                    _db.ProveedoresAgregadosSolicitudesDetalles.AddOrUpdate(actualizaB);
                    _db.SaveChanges();
                }

                var proveedorc = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "C");

                if (proveedorc != null)
                {
                    var actualizaC = new ProveedoresAgregadosSolicitudesDetalles()
                    {
                        Id = proveedorc.Id,
                        Folio = proveedorc.Folio,
                        Proveedor = proveedorc.Proveedor,
                        TipoProveedor = proveedorc.TipoProveedor,
                        Descripcion = proveedorc.Descripcion,
                        Precio = proveedorc.Precio,
                        TiempoEntrega = proveedorc.TiempoEntrega,
                        DocumentoCotizacion = proveedorc.DocumentoCotizacion,
                        Asignado = vm.AsignadoC,
                        Observaciones = proveedorc.Observaciones,
                        FechaRegistro = proveedorc.FechaRegistro,
                        UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                        FechaUltimaActualizacion = fecha,
                        PermiteCredito = proveedorc.PermiteCredito,
                        TiempoCredito = proveedorc.TiempoCredito,
                        TipoMoneda = proveedorc.TipoMoneda,
                        Anticipo = proveedorc.Anticipo,
                        ComentarioAnticipo = proveedorc.ComentarioAnticipo,
                        Iva = proveedorc.Iva,
                        IdProveedor = proveedorc.IdProveedor
                    };

                    _db.ProveedoresAgregadosSolicitudesDetalles.AddOrUpdate(actualizaC);
                    _db.SaveChanges();
                }

                //************************************
                //ACTUALIZAR ESTADO DE SOLICITUD A APROBADO o RECHAZADO DEPENDIENDO EL NIVEL DE APROBACIÓN
                var solicitud = _db.SeguimientoSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio);

                var campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == solicitud.CampanaId);

                //if (solicitud != null && solicitud.EstadoSolicitudId < 5)
                //{
                var actualizaestado = new SeguimientoSolicitudesDetalles()
                {
                    Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = solicitud.DetalledeSolicitud,
                    Unidad = solicitud.Unidad,
                    Marca = solicitud.Marca,
                    Modelo = solicitud.Modelo,
                    ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                    //EstadoSolicitudId = 5,
                    EstadoSolicitudId = estadoid,
                    MotivoRechazo = solicitud.MotivoRechazo,
                    Observaciones = solicitud.Observaciones,
                    Estatus = solicitud.Estatus,
                    FechaRegistro = solicitud.FechaRegistro,
                    UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                    BeneficioCualitativo = solicitud.BeneficioCualitativo,
                    RetornoInversion = solicitud.RetornoInversion,
                    Recurrente = solicitud.Recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura
                };

                _db.SeguimientoSolicitudesDetalles.AddOrUpdate(actualizaestado);
                _db.SaveChanges();
                //************************************

                //SE MANDA CORREO DE APROBACIÓN O RECHAZO DE SOLICITUD
                //SEND NOTIFICATION

                try
                {
                    var proveedor =
                        _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(
                            a => a.Folio == vm.Folio && a.Asignado == true);

                    if (proveedor != null)
                    {
                        infoprovcorreo = proveedor.Proveedor;
                        infosubtotalcorreo = proveedor.Precio.ToString();
                        infoivacorreo = proveedor.Iva.ToString();
                        infotiempoentregacorreo = proveedor.TiempoEntrega;
                        infocreditocorreo = proveedor.PermiteCredito == true ? "SI" : "NO";
                        infotiempocredcorreo = proveedor.TiempoCredito.ToString();
                        infoAnticipo = proveedor.Anticipo.ToString();
                        infoComentarioProv = proveedor.ComentarioAnticipo;
                    }

                    var cc = new List<string> { solicitud.EmailSolicitante, "jgarcia@pentafon.com" };



                    //MAIL APROBADA
                    string strmsjap = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE APROBADA<br/><br/>" +
                                                  "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                  "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                  "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                  "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                  "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                  "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                   "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                                   "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
                                                   "<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                  "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                  "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                  "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                  "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                  "<b>ANTICIPO : </b>" + infoAnticipo + "%<br/>" +
                                                  "<b>COMENTARIO : </b>" + infoComentarioProv + "%<br/>" +
                                                  "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                  "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                  "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>");

                    //MAIL RECHAZADA
                    string strmsjre = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE RECHAZADA<br/><br/>" +
                                                    "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                    "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                    "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                    "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                    "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                    "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                    "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                    "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                    "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                    "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                    "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                    "<b>ANTICIPO : </b>" + infoAnticipo + "%<br/>" +
                                                  "<b>COMENTARIO : </b>" + infoComentarioProv + "%<br/>" +
                                                    "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                    "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                    "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>" +
                                                    "<b>MOTIVO DE RECHAZO: </b>" + vm.MotivoRechazo + "<br/>");
                    //APROBADA
                    if (aprobacion == "1")
                    {
                        if (solicitud.EmailSolicitante == "pferrer@pentafon.com")
                        {

                            cc.Add("acarbajal@pentafon.com");
                        }

                        if (solicitud.EmailSolicitante == "dfuentes@pentafon.com" || solicitud.EmailSolicitante == "nsantos@pentafon.com")
                        {
                            cc.Add("pferrer@pentafon.com");
                        }

                        if (estadoid == 15)
                        {
                            cc.Add("afajer@neikos.com.mx");
                        }
                        if (estadoid == 16)
                        {
                            cc.Add("fmondragon@pentafon.com");
                        }

                        _messenger.SendMail("COMPRAS", "SOLICITUD APROBADA "
                            , strmsjap
                            , correoadmincompras, cc);
                    }
                    //RECHAZADA
                    else
                    {
                        _messenger.SendMail("COMPRAS", "SOLICITUD RECHAZADA "
                            , strmsjre
                            , correoadmincompras, cc);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PROCESO DE CANCELACIÓN DE UN FOLIO O SOLICITUD
        public string SetCancelaFolio(SeguimientoSolicitudesDetalles solicitud)
        {
            var fecha = DateTime.Now;

            try
            {
                //CANCELACIÓN DE FOLIO EN TABLA COMPRAS
                var seguimiento = new SeguimientoSolicitudesDetalles()
                {
                    Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = solicitud.DetalledeSolicitud,
                    Unidad = solicitud.Unidad,
                    Marca = solicitud.Marca,
                    Modelo = solicitud.Modelo,
                    ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                    EstadoSolicitudId = 21,
                    MotivoRechazo = solicitud.MotivoRechazo,
                    Observaciones = solicitud.Observaciones,
                    FechaRegistro = solicitud.FechaRegistro,
                    Estatus = false,
                    //Datos De Usuario
                    UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                    BeneficioCualitativo = solicitud.BeneficioCualitativo,
                    RetornoInversion = solicitud.RetornoInversion,
                    Recurrente = solicitud.Recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura
                };

                _db.SeguimientoSolicitudesDetalles.AddOrUpdate(seguimiento);
                _db.SaveChanges();

                //CANCELACIÓN DE FOLIO EN TABLA SOLICITUDES
                var registro = new SolicitudesDetalles()
                {
                    Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = solicitud.DetalledeSolicitud,
                    Unidad = solicitud.Unidad,
                    Marca = solicitud.Marca,
                    Modelo = solicitud.Modelo,
                    ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                    Observaciones = solicitud.Observaciones,
                    FechaRegistro = solicitud.FechaRegistro,
                    Estatus = false,
                    //Datos De Usuario
                    UsuarioUltimaActualizacion = solicitud.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                    BeneficioCualitativo = solicitud.BeneficioCualitativo,
                    RetornoInversion = solicitud.RetornoInversion,
                    Recurrente = solicitud.Recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura
                };

                _db.SolicitudesDetalles.AddOrUpdate(registro);
                _db.SaveChanges();

                //SE MANDA CORREO DE APROBACIÓN O RECHAZO DE SOLICITUD
                //SEND NOTIFICATION

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

                try
                {
                    //var campana = 
                    var cc = new List<string> { seguimiento.EmailSolicitante };
                    //cc.Add("erivera@neikos.com.mx");
                    //cc.Add("mgonzalez@pentafon.com");
                    //cc.Add("rpadilla@pentafon.com");
                    #region CORREOS ACTIVOS
                    cc.Add("cuentasporpagar@pentafon.com");
                    cc.Add("jgarcia@pentafon.com");
                    cc.Add("igomiciaga@neikos.com.mx");
                    #endregion
                    //cc.Add("fake.machine.92@gmail.com");

                    string strmsj = string.Format("SE HA CANCELADO UNA SOLICITUD DE COMPRA CON FOLIO " + seguimiento.Folio + "<br/><br/>" +
                                                  "<b>SOLICITANTE: </b>" + seguimiento.Solicitante + "<br/>" +
                                                  "<b>CAMPAÑA: </b>" + campana + "<br/>" +
                                                  "<b>DEPARTAMENTO: </b>" + depto + "<br/><br/>" +
                                                  "<b>DETALLE DE LA SOLICITUD: </b>" + seguimiento.DetalledeSolicitud + ".<br/><br/>" +
                                                  "<b>UNIDAD: </b>" + seguimiento.Unidad + "<br/>" +
                                                  "<b>MARCA: </b>" + seguimiento.Marca + "<br/>" +
                                                  "<b>MODELO: </b>" + seguimiento.Modelo + "<br/><br/>" +
                                                  "<b>PROVEEDOR SUGERIDO : </b>" + seguimiento.NombreProveedorSugerido + "<br/><br/>" +
                                                  "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + seguimiento.Observaciones + "<br/>" +
                                                  "<b>MOTIVO DE RECHAZO : </b>" + seguimiento.MotivoRechazo + "<br/>");
                    _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA CANCELADA"
                        , strmsj, correoadmincompras, cc);
                }
                catch (Exception e)
                {
                    var error = "Error";
                }


                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PROCESO DE CANCELACIÓN DE UN FOLIO O SOLICITUD
        public string SetFinalizaFolio(string folio, string usuario)
        {
            var folioint = Int32.Parse(folio);
            var fecha = DateTime.Now;

            try
            {
                //FINALIZACIÓN DE FOLIO EN TABLA COMPRAS
                var datosfolio = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folioint);

                if (datosfolio != null)
                {
                    var compra = new SeguimientoSolicitudesDetalles()
                    {
                        Folio = datosfolio.Folio,
                        Solicitante = datosfolio.Solicitante,
                        EmailSolicitante = datosfolio.EmailSolicitante,
                        CampanaId = datosfolio.CampanaId,
                        DepartamentoId = datosfolio.DepartamentoId,
                        UsuarioFinal = datosfolio.UsuarioFinal,
                        EmailUsuarioFinal = datosfolio.EmailUsuarioFinal,
                        DetalledeSolicitud = datosfolio.DetalledeSolicitud,
                        Unidad = datosfolio.Unidad,
                        Marca = datosfolio.Marca,
                        Modelo = datosfolio.Modelo,
                        ObjetivodeSolicitud = datosfolio.ObjetivodeSolicitud,
                        PosibleProveedor = datosfolio.PosibleProveedor,
                        NombreProveedorSugerido = datosfolio.NombreProveedorSugerido,
                        EstadoSolicitudId = 7,
                        MotivoRechazo = datosfolio.MotivoRechazo,
                        Observaciones = datosfolio.Observaciones,
                        FechaRegistro = datosfolio.FechaRegistro,
                        Estatus = false,
                        //Datos De Usuario
                        UsuarioUltimaActualizacion = usuario,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = datosfolio.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = datosfolio.BeneficioCuantitativo,
                        BeneficioCualitativo = datosfolio.BeneficioCualitativo,
                        RetornoInversion = datosfolio.RetornoInversion,
                        Recurrente = datosfolio.Recurrente,
                        TipoSolicitud = datosfolio.TipoSolicitud,
                        CostoTotalFactura = datosfolio.CostoTotalFactura,
                        TipoMonedaFactura = datosfolio.TipoMonedaFactura,
                        NoFactura = datosfolio.NoFactura
                    };

                    _db.SeguimientoSolicitudesDetalles.AddOrUpdate(compra);
                    _db.SaveChanges();

                    //FINALIZACIÓN DE FOLIO EN TABLA SOLICITUDES
                    var registro = new SolicitudesDetalles()
                    {
                        Folio = datosfolio.Folio,
                        Solicitante = datosfolio.Solicitante,
                        EmailSolicitante = datosfolio.EmailSolicitante,
                        CampanaId = datosfolio.CampanaId,
                        DepartamentoId = datosfolio.DepartamentoId,
                        UsuarioFinal = datosfolio.UsuarioFinal,
                        EmailUsuarioFinal = datosfolio.EmailUsuarioFinal,
                        DetalledeSolicitud = datosfolio.DetalledeSolicitud,
                        Unidad = datosfolio.Unidad,
                        Marca = datosfolio.Marca,
                        Modelo = datosfolio.Modelo,
                        ObjetivodeSolicitud = datosfolio.ObjetivodeSolicitud,
                        Impacto = datosfolio.Impacto,
                        PosibleProveedor = datosfolio.PosibleProveedor,
                        NombreProveedorSugerido = datosfolio.NombreProveedorSugerido,
                        Observaciones = datosfolio.Observaciones,
                        FechaRegistro = datosfolio.FechaRegistro,
                        Estatus = false,
                        //Datos De Usuario
                        UsuarioUltimaActualizacion = usuario,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = datosfolio.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = datosfolio.BeneficioCuantitativo,
                        BeneficioCualitativo = datosfolio.BeneficioCualitativo,
                        RetornoInversion = datosfolio.RetornoInversion,
                        Recurrente = datosfolio.Recurrente,
                        TipoSolicitud = datosfolio.TipoSolicitud,
                        CostoTotalFactura = datosfolio.CostoTotalFactura,
                        TipoMonedaFactura = datosfolio.TipoMonedaFactura,
                        NoFactura = datosfolio.NoFactura
                    };

                    _db.SolicitudesDetalles.AddOrUpdate(registro);
                    _db.SaveChanges();
                }



                try
                {
                    var campana = "";
                    var infocampana = _db.CatalogoCampanas.Find(datosfolio.CampanaId);
                    if (infocampana != null)
                    {
                        campana = infocampana.Campana;
                    }

                    var depto = "";
                    var infodepto = _db.CatalogoDepartamentos.Find(datosfolio.DepartamentoId);
                    if (infodepto != null)
                    {
                        depto = infodepto.Departamento;
                    }
                    //var campana = 
                    var cc = new List<string> { datosfolio.EmailSolicitante };
                    //cc.Add("erivera@neikos.com.mx");
                    //cc.Add("mgonzalez@pentafon.com");
                    //cc.Add("rpadilla@pentafon.com");
                    #region CORREOS ACTIVOS 
                    cc.Add("cuentasporpagar@pentafon.com");
                    cc.Add("jgarcia@pentafon.com");
                    cc.Add("igomiciaga@neikos.com.mx");
                    #endregion 
                    //cc.Add("fake.machine.92@gmail.com");
                    string strmsj = string.Format("SE HA FINALIZADO LA SOLICITUD DE COMPRA CON FOLIO " + datosfolio.Folio + "<br/><br/>" +
                                                  "<b>SOLICITANTE: </b>" + datosfolio.Solicitante + "<br/>" +
                                                  "<b>TIPO SOLICITUD: </b>" + datosfolio.TipoSolicitud + "<br/>" +
                                                  "<b>CAMPAÑA: </b>" + campana + "<br/>" +
                                                  "<b>DEPARTAMENTO: </b>" + depto + "<br/><br/>" +
                                                  "<b>DETALLE DE LA SOLICITUD: </b>" + datosfolio.DetalledeSolicitud + ".<br/><br/>" +
                                                  "<b>UNIDAD: </b>" + datosfolio.Unidad + "<br/>" +
                                                  "<b>MARCA: </b>" + datosfolio.Marca + "<br/>" +
                                                  "<b>MODELO: </b>" + datosfolio.Modelo + "<br/><br/>" +
                                                  "<b>PROVEEDOR SUGERIDO : </b>" + datosfolio.NombreProveedorSugerido + "<br/><br/>" +
                                                  "<b>NO. FACTURA: </b>" + datosfolio.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + datosfolio.CostoTotalFactura + " " + datosfolio.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + datosfolio.Observaciones + "<br/>");
                    _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA FINALIZADA"
                        , strmsj, correoadmincompras, cc);
                }
                catch (Exception e)
                {
                    var error = "Error";
                }


                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GUARDAR DETALLES DE PAGO DE SOLICITUD DE COMPRA
        public string SetPagosCompras(FormaPagoVm compra)
        {
            var fecha = DateTime.Now;

            var infoprovcorreo = "";
            var infosubtotalcorreo = "";
            var infomonedacorreo = "";
            var infoivacorreo = "";
            var infotiempoentregacorreo = "";
            var infocreditocorreo = "";
            var infotiempocredcorreo = "";



            try
            {
                //ACTUALIZAR ESTADO DE SOLICITUD A 6 (FORMA DE PAGO AGREGADA)
                var solicitud = _db.SeguimientoSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == compra.Folio);

                var campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == solicitud.CampanaId);

                if (solicitud != null && solicitud.Estatus)
                {
                    var actualizaestado = new SeguimientoSolicitudesDetalles()
                    {
                        Folio = solicitud.Folio,
                        Solicitante = solicitud.Solicitante,
                        EmailSolicitante = solicitud.EmailSolicitante,
                        CampanaId = solicitud.CampanaId,
                        DepartamentoId = solicitud.DepartamentoId,
                        UsuarioFinal = solicitud.UsuarioFinal,
                        EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                        DetalledeSolicitud = solicitud.DetalledeSolicitud,
                        Unidad = solicitud.Unidad,
                        Marca = solicitud.Marca,
                        Modelo = solicitud.Modelo,
                        ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                        Impacto = solicitud.Impacto,
                        PosibleProveedor = solicitud.PosibleProveedor,
                        NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                        EstadoSolicitudId = 6,
                        MotivoRechazo = solicitud.MotivoRechazo,
                        Observaciones = solicitud.Observaciones,
                        Estatus = solicitud.Estatus,
                        FechaRegistro = solicitud.FechaRegistro,
                        UsuarioUltimaActualizacion = compra.UsuarioUltimaActualizacionFp,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = solicitud.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                        BeneficioCualitativo = solicitud.BeneficioCualitativo,
                        RetornoInversion = solicitud.RetornoInversion,
                        Recurrente = solicitud.Recurrente,
                        TipoSolicitud = solicitud.TipoSolicitud,
                        CostoTotalFactura = solicitud.CostoTotalFactura,
                        TipoMonedaFactura = solicitud.TipoMonedaFactura,
                        NoFactura = solicitud.NoFactura

                    };

                    _db.SeguimientoSolicitudesDetalles.AddOrUpdate(actualizaestado);
                    _db.SaveChanges();
                }

                //Asigna Proveedor
                var pago = _db.PagosComprasDetalles
                    .FirstOrDefault(a => a.Folio == compra.Folio);

                if (pago != null)
                {
                    var fpago = new PagosComprasDetalles()
                    {
                        Folio = pago.Folio,
                        ProveedorAsignadoId = compra.ProveedorAsignadoId,
                        FormaPagoId = (int)compra.FormaPagoId,
                        RazonSocial = compra.RazonSocial,
                        Credito = (bool)compra.Credito,
                        Tiempo = compra.Tiempo,
                        BancoId = (int)compra.BancoId,
                        //BancoId = (int) compra.BancoId,
                        Cuenta = compra.Cuenta,
                        Clabe = compra.Clabe,
                        FolioFactura = compra.FolioFactura,
                        NumRecibo = compra.NumRecibo,
                        //Observaciones = compra.Observaciones,
                        Estatus = pago.Estatus,
                        FechaRegistro = pago.FechaRegistro,
                        UsuarioUltimaActualizacion = compra.UsuarioUltimaActualizacionFp,
                        FechaUltimaActualizacion = fecha
                    };

                    _db.PagosComprasDetalles.AddOrUpdate(fpago);
                    _db.SaveChanges();
                }
                else
                {
                    bool credito = compra.Credito != null;

                    var fpago = new PagosComprasDetalles()
                    {
                        Folio = compra.Folio,
                        ProveedorAsignadoId = compra.ProveedorAsignadoId,
                        FormaPagoId = (int)compra.FormaPagoId,
                        RazonSocial = compra.RazonSocial,
                        Credito = credito,
                        Tiempo = compra.Tiempo,
                        BancoId = (int)compra.BancoId,
                        //BancoId = (int)compra.BancoId,
                        Cuenta = compra.Cuenta,
                        Clabe = compra.Clabe,
                        FolioFactura = compra.FolioFactura,
                        NumRecibo = compra.NumRecibo,
                        //Observaciones = compra.Observaciones,
                        Estatus = true,
                        FechaRegistro = fecha,
                        UsuarioUltimaActualizacion = compra.UsuarioUltimaActualizacionFp,
                        FechaUltimaActualizacion = fecha
                    };

                    _db.PagosComprasDetalles.Add(fpago);
                    _db.SaveChanges();
                }


                var formapago = "";
                var infoforma = _db.CatalogoFormasPago.Find(compra.FormaPagoId);
                if (infoforma != null)
                {
                    formapago = infoforma.FormaPago;
                }

                var banco = "";
                var infobanco = _db.CatalogoBancos.Find(compra.BancoId);
                if (infobanco != null)
                {
                    banco = infobanco.Banco;
                }

                try
                {
                    var proveedor =
                        _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(
                            a => a.Folio == compra.Folio && a.Asignado == true);

                    if (proveedor != null)
                    {
                        infoprovcorreo = proveedor.Proveedor;
                        infosubtotalcorreo = proveedor.Precio.ToString();
                        infoivacorreo = proveedor.Iva.ToString();
                        infotiempoentregacorreo = proveedor.TiempoEntrega;
                        infocreditocorreo = proveedor.PermiteCredito == true ? "SI" : "NO";
                        infotiempocredcorreo = proveedor.TiempoCredito.ToString();
                    }

                    var permite = compra.PermiteCredito == true ? "SI" : "NO";

                    var cc = new List<string> { correoadmincompras };
                    //cc.Add("erivera@neikos.com.mx");
                    //cc.Add("mgonzalez@pentafon.com");
                    //cc.Add("rpadilla@pentafon.com");
                    #region CORREOS ACTIVOS
                    cc.Add("cuentasporpagar@pentafon.com");
                    cc.Add("jgarcia@pentafon.com");
                    cc.Add("igomiciaga@neikos.com.mx");
                    #endregion
                    //cc.Add("fake.machine.92@gmail.com");
                    //MAIL FORMA DE PAGO
                    string strmsj = string.Format("SE AGREGO FORMA DE PAGO A LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + "<br/><br/>" +
                                                    "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                    "<b>TIPO SOLICITUD: </b>" + solicitud.TipoSolicitud + "<br/><br/>" +
                                                    "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                    "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                    "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                    "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                    "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                     "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                    "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                    "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                    "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                    "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                    "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                    "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                    "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/><br/>" +
                                                    "<b>DATOS DE PAGO</b>" + "<br/><br/>" +
                                                    "<b>FORMA DE PAGO</b>" + formapago + "<br/>" +
                                                    "<b>RAZON SOCIAL</b>" + compra.RazonSocial + "<br/>" +
                                                    "<b>CREDITO</b>" + permite + "<br/>" +
                                                    "<b>TIEMPO CREDITO</b>" + compra.TiempoCredito + "<br/>" +
                                                    "<b>BANCO</b>" + banco + "<br/>" +
                                                    "<b>CUENTA</b>" + compra.Cuenta + "<br/>" +
                                                    "<b>CLABE</b>" + compra.Clabe + "<br/>" +
                                                    "<b>NO. FOLIO FACTURA</b>" + compra.NumRecibo + "<br/>");

                    _messenger.SendMail("COMPRAS", "FORMA DE PAGO AGREGADA"
                               , strmsj
                               , correoadmincompras, cc);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //CLASS============================================================================================================================
        //CODE BRINGED BY THE GLORY ULTRAMARINES CHAPTER
        //CODING BY: CAPTAIN DANIEL FUENTES DFR
        //PROJECT PENTA FINANCES
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class DocsManager
        {
            private readonly PentaFinComprasContext _db = new PentaFinComprasContext();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            public void SetCotizacion(int folio, string tipo, string cotizacion)
            {
                var datos =
                    _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(
                        a => a.Folio == folio && a.TipoProveedor == tipo);

                if (datos != null)
                {
                    using (var con = new PentaFinComprasContext())
                    {
                        con.ProveedoresAgregadosSolicitudesDetalles.Attach(datos);
                        datos.DocumentoCotizacion = cotizacion;
                        con.SaveChanges();
                    }

                }
            }
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            public void SetFormaPago(int folio, string cotizacion)
            {
                var datos = _db.PagosComprasDetalles.Find(folio);

                if (datos != null)
                {
                    using (var con = new PentaFinComprasContext())
                    {
                        con.PagosComprasDetalles.Attach(datos);
                        datos.FolioFactura = cotizacion;
                        con.SaveChanges();
                    }

                }
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            public string GetCotizacion(int folio, string tipo)
            {
                string fname = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\ProveedoresDocs\\";

                var datos = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == tipo);

                if (datos != null)
                {
                    return fname + datos.DocumentoCotizacion;
                }
                return "";
            }
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            public string GetFormaPago(int folio)
            {
                var obj = _db.FilesPagosCompras.Where(x => x.id == folio && x.estatus == true).FirstOrDefault();


                string fname = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\FacturasDocs\\";
                fname = fname + obj.nameFile;
                return fname;
                var datos = _db.PagosComprasDetalles.Find(folio);

                if (datos != null)
                {
                    return fname + datos.FolioFactura;
                }
                return "";
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        //GUARDAR APROBACIÓN DE SOLICITUD POR PARTE DE LOS DIRECTORES
        public string SetAprobacionDirectores(int folio)
        {
            var vm = new AgregarProveedoresVm();

            var fecha = DateTime.Now;
            var nivelaprobacion = 0;

            var infoprovcorreo = "";
            var infosubtotalcorreo = "";
            var infomonedacorreo = "";
            var infoivacorreo = "";
            var infotiempoentregacorreo = "";
            var infocreditocorreo = "";
            var infotiempocredcorreo = "";
            var anticipoP = "";
            var comentarioP = "";

            var infosolicitud = _db.SeguimientoSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == folio);
            var campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == infosolicitud.CampanaId);
            vm.Folio = infosolicitud.Folio;
            //Detalles Solicitud
            vm.Solicitante = infosolicitud.Solicitante;
            vm.EmailSolicitante = infosolicitud.EmailSolicitante;
            vm.CampanaId = infosolicitud.CampanaId;
            vm.DepartamentoId = infosolicitud.DepartamentoId;
            vm.UsuarioFinal = infosolicitud.UsuarioFinal;
            vm.EmailUsuarioFinal = infosolicitud.EmailUsuarioFinal;
            vm.DetalledeSolicitud = infosolicitud.DetalledeSolicitud;
            vm.MotivoRechazo = infosolicitud.MotivoRechazo;


            try
            {
                //DATOS PROVEEDOR A
                var proveedora = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");

                if (proveedora != null)
                {
                    bool permitecred = false;
                    int tiempocred = 0;

                    if (proveedora.PermiteCredito == null)
                    {
                        permitecred = false;
                    }
                    else
                    {
                        permitecred = Convert.ToBoolean(proveedora.PermiteCredito);
                    }

                    if (proveedora.TiempoCredito != null)
                    {
                        tiempocred = Convert.ToInt32(proveedora.TiempoCredito);
                    }

                    //Proveedor A
                    vm.IdProveedorA = proveedora.Id;
                    vm.ProveedorA = proveedora.Proveedor;
                    vm.TipoProveedorA = proveedora.TipoProveedor;
                    vm.DescripcionA = proveedora.Descripcion;
                    vm.PrecioA = proveedora.Precio;
                    vm.TiempoEntregaA = proveedora.TiempoEntrega;
                    vm.DocumentoCotizacionA = proveedora.DocumentoCotizacion;
                    vm.AsignadoA = proveedora.Asignado;
                    vm.PermiteCreditoA = permitecred;
                    vm.TiempoCreditoA = tiempocred;
                    vm.TipoMonedaA = proveedora.TipoMoneda;
                    vm.IvaA = proveedora.Iva;
                }



                //DATOS PROVEEDOR B
                var proveedorb = _db.ProveedoresAgregadosSolicitudesDetalles
                     .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "B");

                if (proveedorb != null)
                {
                    bool permitecred = false;
                    int tiempocred = 0;

                    if (proveedorb.PermiteCredito == null)
                    {
                        permitecred = false;
                    }
                    else
                    {
                        permitecred = Convert.ToBoolean(proveedorb.PermiteCredito);
                    }

                    if (proveedorb.TiempoCredito != null)
                    {
                        tiempocred = Convert.ToInt32(proveedorb.TiempoCredito);
                    }

                    //Proveedor B
                    vm.IdProveedorB = proveedorb.Id;
                    vm.ProveedorB = proveedorb.Proveedor;
                    vm.TipoProveedorB = proveedorb.TipoProveedor;
                    vm.DescripcionB = proveedorb.Descripcion;
                    vm.PrecioB = proveedorb.Precio;
                    vm.TiempoEntregaB = proveedorb.TiempoEntrega;
                    vm.DocumentoCotizacionB = proveedorb.DocumentoCotizacion;
                    vm.AsignadoB = proveedorb.Asignado;
                    vm.PermiteCreditoB = permitecred;
                    vm.TiempoCreditoB = tiempocred;
                    vm.TipoMonedaB = proveedorb.TipoMoneda;
                    vm.IvaB = proveedorb.Iva;
                }


                //DATOS PROVEEDOR C
                var proveedorc = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "C");

                if (proveedorc != null)
                {
                    bool permitecred = false;
                    int tiempocred = 0;

                    if (proveedorc.PermiteCredito == null)
                    {
                        permitecred = false;
                    }
                    else
                    {
                        permitecred = Convert.ToBoolean(proveedorc.PermiteCredito);
                    }

                    if (proveedorc.TiempoCredito != null)
                    {
                        tiempocred = Convert.ToInt32(proveedorc.TiempoCredito);
                    }

                    //Proveedor C
                    vm.IdProveedorC = proveedorc.Id;
                    vm.ProveedorC = proveedorc.Proveedor;
                    vm.TipoProveedorC = proveedorc.TipoProveedor;
                    vm.DescripcionC = proveedorc.Descripcion;
                    vm.PrecioC = proveedorc.Precio;
                    vm.TiempoEntregaC = proveedorc.TiempoEntrega;
                    vm.DocumentoCotizacionC = proveedorc.DocumentoCotizacion;
                    vm.AsignadoC = proveedorc.Asignado;
                    vm.PermiteCreditoC = permitecred;
                    vm.TiempoCreditoC = tiempocred;
                    vm.TipoMonedaC = proveedorc.TipoMoneda;
                    vm.IvaC = proveedorc.Iva;
                }

                //VALIDAR NIVEL DE APROBACIÓN
                if (vm.AsignadoA == true)
                {
                    //VALIDAR TIPO DE MONEDA MXN
                    if (vm.TipoMonedaA == "MXN")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioA <= 10000) nivelaprobacion = 9;
                        if (vm.PrecioA > 10000 && vm.PrecioA <= 50000) nivelaprobacion = 10;
                        if (vm.PrecioA > 50000 && vm.PrecioA <= 100000) nivelaprobacion = 11;
                        if (vm.PrecioA > 100000) nivelaprobacion = 12;
                        infomonedacorreo = "MXN";
                    }

                    //VALIDAR TIPO DE MONEDA USD
                    if (vm.TipoMonedaA == "USD")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioA <= 480) nivelaprobacion = 9;
                        if (vm.PrecioA > 480 && vm.PrecioA <= 2380) nivelaprobacion = 10;
                        if (vm.PrecioA > 2380 && vm.PrecioA <= 4760) nivelaprobacion = 11;
                        if (vm.PrecioA > 4760) nivelaprobacion = 12;
                        infomonedacorreo = "USD";
                    }

                    infoprovcorreo = vm.ProveedorA;
                    infosubtotalcorreo = vm.PrecioA.ToString();
                    infoivacorreo = vm.IvaA.ToString();
                    infotiempoentregacorreo = vm.TiempoEntregaA;
                    infocreditocorreo = vm.PermiteCreditoA ? "SI" : "NO";
                    infotiempocredcorreo = vm.TiempoCreditoA.ToString();
                    anticipoP = vm.AnticipoA.ToString();
                    comentarioP = vm.ComentarioAnticipoA;
                }

                if (vm.AsignadoB == true)
                {
                    //VALIDAR TIPO DE MONEDA MXN
                    if (vm.TipoMonedaB == "MXN")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioB <= 10000) nivelaprobacion = 9;
                        if (vm.PrecioB > 10000 && vm.PrecioB <= 50000) nivelaprobacion = 10;
                        if (vm.PrecioB > 50000 && vm.PrecioB <= 100000) nivelaprobacion = 11;
                        if (vm.PrecioB > 100000) nivelaprobacion = 12;
                        infomonedacorreo = "MXN";
                    }

                    //VALIDAR TIPO DE MONEDA USD
                    if (vm.TipoMonedaB == "USD")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioB <= 480) nivelaprobacion = 9;
                        if (vm.PrecioB > 480 && vm.PrecioB <= 2380) nivelaprobacion = 10;
                        if (vm.PrecioB > 2380 && vm.PrecioB <= 4760) nivelaprobacion = 11;
                        if (vm.PrecioB > 4760) nivelaprobacion = 12;
                        infomonedacorreo = "USD";
                    }


                    infoprovcorreo = vm.ProveedorB;
                    infosubtotalcorreo = vm.PrecioB.ToString();
                    infoivacorreo = vm.IvaB.ToString();
                    infotiempoentregacorreo = vm.TiempoEntregaB;
                    infocreditocorreo = vm.PermiteCreditoB ? "SI" : "NO";
                    infotiempocredcorreo = vm.TiempoCreditoB.ToString();
                    anticipoP = vm.AnticipoB.ToString();
                    comentarioP = vm.ComentarioAnticipoB;
                }

                if (vm.AsignadoC == true)
                {
                    //VALIDAR TIPO DE MONEDA MXN
                    if (vm.TipoMonedaC == "MXN")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioC <= 10000) nivelaprobacion = 9;
                        if (vm.PrecioC > 10000 && vm.PrecioC <= 50000) nivelaprobacion = 10;
                        if (vm.PrecioC > 50000 && vm.PrecioC <= 100000) nivelaprobacion = 11;
                        if (vm.PrecioC > 100000) nivelaprobacion = 12;
                        infomonedacorreo = "MXN";
                    }

                    //VALIDAR TIPO DE MONEDA USD
                    if (vm.TipoMonedaC == "USD")
                    {
                        //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                        if (vm.PrecioC <= 480) nivelaprobacion = 9;
                        if (vm.PrecioC > 480 && vm.PrecioC <= 2380) nivelaprobacion = 10;
                        if (vm.PrecioC > 2380 && vm.PrecioC <= 4760) nivelaprobacion = 11;
                        if (vm.PrecioC > 4760) nivelaprobacion = 12;
                        infomonedacorreo = "USD";
                    }

                    infoprovcorreo = vm.ProveedorC;
                    infosubtotalcorreo = vm.PrecioC.ToString();
                    infoivacorreo = vm.IvaC.ToString();
                    infotiempoentregacorreo = vm.TiempoEntregaC;
                    infocreditocorreo = vm.PermiteCreditoC ? "SI" : "NO";
                    infotiempocredcorreo = vm.TiempoCreditoC.ToString();
                    anticipoP = vm.AnticipoC.ToString();
                    comentarioP = vm.ComentarioAnticipoC;

                }


                //SE ACTUALIZA EL ESTADO DE SOLICITUD DEPENDIENDO EL NIVEL DE APROBACIÓN 
                var solicitud = _db.SeguimientoSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == folio);

                //var apruebadirectivo = _db.ApUsuarios.Where(a => a.Usuario == solicitud.Solicitante).FirstOrDefault();

                /*VALIDACION NIVEL APROBACION A DIRECTIVOS*/
                //if (apruebadirectivo != null)
                //{
                //    if (apruebadirectivo.NivelId == 1)
                //    {
                //        nivelaprobacion = 22;
                //    }
                //}
                /*VALIDACION NIVEL APROBACION A DIRECTIVOS*/

                var actualizaestado = new SeguimientoSolicitudesDetalles()
                {
                    Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = solicitud.DetalledeSolicitud,
                    Unidad = solicitud.Unidad,
                    Marca = solicitud.Marca,
                    Modelo = solicitud.Modelo,
                    ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                    //EstadoSolicitudId = 5,
                    EstadoSolicitudId = nivelaprobacion,
                    MotivoRechazo = solicitud.MotivoRechazo,
                    Observaciones = solicitud.Observaciones,
                    Estatus = solicitud.Estatus,
                    FechaRegistro = solicitud.FechaRegistro,
                    UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    //Actualización Campo Caja Chica
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                    BeneficioCualitativo = solicitud.BeneficioCualitativo,
                    RetornoInversion = solicitud.RetornoInversion,
                    Recurrente = solicitud.Recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura

                };

                _db.SeguimientoSolicitudesDetalles.AddOrUpdate(actualizaestado);
                _db.SaveChanges();

                //FIN DE ACTUALIZACIÓN ESTADO DE SOLICITUD


                var linkaprobacion = "";
                var linkrechazo = "";
                var botoncorreoaprobacion = "";
                var botoncorreorechazo = "";

                linkaprobacion = "https://appext2.pentafon.com/PentaFinances/Compras/AvisoAprobacionRechazoDirectivos?folio=" + vm.Folio.ToString() + "&aprobacion=1";
                linkrechazo = "https://appext2.pentafon.com/PentaFinances/Compras/AvisoAprobacionRechazoDirectivos?folio=" + vm.Folio.ToString() + "&aprobacion=2";
                botoncorreoaprobacion = "<a href='" + linkaprobacion + "' target='_blank'><div><h4>Aprobar Solicitud</h4></div></a>";
                botoncorreorechazo = "<a href='" + linkrechazo + "' target='_blank'><div><h4>Rechazar Solicitud</h4></div></a>";

                //SE MANDA CORREO A LAS PERSONAS CORRESPONDIENTES DEPENDIENDO EL NIVEL DE APROBACIÓN, LAS SOLICITUDES ESTARÁN EN 
                //ESTATUS DE ESPERA DE APROBACIÓN
                try
                {
                    var cc = new List<string> { correoadmincompras };

                    //AGREGAR COPIA DE APROBACIÓN
                    //cc.Add("erivera@neikos.com.mx");
                    //cc.Add("mgonzalez@pentafon.com");
                    //cc.Add("rpadilla@pentafon.com");
                    //cc.Add("igomiciaga@neikos.com.mx");
                    #region CORREOS ACTIVOS
                    cc.Add("cuentasporpagar@pentafon.com");
                    cc.Add("jgarcia@pentafon.com");
                    #endregion
                    //cc.Add("fake.machine.92@gmail.com");
                    //var contenido = "LA SOLICITUD DE COMPRA CON FOLIO: " + "<b>" + solicitud.Folio + "<b>"+"ESTA EN ESPERA APROBACIÓN";
                    string strmsj = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA APROBACIÓN<br/><br/>" +
                                               "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                               "<b>TIPO SOLICITUD: </b>" + solicitud.TipoSolicitud + "<br/><br/>" +
                                               "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                               "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                               "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                               "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                               "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                               "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                               "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                               "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                               "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                               "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                               "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                               "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                               "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>" +
                                               "<b>ANTICIPO: : </b>" + anticipoP + "<br/>" +
                                               "<b>COMENTARIO : </b>" + comentarioP + "<br/>" +
                                               "<table style='width: 100%;'><tr><td style='width: 33%;'>" + botoncorreoaprobacion + "</td><td style='width: 33%;'>" + botoncorreorechazo + "</td></tr></table>");

                    if (nivelaprobacion == 9)//MANUEL GONZALEZ
                    {
                        _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsj
                            , correoadmincompras, cc);
                    }
                    if (nivelaprobacion == 10)//RRESENDIZ/JSANTOVENA
                    {
                        _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsj
                            , correodirfinanzas, cc);
                    }
                    if (nivelaprobacion == 11)//FMONDRAGON
                    {
                        _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsj
                            , correodirgral, cc);
                    }
                    if (nivelaprobacion == 12)//AFAJER
                    {
                        _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsj
                            , correopresidencia, cc);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PROCESO DE ASIGNACIÓN Y APROBACIÓN O RECHAZO DE UNA SOLICITUD (GERENCIA Y PRESIDENCIA)
        public string SetRechazoDirectores(int folio, string aprobacion, int estadoid, string motivorechazo, int nivelrechazo)
        {
            var vm = new AgregarProveedoresVm();

            var fecha = DateTime.Now;
            var nivelaprobacion = 0;

            var infoprovcorreo = "";
            var infosubtotalcorreo = "";
            var infomonedacorreo = "";
            var infoivacorreo = "";
            var infotiempoentregacorreo = "";
            var infocreditocorreo = "";
            var infotiempocredcorreo = "";

            var infosolicitud = _db.SeguimientoSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == folio);
            var campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == infosolicitud.CampanaId);

            vm.Folio = infosolicitud.Folio;
            //Detalles Solicitud
            vm.Solicitante = infosolicitud.Solicitante;
            vm.EmailSolicitante = infosolicitud.EmailSolicitante;
            vm.CampanaId = infosolicitud.CampanaId;
            vm.DepartamentoId = infosolicitud.DepartamentoId;
            vm.UsuarioFinal = infosolicitud.UsuarioFinal;
            vm.EmailUsuarioFinal = infosolicitud.EmailUsuarioFinal;
            vm.DetalledeSolicitud = infosolicitud.DetalledeSolicitud;
            vm.MotivoRechazo = infosolicitud.MotivoRechazo;


            try
            {
                #region CONFIGURACION DE PROOVEDORES 
                //DATOS PROVEEDOR A
                var proveedora = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");

                if (proveedora != null)
                {
                    bool permitecred = false;
                    int tiempocred = 0;

                    if (proveedora.PermiteCredito == null)
                    {
                        permitecred = false;
                    }
                    else
                    {
                        permitecred = Convert.ToBoolean(proveedora.PermiteCredito);
                    }

                    if (proveedora.TiempoCredito != null)
                    {
                        tiempocred = Convert.ToInt32(proveedora.TiempoCredito);
                    }

                    //Proveedor A
                    vm.IdProveedorA = proveedora.Id;
                    vm.ProveedorA = proveedora.Proveedor;
                    vm.TipoProveedorA = proveedora.TipoProveedor;
                    vm.DescripcionA = proveedora.Descripcion;
                    vm.PrecioA = proveedora.Precio;
                    vm.TiempoEntregaA = proveedora.TiempoEntrega;
                    vm.DocumentoCotizacionA = proveedora.DocumentoCotizacion;
                    vm.AsignadoA = proveedora.Asignado;
                    vm.PermiteCreditoA = permitecred;
                    vm.TiempoCreditoA = tiempocred;
                    vm.TipoMonedaA = proveedora.TipoMoneda;
                    vm.IvaA = proveedora.Iva;
                }



                //DATOS PROVEEDOR B
                var proveedorb = _db.ProveedoresAgregadosSolicitudesDetalles
                     .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "B");

                if (proveedorb != null)
                {
                    bool permitecred = false;
                    int tiempocred = 0;

                    if (proveedorb.PermiteCredito == null)
                    {
                        permitecred = false;
                    }
                    else
                    {
                        permitecred = Convert.ToBoolean(proveedorb.PermiteCredito);
                    }

                    if (proveedorb.TiempoCredito != null)
                    {
                        tiempocred = Convert.ToInt32(proveedorb.TiempoCredito);
                    }

                    //Proveedor B
                    vm.IdProveedorB = proveedorb.Id;
                    vm.ProveedorB = proveedorb.Proveedor;
                    vm.TipoProveedorB = proveedorb.TipoProveedor;
                    vm.DescripcionB = proveedorb.Descripcion;
                    vm.PrecioB = proveedorb.Precio;
                    vm.TiempoEntregaB = proveedorb.TiempoEntrega;
                    vm.DocumentoCotizacionB = proveedorb.DocumentoCotizacion;
                    vm.AsignadoB = proveedorb.Asignado;
                    vm.PermiteCreditoB = permitecred;
                    vm.TiempoCreditoB = tiempocred;
                    vm.TipoMonedaB = proveedorb.TipoMoneda;
                    vm.IvaB = proveedorb.Iva;
                }


                //DATOS PROVEEDOR C
                var proveedorc = _db.ProveedoresAgregadosSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio && a.TipoProveedor == "C");

                if (proveedorc != null)
                {
                    bool permitecred = false;
                    int tiempocred = 0;

                    if (proveedorc.PermiteCredito == null)
                    {
                        permitecred = false;
                    }
                    else
                    {
                        permitecred = Convert.ToBoolean(proveedorc.PermiteCredito);
                    }

                    if (proveedorc.TiempoCredito != null)
                    {
                        tiempocred = Convert.ToInt32(proveedorc.TiempoCredito);
                    }

                    //Proveedor C
                    vm.IdProveedorC = proveedorc.Id;
                    vm.ProveedorC = proveedorc.Proveedor;
                    vm.TipoProveedorC = proveedorc.TipoProveedor;
                    vm.DescripcionC = proveedorc.Descripcion;
                    vm.PrecioC = proveedorc.Precio;
                    vm.TiempoEntregaC = proveedorc.TiempoEntrega;
                    vm.DocumentoCotizacionC = proveedorc.DocumentoCotizacion;
                    vm.AsignadoC = proveedorc.Asignado;
                    vm.PermiteCreditoC = permitecred;
                    vm.TiempoCreditoC = tiempocred;
                    vm.TipoMonedaC = proveedorc.TipoMoneda;
                    vm.IvaC = proveedorc.Iva;
                }
                #endregion

                //************************************
                //ACTUALIZAR ESTADO DE SOLICITUD A APROBADO o RECHAZADO DEPENDIENDO EL NIVEL DE APROBACIÓN
                var solicitud = _db.SeguimientoSolicitudesDetalles
                    .FirstOrDefault(a => a.Folio == vm.Folio);

                //if (solicitud != null && solicitud.EstadoSolicitudId < 5)
                //{
                var actualizaestado = new SeguimientoSolicitudesDetalles()
                {
                    Folio = solicitud.Folio,
                    Solicitante = solicitud.Solicitante,
                    EmailSolicitante = solicitud.EmailSolicitante,
                    CampanaId = solicitud.CampanaId,
                    DepartamentoId = solicitud.DepartamentoId,
                    UsuarioFinal = solicitud.UsuarioFinal,
                    EmailUsuarioFinal = solicitud.EmailUsuarioFinal,
                    DetalledeSolicitud = solicitud.DetalledeSolicitud,
                    Unidad = solicitud.Unidad,
                    Marca = solicitud.Marca,
                    Modelo = solicitud.Modelo,
                    ObjetivodeSolicitud = solicitud.ObjetivodeSolicitud,
                    Impacto = solicitud.Impacto,
                    PosibleProveedor = solicitud.PosibleProveedor,
                    NombreProveedorSugerido = solicitud.NombreProveedorSugerido,
                    //EstadoSolicitudId = 5,
                    EstadoSolicitudId = estadoid,
                    MotivoRechazo = motivorechazo,
                    Observaciones = solicitud.Observaciones,
                    Estatus = solicitud.Estatus,
                    FechaRegistro = solicitud.FechaRegistro,
                    UsuarioUltimaActualizacion = vm.UsuarioUltimaActualizacion,
                    FechaUltimaActualizacion = fecha,
                    CajaChica = solicitud.CajaChica,
                    //NUEVOS CAMPOS
                    BeneficioCuantitativo = solicitud.BeneficioCuantitativo,
                    BeneficioCualitativo = solicitud.BeneficioCualitativo,
                    RetornoInversion = solicitud.RetornoInversion,
                    Recurrente = solicitud.Recurrente,
                    TipoSolicitud = solicitud.TipoSolicitud,
                    CostoTotalFactura = solicitud.CostoTotalFactura,
                    TipoMonedaFactura = solicitud.TipoMonedaFactura,
                    NoFactura = solicitud.NoFactura

                };

                _db.SeguimientoSolicitudesDetalles.AddOrUpdate(actualizaestado);
                _db.SaveChanges();
                //************************************

                //SE MANDA CORREO DE APROBACIÓN O RECHAZO DE SOLICITUD
                //SEND NOTIFICATION

                try
                {
                    var proveedor =
                        _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(
                            a => a.Folio == vm.Folio && a.Asignado == true);

                    if (proveedor != null)
                    {
                        infoprovcorreo = proveedor.Proveedor;
                        infosubtotalcorreo = proveedor.Precio.ToString();
                        infoivacorreo = proveedor.Iva.ToString();
                        infotiempoentregacorreo = proveedor.TiempoEntrega;
                        infocreditocorreo = proveedor.PermiteCredito == true ? "SI" : "NO";
                        infotiempocredcorreo = proveedor.TiempoCredito.ToString();
                        infomonedacorreo = proveedor.TipoMoneda.ToString();
                    }

                    var cc = new List<string> { solicitud.EmailSolicitante, "jgarcia@pentafon.com" };
                    //cc.Add("erivera@neikos.com.mx");
                    //cc.Add("mgonzalez@pentafon.com");
                    //cc.Add("rpadilla@pentafon.com");

                    #region CORREOS ACTIVOS
                    cc.Add("cuentasporpagar@pentafon.com");
                    cc.Add("jgarcia@pentafon.com");
                    cc.Add("igomiciaga@neikos.com.mx");
                    #endregion
                    //cc.Add("fake.machine.92@gmail.com");
                    //MAIL APROBADA
                    string strmsjap = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE APROBADA<br/><br/>" +
                                                  "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                  "<b>TIPO SOLICITUD: </b>" + solicitud.TipoSolicitud + "<br/><br/>" +
                                                  "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                  "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                  "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                  "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                  "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                  "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                  "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                  "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                  "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                  "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                  "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                  "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                  "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>");

                    var quienrechaza = "";
                    //MAIL RECHAZADA
                    if (nivelaprobacion == 0)
                    {
                        quienrechaza = " POR EL DIRECTOR";
                    }
                    string strmsjre = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE RECHAZADA" + quienrechaza + "<br/><br/>" +
                                                    "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                    "<b>TIPO SOLICITUD: </b>" + solicitud.TipoSolicitud + "<br/><br/>" +
                                                    "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                    "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                    "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                    "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                    "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                     "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                                "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                    "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                    "<b>PROVEEDOR ASIGNADO : </b>" + infoprovcorreo + "<br/>" +
                                                    "<b>SUBTOTAL : </b>" + infosubtotalcorreo + "  " + infomonedacorreo + "<br/>" +
                                                    "<b>MONTO IVA : </b>" + infoivacorreo + "  " + infomonedacorreo + "<br/>" +
                                                    "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + infotiempoentregacorreo + "<br/>" +
                                                    "<b>PERMITE CREDITO: </b>" + infocreditocorreo + "<br/>" +
                                                    "<b>TIEMPO CREDITO (DIAS) : </b>" + infotiempocredcorreo + "<br/>" +
                                                    "<b>MOTIVO DE RECHAZO: </b>" + motivorechazo + "<br/>");

                    if (solicitud.EstadoSolicitudId == 24)
                    {
                        strmsjre = string.Format("LA PRESOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " FUE RECHAZADA" + quienrechaza + "<br/><br/>" +
                                                        "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                        "<b>TIPO SOLICITUD: </b>" + solicitud.TipoSolicitud + "<br/><br/>" +
                                                        "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                        "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                        "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                        "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                        "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                         "<b>MOTIVO DE RECHAZO: </b>" + motivorechazo + "<br/>");
                    }

                    //APROBADA
                    if (aprobacion == "1")
                    {
                        //cc.Add("erivera@neikos.com.mx");
                        //cc.Add("mgonzalez@pentafon.com");
                        //cc.Add("rpadilla@pentafon.com");

                        #region CORREOS ACTIVOS
                        cc.Add("cuentasporpagar@pentafon.com");
                        cc.Add("jgarcia@pentafon.com");
                        cc.Add("igomiciaga@neikos.com.mx");
                        #endregion
                        //cc.Add("fake.machine.92@gmail.com");
                        if (solicitud.EstadoSolicitudId != 24)
                        {
                            _messenger.SendMail("COMPRAS", "SOLICITUD APROBADA "
                            , strmsjap
                            , correoadmincompras, cc);
                        }
                        else
                        {
                            _messenger.SendMail("COMPRAS", "PRESOLICITUD APROBADA "
                            , strmsjap
                            , correoadmincompras, cc);
                        }
                    }
                    //RECHAZADA
                    else
                    {
                        if (solicitud.EstadoSolicitudId != 24)
                        {
                            _messenger.SendMail("COMPRAS", "SOLICITUD RECHAZADA "
                            , strmsjre, correoadmincompras, cc);
                        }
                        else
                        {
                            _messenger.SendMail("COMPRAS", "PRESOLICITUD RECHAZADA "
                             , strmsjre, correoadmincompras, cc);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string SaveCompleteFolio(int idfoiio, string usuario)
        {
            var result = "SI";

            var fecha = DateTime.Now;

            //FINALIZACIÓN DE FOLIO EN TABLA COMPRAS
            try
            {
                var datosfolio = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == idfoiio);

                if (datosfolio != null)
                {
                    var compra = new SeguimientoSolicitudesDetalles()
                    {
                        Folio = datosfolio.Folio,
                        Solicitante = datosfolio.Solicitante,
                        EmailSolicitante = datosfolio.EmailSolicitante,
                        CampanaId = datosfolio.CampanaId,
                        DepartamentoId = datosfolio.DepartamentoId,
                        UsuarioFinal = datosfolio.UsuarioFinal,
                        EmailUsuarioFinal = datosfolio.EmailUsuarioFinal,
                        DetalledeSolicitud = datosfolio.DetalledeSolicitud,
                        Unidad = datosfolio.Unidad,
                        Marca = datosfolio.Marca,
                        Modelo = datosfolio.Modelo,
                        ObjetivodeSolicitud = datosfolio.ObjetivodeSolicitud,
                        PosibleProveedor = datosfolio.PosibleProveedor,
                        NombreProveedorSugerido = datosfolio.NombreProveedorSugerido,
                        EstadoSolicitudId = 7,
                        MotivoRechazo = datosfolio.MotivoRechazo,
                        Observaciones = datosfolio.Observaciones,
                        FechaRegistro = datosfolio.FechaRegistro,
                        Estatus = false,
                        //Datos De Usuario
                        UsuarioUltimaActualizacion = usuario,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = datosfolio.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = datosfolio.BeneficioCuantitativo,
                        BeneficioCualitativo = datosfolio.BeneficioCualitativo,
                        RetornoInversion = datosfolio.RetornoInversion,
                        Recurrente = datosfolio.Recurrente,
                        TipoSolicitud = datosfolio.TipoSolicitud,
                        CostoTotalFactura = datosfolio.CostoTotalFactura,
                        TipoMonedaFactura = datosfolio.TipoMonedaFactura,
                        NoFactura = datosfolio.NoFactura
                    };

                    _db.SeguimientoSolicitudesDetalles.AddOrUpdate(compra);
                    _db.SaveChanges();

                    //FINALIZACIÓN DE FOLIO EN TABLA SOLICITUDES
                    var registro = new SolicitudesDetalles()
                    {
                        Folio = datosfolio.Folio,
                        Solicitante = datosfolio.Solicitante,
                        EmailSolicitante = datosfolio.EmailSolicitante,
                        CampanaId = datosfolio.CampanaId,
                        DepartamentoId = datosfolio.DepartamentoId,
                        UsuarioFinal = datosfolio.UsuarioFinal,
                        EmailUsuarioFinal = datosfolio.EmailUsuarioFinal,
                        DetalledeSolicitud = datosfolio.DetalledeSolicitud,
                        Unidad = datosfolio.Unidad,
                        Marca = datosfolio.Marca,
                        Modelo = datosfolio.Modelo,
                        ObjetivodeSolicitud = datosfolio.ObjetivodeSolicitud,
                        Impacto = datosfolio.Impacto,
                        PosibleProveedor = datosfolio.PosibleProveedor,
                        NombreProveedorSugerido = datosfolio.NombreProveedorSugerido,
                        Observaciones = datosfolio.Observaciones,
                        FechaRegistro = datosfolio.FechaRegistro,
                        Estatus = false,
                        //Datos De Usuario
                        UsuarioUltimaActualizacion = usuario,
                        FechaUltimaActualizacion = fecha,
                        CajaChica = datosfolio.CajaChica,
                        //NUEVOS CAMPOS
                        BeneficioCuantitativo = datosfolio.BeneficioCuantitativo,
                        BeneficioCualitativo = datosfolio.BeneficioCualitativo,
                        RetornoInversion = datosfolio.RetornoInversion,
                        Recurrente = datosfolio.Recurrente,
                        TipoSolicitud = datosfolio.TipoSolicitud,
                        CostoTotalFactura = datosfolio.CostoTotalFactura,
                        TipoMonedaFactura = datosfolio.TipoMonedaFactura,
                        NoFactura = datosfolio.NoFactura
                    };

                    _db.SolicitudesDetalles.AddOrUpdate(registro);
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = "NO";
            }

            return result;
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int SaveDataFile(int folio, string uploadName)
        {
            FilesPagosCompras obj = new FilesPagosCompras();
            obj.estatus = true;
            obj.fechaCarga = DateTime.Now;
            obj.Folio = folio;
            obj.nameFile = uploadName;
            obj.ruta = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\\FacturasDocs\\" + uploadName;
            //var lastReg = _db.FilesPagosCompras.Where(x => x.Folio == folio).OrderByDescending(x => x.id).FirstOrDefault();
            //if(lastReg == null) 
            //{

            //}
            _db.FilesPagosCompras.Add(obj);
            int i = _db.SaveChanges();
            return i;
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string DelForma(int id)
        {
            try
            {
                var obj = _db.FilesPagosCompras.Where(x => x.id == id).FirstOrDefault();
                obj.estatus = false;
                _db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //PROCESO DE ASIGNACIÓN Y APROBACIÓN O RECHAZO DE UNA SOLICITUD RECURRENTE(GERENCIA Y PRESIDENCIA) 
        public void SetAsignaProveedorRecurrente(int? folio, string aprobacion)
        {
            //PRIMER PASO
            //===========
            var datossol = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio);

            var datosprova = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "A");
            var datosprovb = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "B");
            var datosprovc = _db.ProveedoresAgregadosSolicitudesDetalles.FirstOrDefault(a => a.Folio == folio && a.TipoProveedor == "C");

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


            var user = HttpContext.Current.User.Identity.Name;
            solicitud.UsuarioUltimaActualizacion = user;
            var estadoid = 0;

            //Roles: AprobadorDirFin, AprobadorDirGral, AprobadorPresidencia

            //APROBADA POR
            if (aprobacion == "1")
            {
                var infoctrlval = _db.CtrlValidacionesDireccion.Where(a => a.Folio == folio).FirstOrDefault();

                if (infoctrlval != null)
                {

                    if (infoctrlval.EstadoSolicitudId == 9)
                    {
                        infoctrlval.ValidaGerencia = true;
                        infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
                    }
                    if (infoctrlval.EstadoSolicitudId == 10)
                    {
                        infoctrlval.ValidaDirFinanzas = true;
                        infoctrlval.UsuarioValidaRechaza = "MBARRIOS";
                    }
                    if (infoctrlval.EstadoSolicitudId == 11)
                    {
                        infoctrlval.ValidaDirGeneral = true;
                        infoctrlval.UsuarioValidaRechaza = "fmondragon";
                    }
                    if (infoctrlval.EstadoSolicitudId == 12)
                    {
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
                if (nivelesperaaprobacion == 11) estadoid = 15;
                if (nivelesperaaprobacion == 12) estadoid = 16;

                if (datossol.EstadoSolicitudId == 9 || datossol.EstadoSolicitudId == 10 ||
                    datossol.EstadoSolicitudId == 11 || datossol.EstadoSolicitudId == 12)
                {
                    var result = SetAsignaProveedor(solicitud, aprobacion, estadoid);
                }
            }
            //===========     

        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public string GetComprobante(int folio)
        {
            string fname = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\Comprobantes\\";

            var datos = _db.tbl_ComprobantePago.FirstOrDefault(a => a.Folio == folio);

            if (datos != null)
            {
                return fname + datos.Comprobante;
            }
            return "";
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public void SetEncuestaSat(EncuestaSatPentaFinances vm)
        {
            vm.FechaRegistro = DateTime.Now;

            _db.EncuestaSatPentaFinances.Add(vm);
            _db.SaveChanges();

        }
        public void EnvioEncuesta()
        {

            string linkaprobacion =
                "http://appext.pentafon.com/PentaFinances/Compras/EncuestaSat?Folio=21301";


            List<string> cc = new List<string>
            {//CORREO ACTIVO  

            };

            //cc.Add("psalinas@pentafon.com");
            //cc.Add("psalinas@pentafon.com");

            string strmsj = string.Format("ESTA ENCUESTA BUSCAR OBTENER INFORMACION ACERCA DE LA CALIDAD DEL SERVICIO. <br/><br/>" +
                                       "HOLA PAOLA FERRER! <br> " +
                                       "AL CONTESTAR RECUERDE QUE SU OPONION ES MUY IMPORTANTE, POR LO QUE LE PEDIMOS QUE SEA LO MAS SINCERO POSIBLE.<br/>" +
                                       "SU RESPUESTAS AYUDARAN A LA ADMINISTRACION A OFRECER UN MEJOR SERVICIO<br/>" +
                                       "GRACIAS.<br/>                                                                   " +
                                       "<a href=" + linkaprobacion + ">Encuesta</a>"
                                       );

            _messenger.SendMail("ENCUESTA DE SATISFACCIÓN FOLIO: 21301", "ENCUESTA DE SATISFACCION"
              , strmsj, "acarbajal@pentafon.com", cc);

        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void SetEvaluacionProveedor(EvaluacionProveedores vm)
        {
            //vm.FechaRegistro = DateTime.Now;

            _db.EvaluacionProveedores.Add(vm);
            _db.SaveChanges();

        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetReport(string path)
        {


            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            xlApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet1;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkBook.Worksheets.Add();

            xlWorkSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);


            //Here saving the file in xlsx
            var fileName = Path.GetFileName("test.xlsx");

            xlWorkBook.SaveAs(path + fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);


        }

        public string SetProveedoresResend(int idFolio)
        {
            var fecha = DateTime.Now;
            var nivelaprobacion = 0;

            var infoprovcorreo = "";
            var infosubtotalcorreo = "";
            var infomonedacorreo = "";
            var infoivacorreo = "";
            var infotiempoentregacorreo = "";
            var infocreditocorreo = "";
            var infotiempocredcorreo = "";
            var solicitud = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == idFolio);
            var campania = _db.CatalogoCampanas.FirstOrDefault(a => a.Id == solicitud.CampanaId);
            var datosProveedor = _db.ProveedoresAgregadosSolicitudesDetalles.Where(a => a.Folio == idFolio && a.Proveedor != null).FirstOrDefault();


            try
            {

                #region CONFIGURACION TIPO DE APROBACION; (NivelAprobacion : Cantidad); 9 <= 10 000 , 10 <= 50000, 11 <= 100 000

                //VALIDAR NIVEL DE APROBACIÓN

                //VALIDAR TIPO DE MONEDA MXN
                if (datosProveedor.TipoMoneda == "MXN")
                {

                    //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                    if (datosProveedor.Precio <= 10000) nivelaprobacion = 9;
                    if (datosProveedor.Precio > 10000 && datosProveedor.Precio <= 50000) nivelaprobacion = 10;
                    if (datosProveedor.Precio > 50000 && datosProveedor.Precio <= 100000) nivelaprobacion = 11;
                    if (datosProveedor.Precio > 100000) nivelaprobacion = 12;
                    infomonedacorreo = "MXN";
                }

                //VALIDAR TIPO DE MONEDA USD
                if (datosProveedor.TipoMoneda == "USD")
                {
                    //SI ES MENOR O IGUAL A 10,000 SE APRUEBA AUTOMATICAMENTE
                    if (datosProveedor.Precio <= 480) nivelaprobacion = 9;
                    if (datosProveedor.Precio > 480 && datosProveedor.Precio <= 2380) nivelaprobacion = 10;
                    if (datosProveedor.Precio > 2380 && datosProveedor.Precio <= 4760) nivelaprobacion = 11;
                    if (datosProveedor.Precio > 4760) nivelaprobacion = 12;
                    infomonedacorreo = "USD";
                }


                #endregion

                //SE ACTUALIZA EL ESTADO DE SOLICITUD DEPENDIENDO EL NIVEL DE APROBACIÓN 
                solicitud = _db.SeguimientoSolicitudesDetalles.FirstOrDefault(a => a.Folio == idFolio);

                var apruebadirectivo = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
                var linkaprobacion = "";
                var linkrechazo = "";
                var botoncorreoaprobacion = "";
                var botoncorreorechazo = "";
                //if (vm.Actualizar != 1)
                //{
                /*VALIDACION NIVEL APROBACION A DIRECTIVOS*/
                if (apruebadirectivo != null)
                {
                    linkaprobacion = "https://appext2.pentafon.com/Pentafinances/Compras/AvisoAprobacionRechazoDirectivos?folio=" + idFolio.ToString() + "&aprobacion=1";
                    linkrechazo = "https://appext2.pentafon.com/Pentafinances/Compras/AvisoAprobacionRechazoDirectivos?folio=" + idFolio.ToString() + "&aprobacion=2";
                    botoncorreoaprobacion = "<a href='" + linkaprobacion + "' target='_blank'><div><h4>Aprobar Solicitud</h4></div></a>";
                    botoncorreorechazo = "<a href='" + linkrechazo + "' target='_blank'><div><h4>Rechazar Solicitud</h4></div></a>";

                    var ctrlvalidaciones = new CtrlValidacionesDireccion();

                    ctrlvalidaciones.Folio = solicitud.Folio;
                    ctrlvalidaciones.ValidaGerencia = false;
                    ctrlvalidaciones.ValidaDirFinanzas = false;
                    ctrlvalidaciones.ValidaDirGeneral = false;
                    ctrlvalidaciones.ValidaPresidencia = false;
                    ctrlvalidaciones.EnvioMailGerencia = false;
                    ctrlvalidaciones.EnvioMailDirFinanzas = false;
                    ctrlvalidaciones.EnvioMailDirGeneral = false;
                    ctrlvalidaciones.EnvioMailPresidencia = false;
                    ctrlvalidaciones.EstadoSolicitudId = nivelaprobacion;
                    //ctrlvalidaciones.AprobadoRechazado = null;
                    ctrlvalidaciones.FechaRegistro = DateTime.Now;
                    //ctrlvalidaciones.UsuarioValidaRechaza = null;
                    //ctrlvalidaciones.FechaValidacionRechazo = null;

                    if (nivelaprobacion == 9)
                    {
                        ctrlvalidaciones.ValidaGerencia = true;
                        ctrlvalidaciones.EnvioMailGerencia = true;
                    }
                    if (nivelaprobacion == 10)
                    {
                        ctrlvalidaciones.ValidaDirFinanzas = true;
                        ctrlvalidaciones.EnvioMailDirFinanzas = true;
                    }
                    if (nivelaprobacion == 11)
                    {
                        ctrlvalidaciones.ValidaGerencia = true;
                        ctrlvalidaciones.EnvioMailGerencia = true;
                        ctrlvalidaciones.ValidaDirGeneral = true;
                        ctrlvalidaciones.EnvioMailDirGeneral = false;
                    }
                    if (nivelaprobacion == 12)
                    {
                        ctrlvalidaciones.ValidaGerencia = true;
                        ctrlvalidaciones.EnvioMailGerencia = true;
                        ctrlvalidaciones.ValidaPresidencia = true;
                        ctrlvalidaciones.EnvioMailPresidencia = false;

                    }


                }


                //SE MANDA CORREO A LAS PERSONAS CORRESPONDIENTES DEPENDIENDO EL NIVEL DE APROBACIÓN, LAS SOLICITUDES ESTARÁN EN 
                //ESTATUS DE ESPERA DE APROBACIÓN
                try
                {
                    var cc = new List<string> { correoadmincompras };
                    //cc.Add("erivera@neikos.com.mx");
                    //cc.Add("mgonzalez@pentafon.com");
                    //cc.Add("rpadilla@pentafon.com");
                    #region CORREOS ACTIVOS
                    cc.Add("cuentasporpagar@pentafon.com");// DESCOMENTE PASR
                    cc.Add("jgarcia@pentafon.com");
                    //cc.Add("igomiciaga@neikos.com.mx");
                    //cc.Add("fake.machine.92@gmail.com");
                    #endregion

                    //AGREGAR COPIA DE APROBACIÓN
                    //cc.Add("erivera@neikos.com.mx");

                    //var contenido = "LA SOLICITUD DE COMPRA CON FOLIO: " + "<b>" + solicitud.Folio + "<b>"+"ESTA EN ESPERA APROBACIÓN";
                    //CORREOS DE APROBACION 
                    string strmsjToApprove = "";
                    string strmsj = "";
                    strmsj = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA APROBACIÓN<br/><br/>" +
                                                      "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                      "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                      "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                      "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                      "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                      "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                       "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                            "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                      "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                      "<b>PROVEEDOR ASIGNADO : </b>" + datosProveedor.Proveedor + "<br/>" +
                                                      "<b>SUBTOTAL : </b>" + datosProveedor.Precio + "  " + infomonedacorreo + "<br/>" +
                                                      "<b>MONTO IVA : </b>" + datosProveedor.Iva + "  " + infomonedacorreo + "<br/>" +
                                                      "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + datosProveedor.TiempoEntrega + "<br/>" +
                                                      "<b>PERMITE CREDITO: </b>" + datosProveedor.PermiteCredito + "<br/>" +
                                                      "<b>TIEMPO CREDITO (DIAS) : </b>" + datosProveedor.TiempoCredito + "<br/>"
                                                      );


                    strmsjToApprove = string.Format("LA SOLICITUD DE COMPRA CON FOLIO: " + solicitud.Folio + " ESTA EN ESPERA APROBACIÓN<br/><br/>" +
                                                      "<b>SOLICITANTE: </b>" + solicitud.Solicitante + "<br/><br/>" +
                                                      "<b>DETALLE DE LA SOLICITUD: </b>" + solicitud.DetalledeSolicitud + ".<br/><br/>" +
                                                      "<b>CAMPAÑA: </b>" + campania.Campana + "<br/>" +
                                                      "<b>UNIDAD: </b>" + solicitud.Unidad + "<br/>" +
                                                      "<b>MARCA: </b>" + solicitud.Marca + "<br/>" +
                                                      "<b>MODELO: </b>" + solicitud.Modelo + "<br/><br/>" +
                                                       "<b>NO. FACTURA: </b>" + solicitud.NoFactura + "<br/><br/>" +
                            "<b>COSTO TOTAL FACTURA: </b>" + solicitud.CostoTotalFactura + " " + solicitud.TipoMonedaFactura + "<br/><br/>" +
"<b>OBSERVACIONES : </b>" + solicitud.Observaciones + "<br/><br/>" +
                                                      "<b>DATOS DEL PROVEEDOR</b>" + "<br/><br/>" +
                                                      "<b>PROVEEDOR ASIGNADO : </b>" + datosProveedor.Proveedor + "<br/>" +
                                                      "<b>SUBTOTAL : </b>" + datosProveedor.Precio + "  " + infomonedacorreo + "<br/>" +
                                                      "<b>MONTO IVA : </b>" + datosProveedor.Iva + "  " + infomonedacorreo + "<br/>" +
                                                      "<b>TIEMPO DE ENTREGA (DIAS) : </b>" + datosProveedor.TiempoEntrega + "<br/>" +
                                                      "<b>PERMITE CREDITO: </b>" + datosProveedor.PermiteCredito + "<br/>" +
                                                      "<b>TIEMPO CREDITO (DIAS) : </b>" + datosProveedor.TiempoCredito + "<br/>" +
                                                      "<table style='width: 100%;'><tr><td style='width: 33%;'>" + botoncorreoaprobacion + "</td><td style='width: 33%;'>" + botoncorreorechazo + "</td></tr></table>");



                    var correodirector = "";
                    var infosolicitante = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
                    if (infosolicitante != null)
                    {
                        var infodirector = _db.CatalogoDirectores.Where(a => a.Id == infosolicitante.DirectorId).FirstOrDefault();
                        if (infodirector != null)
                        {
                            correodirector = infodirector.Correo;
                            if (infosolicitante.DirectorId != 27)
                            {
                                //cc.Add(correodirector);
                            }
                        }
                    }

                    if (nivelaprobacion == 9)//MANUEL GONZALEZ
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(idFolio, "1");
                        }
                        else
                        {

                            _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsj, correoadmincompras, cc);
                            //MENSAJE CON LINK DE APROBACION/RECHAZO 
                            _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsjToApprove
                                , correoadmincompras);


                        }
                    }

                    if (nivelaprobacion == 10)//RRESENDIZ/JSANTOVENA
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(idFolio, "1");
                        }
                        else
                        {

                            _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsj
                                , correoadmincompras, cc);

                            //MENSAJE CON LINK DE APROBACION/RECHAZO 

                            _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsjToApprove
                            , correodirfinanzas);

                        }
                    }

                    if (nivelaprobacion == 11)//FMONDRAGON
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(idFolio, "1");
                        }
                        else
                        {

                            //_messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            //    , strmsj
                            //    , "jgarcia@pentafon.com", cc);


                            //MENSAJE CON LINK DE APROBACION/RECHAZO 
                            _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsjToApprove
                                , correodirgral);

                        }
                    }

                    if (nivelaprobacion == 12)//AFAJER
                    {
                        if (solicitud.Recurrente == "SI")
                        {
                            //APROBAR SOLICITUD RECURRENTE
                            SetAsignaProveedorRecurrente(idFolio, "1");
                        }
                        else
                        {

                            _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                                , strmsj
                                , "jgarcia@pentafon.com", cc);


                            //MENSAJE CON LINK DE APROBACION/RECHAZO 

                            _messenger.SendMailToApprove("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO"
                            , strmsjToApprove
                            , correopresidencia);

                        }
                    }

                    if (nivelaprobacion == 22)//DIRECTOR DE ÁREA
                    {
                        //var correodirector = "";
                        //var infosolicitante = _db.ApUsuarios.Where(a => a.Correo == solicitud.EmailSolicitante).FirstOrDefault();
                        if (infosolicitante != null)
                        {
                            var infodirector = _db.CatalogoDirectores.Where(a => a.Id == infosolicitante.DirectorId).FirstOrDefault();
                            if (infodirector != null)
                            {
                                correodirector = infodirector.Correo;
                            }
                            else
                            {
                                correodirector = correoadmincompras;
                            }
                        }
                        else
                        {
                            correodirector = correoadmincompras;
                        }

                        _messenger.SendMail("COMPRAS", "SOLICITUD DE COMPRA PARA APROBACIÓN O RECHAZO DIRECTORES"
                            , strmsj
                            , correodirector, cc);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "Exito";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        //-------------------------------------------------------------------------------------------------
        public string SetCatProveedores(string nomEmpresa, string nomProveedor, string nomPeriocidad)
        {
            proveedores vm = new proveedores()
            {
                ClaveProveedor = 0,
                Empresa = nomEmpresa,
                Nombre = nomProveedor,
                Periodicidad = nomPeriocidad,
                Activo = true
            };

            _db.proveedores.Add(vm);
            _db.SaveChanges();
            return "Ok";
        }
    }

    //-------------------------------------------------------------------------------------------------

    //CLASS============================================================================================================================

}

