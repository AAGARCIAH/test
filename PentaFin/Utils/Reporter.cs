using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PentaFinances.Utils
{
    public class Reporter
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -       
        public void GetReporteNoParams(string procedure, string conexion, string reporte)
        {
            string val = "ADMINFALTAS";
            var tipoUParam = new SqlParameter("@Origen", SqlDbType.VarChar) { Value = val, IsNullable = false };
            var sp = new List<SqlParameter> { tipoUParam };
            var data = GetDataSet(sp, "[dbo].[" + procedure + "]", conexion).Tables[0];
            GetFile(data, reporte);
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -       
        public void GetReporteIncCapa(DateTime fechaInicio, DateTime fechaFin, string procedure, string conexion, string reporte,
            int grupo)
        {
            var fechaIParam = new SqlParameter("@FechaIni", SqlDbType.Date) { Value = fechaInicio, IsNullable = false };
            var fechaFParam = new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin, IsNullable = false };
            var tipoUParam = new SqlParameter("@GrupoId", SqlDbType.Int) { Value = grupo, IsNullable = false };
            var sp = new List<SqlParameter> { fechaIParam, fechaFParam, tipoUParam };
            var data = GetDataSet(sp, "[dbo].[" + procedure + "]", conexion).Tables[0];
            GetFile(data, reporte);
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetReporteByDate(DateTime fechaInicio, DateTime fechaFin, string procedure, string conexion, string reporte)
        {
            var fechaIParam = new SqlParameter("@FechaIni", SqlDbType.Date) { Value = fechaInicio, IsNullable = false };
            var fechaFParam = new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin, IsNullable = false };
            var sp = new List<SqlParameter> { fechaIParam, fechaFParam };
            var data = GetDataSet(sp, "[dbo].[" + procedure + "]", conexion).Tables[0];
            GetFile(data, reporte);
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -       
        public void GetReporte(DateTime fechaInicio, DateTime fechaFin, string procedure, string conexion, string reporte, int tipo)
        {
            var fechaIParam = new SqlParameter("@FechaIni", SqlDbType.Date) { Value = fechaInicio, IsNullable = false };
            var fechaFParam = new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin, IsNullable = false };
            var tipoUParam = new SqlParameter("@TipoUsuario", SqlDbType.Int) { Value = tipo, IsNullable = false };
            var sp = new List<SqlParameter> { fechaIParam, fechaFParam, tipoUParam };
            var data = GetDataSet(sp, "[dbo].[" + procedure + "]", conexion).Tables[0];
            GetFile(data, reporte);
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -       
        public void GetNoParamsReporte(string procedure, string conexion, string reporte)
        {
            DateTime fechaInicio = DateTime.Now;
            var fechaIParam = new SqlParameter("@FechaIni", SqlDbType.Date) { Value = fechaInicio, IsNullable = false };
            var sp = new List<SqlParameter> { fechaIParam };
            var data = GetDataSet(sp, "[dbo].[" + procedure + "]", conexion).Tables[0];
            GetFile(data, reporte);
            System.Threading.Thread.Sleep(5000);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetFile(DataTable dataTable, string Reporte)
        {
            var lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                Select(column => column.ColumnName).
                ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = dataTable.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\Content\" + Reporte + ".csv",
                lines, Encoding.UTF8);

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public DataSet GetDataSet(List<SqlParameter> parametros, string sqlQuery, string conn)
        {
            var ds = new DataSet();
            var cnnString = ConfigurationManager.ConnectionStrings[conn].ConnectionString;
            var cnn = new SqlConnection(cnnString);
            var cmd = new SqlCommand
            {
                CommandText = sqlQuery,
                CommandType = CommandType.StoredProcedure,
                Connection = cnn,
            };
            foreach (var parametro in parametros)
            {
                cmd.Parameters.Add(parametro);
            }
            var adapter = new SqlDataAdapter(cmd);
            cnn.Open();
            adapter.Fill(ds);
            cnn.Close();
            return ds;
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}