using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using PentaFinances.Dtos;
using PentaFinances.Models;
using PentaFinances.ViewModels;

namespace PentaFinances.Managers
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class CostoManager
    {
        PentaFinContext _db = new PentaFinContext();
        PentaFinComprasContext _dbcom = new PentaFinComprasContext();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //-----Costos Directos
        public void SetCostosDirectosByList(List<CostosDirectosDto> costo, int mes, int an)
        {
            foreach (var cost in costo)
            {
                var pt =
                    _db.Database.SqlQuery<CostosDirectosPt>("dbo.sp_GetCostosDirectosPtDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        cost.Campana.idCampana, mes, an ).FirstOrDefault();

                var fr =
                    _db.Database.SqlQuery<CostosDirectosFr>("dbo.sp_GetCostosDirectosFrDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        cost.Campana.idCampana, mes, an).FirstOrDefault();

                var ci =
                   _db.Database.SqlQuery<CostosDirectosCi>("dbo.sp_GetCostosDirectosCiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                       cost.Campana.idCampana, mes, an).FirstOrDefault();

                var re =
                  _db.Database.SqlQuery<CostosDirectosRe>("dbo.sp_GetCostosDirectosReDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                      cost.Campana.idCampana, mes, an).FirstOrDefault();

                if (pt == null)
                {
                    var datosPt = new CostosDirectosPt
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosDirectos.Gerencial.Pt,
                        Operacion = cost.CostosDirectos.Operacion.Pt,
                        NominaEspecial = cost.CostosDirectos.NominaEspecial.Pt,
                        RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Pt,
                        ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Pt,
                        ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Pt,
                        SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Pt,
                        Directo = cost.CostosDirectos.Directo.Pt,
                        Otros = cost.CostosDirectos.Otros.Pt,
                        Licencias = cost.CostosDirectos.Licencias.Pt,
                        AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Pt,
                       
                    };
                    _db.CostosDirectosPt.Add(datosPt);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosDirectosPt.Attach(pt);
                        pt.IdCampana = cost.Campana.idCampana;
                        pt.Mes = mes;
                        pt.Year = an;
                        pt.FechaRegistro = DateTime.Now;
                        pt.Gerencial = cost.CostosDirectos.Gerencial.Pt;
                        pt.Operacion = cost.CostosDirectos.Operacion.Pt;
                        pt.NominaEspecial = cost.CostosDirectos.NominaEspecial.Pt;
                        pt.RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Pt;
                        pt.ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Pt;
                        pt.ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Pt;
                        pt.SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Pt;
                        pt.Directo = cost.CostosDirectos.Directo.Pt;
                        pt.Otros = cost.CostosDirectos.Otros.Pt;
                        pt.Licencias = cost.CostosDirectos.Licencias.Pt;
                        pt.AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Pt;
                        metaCon.SaveChanges();
                    }
                }

                if (fr == null)
                {
                    var datosFr = new CostosDirectosFr
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosDirectos.Gerencial.Fr,
                        Operacion = cost.CostosDirectos.Operacion.Fr,
                        NominaEspecial = cost.CostosDirectos.NominaEspecial.Fr,
                        RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Fr,
                        ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Fr,
                        ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Fr,
                        SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Fr,
                        Directo = cost.CostosDirectos.Directo.Fr,
                        Otros = cost.CostosDirectos.Otros.Fr,
                        Licencias = cost.CostosDirectos.Licencias.Fr,
                        AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Fr,

                    };
                    _db.CostosDirectosFr.Add(datosFr);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosDirectosFr.Attach(fr);
                        fr.IdCampana = cost.Campana.idCampana;
                        fr.Mes = mes;
                        fr.Year = an;
                        fr.FechaRegistro = DateTime.Now;
                        fr.Gerencial = cost.CostosDirectos.Gerencial.Fr;
                        fr.Operacion = cost.CostosDirectos.Operacion.Fr;
                        fr.NominaEspecial = cost.CostosDirectos.NominaEspecial.Fr;
                        fr.RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Fr;
                        fr.ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Fr;
                        fr.ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Fr;
                        fr.SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Fr;
                        fr.Directo = cost.CostosDirectos.Directo.Fr;
                        fr.Otros = cost.CostosDirectos.Otros.Fr;
                        fr.Licencias = cost.CostosDirectos.Licencias.Fr;
                        fr.AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Fr;
                        metaCon.SaveChanges();
                    }
                }

                if (ci == null)
                {
                    var datosCi = new CostosDirectosCi
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosDirectos.Gerencial.Ci,
                        Operacion = cost.CostosDirectos.Operacion.Ci,
                        NominaEspecial = cost.CostosDirectos.NominaEspecial.Ci,
                        RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Ci,
                        ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Ci,
                        ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Ci,
                        SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Ci,
                        Directo = cost.CostosDirectos.Directo.Ci,
                        Otros = cost.CostosDirectos.Otros.Ci,
                        Licencias = cost.CostosDirectos.Licencias.Ci,
                        AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Ci,

                    };
                    _db.CostosDirectosCi.Add(datosCi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosDirectosCi.Attach(ci);
                        ci.IdCampana = cost.Campana.idCampana;
                        ci.Mes = mes;
                        ci.Year = an;
                        ci.FechaRegistro = DateTime.Now;
                        ci.Gerencial = cost.CostosDirectos.Gerencial.Ci;
                        ci.Operacion = cost.CostosDirectos.Operacion.Ci;
                        ci.NominaEspecial = cost.CostosDirectos.NominaEspecial.Ci;
                        ci.RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Ci;
                        ci.ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Ci;
                        ci.ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Ci;
                        ci.SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Ci;
                        ci.Directo = cost.CostosDirectos.Directo.Ci;
                        ci.Otros = cost.CostosDirectos.Otros.Ci;
                        ci.Licencias = cost.CostosDirectos.Licencias.Ci;
                        ci.AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Ci;
                        metaCon.SaveChanges();
                    }
                }

                if (re == null)
                {
                    var datosRe = new CostosDirectosRe
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosDirectos.Gerencial.Re,
                        Operacion = cost.CostosDirectos.Operacion.Re,
                        NominaEspecial = cost.CostosDirectos.NominaEspecial.Re,
                        RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Re,
                        ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Re,
                        ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Re,
                        SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Re,
                        Directo = cost.CostosDirectos.Directo.Re,
                        Otros = cost.CostosDirectos.Otros.Re,
                        Licencias = cost.CostosDirectos.Licencias.Re,
                        AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Re,

                    };
                    _db.CostosDirectosRe.Add(datosRe);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosDirectosRe.Attach(re);
                        re.IdCampana = cost.Campana.idCampana;
                        re.Mes = mes;
                        re.Year = an;
                        re.FechaRegistro = DateTime.Now;
                        re.Gerencial = cost.CostosDirectos.Gerencial.Re;
                        re.Operacion = cost.CostosDirectos.Operacion.Re;
                        re.NominaEspecial = cost.CostosDirectos.NominaEspecial.Re;
                        re.RentaEquipoComputo = cost.CostosDirectos.RentaEquipoComputo.Re;
                        re.ServiciosOutsourcing = cost.CostosDirectos.ServiciosOutsourcing.Re;
                        re.ServiciosMaquilados = cost.CostosDirectos.ServiciosMaquilados.Re;
                        re.SegurosyFianzasCuotas_Suscripciones = cost.CostosDirectos.SegurosyFianzasCuotas_Suscripciones.Re;
                        re.Directo = cost.CostosDirectos.Directo.Re;
                        re.Otros = cost.CostosDirectos.Otros.Re;
                        re.Licencias = cost.CostosDirectos.Licencias.Re;
                        re.AplicativoCitasSNE = cost.CostosDirectos.AplicativoCitasSNE.Re;
                        metaCon.SaveChanges();
                    }
                }

              

            }
        }
       
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //-----Costos Indirectos
        public void SetCostosIndirectosByList(List<CostosIndirectosDto> costo, int mes, int an)
        {
            foreach (var cost in costo)
            {
                var pt =
                    _db.Database.SqlQuery<CostosIndirectosPt>("dbo.sp_GetCostosIndirectosPtDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        cost.Campana.idCampana, mes, an).FirstOrDefault();

                var fr =
                    _db.Database.SqlQuery<CostosIndirectosFr>("dbo.sp_GetCostosIndirectosFrDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        cost.Campana.idCampana, mes, an).FirstOrDefault();

                var ci =
                   _db.Database.SqlQuery<CostosIndirectosCi>("dbo.sp_GetCostosIndirectosCiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                       cost.Campana.idCampana, mes, an).FirstOrDefault();

                var re =
                  _db.Database.SqlQuery<CostosIndirectosRe>("dbo.sp_GetCostosIndirectosReDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                      cost.Campana.idCampana, mes, an).FirstOrDefault();

                if (pt == null)
                {
                    var datosPt = new CostosIndirectosPt
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year= an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosIndirectos.Gerencial.Pt,
                        Operacion = cost.CostosIndirectos.Operacion.Pt,
                        Depreciaciones = cost.CostosIndirectos.Depreciaciones.Pt,
                        AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Pt,
                        AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Pt,
                        EquipoOficina = cost.CostosIndirectos.EquipoOficina.Pt,
                        CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Pt,
                        MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Pt,
                        Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Pt,
                        Diademas = cost.CostosIndirectos.Diademas.Pt,
                        Renta = cost.CostosIndirectos.Renta.Pt,
                        Luz = cost.CostosIndirectos.Luz.Pt,
                        Agua = cost.CostosIndirectos.Agua.Pt,
                        Vigilancia = cost.CostosIndirectos.Vigilancia.Pt,
                        Limpieza = cost.CostosIndirectos.Limpieza.Pt,
                        Edificio = cost.CostosIndirectos.Edificio.Pt,
                        ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Pt,
                        ServDeLegal = cost.CostosIndirectos.ServDeLegal.Pt,
                        servContables = cost.CostosIndirectos.servContables.Pt,
                        ServdeAdministrativos = cost.CostosIndirectos.Gerencial.Pt,
                        Corporativo = cost.CostosIndirectos.Corporativo.Pt,
                        Papeleria = cost.CostosIndirectos.Papeleria.Pt,
                        Diversos = cost.CostosIndirectos.Diversos.Pt,
                        Nodeducibles = cost.CostosIndirectos.Nodeducibles.Pt,
                        IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Pt,
                        Pasajes = cost.CostosIndirectos.Pasajes.Pt,
                        Despensa = cost.CostosIndirectos.Despensa.Pt,
                        Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Pt,
                        SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Pt,
                        BaseDatos = cost.CostosIndirectos.BaseDatos.Pt,
                        CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Pt,
                        Indirecto = cost.CostosIndirectos.Indirecto.Pt,
                        OCC = cost.CostosIndirectos.OCC.Pt,
                        Cursos = cost.CostosIndirectos.Cursos.Pt,
                        PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Pt,
                        Comisiones = cost.CostosIndirectos.Comisiones.Pt,
                        PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Pt,
                        Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Pt,
                        InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Pt,
                        RentadeUPS = cost.CostosIndirectos.RentadeUPS.Pt,
                        RentadePlanta = cost.CostosIndirectos.RentadePlanta.Pt,    

                    };
                    _db.CostosIndirectosPt.Add(datosPt);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosIndirectosPt.Attach(pt);
                        pt.IdCampana = cost.Campana.idCampana;
                        pt.Mes = mes;
                        pt.Year = an;
                        pt.FechaRegistro = DateTime.Now;
                        pt.Gerencial = cost.CostosIndirectos.Gerencial.Pt;
                        pt.Operacion = cost.CostosIndirectos.Operacion.Pt;
                        pt.Depreciaciones = cost.CostosIndirectos.Depreciaciones.Pt;
                        pt.AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Pt;
                        pt.AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Pt;
                        pt.EquipoOficina = cost.CostosIndirectos.EquipoOficina.Pt;
                        pt.CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Pt;
                        pt.MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Pt;
                        pt.Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Pt;
                        pt.Diademas = cost.CostosIndirectos.Diademas.Pt;
                        pt.Renta = cost.CostosIndirectos.Renta.Pt;
                        pt.Luz = cost.CostosIndirectos.Luz.Pt;
                        pt.Agua = cost.CostosIndirectos.Agua.Pt;
                        pt.Vigilancia = cost.CostosIndirectos.Vigilancia.Pt;
                        pt.Limpieza = cost.CostosIndirectos.Limpieza.Pt;
                        pt.Edificio = cost.CostosIndirectos.Edificio.Pt;
                        pt.ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Pt;
                        pt.ServDeLegal = cost.CostosIndirectos.ServDeLegal.Pt;
                        pt.servContables = cost.CostosIndirectos.servContables.Pt;
                        pt.ServdeAdministrativos = cost.CostosIndirectos.ServdeAdministrativos.Pt;
                        pt.Corporativo = cost.CostosIndirectos.Corporativo.Pt;
                        pt.Papeleria = cost.CostosIndirectos.Papeleria.Pt;
                        pt.Diversos = cost.CostosIndirectos.Diversos.Pt;
                        pt.Nodeducibles = cost.CostosIndirectos.Nodeducibles.Pt;
                        pt.IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Pt;
                        pt.Pasajes = cost.CostosIndirectos.Pasajes.Pt;
                        pt.Despensa = cost.CostosIndirectos.Despensa.Pt;
                        pt.Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Pt;
                        pt.SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Pt;
                        pt.BaseDatos = cost.CostosIndirectos.BaseDatos.Pt;
                        pt.CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Pt;
                        pt.Indirecto = cost.CostosIndirectos.Indirecto.Pt;
                        pt.OCC = cost.CostosIndirectos.OCC.Pt;
                        pt.Cursos = cost.CostosIndirectos.Cursos.Pt;
                        pt.PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Pt;
                        pt.Comisiones = cost.CostosIndirectos.Comisiones.Pt;
                        pt.PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Pt;
                        pt.Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Pt;
                        pt.InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Pt;
                        pt.RentadeUPS = cost.CostosIndirectos.RentadeUPS.Pt;
                        pt.RentadePlanta = cost.CostosIndirectos.RentadePlanta.Pt;    
                        metaCon.SaveChanges();
                    }
                }

                if (fr == null)
                {
                    var datosFr = new CostosIndirectosFr
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosIndirectos.Gerencial.Fr,
                        Operacion = cost.CostosIndirectos.Operacion.Fr,
                        Depreciaciones = cost.CostosIndirectos.Depreciaciones.Fr,
                        AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Fr,
                        AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Fr,
                        EquipoOficina = cost.CostosIndirectos.EquipoOficina.Fr,
                        CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Fr,
                        MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Fr,
                        Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Fr,
                        Diademas = cost.CostosIndirectos.Diademas.Fr,
                        Renta = cost.CostosIndirectos.Renta.Fr,
                        Luz = cost.CostosIndirectos.Luz.Fr,
                        Agua = cost.CostosIndirectos.Agua.Fr,
                        Vigilancia = cost.CostosIndirectos.Vigilancia.Fr,
                        Limpieza = cost.CostosIndirectos.Limpieza.Fr,
                        Edificio = cost.CostosIndirectos.Edificio.Fr,
                        ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Fr,
                        ServDeLegal = cost.CostosIndirectos.ServDeLegal.Fr,
                        servContables = cost.CostosIndirectos.servContables.Fr,
                        ServdeAdministrativos = cost.CostosIndirectos.Gerencial.Fr,
                        Corporativo = cost.CostosIndirectos.Corporativo.Fr,
                        Papeleria = cost.CostosIndirectos.Papeleria.Fr,
                        Diversos = cost.CostosIndirectos.Diversos.Fr,
                        Nodeducibles = cost.CostosIndirectos.Nodeducibles.Fr,
                        IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Fr,
                        Pasajes = cost.CostosIndirectos.Pasajes.Fr,
                        Despensa = cost.CostosIndirectos.Despensa.Fr,
                        Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Fr,
                        SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Fr,
                        BaseDatos = cost.CostosIndirectos.BaseDatos.Fr,
                        CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Fr,
                        Indirecto = cost.CostosIndirectos.Indirecto.Fr,
                        OCC = cost.CostosIndirectos.OCC.Fr,
                        Cursos = cost.CostosIndirectos.Cursos.Fr,
                        PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Fr,
                        Comisiones = cost.CostosIndirectos.Comisiones.Fr,
                        PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Fr,
                        Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Fr,
                        InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Fr,
                        RentadeUPS = cost.CostosIndirectos.RentadeUPS.Fr,
                        RentadePlanta = cost.CostosIndirectos.RentadePlanta.Fr,    

                    };
                    _db.CostosIndirectosFr.Add(datosFr);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosIndirectosFr.Attach(fr);
                        fr.IdCampana = cost.Campana.idCampana;
                        fr.Mes = mes;
                        fr.Year = an;
                        fr.FechaRegistro = DateTime.Now;
                        fr.Gerencial = cost.CostosIndirectos.Gerencial.Fr;
                        fr.Operacion = cost.CostosIndirectos.Operacion.Fr;
                        fr.Depreciaciones = cost.CostosIndirectos.Depreciaciones.Fr;
                        fr.AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Fr;
                        fr.AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Fr;
                        fr.EquipoOficina = cost.CostosIndirectos.EquipoOficina.Fr;
                        fr.CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Fr;
                        fr.MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Fr;
                        fr.Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Fr;
                        fr.Diademas = cost.CostosIndirectos.Diademas.Fr;
                        fr.Renta = cost.CostosIndirectos.Renta.Fr;
                        fr.Luz = cost.CostosIndirectos.Luz.Fr;
                        fr.Agua = cost.CostosIndirectos.Agua.Fr;
                        fr.Vigilancia = cost.CostosIndirectos.Vigilancia.Fr;
                        fr.Limpieza = cost.CostosIndirectos.Limpieza.Fr;
                        fr.Edificio = cost.CostosIndirectos.Edificio.Fr;
                        fr.ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Fr;
                        fr.ServDeLegal = cost.CostosIndirectos.ServDeLegal.Fr;
                        fr.servContables = cost.CostosIndirectos.servContables.Fr;
                        fr.ServdeAdministrativos = cost.CostosIndirectos.ServdeAdministrativos.Fr;
                        fr.Corporativo = cost.CostosIndirectos.Corporativo.Fr;
                        fr.Papeleria = cost.CostosIndirectos.Papeleria.Fr;
                        fr.Diversos = cost.CostosIndirectos.Diversos.Fr;
                        fr.Nodeducibles = cost.CostosIndirectos.Nodeducibles.Fr;
                        fr.IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Fr;
                        fr.Pasajes = cost.CostosIndirectos.Pasajes.Fr;
                        fr.Despensa = cost.CostosIndirectos.Despensa.Fr;
                        fr.Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Fr;
                        fr.SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Fr;
                        fr.BaseDatos = cost.CostosIndirectos.BaseDatos.Fr;
                        fr.CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Fr;
                        fr.Indirecto = cost.CostosIndirectos.Indirecto.Fr;
                        fr.OCC = cost.CostosIndirectos.OCC.Fr;
                        fr.Cursos = cost.CostosIndirectos.Cursos.Fr;
                        fr.PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Fr;
                        fr.Comisiones = cost.CostosIndirectos.Comisiones.Fr;
                        fr.PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Fr;
                        fr.Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Fr;
                        fr.InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Fr;
                        fr.RentadeUPS = cost.CostosIndirectos.RentadeUPS.Fr;
                        fr.RentadePlanta = cost.CostosIndirectos.RentadePlanta.Fr;    
                        metaCon.SaveChanges();
                    }
                }

                if (ci == null)
                {
                    var datosCi = new CostosIndirectosCi
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosIndirectos.Gerencial.Ci,
                        Operacion = cost.CostosIndirectos.Operacion.Ci,
                        Depreciaciones = cost.CostosIndirectos.Depreciaciones.Ci,
                        AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Ci,
                        AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Ci,
                        EquipoOficina = cost.CostosIndirectos.EquipoOficina.Ci,
                        CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Ci,
                        MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Ci,
                        Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Ci,
                        Diademas = cost.CostosIndirectos.Diademas.Ci,
                        Renta = cost.CostosIndirectos.Renta.Ci,
                        Luz = cost.CostosIndirectos.Luz.Ci,
                        Agua = cost.CostosIndirectos.Agua.Ci,
                        Vigilancia = cost.CostosIndirectos.Vigilancia.Ci,
                        Limpieza = cost.CostosIndirectos.Limpieza.Ci,
                        Edificio = cost.CostosIndirectos.Edificio.Ci,
                        ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Ci,
                        ServDeLegal = cost.CostosIndirectos.ServDeLegal.Ci,
                        servContables = cost.CostosIndirectos.servContables.Ci,
                        ServdeAdministrativos = cost.CostosIndirectos.Gerencial.Ci,
                        Corporativo = cost.CostosIndirectos.Corporativo.Ci,
                        Papeleria = cost.CostosIndirectos.Papeleria.Ci,
                        Diversos = cost.CostosIndirectos.Diversos.Ci,
                        Nodeducibles = cost.CostosIndirectos.Nodeducibles.Ci,
                        IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Ci,
                        Pasajes = cost.CostosIndirectos.Pasajes.Ci,
                        Despensa = cost.CostosIndirectos.Despensa.Ci,
                        Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Ci,
                        SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Ci,
                        BaseDatos = cost.CostosIndirectos.BaseDatos.Ci,
                        CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Ci,
                        Indirecto = cost.CostosIndirectos.Indirecto.Ci,
                        OCC = cost.CostosIndirectos.OCC.Ci,
                        Cursos = cost.CostosIndirectos.Cursos.Ci,
                        PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Ci,
                        Comisiones = cost.CostosIndirectos.Comisiones.Ci,
                        PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Ci,
                        Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Ci,
                        InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Ci,
                        RentadeUPS = cost.CostosIndirectos.RentadeUPS.Ci,
                        RentadePlanta = cost.CostosIndirectos.RentadePlanta.Ci,

                    };
                    _db.CostosIndirectosCi.Add(datosCi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosIndirectosCi.Attach(ci);
                        ci.IdCampana = cost.Campana.idCampana;
                        ci.Mes = mes;
                        ci.Year = an;
                        ci.FechaRegistro = DateTime.Now;
                        ci.Gerencial = cost.CostosIndirectos.Gerencial.Ci;
                        ci.Operacion = cost.CostosIndirectos.Operacion.Ci;
                        ci.Depreciaciones = cost.CostosIndirectos.Depreciaciones.Ci;
                        ci.AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Ci;
                        ci.AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Ci;
                        ci.EquipoOficina = cost.CostosIndirectos.EquipoOficina.Ci;
                        ci.CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Ci;
                        ci.MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Ci;
                        ci.Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Ci;
                        ci.Diademas = cost.CostosIndirectos.Diademas.Ci;
                        ci.Renta = cost.CostosIndirectos.Renta.Ci;
                        ci.Luz = cost.CostosIndirectos.Luz.Ci;
                        ci.Agua = cost.CostosIndirectos.Agua.Ci;
                        ci.Vigilancia = cost.CostosIndirectos.Vigilancia.Ci;
                        ci.Limpieza = cost.CostosIndirectos.Limpieza.Ci;
                        ci.Edificio = cost.CostosIndirectos.Edificio.Ci;
                        ci.ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Ci;
                        ci.ServDeLegal = cost.CostosIndirectos.ServDeLegal.Ci;
                        ci.servContables = cost.CostosIndirectos.servContables.Ci;
                        ci.ServdeAdministrativos = cost.CostosIndirectos.ServdeAdministrativos.Ci;
                        ci.Corporativo = cost.CostosIndirectos.Corporativo.Ci;
                        ci.Papeleria = cost.CostosIndirectos.Papeleria.Ci;
                        ci.Diversos = cost.CostosIndirectos.Diversos.Ci;
                        ci.Nodeducibles = cost.CostosIndirectos.Nodeducibles.Ci;
                        ci.IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Ci;
                        ci.Pasajes = cost.CostosIndirectos.Pasajes.Ci;
                        ci.Despensa = cost.CostosIndirectos.Despensa.Ci;
                        ci.Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Ci;
                        ci.SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Ci;
                        ci.BaseDatos = cost.CostosIndirectos.BaseDatos.Ci;
                        ci.CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Ci;
                        ci.Indirecto = cost.CostosIndirectos.Indirecto.Ci;
                        ci.OCC = cost.CostosIndirectos.OCC.Ci;
                        ci.Cursos = cost.CostosIndirectos.Cursos.Ci;
                        ci.PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Ci;
                        ci.Comisiones = cost.CostosIndirectos.Comisiones.Ci;
                        ci.PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Ci;
                        ci.Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Ci;
                        ci.InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Ci;
                        ci.RentadeUPS = cost.CostosIndirectos.RentadeUPS.Ci;
                        ci.RentadePlanta = cost.CostosIndirectos.RentadePlanta.Ci;   
                        metaCon.SaveChanges();
                    }
                }

                if (re == null)
                {
                    var datosRe = new CostosIndirectosRe
                    {
                        IdCampana = cost.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        Gerencial = cost.CostosIndirectos.Gerencial.Re,
                        Operacion = cost.CostosIndirectos.Operacion.Re,
                        Depreciaciones = cost.CostosIndirectos.Depreciaciones.Re,
                        AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Re,
                        AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Re,
                        EquipoOficina = cost.CostosIndirectos.EquipoOficina.Re,
                        CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Re,
                        MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Re,
                        Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Re,
                        Diademas = cost.CostosIndirectos.Diademas.Re,
                        Renta = cost.CostosIndirectos.Renta.Re,
                        Luz = cost.CostosIndirectos.Luz.Re,
                        Agua = cost.CostosIndirectos.Agua.Re,
                        Vigilancia = cost.CostosIndirectos.Vigilancia.Re,
                        Limpieza = cost.CostosIndirectos.Limpieza.Re,
                        Edificio = cost.CostosIndirectos.Edificio.Re,
                        ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Re,
                        ServDeLegal = cost.CostosIndirectos.ServDeLegal.Re,
                        servContables = cost.CostosIndirectos.servContables.Re,
                        ServdeAdministrativos = cost.CostosIndirectos.Gerencial.Re,
                        Corporativo = cost.CostosIndirectos.Corporativo.Re,
                        Papeleria = cost.CostosIndirectos.Papeleria.Re,
                        Diversos = cost.CostosIndirectos.Diversos.Re,
                        Nodeducibles = cost.CostosIndirectos.Nodeducibles.Re,
                        IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Re,
                        Pasajes = cost.CostosIndirectos.Pasajes.Re,
                        Despensa = cost.CostosIndirectos.Despensa.Re,
                        Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Re,
                        SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Re,
                        BaseDatos = cost.CostosIndirectos.BaseDatos.Re,
                        CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Re,
                        Indirecto = cost.CostosIndirectos.Indirecto.Re,
                        OCC = cost.CostosIndirectos.OCC.Re,
                        Cursos = cost.CostosIndirectos.Cursos.Re,
                        PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Re,
                        Comisiones = cost.CostosIndirectos.Comisiones.Re,
                        PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Re,
                        Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Re,
                        InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Re,
                        RentadeUPS = cost.CostosIndirectos.RentadeUPS.Re,
                        RentadePlanta = cost.CostosIndirectos.RentadePlanta.Re,
                    };
                    _db.CostosIndirectosRe.Add(datosRe);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.CostosIndirectosRe.Attach(re);
                        re.IdCampana = cost.Campana.idCampana;
                        re.Mes = mes;
                        re.Year = an;
                        re.FechaRegistro = DateTime.Now;
                        re.Gerencial = cost.CostosIndirectos.Gerencial.Re;
                        re.Operacion = cost.CostosIndirectos.Operacion.Re;
                        re.Depreciaciones = cost.CostosIndirectos.Depreciaciones.Re;
                        re.AmortizacionesLicencias = cost.CostosIndirectos.AmortizacionesLicencias.Re;
                        re.AmortizacionesServiciosMantenimiento = cost.CostosIndirectos.AmortizacionesServiciosMantenimiento.Re;
                        re.EquipoOficina = cost.CostosIndirectos.EquipoOficina.Re;
                        re.CompraEquipoComputo = cost.CostosIndirectos.CompraEquipoComputo.Re;
                        re.MantenimientoEquipoComputo = cost.CostosIndirectos.MantenimientoEquipoComputo.Re;
                        re.Firewall_Dominio = cost.CostosIndirectos.Firewall_Dominio.Re;
                        re.Diademas = cost.CostosIndirectos.Diademas.Re;
                        re.Renta = cost.CostosIndirectos.Renta.Re;
                        re.Luz = cost.CostosIndirectos.Luz.Re;
                        re.Agua = cost.CostosIndirectos.Agua.Re;
                        re.Vigilancia = cost.CostosIndirectos.Vigilancia.Re;
                        re.Limpieza = cost.CostosIndirectos.Limpieza.Re;
                        re.Edificio = cost.CostosIndirectos.Edificio.Re;
                        re.ServAudFiscal = cost.CostosIndirectos.ServAudFiscal.Re;
                        re.ServDeLegal = cost.CostosIndirectos.ServDeLegal.Re;
                        re.servContables = cost.CostosIndirectos.servContables.Re;
                        re.ServdeAdministrativos = cost.CostosIndirectos.ServdeAdministrativos.Re;
                        re.Corporativo = cost.CostosIndirectos.Corporativo.Re;
                        re.Papeleria = cost.CostosIndirectos.Papeleria.Re;
                        re.Diversos = cost.CostosIndirectos.Diversos.Re;
                        re.Nodeducibles = cost.CostosIndirectos.Nodeducibles.Re;
                        re.IncentivosEmpleados = cost.CostosIndirectos.IncentivosEmpleados.Re;
                        re.Pasajes = cost.CostosIndirectos.Pasajes.Re;
                        re.Despensa = cost.CostosIndirectos.Despensa.Re;
                        re.Alimentos_Consumos_Gastosviaje = cost.CostosIndirectos.Alimentos_Consumos_Gastosviaje.Re;
                        re.SMS_Carteo = cost.CostosIndirectos.SMS_Carteo.Re;
                        re.BaseDatos = cost.CostosIndirectos.BaseDatos.Re;
                        re.CertificacionPCI = cost.CostosIndirectos.CertificacionPCI.Re;
                        re.Indirecto = cost.CostosIndirectos.Indirecto.Re;
                        re.OCC = cost.CostosIndirectos.OCC.Re;
                        re.Cursos = cost.CostosIndirectos.Cursos.Re;
                        re.PacketLincencias_servidores_implementaciones = cost.CostosIndirectos.PacketLincencias_servidores_implementaciones.Re;
                        re.Comisiones = cost.CostosIndirectos.Comisiones.Re;
                        re.PerdidaUtilidadCambiaria = cost.CostosIndirectos.PerdidaUtilidadCambiaria.Re;
                        re.Otrosgastos_Ingresos = cost.CostosIndirectos.Otrosgastos_Ingresos.Re;
                        re.InteresesPagados_Ganados = cost.CostosIndirectos.InteresesPagados_Ganados.Re;
                        re.RentadeUPS = cost.CostosIndirectos.RentadeUPS.Re;
                        re.RentadePlanta = cost.CostosIndirectos.RentadePlanta.Re;
                        metaCon.SaveChanges();
                    }
                }



            }
        }


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string SetReporte(string anio, string path)
        {
            //var Cons = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio).Select(x=> new { x.Id, x.proveedor}).Distinct().ToList();

            var Cons = _dbcom.Database.SqlQuery<ProveedoresVm>("EXEC dbo.GET_PROVEEDOR_ENCUESTA_COMPRAS @Anio = {0}", anio).ToList();

            //var Cons = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 12).Select(x => new {x.Id,x.IdProveedor,x.Anio }).Distinct().ToList();

            var Estatus = "";

            if ( Cons.Count > 0  )
            {

                int cantrow = Cons.Count() * 10;

                #region Genera Reporte Excel

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                xlApp.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet1;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkBook.Worksheets.Add();

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);


                //Datos Generales Hoja 0
                #region Propiedades tabla 0


                xlWorkSheet.Columns[1].ColumnWidth = 5;
                xlWorkSheet.Columns[2].ColumnWidth = 32;
                xlWorkSheet.Columns[3].ColumnWidth = 20;
                xlWorkSheet.Columns[4].ColumnWidth = 10;
                xlWorkSheet.Columns[5].ColumnWidth = 20;
                xlWorkSheet.Columns[6].ColumnWidth = 20;
                xlWorkSheet.Columns[7].ColumnWidth = 20;
                xlWorkSheet.Columns[8].ColumnWidth = 20;
                xlWorkSheet.Columns[9].ColumnWidth = 20;
                xlWorkSheet.Columns[10].ColumnWidth = 20;
                xlWorkSheet.Columns[11].ColumnWidth = 20;
                xlWorkSheet.Columns[12].ColumnWidth = 20;
                xlWorkSheet.Columns[13].ColumnWidth = 20;
                xlWorkSheet.Columns[14].ColumnWidth = 20;
                xlWorkSheet.Columns[15].ColumnWidth = 20;
                xlWorkSheet.Columns[16].ColumnWidth = 20;
                xlWorkSheet.Columns[17].ColumnWidth = 20;
                xlWorkSheet.Columns[18].ColumnWidth = 20;

                xlWorkSheet.get_Range("A1", "A" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("B1", "B" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("C1", "C" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("D1", "D" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("E1", "E" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("F1", "F" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("G1", "G" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("H1", "H" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("I1", "I" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("J1", "J" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("K1", "K" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("L1", "L" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("M1", "M" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("N1", "N" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("O1", "O" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("P1", "P" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("Q1", "Q" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("R1", "R" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;



                //Encabezados
                xlWorkSheet.Cells[5, 2] = "Nombre:";
                xlWorkSheet.Cells[5, 2].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[5, 2].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[6, 2] = "FO.COM.000.01";

              //  xlWorkSheet.Shapes.AddPicture(@"\Content\Images\logopenta.png", MsoTriState.msoFalse, MsoTriState.msoCTrue, 50, 50, 300, 45);

                xlWorkSheet.Cells[9, 2] = "Proveedor";
                xlWorkSheet.Cells[9, 2].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 2].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 3] = "Reevaluación  (SERVICIO CONFORME)";
                xlWorkSheet.Cells[9, 3].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 3].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 4] = "Clave";
                xlWorkSheet.Cells[9, 4].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 4].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 5] = "Enero";
                xlWorkSheet.Cells[9, 5].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 5].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 6] = "Febrero";
                xlWorkSheet.Cells[9, 6].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 6].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 7] = "Marzo";
                xlWorkSheet.Cells[9, 7].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 7].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 8] = "Abril";
                xlWorkSheet.Cells[9, 8].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 8].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 9] = "Mayo";
                xlWorkSheet.Cells[9, 9].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 9].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 10] = "Junio";
                xlWorkSheet.Cells[9, 10].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 10].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 11] = "Promedio Semestral";
                xlWorkSheet.Cells[9, 11].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 11].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 12] = " Julio";
                xlWorkSheet.Cells[9, 12].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 12].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 13] = "Agosto";
                xlWorkSheet.Cells[9, 13].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 13].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 14] = "Septiembre";
                xlWorkSheet.Cells[9, 14].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 14].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 15] = "Octubre";
                xlWorkSheet.Cells[9, 15].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 15].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 16] = "Noviembre";
                xlWorkSheet.Cells[9, 16].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 16].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 17] = "Diciembre";
                xlWorkSheet.Cells[9, 17].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 17].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
                xlWorkSheet.Cells[9, 18] = "Total 2do Semestre";
                xlWorkSheet.Cells[9, 18].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[9, 18].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;

                #endregion

                //Detalle hoja 0

                var ConsP = 10;

                foreach (var c in Cons)
                {
                    var prov = _dbcom.EvaluacionProveedores.Where(x => x.Anio == c.Anio && x.IdProveedor == c.IdProveedor).FirstOrDefault();
                    xlWorkSheet.Cells[ConsP, 1] = prov.Id.ToString();
                    xlWorkSheet.Cells[ConsP, 2] = c.proveedor.ToString();

                    var Semestre1 = 0.00;
                    var Semestre2 = 0.00;

                    EvaluacionesVm i1 = new EvaluacionesVm();
                    var Calculo1 = 0.00;

                    var Evalua1 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 1 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua1 != null)
                    {
                        i1 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(1.00)).FirstOrDefault();
                        var R1 = Convert.ToDouble(Evalua1.Requisitos);
                        var P1 = Convert.ToDouble(Evalua1.Precio);
                        var C1 = Convert.ToDouble(Evalua1.Condiciones);
                        var D1 = Convert.ToDouble(Evalua1.Disponibilidad);
                        var T1 = Convert.ToDouble(i1.Entregas);
                        var A1 = Convert.ToDouble(i1.Expectativas);

                        double suma1 = (R1 + P1 + C1 + D1 + T1 + A1) / 6;
                        Calculo1 = Math.Round(suma1 * 100, 2, MidpointRounding.ToEven);

                    }

                    xlWorkSheet.Cells[ConsP, 5] = Calculo1.ToString() + "%";



                    var i2 = new EvaluacionesVm();
                    var Calculo2 = 0.00;
                    var Evalua2 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 2 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua2 != null)
                    {
                        i2 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), 2).FirstOrDefault();
                        var R2 = Convert.ToDouble(Evalua2.Requisitos);
                        var P2 = Convert.ToDouble(Evalua2.Precio);
                        var C2 = Convert.ToDouble(Evalua2.Condiciones);
                        var D2 = Convert.ToDouble(Evalua2.Disponibilidad);
                        var T2 = Convert.ToDouble(i2.Entregas);
                        var A2 = Convert.ToDouble(i2.Expectativas);
                        double suma2 = (R2 + P2 + C2 + D2 + T2 + A2) / 6;
                        Calculo2 = Math.Round(suma2 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 6] = Calculo2.ToString() + "%";



                    EvaluacionesVm i3 = new EvaluacionesVm();
                    var Calculo3 = 0.00;
                    var Evalua3 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 3 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua3 != null)
                    {
                        i3 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(3)).FirstOrDefault();
                        var R3 = Convert.ToDouble(Evalua3.Requisitos);
                        var P3 = Convert.ToDouble(Evalua3.Precio);
                        var C3 = Convert.ToDouble(Evalua3.Condiciones);
                        var D3 = Convert.ToDouble(Evalua3.Disponibilidad);
                        var T3 = Convert.ToDouble(i3.Entregas);
                        var A3 = Convert.ToDouble(i3.Expectativas);
                        double suma3 = (R3 + P3 + C3 + D3 + T3 + A3) / 6;
                        Calculo3 = Math.Round(suma3 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 7] = Calculo3.ToString() + "%";


                    EvaluacionesVm i4 = new EvaluacionesVm();
                    var Calculo4 = 0.00;
                    var Evalua4 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 4 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua4 != null)
                    {
                        i4 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(4)).FirstOrDefault();
                        var R4 = Convert.ToDouble(Evalua4.Requisitos);
                        var P4 = Convert.ToDouble(Evalua4.Precio);
                        var C4 = Convert.ToDouble(Evalua4.Condiciones);
                        var D4 = Convert.ToDouble(Evalua4.Disponibilidad);
                        var T4 = Convert.ToDouble(i4.Entregas);
                        var A4 = Convert.ToDouble(i4.Expectativas);
                        double suma4 = (R4 + P4 + C4 + D4 + T4 + A4) / 6;
                        Calculo4 = Math.Round(suma4 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 8] = Calculo4.ToString() + "%";


                    EvaluacionesVm i5 = new EvaluacionesVm();
                    var Calculo5 = 0.00;
                    var Evalua5 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 5 && x.proveedor == c.proveedor).FirstOrDefault();

                    if (Evalua5 != null)
                    {
                        i5 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(5)).FirstOrDefault();
                        var R5 = Convert.ToDouble(Evalua5.Requisitos);
                        var P5 = Convert.ToDouble(Evalua5.Precio);
                        var C5 = Convert.ToDouble(Evalua5.Condiciones);
                        var D5 = Convert.ToDouble(Evalua5.Disponibilidad);
                        var T5 = Convert.ToDouble(i5.Entregas);
                        var A5 = Convert.ToDouble(i5.Expectativas);
                        double suma5 = (R5 + P5 + C5 + D5 + T5 + A5) / 6;
                        Calculo5 = Math.Round(suma5 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 9] = Calculo5.ToString() + "%";


                    EvaluacionesVm i6 = new EvaluacionesVm();
                    var Calculo6 = 0.00;
                    var Evalua6 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 6 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua6 != null)
                    {
                        i6 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(6)).FirstOrDefault();
                        var R6 = Convert.ToDouble(Evalua6.Requisitos);
                        var P6 = Convert.ToDouble(Evalua6.Precio);
                        var C6 = Convert.ToDouble(Evalua6.Condiciones);
                        var D6 = Convert.ToDouble(Evalua6.Disponibilidad);
                        var T6 = Convert.ToDouble(i6.Entregas);
                        var A6 = Convert.ToDouble(i6.Expectativas);
                        double suma6 = (R6 + P6 + C6 + D6 + T6 + A6) / 6;
                        Calculo6 = Math.Round(suma6 * 100, 2, MidpointRounding.ToEven);
                    }


                    xlWorkSheet.Cells[ConsP, 10] = Calculo6.ToString() + "%";


                    ///SEMESTRE1
                    ///
                    var sums1 = Calculo1 + Calculo2 + Calculo3 + Calculo4 + Calculo5 + Calculo6;
                    Semestre1= Math.Round(sums1 / 6, 2, MidpointRounding.ToEven);
                    xlWorkSheet.Cells[ConsP, 11] = Semestre1.ToString() + "%";



                    EvaluacionesVm i7 = new EvaluacionesVm();
                    var Calculo7 = 0.00;
                    var Evalua7 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 7 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua7 != null)
                    {
                        i7 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(7)).FirstOrDefault();
                        var R7 = Convert.ToDouble(Evalua7.Requisitos);
                        var P7 = Convert.ToDouble(Evalua7.Precio);
                        var C7 = Convert.ToDouble(Evalua7.Condiciones);
                        var D7 = Convert.ToDouble(Evalua7.Disponibilidad);
                        var T7 = Convert.ToDouble(i7.Entregas);
                        var A7 = Convert.ToDouble(i7.Expectativas);
                        double suma7 = (R7 + P7 + C7 + D7 + T7 + A7) / 6;
                        Calculo7 = Math.Round(suma7 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 12] = Calculo7.ToString() + "%";



                    EvaluacionesVm i8 = new EvaluacionesVm();
                    var Calculo8 = 0.00;
                    var Evalua8 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 8 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua8 != null)
                    {
                        i8 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(8)).FirstOrDefault();
                        var R8 = Convert.ToDouble(Evalua8.Requisitos);
                        var P8 = Convert.ToDouble(Evalua8.Precio);
                        var C8 = Convert.ToDouble(Evalua8.Condiciones);
                        var D8 = Convert.ToDouble(Evalua8.Disponibilidad);
                        var T8 = Convert.ToDouble(i8.Entregas);
                        var A8 = Convert.ToDouble(i8.Expectativas);
                        double suma8 = (R8 + P8 + C8 + D8 + T8 + A8) / 6;
                        Calculo8 = Math.Round(suma8 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 13] = Calculo8.ToString() + "%";


                    EvaluacionesVm i9 = new EvaluacionesVm();
                    var Calculo9 = 0.00;
                    var Evalua9 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 9 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua9 != null)
                    {
                        i9 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(9)).FirstOrDefault();
                        var R9 = Convert.ToDouble(Evalua9.Requisitos);
                        var P9 = Convert.ToDouble(Evalua9.Precio);
                        var C9 = Convert.ToDouble(Evalua9.Condiciones);
                        var D9 = Convert.ToDouble(Evalua9.Disponibilidad);
                        var T9 = Convert.ToDouble(i9.Entregas);
                        var A9 = Convert.ToDouble(i9.Expectativas);
                        double suma9 = (R9 + P9 + C9 + D9 + T9 + A9) / 6;
                        Calculo9 = Math.Round(suma9 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 14] = Calculo9.ToString() + "%";


                    EvaluacionesVm i10 = new EvaluacionesVm();
                    var Calculo10 = 0.00;
                    var Evalua10 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 10 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua10 != null)
                    {
                        i10 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(10)).FirstOrDefault();
                        var R10 = Convert.ToDouble(Evalua10.Requisitos);
                        var P10 = Convert.ToDouble(Evalua10.Precio);
                        var C10 = Convert.ToDouble(Evalua10.Condiciones);
                        var D10 = Convert.ToDouble(Evalua10.Disponibilidad);
                        var T10 = Convert.ToDouble(i10.Entregas);
                        var A10 = Convert.ToDouble(i10.Expectativas);
                        double suma10 = (R10 + P10 + C10 + D10 + T10 + A10) / 6;
                        Calculo10 = Math.Round(suma10 * 100, 2, MidpointRounding.ToEven);
                    }


                    xlWorkSheet.Cells[ConsP, 15] = Calculo10.ToString() + "%";


                    EvaluacionesVm i11 = new EvaluacionesVm();
                    var Calculo11 = 0.00;
                    var Evalua11 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 11 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua11 != null)
                    {
                        i11 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(11)).FirstOrDefault();
                        var R11 = Convert.ToDouble(Evalua11.Requisitos);
                        var P11 = Convert.ToDouble(Evalua11.Precio);
                        var C11 = Convert.ToDouble(Evalua11.Condiciones);
                        var D11 = Convert.ToDouble(Evalua11.Disponibilidad);
                        var T11 = Convert.ToDouble(i11.Entregas);
                        var A11 = Convert.ToDouble(i11.Expectativas);
                        double suma11 = (R11 + P11 + C11 + D11 + T11 + A11) / 6;
                        Calculo11 = Math.Round(suma11 * 100, 2, MidpointRounding.ToEven);
                    }

                    xlWorkSheet.Cells[ConsP, 16] = Calculo11.ToString() + "%";


                    EvaluacionesVm i12 = new EvaluacionesVm();
                    var Calculo12 = 0.00;
                    var Evalua12 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 12 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua12 != null)
                    {
                        i12 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(12)).FirstOrDefault();
                        var R12 = Convert.ToDouble(Evalua12.Requisitos);
                        var P12 = Convert.ToDouble(Evalua12.Precio);
                        var C12 = Convert.ToDouble(Evalua12.Condiciones);
                        var D12 = Convert.ToDouble(Evalua12.Disponibilidad);
                        var T12 = Convert.ToDouble(i12.Entregas);
                        var A12 = Convert.ToDouble(i12.Expectativas);
                        double suma12 = (R12 + P12 + C12 + D12 + T12 + A12) / 6;
                        Calculo12 = Math.Round(suma12 * 100, 2, MidpointRounding.ToEven);
                    }


                    xlWorkSheet.Cells[ConsP, 17] = Calculo12.ToString() + "%";


                    ///SEMESTRE2
                    ///
                    var sums2 = Calculo7 + Calculo8 + Calculo9 + Calculo10 + Calculo11 + Calculo12;
                    Semestre2 = Math.Round(sums2 / 6, 2, MidpointRounding.ToEven);
                    xlWorkSheet.Cells[ConsP, 18] = Semestre2.ToString() + "%";



                    ConsP++;
                }


                //Comentarios

                xlWorkSheet.Cells[ConsP + 5, 2] = "ANÁLISIS DE PROVEEDORES SEMESTRAL";
                xlWorkSheet.Cells[ConsP + 5, 2].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[ConsP + 5, 2].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkOrange;

                xlWorkSheet.Cells[ConsP + 6, 2] = "NOTA 1: Los proveedores institucionales se consideran a partir de la 3 compra y con un monto superior a $500,000.00 mn semestrales";


                xlWorkSheet.Cells[ConsP + 7, 2] = "ANÁLISIS DE PROVEEDORES SEMESTRAL";
                xlWorkSheet.Cells[ConsP + 7, 2].Font.Color = System.Drawing.Color.White;
                xlWorkSheet.Cells[ConsP + 7, 2].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkOrange;

                xlWorkSheet.Cells[ConsP + 8, 2] = "De acuerdo a las evaluaciones aplicadas  a los proveedores organizacionales se detecta que del periodo de Enero-Diciembre 2021 todos cumplen con lo requerido para la organización. Por lo que de acuerdo al proceso de compras no es necesario proporcionar ningun tipo de retroalimentación o sanción";

                //Datos Generales Hoja 1
                #region propiedades tabla 1
                //Propiedades de tabla

                xlWorkSheet1.Columns[1].ColumnWidth = 5;
                xlWorkSheet1.Columns[2].ColumnWidth = 32;
                xlWorkSheet1.Columns[3].ColumnWidth = 45;
                xlWorkSheet1.Columns[4].ColumnWidth = 10;
                xlWorkSheet1.Columns[5].ColumnWidth = 10;
                xlWorkSheet1.Columns[6].ColumnWidth = 10;
                xlWorkSheet1.Columns[7].ColumnWidth = 10;
                xlWorkSheet1.Columns[8].ColumnWidth = 10;
                xlWorkSheet1.Columns[9].ColumnWidth = 10;
                xlWorkSheet1.Columns[10].ColumnWidth = 10;
                xlWorkSheet1.Columns[11].ColumnWidth = 10;
                xlWorkSheet1.Columns[12].ColumnWidth = 10;
                xlWorkSheet1.Columns[13].ColumnWidth = 10;
                xlWorkSheet1.Columns[14].ColumnWidth = 10;
                xlWorkSheet1.Columns[15].ColumnWidth = 10;


                xlWorkSheet1.get_Range("A1", "A"+ cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("B1", "B"+ cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("C1", "C"+ cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("D1", "D"+ cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("E1", "E" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("F1", "F" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("G1", "G" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("H1", "H" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("I1", "I" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("J1", "J" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("K1", "K" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("L1", "L" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("M1", "M" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("N1", "N" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet1.get_Range("O1", "O" + cantrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                

                #endregion


                int val = 1;

                foreach (var c in Cons)
                {

                    var gene = _dbcom.EvaluacionProveedores.Where(x => x.Anio == c.Anio && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    xlWorkSheet1.Cells[val, 1] = gene.Id.ToString();
                    xlWorkSheet1.Cells[val + 1, 1] = "";
                    xlWorkSheet1.Cells[val + 2, 1] = "";
                    xlWorkSheet1.Cells[val + 3, 1] = "";
                    xlWorkSheet1.Cells[val + 4, 1] = "";
                    xlWorkSheet1.Cells[val + 5, 1] = "";
                    xlWorkSheet1.Cells[val + 6, 1] = "";
                    xlWorkSheet1.Cells[val + 7, 1] = "";
                    xlWorkSheet1.Cells[val + 8, 1] = "";

                    xlWorkSheet1.Cells[val, 2] = c.proveedor.ToString();
                    xlWorkSheet1.Cells[val + 1, 2] = "";
                    xlWorkSheet1.Cells[val + 2, 2] = "";
                    xlWorkSheet1.Cells[val + 3, 2] = "";
                    xlWorkSheet1.Cells[val + 4, 2] = "";
                    xlWorkSheet1.Cells[val + 5, 2] = "";
                    xlWorkSheet1.Cells[val + 6, 2] = "";
                    xlWorkSheet1.Cells[val + 7, 2] = "";
                    xlWorkSheet1.Cells[val + 8, 2] = "";

                    xlWorkSheet1.Cells[val, 3] = "";
                    xlWorkSheet1.Cells[val + 1, 3] = "Requisitos ficales, legales, y CV del proveedor";
                    xlWorkSheet1.Cells[val + 2, 3] = "Precio más bajo *";
                    xlWorkSheet1.Cells[val + 3, 3] = "Condiciones comerciales, (crédito 30 días)";
                    xlWorkSheet1.Cells[val + 4, 3] = "Disponibilidad del producto y/o servicio ";
                    xlWorkSheet1.Cells[val + 5, 3] = "Tiempo de entrega ";
                    xlWorkSheet1.Cells[val + 6, 3] = "Atención al cliente (nivel de servicio)";
                    xlWorkSheet1.Cells[val + 7, 3] = "";
                    xlWorkSheet1.Cells[val + 8, 3] = "";



                    //Declaramos variables 
                    EvaluacionesVm i1 = new EvaluacionesVm();
                    var Calculo1 = 0.00;

                    var Evalua1 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 1 && x.IdProveedor==c.IdProveedor).FirstOrDefault();              

                    if (Evalua1!=null)
                    {
                        i1 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(1.00)).FirstOrDefault();
                        var R1 = Convert.ToDouble(Evalua1.Requisitos);
                        var P1 = Convert.ToDouble(Evalua1.Precio);
                        var C1 = Convert.ToDouble(Evalua1.Condiciones);
                        var D1 = Convert.ToDouble(Evalua1.Disponibilidad);
                        var T1 = Convert.ToDouble(i1.Entregas);
                        var A1 = Convert.ToDouble(i1.Expectativas);

                        double suma1 = (R1 + P1 + C1 + D1 + T1 + A1) / 6;
                        Calculo1 = Math.Round(suma1 * 100, 2, MidpointRounding.ToEven);

                    }





                    // MESES
                    //var M1 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes==1 && x.).FirstOrDefault();

                    xlWorkSheet1.get_Range("D" + val, "D" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    if (Evalua1 != null)
                    {
                        
                        

                        xlWorkSheet1.Cells[val, 4] = "Enero";
                        xlWorkSheet1.Cells[val + 1, 4] = Convert.ToInt32(Evalua1.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 4] = Convert.ToInt32(Evalua1.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 4] = Convert.ToInt32(Evalua1.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 4] = Convert.ToInt32(Evalua1.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 4] = Convert.ToInt32(i1.Entregas).ToString(); 
                        xlWorkSheet1.Cells[val + 6, 4] = Convert.ToInt32(i1.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 4] = Calculo1.ToString()+"%";
                        xlWorkSheet1.Cells[val + 8, 4] = "";
                    }
                    else
                    {                        
                        xlWorkSheet1.Cells[val, 4] = "Enero";
                        xlWorkSheet1.Cells[val + 1, 4] = "";
                        xlWorkSheet1.Cells[val + 2, 4] = "";
                        xlWorkSheet1.Cells[val + 3, 4] = "";
                        xlWorkSheet1.Cells[val + 4, 4] = "";
                        xlWorkSheet1.Cells[val + 5, 4] = "";
                        xlWorkSheet1.Cells[val + 6, 4] = "";
                        xlWorkSheet1.Cells[val + 7, 4] = "";
                        xlWorkSheet1.Cells[val + 8, 4] = "";
                    }

                    xlWorkSheet1.get_Range("E" + val, "E" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;


                    var i2 = new EvaluacionesVm();
                    var Calculo2 = 0.00;
                    var Evalua2 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 2 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua2 != null)
                    {
                        i2 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), 2).FirstOrDefault();
                        var R2 = Convert.ToDouble(Evalua2.Requisitos);
                        var P2 = Convert.ToDouble(Evalua2.Precio);
                        var C2 = Convert.ToDouble(Evalua2.Condiciones);
                        var D2 = Convert.ToDouble(Evalua2.Disponibilidad);
                        var T2 = Convert.ToDouble(i2.Entregas);
                        var A2 = Convert.ToDouble(i2.Expectativas);
                        double suma2 = (R2 + P2 + C2 + D2 + T2 + A2) / 6;
                        Calculo2 = Math.Round(suma2 * 100, 2, MidpointRounding.ToEven);
                    }



                    if (Evalua2 != null)
                    {                        

                        xlWorkSheet1.Cells[val, 5] = "Febrero";
                        xlWorkSheet1.Cells[val + 1, 5] = Convert.ToInt32(Evalua2.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 5] = Convert.ToInt32(Evalua2.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 5] = Convert.ToInt32(Evalua2.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 5] = Convert.ToInt32(Evalua2.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 5] = Convert.ToInt32(i2.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 5] = Convert.ToInt32(i2.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 5] = Calculo2.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 5] = "";
                    }
                    else
                    {                        

                        xlWorkSheet1.Cells[val, 5] = "Febrero";
                        xlWorkSheet1.Cells[val + 1, 5] = "";
                        xlWorkSheet1.Cells[val + 2, 5] = "";
                        xlWorkSheet1.Cells[val + 3, 5] = "";
                        xlWorkSheet1.Cells[val + 4, 5] = "";
                        xlWorkSheet1.Cells[val + 5, 5] = "";
                        xlWorkSheet1.Cells[val + 6, 5] = "";
                        xlWorkSheet1.Cells[val + 7, 5] = "";
                        xlWorkSheet1.Cells[val + 8, 5] = "";
                    }

                    xlWorkSheet1.get_Range("F" + val, "F" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i3 = new EvaluacionesVm();
                    var Calculo3 = 0.00;
                    var Evalua3 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 3 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua3 != null)
                    {
                        i3 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(3)).FirstOrDefault();
                        var R3 = Convert.ToDouble(Evalua3.Requisitos);
                        var P3 = Convert.ToDouble(Evalua3.Precio);
                        var C3 = Convert.ToDouble(Evalua3.Condiciones);
                        var D3 = Convert.ToDouble(Evalua3.Disponibilidad);
                        var T3 = Convert.ToDouble(i3.Entregas);
                        var A3 = Convert.ToDouble(i3.Expectativas);
                        double suma3 = (R3 + P3 + C3 + D3 + T3 + A3) / 6;
                        Calculo3 = Math.Round(suma3 * 100, 2, MidpointRounding.ToEven);
                    }



                    if (Evalua3 != null)
                    {
                        xlWorkSheet1.Cells[val, 6] = "Marzo";
                        xlWorkSheet1.Cells[val + 1, 6] = Convert.ToInt32(Evalua3.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 6] = Convert.ToInt32(Evalua3.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 6] = Convert.ToInt32(Evalua3.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 6] = Convert.ToInt32(Evalua3.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 6] = Convert.ToInt32(i3.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 6] = Convert.ToInt32(i3.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 6] = Calculo3.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 6] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 6] = "Marzo";
                        xlWorkSheet1.Cells[val + 1, 6] = "";
                        xlWorkSheet1.Cells[val + 2, 6] = "";
                        xlWorkSheet1.Cells[val + 3, 6] = "";
                        xlWorkSheet1.Cells[val + 4, 6] = "";
                        xlWorkSheet1.Cells[val + 5, 6] = "";
                        xlWorkSheet1.Cells[val + 6, 6] = "";
                        xlWorkSheet1.Cells[val + 7, 6] = "";
                        xlWorkSheet1.Cells[val + 8, 6] = "";
                    }


                    xlWorkSheet1.get_Range("G" + val, "G" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i4 = new EvaluacionesVm();
                    var Calculo4 = 0.00;
                    var Evalua4 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 4 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua4 != null)
                    {
                        i4 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(4)).FirstOrDefault();
                        var R4 = Convert.ToDouble(Evalua4.Requisitos);
                        var P4 = Convert.ToDouble(Evalua4.Precio);
                        var C4 = Convert.ToDouble(Evalua4.Condiciones);
                        var D4 = Convert.ToDouble(Evalua4.Disponibilidad);
                        var T4 = Convert.ToDouble(i4.Entregas);
                        var A4 = Convert.ToDouble(i4.Expectativas);
                        double suma4 = (R4 + P4 + C4 + D4 + T4 + A4) / 6;
                        Calculo4 = Math.Round(suma4 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua4 != null)
                    {
                        xlWorkSheet1.Cells[val, 7] = "Abril";
                        xlWorkSheet1.Cells[val + 1, 7] = Convert.ToInt32(Evalua4.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 7] = Convert.ToInt32(Evalua4.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 7] = Convert.ToInt32(Evalua4.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 7] = Convert.ToInt32(Evalua4.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 7] = Convert.ToInt32(i4.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 7] = Convert.ToInt32(i4.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 7] = Calculo4.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 7] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 7] = "Abril";
                        xlWorkSheet1.Cells[val + 1, 7] = "";
                        xlWorkSheet1.Cells[val + 2, 7] = "";
                        xlWorkSheet1.Cells[val + 3, 7] = "";
                        xlWorkSheet1.Cells[val + 4, 7] = "";
                        xlWorkSheet1.Cells[val + 5, 7] = "";
                        xlWorkSheet1.Cells[val + 6, 7] = "";
                        xlWorkSheet1.Cells[val + 7, 7] = "";
                        xlWorkSheet1.Cells[val + 8, 7] = "";
                    }


                    xlWorkSheet1.get_Range("H" + val, "H" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i5 = new EvaluacionesVm();
                    var Calculo5 = 0.00;
                    var Evalua5 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 5 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua5 != null)
                    {
                        i5 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(5)).FirstOrDefault();
                        var R5 = Convert.ToDouble(Evalua5.Requisitos);
                        var P5 = Convert.ToDouble(Evalua5.Precio);
                        var C5 = Convert.ToDouble(Evalua5.Condiciones);
                        var D5 = Convert.ToDouble(Evalua5.Disponibilidad);
                        var T5 = Convert.ToDouble(i5.Entregas);
                        var A5 = Convert.ToDouble(i5.Expectativas);
                        double suma5 = (R5 + P5 + C5 + D5 + T5 + A5) / 6;
                        Calculo5 = Math.Round(suma5 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua5 != null)
                    {
                        xlWorkSheet1.Cells[val, 8] = "Mayo";
                        xlWorkSheet1.Cells[val + 1, 8] = Convert.ToInt32(Evalua5.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 8] = Convert.ToInt32(Evalua5.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 8] = Convert.ToInt32(Evalua5.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 8] = Convert.ToInt32(Evalua5.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 8] = Convert.ToInt32(i5.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 8] = Convert.ToInt32(i5.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 8] = Calculo5.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 8] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 8] = "Mayo";
                        xlWorkSheet1.Cells[val + 1, 8] = "";
                        xlWorkSheet1.Cells[val + 2, 8] = "";
                        xlWorkSheet1.Cells[val + 3, 8] = "";
                        xlWorkSheet1.Cells[val + 4, 8] = "";
                        xlWorkSheet1.Cells[val + 5, 8] = "";
                        xlWorkSheet1.Cells[val + 6, 8] = "";
                        xlWorkSheet1.Cells[val + 7, 8] = "";
                        xlWorkSheet1.Cells[val + 8, 8] = "";
                    }


                    xlWorkSheet1.get_Range("I" + val, "I" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i6 = new EvaluacionesVm();
                    var Calculo6 = 0.00;
                    var Evalua6 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 6 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua6 != null)
                    {
                        i6 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(6)).FirstOrDefault();
                        var R6 = Convert.ToDouble(Evalua6.Requisitos);
                        var P6 = Convert.ToDouble(Evalua6.Precio);
                        var C6 = Convert.ToDouble(Evalua6.Condiciones);
                        var D6 = Convert.ToDouble(Evalua6.Disponibilidad);
                        var T6 = Convert.ToDouble(i6.Entregas);
                        var A6 = Convert.ToDouble(i6.Expectativas);
                        double suma6 = (R6 + P6 + C6 + D6 + T6 + A6) / 6;
                        Calculo6 = Math.Round(suma6 * 100, 2, MidpointRounding.ToEven);
                    }


                    if (Evalua6 != null)
                    {
                        xlWorkSheet1.Cells[val, 9] = "Junio";
                        xlWorkSheet1.Cells[val + 1, 9] = Convert.ToInt32(Evalua6.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 9] = Convert.ToInt32(Evalua6.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 9] = Convert.ToInt32(Evalua6.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 9] = Convert.ToInt32(Evalua6.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 9] = Convert.ToInt32(i6.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 9] = Convert.ToInt32(i6.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 9] = Calculo6.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 9] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 9] = "Junio";
                        xlWorkSheet1.Cells[val + 1, 9] = "";
                        xlWorkSheet1.Cells[val + 2, 9] = "";
                        xlWorkSheet1.Cells[val + 3, 9] = "";
                        xlWorkSheet1.Cells[val + 4, 9] = "";
                        xlWorkSheet1.Cells[val + 5, 9] = "";
                        xlWorkSheet1.Cells[val + 6, 9] = "";
                        xlWorkSheet1.Cells[val + 7, 9] = "";
                        xlWorkSheet1.Cells[val + 8, 9] = "";
                    }

                    xlWorkSheet1.get_Range("J" + val, "J" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i7 = new EvaluacionesVm();
                    var Calculo7 = 0.00;
                    var Evalua7 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 7 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua7 != null)
                    {
                        i7 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(7)).FirstOrDefault();
                        var R7 = Convert.ToDouble(Evalua7.Requisitos);
                        var P7 = Convert.ToDouble(Evalua7.Precio);
                        var C7 = Convert.ToDouble(Evalua7.Condiciones);
                        var D7 = Convert.ToDouble(Evalua7.Disponibilidad);
                        var T7 = Convert.ToDouble(i7.Entregas);
                        var A7 = Convert.ToDouble(i7.Expectativas);
                        double suma7 = (R7 + P7 + C7 + D7 + T7 + A7) / 6;
                        Calculo7 = Math.Round(suma7 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua7 != null)
                    {
                        xlWorkSheet1.Cells[val, 10] = "Julio";
                        xlWorkSheet1.Cells[val + 1, 10] = Convert.ToInt32(Evalua7.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 10] = Convert.ToInt32(Evalua7.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 10] = Convert.ToInt32(Evalua7.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 10] = Convert.ToInt32(Evalua7.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 10] = Convert.ToInt32(i7.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 10] = Convert.ToInt32(i7.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 10] = Calculo7.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 10] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 10] = "Julio";
                        xlWorkSheet1.Cells[val + 1, 10] = "";
                        xlWorkSheet1.Cells[val + 2, 10] = "";
                        xlWorkSheet1.Cells[val + 3, 10] = "";
                        xlWorkSheet1.Cells[val + 4, 10] = "";
                        xlWorkSheet1.Cells[val + 5, 10] = "";
                        xlWorkSheet1.Cells[val + 6, 10] = "";
                        xlWorkSheet1.Cells[val + 7, 10] = "";
                        xlWorkSheet1.Cells[val + 8, 10] = "";
                    }


                    xlWorkSheet1.get_Range("K" + val, "K" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i8 = new EvaluacionesVm();
                    var Calculo8 = 0.00;
                    var Evalua8 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 8 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua8 != null)
                    {
                        i8 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(8)).FirstOrDefault();
                        var R8 = Convert.ToDouble(Evalua8.Requisitos);
                        var P8 = Convert.ToDouble(Evalua8.Precio);
                        var C8 = Convert.ToDouble(Evalua8.Condiciones);
                        var D8 = Convert.ToDouble(Evalua8.Disponibilidad);
                        var T8 = Convert.ToDouble(i8.Entregas);
                        var A8 = Convert.ToDouble(i8.Expectativas);
                        double suma8 = (R8 + P8 + C8 + D8 + T8 + A8) / 6;
                        Calculo8 = Math.Round(suma8 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua8 != null)
                    {
                        xlWorkSheet1.Cells[val, 11] = "Agosto";
                        xlWorkSheet1.Cells[val + 1, 11] = Convert.ToInt32(Evalua8.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 11] = Convert.ToInt32(Evalua8.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 11] = Convert.ToInt32(Evalua8.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 11] = Convert.ToInt32(Evalua8.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 11] = Convert.ToInt32(i6.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 11] = Convert.ToInt32(i6.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 11] = Calculo6.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 11] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 11] = "Agosto";
                        xlWorkSheet1.Cells[val + 1, 11] = "";
                        xlWorkSheet1.Cells[val + 2, 11] = "";
                        xlWorkSheet1.Cells[val + 3, 11] = "";
                        xlWorkSheet1.Cells[val + 4, 11] = "";
                        xlWorkSheet1.Cells[val + 5, 11] = "";
                        xlWorkSheet1.Cells[val + 6, 11] = "";
                        xlWorkSheet1.Cells[val + 7, 11] = "";
                        xlWorkSheet1.Cells[val + 8, 11] = "";
                    }


                    xlWorkSheet1.get_Range("L" + val, "L" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i9 = new EvaluacionesVm();
                    var Calculo9 = 0.00;
                    var Evalua9 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 9 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua9 != null)
                    {
                        i9 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(9)).FirstOrDefault();
                        var R9 = Convert.ToDouble(Evalua9.Requisitos);
                        var P9 = Convert.ToDouble(Evalua9.Precio);
                        var C9 = Convert.ToDouble(Evalua9.Condiciones);
                        var D9 = Convert.ToDouble(Evalua9.Disponibilidad);
                        var T9 = Convert.ToDouble(i9.Entregas);
                        var A9 = Convert.ToDouble(i9.Expectativas);
                        double suma9 = (R9 + P9 + C9 + D9 + T9 + A9) / 6;
                        Calculo9 = Math.Round(suma9 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua9 != null)
                    {
                        xlWorkSheet1.Cells[val, 12] = "Septiembre";
                        xlWorkSheet1.Cells[val + 1, 12] = Convert.ToInt32(Evalua9.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 12] = Convert.ToInt32(Evalua9.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 12] = Convert.ToInt32(Evalua9.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 12] = Convert.ToInt32(Evalua9.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 12] = Convert.ToInt32(i9.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 12] = Convert.ToInt32(i9.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 12] = Calculo9.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 12] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 12] = "Septiembre";
                        xlWorkSheet1.Cells[val + 1, 12] = "";
                        xlWorkSheet1.Cells[val + 2, 12] = "";
                        xlWorkSheet1.Cells[val + 3, 12] = "";
                        xlWorkSheet1.Cells[val + 4, 12] = "";
                        xlWorkSheet1.Cells[val + 5, 12] = "";
                        xlWorkSheet1.Cells[val + 6, 12] = "";
                        xlWorkSheet1.Cells[val + 7, 12] = "";
                        xlWorkSheet1.Cells[val + 8, 12] = "";
                    }

                    xlWorkSheet1.get_Range("M" + val, "M" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i10 = new EvaluacionesVm();
                    var Calculo10 = 0.00;
                    var Evalua10 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 10 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua10 != null)
                    {
                        i10 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(10)).FirstOrDefault();
                        var R10 = Convert.ToDouble(Evalua10.Requisitos);
                        var P10 = Convert.ToDouble(Evalua10.Precio);
                        var C10 = Convert.ToDouble(Evalua10.Condiciones);
                        var D10 = Convert.ToDouble(Evalua10.Disponibilidad);
                        var T10 = Convert.ToDouble(i10.Entregas);
                        var A10 = Convert.ToDouble(i10.Expectativas);
                        double suma10 = (R10 + P10 + C10 + D10 + T10 + A10) / 6;
                        Calculo10 = Math.Round(suma10 * 100, 2, MidpointRounding.ToEven);
                    }


                    if (Evalua10 != null)
                    {
                        xlWorkSheet1.Cells[val, 13] = "Octubre";
                        xlWorkSheet1.Cells[val + 1, 13] = Convert.ToInt32(Evalua10.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 13] = Convert.ToInt32(Evalua10.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 13] = Convert.ToInt32(Evalua10.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 13] = Convert.ToInt32(Evalua10.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 13] = Convert.ToInt32(i10.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 13] = Convert.ToInt32(i10.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 13] = Calculo10.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 13] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 13] = "Octubre";
                        xlWorkSheet1.Cells[val + 1, 13] = "";
                        xlWorkSheet1.Cells[val + 2, 13] = "";
                        xlWorkSheet1.Cells[val + 3, 13] = "";
                        xlWorkSheet1.Cells[val + 4, 13] = "";
                        xlWorkSheet1.Cells[val + 5, 13] = "";
                        xlWorkSheet1.Cells[val + 6, 13] = "";
                        xlWorkSheet1.Cells[val + 7, 13] = "";
                        xlWorkSheet1.Cells[val + 8, 13] = "";
                    }

                    xlWorkSheet1.get_Range("N" + val, "N" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i11 = new EvaluacionesVm();
                    var Calculo11 = 0.00;
                    var Evalua11 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 11 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua11 != null)
                    {
                        i11 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(11)).FirstOrDefault();
                        var R11 = Convert.ToDouble(Evalua11.Requisitos);
                        var P11 = Convert.ToDouble(Evalua11.Precio);
                        var C11 = Convert.ToDouble(Evalua11.Condiciones);
                        var D11 = Convert.ToDouble(Evalua11.Disponibilidad);
                        var T11 = Convert.ToDouble(i11.Entregas);
                        var A11 = Convert.ToDouble(i11.Expectativas);
                        double suma11 = (R11 + P11 + C11 + D11 + T11 + A11) / 6;
                        Calculo11 = Math.Round(suma11 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua11 != null)
                    {
                        xlWorkSheet1.Cells[val, 14] = "Noviembre";
                        xlWorkSheet1.Cells[val + 1, 14] = Convert.ToInt32(Evalua11.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 14] = Convert.ToInt32(Evalua11.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 14] = Convert.ToInt32(Evalua11.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 14] = Convert.ToInt32(Evalua11.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 14] = Convert.ToInt32(i11.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 14] = Convert.ToInt32(i11.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 14] = Calculo11.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 14] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 14] = "Noviembre";
                        xlWorkSheet1.Cells[val + 1, 14] = "";
                        xlWorkSheet1.Cells[val + 2, 14] = "";
                        xlWorkSheet1.Cells[val + 3, 14] = "";
                        xlWorkSheet1.Cells[val + 4, 14] = "";
                        xlWorkSheet1.Cells[val + 5, 14] = "";
                        xlWorkSheet1.Cells[val + 6, 14] = "";
                        xlWorkSheet1.Cells[val + 7, 14] = "";
                        xlWorkSheet1.Cells[val + 8, 14] = "";
                    }

                    xlWorkSheet1.get_Range("O" + val, "O" + (val + 7)).Cells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

                    EvaluacionesVm i12 = new EvaluacionesVm();
                    var Calculo12 = 0.00;
                    var Evalua12 = _dbcom.EvaluacionProveedores.Where(x => x.Anio == anio && x.Mes == 12 && x.IdProveedor == c.IdProveedor).FirstOrDefault();

                    if (Evalua12 != null)
                    {
                        i12 = _db.Database.SqlQuery<EvaluacionesVm>("dbo.sp_GetEvaluacionProve @Prove={0}, @Ano={1},@mes={2} ", c.proveedor, Convert.ToInt32(c.Anio), Convert.ToInt32(12)).FirstOrDefault();
                        var R12 = Convert.ToDouble(Evalua12.Requisitos);
                        var P12 = Convert.ToDouble(Evalua12.Precio);
                        var C12 = Convert.ToDouble(Evalua12.Condiciones);
                        var D12 = Convert.ToDouble(Evalua12.Disponibilidad);
                        var T12 = Convert.ToDouble(i12.Entregas);
                        var A12 = Convert.ToDouble(i12.Expectativas);
                        double suma12 = (R12 + P12 + C12 + D12 + T12 + A12) / 6;
                        Calculo12 = Math.Round(suma12 * 100, 2, MidpointRounding.ToEven);
                    }

                    if (Evalua12 != null)
                    {
                        xlWorkSheet1.Cells[val, 15] = "Diciembre";
                        xlWorkSheet1.Cells[val + 1, 15] = Convert.ToInt32(Evalua12.Requisitos).ToString();
                        xlWorkSheet1.Cells[val + 2, 15] = Convert.ToInt32(Evalua12.Precio).ToString();
                        xlWorkSheet1.Cells[val + 3, 15] = Convert.ToInt32(Evalua12.Condiciones).ToString();
                        xlWorkSheet1.Cells[val + 4, 15] = Convert.ToInt32(Evalua12.Disponibilidad).ToString();
                        xlWorkSheet1.Cells[val + 5, 15] = Convert.ToInt32(i12.Entregas).ToString();
                        xlWorkSheet1.Cells[val + 6, 15] = Convert.ToInt32(i12.Expectativas).ToString();
                        xlWorkSheet1.Cells[val + 7, 15] = Calculo12.ToString() + "%";
                        xlWorkSheet1.Cells[val + 8, 15] = "";
                    }
                    else
                    {
                        xlWorkSheet1.Cells[val, 15] = "Diciembre";
                        xlWorkSheet1.Cells[val + 1, 15] = "";
                        xlWorkSheet1.Cells[val + 2, 15] = "";
                        xlWorkSheet1.Cells[val + 3, 15] = "";
                        xlWorkSheet1.Cells[val + 4, 15] = "";
                        xlWorkSheet1.Cells[val + 5, 15] = "";
                        xlWorkSheet1.Cells[val + 6, 15] = "";
                        xlWorkSheet1.Cells[val + 7, 15] = "";
                        xlWorkSheet1.Cells[val + 8, 15] = "";
                    }


                    val = val + 9;

                }
                           

                //Here saving the file in xlsx
                var fileName = Path.GetFileName("Proveedores_" + anio.ToString() + ".xlsx");

                xlWorkBook.SaveAs(path + fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet1);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
                #endregion

                Estatus = "Generado";


            }

            if (Estatus != "Generado")
            {
                Estatus = "Existe un problema para generar el reporte, favor de validar!";
            }

            if (Cons.Count == 0)
            {
                Estatus = "No hay información de ese Periodo!";
            }

            return Estatus;
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public class EvaluacionesVm
        {
            public int Expectativas { get; set; }
            public int Entregas { get; set; }

        }

    }

  
}