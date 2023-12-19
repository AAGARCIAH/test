using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PentaFinances.Models
{
    public class PtfStageIndicadoresContext : DbContext
    {
        public DbSet<Campanas> Campanas { get; set; }

        public PtfStageIndicadoresContext()
            : base("name=PtfCnn")
        {
            Database.SetInitializer<PtfStageIndicadoresContext>((IDatabaseInitializer<PtfStageIndicadoresContext>)null);
        }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    [Table("CAT_CAMPANAS",Schema = "dbo")]
    public class Campanas
    {
        [Key]
        public string idCampana { get; set; }
        public string idCliente { get; set; }
        public string nombreCampana { get; set; }
        public int idCoordinador { get; set; }
        public bool? tipoVenta { get; set; }
        public bool activo { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
  
}