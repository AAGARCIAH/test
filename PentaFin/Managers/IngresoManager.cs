using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PentaFinances.Dtos;
using PentaFinances.Models;

namespace PentaFinances.Managers
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class IngresoManager
    {
        PentaFinContext _db = new PentaFinContext();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void SetIngresoByList(List<IngresosDto> ingreso, int mes, int an)
        {
            foreach (var ing in ingreso)
            {
                var bi =
                    _db.Database.SqlQuery<IngresoBi>("dbo.sp_GetBiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                var op =
                    _db.Database.SqlQuery<IngresoOp>("dbo.sp_GetOpDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<IngresoCi>("dbo.sp_GetCiDetById @idCampana = {0}, @Mes = {1}, @Year = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                if (bi == null)
                {
                    var datosBi = new IngresoBi
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        DiasServicio = ing.Ingreso.DiasServicio.Bi,
                        HorasServicio = ing.Ingreso.HorasServicio.Bi,
                        LlamadasAcd = ing.Ingreso.LlamadasAcd.Bi,
                        LlamadasIvr = ing.Ingreso.LlamadasIvr.Bi,
                        LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Bi,
                        LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Bi,
                        LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Bi,
                        LlamadasSalida = ing.Ingreso.LlamadasSalida.Bi,
                        Chat = ing.Ingreso.Chat.Bi,
                        Sms = ing.Ingreso.Sms.Bi,
                        Email = ing.Ingreso.Email.Bi,
                        NivelServicio = ing.Ingreso.NivelServicio.Bi,
                        Abandono = ing.Ingreso.Abandono.Bi,
                        Asa = ing.Ingreso.Asa.Bi,
                        Aht = ing.Ingreso.Aht.Bi,
                        Sph = ing.Ingreso.Sph.Bi,
                        MinutosEntrada = ing.Ingreso.MinutosEntrada.Bi,
                        MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Bi,
                        MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Bi,
                        Ocupacion = ing.Ingreso.Ocupacion.Bi,
                        Adherencia = ing.Ingreso.Adherencia.Bi,
                        Ausentismo = ing.Ingreso.Ausentismo.Bi,
                        Rotacion = ing.Ingreso.Rotacion.Bi,
                        HorasConexion = ing.Ingreso.HorasConexion.Bi,
                        HorasPagadas = ing.Ingreso.HorasPagadas.Bi
                    };
                    _db.IngresoBi.Add(datosBi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresoBi.Attach(bi);
                        bi.IdCampana = ing.Campana.idCampana;
                        bi.Mes = mes;
                        bi.Year = an;
                        bi.FechaRegistro = DateTime.Now;
                        bi.DiasServicio = ing.Ingreso.DiasServicio.Bi;
                        bi.HorasServicio = ing.Ingreso.HorasServicio.Bi;
                        bi.LlamadasAcd = ing.Ingreso.LlamadasAcd.Bi;
                        bi.LlamadasIvr = ing.Ingreso.LlamadasIvr.Bi;
                        bi.LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Bi;
                        bi.LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Bi;
                        bi.LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Bi;
                        bi.LlamadasSalida = ing.Ingreso.LlamadasSalida.Bi;
                        bi.Chat = ing.Ingreso.Chat.Bi;
                        bi.Sms = ing.Ingreso.Sms.Bi;
                        bi.Email = ing.Ingreso.Email.Bi;
                        bi.NivelServicio = ing.Ingreso.NivelServicio.Bi;
                        bi.Abandono = ing.Ingreso.Abandono.Bi;
                        bi.Asa = ing.Ingreso.Asa.Bi;
                        bi.Aht = ing.Ingreso.Aht.Bi;
                        bi.Sph = ing.Ingreso.Sph.Bi;
                        bi.MinutosEntrada = ing.Ingreso.MinutosEntrada.Bi;
                        bi.MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Bi;
                        bi.MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Bi;
                        bi.Ocupacion = ing.Ingreso.Ocupacion.Bi;
                        bi.Adherencia = ing.Ingreso.Adherencia.Bi;
                        bi.Ausentismo = ing.Ingreso.Ausentismo.Bi;
                        bi.Rotacion = ing.Ingreso.Rotacion.Bi;
                        bi.HorasConexion = ing.Ingreso.HorasConexion.Bi;
                        bi.HorasPagadas = ing.Ingreso.HorasPagadas.Bi;
                        metaCon.SaveChanges();
                    }
                }

                if (op == null)
                {
                    var datosOp = new IngresoOp
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        DiasServicio = ing.Ingreso.DiasServicio.Op,
                        HorasServicio = ing.Ingreso.HorasServicio.Op,
                        LlamadasAcd = ing.Ingreso.LlamadasAcd.Op,
                        LlamadasIvr = ing.Ingreso.LlamadasIvr.Op,
                        LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Op,
                        LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Op,
                        LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Op,
                        LlamadasSalida = ing.Ingreso.LlamadasSalida.Op,
                        Chat = ing.Ingreso.Chat.Op,
                        Sms = ing.Ingreso.Sms.Op,
                        Email = ing.Ingreso.Email.Op,
                        NivelServicio = ing.Ingreso.NivelServicio.Op,
                        Abandono = ing.Ingreso.Abandono.Op,
                        Asa = ing.Ingreso.Asa.Op,
                        Aht = ing.Ingreso.Aht.Op,
                        Sph = ing.Ingreso.Sph.Op,
                        MinutosEntrada = ing.Ingreso.MinutosEntrada.Op,
                        MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Op,
                        MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Op,
                        Ocupacion = ing.Ingreso.Ocupacion.Op,
                        Adherencia = ing.Ingreso.Adherencia.Op,
                        Ausentismo = ing.Ingreso.Ausentismo.Op,
                        Rotacion = ing.Ingreso.Rotacion.Op,
                        HorasConexion = ing.Ingreso.HorasConexion.Op,
                        HorasPagadas = ing.Ingreso.HorasPagadas.Op
                    };
                    _db.IngresoOp.Add(datosOp);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresoOp.Attach(op);
                        op.IdCampana = ing.Campana.idCampana;
                        op.Mes = mes;
                        op.Year = an;
                        op.FechaRegistro = DateTime.Now;
                        op.DiasServicio = ing.Ingreso.DiasServicio.Op;
                        op.HorasServicio = ing.Ingreso.HorasServicio.Op;
                        op.LlamadasAcd = ing.Ingreso.LlamadasAcd.Op;
                        op.LlamadasIvr = ing.Ingreso.LlamadasIvr.Op;
                        op.LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Op;
                        op.LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Op;
                        op.LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Op;
                        op.LlamadasSalida = ing.Ingreso.LlamadasSalida.Op;
                        op.Chat = ing.Ingreso.Chat.Op;
                        op.Sms = ing.Ingreso.Sms.Op;
                        op.Email = ing.Ingreso.Email.Op;
                        op.NivelServicio = ing.Ingreso.NivelServicio.Op;
                        op.Abandono = ing.Ingreso.Abandono.Op;
                        op.Asa = ing.Ingreso.Asa.Op;
                        op.Aht = ing.Ingreso.Aht.Op;
                        op.Sph = ing.Ingreso.Sph.Op;
                        op.MinutosEntrada = ing.Ingreso.MinutosEntrada.Op;
                        op.MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Op;
                        op.MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Op;
                        op.Ocupacion = ing.Ingreso.Ocupacion.Op;
                        op.Adherencia = ing.Ingreso.Adherencia.Op;
                        op.Ausentismo = ing.Ingreso.Ausentismo.Op;
                        op.Rotacion = ing.Ingreso.Rotacion.Op;
                        op.HorasConexion = ing.Ingreso.HorasConexion.Op;
                        op.HorasPagadas = ing.Ingreso.HorasPagadas.Op;
                        metaCon.SaveChanges();
                    }
                }

                if (ci == null)
                {
                    var datosCi = new IngresoCi
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        Year = an,
                        FechaRegistro = DateTime.Now,
                        DiasServicio = ing.Ingreso.DiasServicio.Ci,
                        HorasServicio = ing.Ingreso.HorasServicio.Ci,
                        LlamadasAcd = ing.Ingreso.LlamadasAcd.Ci,
                        LlamadasIvr = ing.Ingreso.LlamadasIvr.Ci,
                        LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Ci,
                        LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Ci,
                        LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Ci,
                        LlamadasSalida = ing.Ingreso.LlamadasSalida.Ci,
                        Chat = ing.Ingreso.Chat.Ci,
                        Sms = ing.Ingreso.Sms.Ci,
                        Email = ing.Ingreso.Email.Ci,
                        NivelServicio = ing.Ingreso.NivelServicio.Ci,
                        Abandono = ing.Ingreso.Abandono.Ci,
                        Asa = ing.Ingreso.Asa.Ci,
                        Aht = ing.Ingreso.Aht.Ci,
                        Sph = ing.Ingreso.Sph.Ci,
                        MinutosEntrada = ing.Ingreso.MinutosEntrada.Ci,
                        MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Ci,
                        MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Ci,
                        Ocupacion = ing.Ingreso.Ocupacion.Ci,
                        Adherencia = ing.Ingreso.Adherencia.Ci,
                        Ausentismo = ing.Ingreso.Ausentismo.Ci,
                        Rotacion = ing.Ingreso.Rotacion.Ci,
                        HorasConexion = ing.Ingreso.HorasConexion.Ci,
                        HorasPagadas = ing.Ingreso.HorasPagadas.Ci
                    };
                    _db.IngresoCi.Add(datosCi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresoCi.Attach(ci);
                        ci.IdCampana = ing.Campana.idCampana;
                        ci.Mes = mes;
                        ci.Year = an;
                        ci.FechaRegistro = DateTime.Now;
                        ci.DiasServicio = ing.Ingreso.DiasServicio.Ci;
                        ci.HorasServicio = ing.Ingreso.HorasServicio.Ci;
                        ci.LlamadasAcd = ing.Ingreso.LlamadasAcd.Ci;
                        ci.LlamadasIvr = ing.Ingreso.LlamadasIvr.Ci;
                        ci.LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Ci;
                        ci.LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Ci;
                        ci.LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Ci;
                        ci.LlamadasSalida = ing.Ingreso.LlamadasSalida.Ci;
                        ci.Chat = ing.Ingreso.Chat.Ci;
                        ci.Sms = ing.Ingreso.Sms.Ci;
                        ci.Email = ing.Ingreso.Email.Ci;
                        ci.NivelServicio = ing.Ingreso.NivelServicio.Ci;
                        ci.Abandono = ing.Ingreso.Abandono.Ci;
                        ci.Asa = ing.Ingreso.Asa.Ci;
                        ci.Aht = ing.Ingreso.Aht.Ci;
                        ci.Sph = ing.Ingreso.Sph.Ci;
                        ci.MinutosEntrada = ing.Ingreso.MinutosEntrada.Ci;
                        ci.MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Ci;
                        ci.MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Ci;
                        ci.Ocupacion = ing.Ingreso.Ocupacion.Ci;
                        ci.Adherencia = ing.Ingreso.Adherencia.Ci;
                        ci.Ausentismo = ing.Ingreso.Ausentismo.Ci;
                        ci.Rotacion = ing.Ingreso.Rotacion.Ci;
                        ci.HorasConexion = ing.Ingreso.HorasConexion.Ci;
                        ci.HorasPagadas = ing.Ingreso.HorasPagadas.Ci;
                        metaCon.SaveChanges();
                    }
                }

            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public void SetIndEspecificosByList(List<IngresosIndEspDto> ingreso, int mes, int an)
        {
            foreach (var ing in ingreso)
            {
                var bi =
                    _db.Database.SqlQuery<IndicadoresEspecificosBi>("dbo.sp_GetIndEspecificosBiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                var op =
                    _db.Database.SqlQuery<IndicadoresEspecificosOp>("dbo.sp_GetIndEspecificosOpDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<IndicadoresEspecificosCi>("dbo.sp_GetIndEspecificosCiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                if (bi == null)
                {
                    var datosBi = new IndicadoresEspecificosBi
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        Asignacion = ing.Indicadores.Asignacion.Bi,
                        PorcAsignacion = ing.Indicadores.PorcAsignacion.Bi,
                        PorcHonorarios = ing.Indicadores.PorcHonorarios.Bi,
                        PorcRecuperacion = ing.Indicadores.PorcRecuperacion.Bi,
                        PorcConversion = ing.Indicadores.PorcConversion.Bi,
                        Pedidos = ing.Indicadores.Pedidos.Bi,
                        VentasUpsell = ing.Indicadores.VentasUpsell.Bi,
                        UpsellPromedio = ing.Indicadores.UpsellPromedio.Bi,
                        Ventas = ing.Indicadores.Ventas.Bi,
                        PorcValidacion = ing.Indicadores.PorcValidacion.Bi,
                        PorcActivacion = ing.Indicadores.PorcActivacion.Bi,
                    };
                    _db.IndicadoresEspecificosBi.Add(datosBi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IndicadoresEspecificosBi.Attach(bi);
                        bi.IdCampana = ing.Campana.idCampana;
                        bi.Mes = mes;
                        bi.RegYear = an;
                        bi.FechaRegistro = DateTime.Now;
                        bi.Asignacion = ing.Indicadores.Asignacion.Bi;
                        bi.PorcAsignacion = ing.Indicadores.PorcAsignacion.Bi;
                        bi.PorcHonorarios = ing.Indicadores.PorcHonorarios.Bi;
                        bi.PorcRecuperacion = ing.Indicadores.PorcRecuperacion.Bi;
                        bi.PorcConversion = ing.Indicadores.PorcConversion.Bi;
                        bi.Pedidos = ing.Indicadores.Pedidos.Bi;
                        bi.VentasUpsell = ing.Indicadores.VentasUpsell.Bi;
                        bi.UpsellPromedio = ing.Indicadores.UpsellPromedio.Bi;
                        bi.Ventas = ing.Indicadores.Ventas.Bi;
                        bi.PorcValidacion = ing.Indicadores.PorcValidacion.Bi;
                        bi.PorcActivacion = ing.Indicadores.PorcActivacion.Bi;
                        metaCon.SaveChanges();
                    }
                }

                if (op == null)
                {
                    var datosOp = new IndicadoresEspecificosOp
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        Asignacion = ing.Indicadores.Asignacion.Op,
                        PorcAsignacion = ing.Indicadores.PorcAsignacion.Op,
                        PorcHonorarios = ing.Indicadores.PorcHonorarios.Op,
                        PorcRecuperacion = ing.Indicadores.PorcRecuperacion.Op,
                        PorcConversion = ing.Indicadores.PorcConversion.Op,
                        Pedidos = ing.Indicadores.Pedidos.Op,
                        VentasUpsell = ing.Indicadores.VentasUpsell.Op,
                        UpsellPromedio = ing.Indicadores.UpsellPromedio.Op,
                        Ventas = ing.Indicadores.Ventas.Op,
                        PorcValidacion = ing.Indicadores.PorcValidacion.Op,
                        PorcActivacion = ing.Indicadores.PorcActivacion.Op,
                    };
                    _db.IndicadoresEspecificosOp.Add(datosOp);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IndicadoresEspecificosOp.Attach(op);
                        op.IdCampana = ing.Campana.idCampana;
                        op.Mes = mes;
                        op.RegYear = an;
                        op.FechaRegistro = DateTime.Now;
                        op.Asignacion = ing.Indicadores.Asignacion.Op;
                        op.PorcAsignacion = ing.Indicadores.PorcAsignacion.Op;
                        op.PorcHonorarios = ing.Indicadores.PorcHonorarios.Op;
                        op.PorcRecuperacion = ing.Indicadores.PorcRecuperacion.Op;
                        op.PorcConversion = ing.Indicadores.PorcConversion.Op;
                        op.Pedidos = ing.Indicadores.Pedidos.Op;
                        op.VentasUpsell = ing.Indicadores.VentasUpsell.Op;
                        op.UpsellPromedio = ing.Indicadores.UpsellPromedio.Op;
                        op.Ventas = ing.Indicadores.Ventas.Op;
                        op.PorcValidacion = ing.Indicadores.PorcValidacion.Op;
                        op.PorcActivacion = ing.Indicadores.PorcActivacion.Op;
                        metaCon.SaveChanges();
                    }
                }

                if (ci == null)
                {
                    var datosCi = new IndicadoresEspecificosCi
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        Asignacion = ing.Indicadores.Asignacion.Ci,
                        PorcAsignacion = ing.Indicadores.PorcAsignacion.Ci,
                        PorcHonorarios = ing.Indicadores.PorcHonorarios.Ci,
                        PorcRecuperacion = ing.Indicadores.PorcRecuperacion.Ci,
                        PorcConversion = ing.Indicadores.PorcConversion.Ci,
                        Pedidos = ing.Indicadores.Pedidos.Ci,
                        VentasUpsell = ing.Indicadores.VentasUpsell.Ci,
                        UpsellPromedio = ing.Indicadores.UpsellPromedio.Ci,
                        Ventas = ing.Indicadores.Ventas.Ci,
                        PorcValidacion = ing.Indicadores.PorcValidacion.Ci,
                        PorcActivacion = ing.Indicadores.PorcActivacion.Ci,
                    };
                    _db.IndicadoresEspecificosCi.Add(datosCi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IndicadoresEspecificosCi.Attach(ci);
                        ci.IdCampana = ing.Campana.idCampana;
                        ci.Mes = mes;
                        ci.RegYear = an;
                        ci.FechaRegistro = DateTime.Now;
                        ci.Asignacion = ing.Indicadores.Asignacion.Ci;
                        ci.PorcAsignacion = ing.Indicadores.PorcAsignacion.Ci;
                        ci.PorcHonorarios = ing.Indicadores.PorcHonorarios.Ci;
                        ci.PorcRecuperacion = ing.Indicadores.PorcRecuperacion.Ci;
                        ci.PorcConversion = ing.Indicadores.PorcConversion.Ci;
                        ci.Pedidos = ing.Indicadores.Pedidos.Ci;
                        ci.VentasUpsell = ing.Indicadores.VentasUpsell.Ci;
                        ci.UpsellPromedio = ing.Indicadores.UpsellPromedio.Ci;
                        ci.Ventas = ing.Indicadores.Ventas.Ci;
                        ci.PorcValidacion = ing.Indicadores.PorcValidacion.Ci;
                        ci.PorcActivacion = ing.Indicadores.PorcActivacion.Ci;
                        metaCon.SaveChanges();
                    }
                }

            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public void SetEstEspecializadasByList(List<IngresosEstEspDto> ingreso, int mes, int an)
        {
            foreach (var ing in ingreso)
            {
                var bi =
                    _db.Database.SqlQuery<EstacionesEspecializadasBi>("dbo.sp_GetEstEspecializadasBiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();
                var op =
                    _db.Database.SqlQuery<EstacionesEspecializadasOp>("dbo.sp_GetEstEspecializadasOpDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<EstacionesEspecializadasCi>("dbo.sp_GetEstEspecializadasCiDetById @idCampana = {0}, @Mes = {1}, @RegYear = {2}",
                        ing.Campana.idCampana, mes, an).FirstOrDefault();

                if (bi == null)
                {
                    var datosBi = new EstacionesEspecializadasBi
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        Nafin = ing.Estaciones.Nafin.Bi,
                        Proveedor = ing.Estaciones.Proveedor.Bi,
                        Vip = ing.Estaciones.Vip.Bi,
                        Credito = ing.Estaciones.Credito.Bi,
                        KioscoVirtual = ing.Estaciones.KioscoVirtual.Bi,
                        Operativa = ing.Estaciones.Operativa.Bi,
                        Especializada = ing.Estaciones.Especializada.Bi,
                        SinDelantal = ing.Estaciones.SinDelantal.Bi,
                        ServicioImpresionEscaner = ing.Estaciones.ServicioImpresionEscaner.Bi,
                    };
                    _db.EstacionesEspecializadasBi.Add(datosBi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.EstacionesEspecializadasBi.Attach(bi);
                        bi.IdCampana = ing.Campana.idCampana;
                        bi.Mes = mes;
                        bi.RegYear = an;
                        bi.FechaRegistro = DateTime.Now;
                        bi.Nafin = ing.Estaciones.Nafin.Ci;
                        bi.Proveedor = ing.Estaciones.Proveedor.Ci;
                        bi.Vip = ing.Estaciones.Vip.Ci;
                        bi.Credito = ing.Estaciones.Credito.Ci;
                        bi.KioscoVirtual = ing.Estaciones.KioscoVirtual.Ci;
                        bi.Operativa = ing.Estaciones.Operativa.Ci;
                        bi.Especializada = ing.Estaciones.Especializada.Ci;
                        bi.SinDelantal = ing.Estaciones.SinDelantal.Ci;
                        bi.ServicioImpresionEscaner = ing.Estaciones.ServicioImpresionEscaner.Ci;
                        metaCon.SaveChanges();
                    }
                }
//-----------------------------------
                if (op == null)
                {
                    var datosOp = new EstacionesEspecializadasOp
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        Nafin = ing.Estaciones.Nafin.Op,
                        Proveedor = ing.Estaciones.Proveedor.Op,
                        Vip = ing.Estaciones.Vip.Op,
                        Credito = ing.Estaciones.Credito.Op,
                        KioscoVirtual = ing.Estaciones.KioscoVirtual.Op,
                        Operativa = ing.Estaciones.Operativa.Op,
                        Especializada = ing.Estaciones.Especializada.Op,
                        SinDelantal = ing.Estaciones.SinDelantal.Op,
                        ServicioImpresionEscaner = ing.Estaciones.ServicioImpresionEscaner.Op,
                    };
                    _db.EstacionesEspecializadasOp.Add(datosOp);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.EstacionesEspecializadasOp.Attach(op);
                        op.IdCampana = ing.Campana.idCampana;
                        op.Mes = mes;
                        op.RegYear = an;
                        op.FechaRegistro = DateTime.Now;
                        op.Nafin = ing.Estaciones.Nafin.Op;
                        op.Proveedor = ing.Estaciones.Proveedor.Op;
                        op.Vip = ing.Estaciones.Vip.Op;
                        op.Credito = ing.Estaciones.Credito.Op;
                        op.KioscoVirtual = ing.Estaciones.KioscoVirtual.Op;
                        op.Operativa = ing.Estaciones.Operativa.Op;
                        op.Especializada = ing.Estaciones.Especializada.Op;
                        op.SinDelantal = ing.Estaciones.SinDelantal.Op;
                        op.ServicioImpresionEscaner = ing.Estaciones.ServicioImpresionEscaner.Op;
                        metaCon.SaveChanges();
                    }
                }

                if (ci == null)
                {
                    var datosCi = new EstacionesEspecializadasCi
                    {
                        IdCampana = ing.Campana.idCampana,
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        Nafin = ing.Estaciones.Nafin.Ci,
                        Proveedor = ing.Estaciones.Proveedor.Ci,
                        Vip = ing.Estaciones.Vip.Ci,
                        Credito = ing.Estaciones.Credito.Ci,
                        KioscoVirtual = ing.Estaciones.KioscoVirtual.Ci,
                        Operativa = ing.Estaciones.Operativa.Ci,
                        Especializada = ing.Estaciones.Especializada.Ci,
                        SinDelantal = ing.Estaciones.SinDelantal.Ci,
                        ServicioImpresionEscaner = ing.Estaciones.ServicioImpresionEscaner.Ci,
                    };
                    _db.EstacionesEspecializadasCi.Add(datosCi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.EstacionesEspecializadasCi.Attach(ci);
                        ci.IdCampana = ing.Campana.idCampana;
                        ci.Mes = mes;
                        ci.RegYear = an;
                        ci.FechaRegistro = DateTime.Now;
                        ci.Nafin = ing.Estaciones.Nafin.Ci;
                        ci.Proveedor = ing.Estaciones.Proveedor.Ci;
                        ci.Vip = ing.Estaciones.Vip.Ci;
                        ci.Credito = ing.Estaciones.Credito.Ci;
                        ci.KioscoVirtual = ing.Estaciones.KioscoVirtual.Ci;
                        ci.Operativa = ing.Estaciones.Operativa.Ci;
                        ci.Especializada = ing.Estaciones.Especializada.Ci;
                        ci.SinDelantal = ing.Estaciones.SinDelantal.Ci;
                        ci.ServicioImpresionEscaner = ing.Estaciones.ServicioImpresionEscaner.Ci;
                        metaCon.SaveChanges();
                    }
                }

            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public void SetPrecioByList(List<PrecioDto> precio, int mes)
        {
            foreach (var price in precio)
            {
                var op =
                    _db.Database.SqlQuery<PrecioOp>("dbo.sp_GetPriceOpDetById @idCampana = {0}, @Mes = {1}",
                        price.Campana.idCampana, DateTime.Now.Month).FirstOrDefault();
                if (op == null)
                {
                    var datosOp = new PrecioOp
                    {
                        IdCampana = price.Campana.idCampana,
                        Mes = mes,
                        FechaRegistro = DateTime.Now,
                        Fijo = price.Precios.Fijo.Op,
                        Persona = price.Precios.Persona.Op,
                        EstacionEspecializada = price.Precios.EstacionEspecializada.Op,
                        Hora = price.Precios.Hora.Op,
                        Minuto = price.Precios.Minuto.Op,
                        LlamadaEntrada = price.Precios.LlamadaEntrada.Op,
                        LlamadaSalida = price.Precios.LlamadaSalida.Op,
                        Chat = price.Precios.Chat.Op,
                        SMS = price.Precios.SMS.Op,
                        Email = price.Precios.Email.Op,
                        Venta = price.Precios.Venta.Op,
                        TicketVenta = price.Precios.TicketVenta.Op,
                        MinutosEntrada = price.Precios.MinutosEntrada.Op,
                        MinutosSalidaFijo = price.Precios.MinutosSalidaFijo.Op,
                        MinutosSalidaCelular = price.Precios.MinutosSalidaCelular.Op,
                        KioscoVirtual = price.Precios.KioscoVirtual.Op,
                        ServicioImpresiónyEscaner = price.Precios.ServicioImpresiónyEscaner.Op,
                       
                    };
                    _db.PrecioOp.Add(datosOp);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.PrecioOp.Attach(op);
                        op.IdCampana = price.Campana.idCampana;
                        op.Mes = mes;
                        op.FechaRegistro = DateTime.Now;
                        op.Fijo = price.Precios.Fijo.Op;
                        op.Persona = price.Precios.Persona.Op;
                        op.EstacionEspecializada = price.Precios.EstacionEspecializada.Op;
                        op.Hora = price.Precios.Hora.Op;
                        op.Minuto = price.Precios.Minuto.Op;
                        op.LlamadaEntrada = price.Precios.LlamadaEntrada.Op;
                        op.LlamadaSalida = price.Precios.LlamadaSalida.Op;
                        op.Chat = price.Precios.Chat.Op;
                        op.SMS = price.Precios.SMS.Op;
                        op.Email = price.Precios.Email.Op;
                        op.Venta = price.Precios.Venta.Op;
                        op.TicketVenta = price.Precios.TicketVenta.Op;
                        op.MinutosEntrada = price.Precios.MinutosEntrada.Op;
                        op.MinutosSalidaFijo = price.Precios.MinutosSalidaFijo.Op;
                        op.MinutosSalidaCelular = price.Precios.MinutosSalidaCelular.Op;
                        op.KioscoVirtual = price.Precios.KioscoVirtual.Op;
                        op.ServicioImpresiónyEscaner = price.Precios.ServicioImpresiónyEscaner.Op;
                        metaCon.SaveChanges();
                    }
                }

            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }

    
    /*
     * var datosCi = new IngresoCi
                {
                    IdCampana = ing.Campana.idCampana,
                    Mes = mes,
                    FechaRegistro = DateTime.Now,
                    DiasServicio = ing.Ingreso.DiasServicio.Ci,
                    HorasServicio = ing.Ingreso.HorasServicio.Ci,
                    LlamadasAcd = ing.Ingreso.LlamadasAcd.Ci,
                    LlamadasIvr = ing.Ingreso.LlamadasIvr.Ci,
                    LlamadasEntrada = ing.Ingreso.LlamadasEntrada.Ci,
                    LlamadasContestadas = ing.Ingreso.LlamadasContestadas.Ci,
                    LlamadasFacturables = ing.Ingreso.LlamadasFacturables.Ci,
                    LlamadasSalida = ing.Ingreso.LlamadasSalida.Ci,
                    Chat = ing.Ingreso.Chat.Ci,
                    Sms = ing.Ingreso.Sms.Ci,
                    Email = ing.Ingreso.Email.Ci,
                    NivelServicio = ing.Ingreso.NivelServicio.Ci,
                    Abandono = ing.Ingreso.Abandono.Ci,
                    Asa = ing.Ingreso.Asa.Ci,
                    Aht = ing.Ingreso.Aht.Ci,
                    Sph = ing.Ingreso.Sph.Ci,
                    MinutosEntrada = ing.Ingreso.MinutosEntrada.Ci,
                    MinutosSalidaFijo = ing.Ingreso.MinutosSalidaFijo.Ci,
                    MinutosSalidaCelular = ing.Ingreso.MinutosSalidaCelular.Ci,
                    Ocupacion = ing.Ingreso.Ocupacion.Ci,
                    Adherencia = ing.Ingreso.Adherencia.Ci,
                    Ausentismo = ing.Ingreso.Ausentismo.Ci,
                    Rotacion = ing.Ingreso.Rotacion.Ci,
                    HorasConexion = ing.Ingreso.HorasConexion.Ci,
                    HorasPagadas = ing.Ingreso.HorasPagadas.Ci
                };
                _db.IngresoCi.Add(datosCi);
                _db.SaveChanges();
                */
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
}