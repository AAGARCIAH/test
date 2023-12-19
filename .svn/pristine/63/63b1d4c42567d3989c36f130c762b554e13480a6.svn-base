using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PentaFinances.Models;
using PentaFinances.Managers;

namespace PentaFinances.Controllers
{
    public class ReportesComprasController : Controller
    {
        //
        // GET: /ReportesCompras/
        PentaFinComprasContext _db = new PentaFinComprasContext();
        private CostoManager _manager = new CostoManager();
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public ActionResult Index()
        {
            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //REPORTE DE GASTOS DE MES PARA EL MÓDULO DE COMPRAS
        //FECHA: 08/02/2018
        public ActionResult Gastos()
        {
            ViewBag.Solicitantes = new SelectList(_db.ApUsuarios,"Nombre","Nombre");
            ViewBag.Campanas = new SelectList(_db.CatalogoCampanas, "Id", "Campana");
            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetReporteGastos(DateTime fechaInicio, DateTime fechaFin, string solicita, int? campana)
        {
            string fechai = fechaInicio.ToShortDateString();
            string fechaf = fechaFin.ToShortDateString();

            solicita = (solicita == "") ? null : solicita;

            SqlParameter fechaIParam = new SqlParameter("@FechaIni", SqlDbType.VarChar) { Value = fechai, IsNullable = false };
            SqlParameter fechaFParam = new SqlParameter("@FechaFin", SqlDbType.VarChar) { Value = fechaf, IsNullable = false };
            SqlParameter solicitaParam = new SqlParameter("@Solicitante", SqlDbType.VarChar) { Value = solicita, IsNullable = true };
            SqlParameter campanaParam = new SqlParameter("@Campana", SqlDbType.Int) { Value = campana, IsNullable = true };
            List<SqlParameter> sp = new List<SqlParameter> { fechaIParam, fechaFParam, solicitaParam, campanaParam };
            DataTable data = GetDataSet(sp, "dbo.GET_REP_GASTOS_COMPRAS").Tables[0];
            GetFile(data, "Gastos");
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public DataSet GetDataSet(List<SqlParameter> parametros, string sqlQuery)
        {
            DataSet ds = new DataSet();
            string cnnString = ConfigurationManager.ConnectionStrings["FinConn"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = sqlQuery,
                CommandType = CommandType.StoredProcedure,
                Connection = cnn,
                CommandTimeout = 180
            };
            foreach (var parametro in parametros)
            {
                cmd.Parameters.Add(parametro);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cnn.Open();
            adapter.Fill(ds);
            cnn.Close();
            return ds;

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetFile(DataTable dataTable, string reporteName)
        {
            List<string> lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                Select(column => column.ColumnName).
                ToArray();
            string header = string.Join(",", columnNames);
            lines.Add(header);
            EnumerableRowCollection<string> valueLines = dataTable.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\Content\" + reporteName + ".csv",
                lines, Encoding.UTF8);

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //REPORTE DE ENCUESTA
        //FECHA: 08/02/2018
        public ActionResult ReporteEncuesta()
        {
            ViewBag.Solicitantes = new SelectList(_db.ApUsuarios, "Nombre", "Nombre");
            ViewBag.Campanas = new SelectList(_db.CatalogoCampanas, "Id", "Campana");
            return View();
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public void GetReporteEncuesta(DateTime fechaInicio, DateTime fechaFin)
        {
            string fechai = fechaInicio.ToShortDateString();
            string fechaf = fechaFin.ToShortDateString();


            SqlParameter fechaIParam = new SqlParameter("@FechaIni", SqlDbType.VarChar) { Value = fechai, IsNullable = false };
            SqlParameter fechaFParam = new SqlParameter("@FechaFin", SqlDbType.VarChar) { Value = fechaf, IsNullable = false };
            List<SqlParameter> sp = new List<SqlParameter> { fechaIParam, fechaFParam };
            DataTable data = GetDataSet2(sp, "dbo.GET_REP_ENCUESTA_COMPRAS").Tables[0];
            GetFile2(data, "Encuesta");
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetFile2(DataTable dataTable, string reporteName)
        {
            List<string> lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                Select(column => column.ColumnName).
                ToArray();
            string header = string.Join(",", columnNames);
            lines.Add(header);
            EnumerableRowCollection<string> valueLines = dataTable.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\Content\" + reporteName + ".csv",
                lines, Encoding.UTF8);

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public DataSet GetDataSet2(List<SqlParameter> parametros, string sqlQuery)
        {
            DataSet ds = new DataSet();
            string cnnString = ConfigurationManager.ConnectionStrings["FinConn"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = sqlQuery,
                CommandType = CommandType.StoredProcedure,
                Connection = cnn,
                CommandTimeout = 180
            };
            foreach (SqlParameter parametro in parametros)
            {
                cmd.Parameters.Add(parametro);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cnn.Open();
            adapter.Fill(ds);
            cnn.Close();
            return ds;

        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult ReporteProveedores()
        {

            List<SelectListItem> añosdata = new List<SelectListItem> {

                new SelectListItem{ Value = "2020", Text = "2020" },
                new SelectListItem{ Value = "2021", Text = "2021" },
                new SelectListItem{ Value = "2022", Text = "2022" },
                new SelectListItem{ Value = "2023", Text = "2023" },
                new SelectListItem{ Value = "2024", Text = "2024" },
                new SelectListItem{ Value = "2025", Text = "2025" },
                new SelectListItem{ Value = "2026", Text = "2026" },
                new SelectListItem{ Value = "2027", Text = "2027" },
                new SelectListItem{ Value = "2028", Text = "2028" },
                new SelectListItem{ Value = "2029", Text = "2029" },
                new SelectListItem{ Value = "2030", Text = "2030" },
            };

            ViewBag.Años = añosdata;
            return View();
        }
        
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult GeneraReporteProveedores(string Anio)
        {
            try
            {
                var toPath = Path.Combine(Server.MapPath("~/Content/"));
                var Estatus = _manager.SetReporte(Anio, toPath);

                return Json(Estatus, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error: " + e, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
