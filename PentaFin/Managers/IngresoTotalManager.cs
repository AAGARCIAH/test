using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PentaFinances.Dtos;
using PentaFinances.Models;

namespace PentaFinances.Managers
{
    public class IngresoTotalManager
    {
        PentaFinContext _db = new PentaFinContext();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void SetIngresoTotalByList(List<IngresoTotDto> ingreso, int mes, int an)
        {
            foreach (var ing in ingreso)
            {
                var pt =
                    _db.Database.SqlQuery<IngresosTotPt>("dbo.sp_GetIngresoTotalPtDetById @Mes = {0}, @RegYear = {1}", mes, an).FirstOrDefault();

                var fr =
                    _db.Database.SqlQuery<IngresosTotFr>("dbo.sp_GetIngresoTotalFrDetById @Mes = {0}, @RegYear = {1}", mes, an).FirstOrDefault();

                var ci =
                    _db.Database.SqlQuery<IngresosTotCi>("dbo.sp_GetIngresoTotalCiDetById @Mes = {0}, @RegYear = {1}", mes, an).FirstOrDefault();

                var re =
                    _db.Database.SqlQuery<IngresosTotRe>("dbo.sp_GetIngresoTotalReDetById @Mes = {0}, @RegYear = {1}", mes, an).FirstOrDefault();

                if (pt == null)
                {
                    var datosPt = new IngresosTotPt
                    {
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        IngresosTotales = ing.IngresosTotales.IngresosTotales.Pt,

                    };
                    _db.IngresosTotPt.Add(datosPt);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresosTotPt.Attach(pt);
                        pt.Mes = mes;
                        pt.RegYear = an;
                        pt.FechaRegistro = DateTime.Now;
                        pt.IngresosTotales = ing.IngresosTotales.IngresosTotales.Pt;
                        metaCon.SaveChanges();
                    }
                }

                if (fr == null)
                {
                    var datosFr = new IngresosTotFr
                    {
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        IngresosTotales = ing.IngresosTotales.IngresosTotales.Fr,

                    };
                    _db.IngresosTotFr.Add(datosFr);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresosTotFr.Attach(fr);
                        fr.Mes = mes;
                        fr.RegYear = an;
                        fr.FechaRegistro = DateTime.Now;
                        fr.IngresosTotales = ing.IngresosTotales.IngresosTotales.Fr;
                        metaCon.SaveChanges();
                    }
                }

                if (ci == null)
                {
                    var datosCi = new IngresosTotCi
                    {
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        IngresosTotales = ing.IngresosTotales.IngresosTotales.Ci,

                    };
                    _db.IngresosTotCi.Add(datosCi);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresosTotCi.Attach(ci);
                        ci.Mes = mes;
                        ci.RegYear = an;
                        ci.FechaRegistro = DateTime.Now;
                        ci.IngresosTotales = ing.IngresosTotales.IngresosTotales.Ci;
                        metaCon.SaveChanges();
                    }
                }

                if (re == null)
                {
                    var datosRe = new IngresosTotRe
                    {
                        Mes = mes,
                        RegYear = an,
                        FechaRegistro = DateTime.Now,
                        IngresosTotales = ing.IngresosTotales.IngresosTotales.Re,

                    };
                    _db.IngresosTotRe.Add(datosRe);
                    _db.SaveChanges();

                }
                else
                {
                    using (var metaCon = new PentaFinContext())
                    {
                        metaCon.IngresosTotRe.Attach(re);
                        re.Mes = mes;
                        re.RegYear = an;
                        re.FechaRegistro = DateTime.Now;
                        re.IngresosTotales = ing.IngresosTotales.IngresosTotales.Re;
                        metaCon.SaveChanges();
                    }
                }
            }
        }
    }
}