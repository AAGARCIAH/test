using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PentaFinances.Models
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class RhContext : DbContext
    {
        public DbSet<CatArea> CatArea { get; set; }

        public RhContext()
            : base("name=RhConn")
        {
            Database.SetInitializer<RhContext>((IDatabaseInitializer<RhContext>)null);
        }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    
    [Table("cat_Area",Schema = "dbo")]
    public class CatArea
    {
        [Key]
        public int AreaID { get; set; }
        public string Area { get; set; }
        public bool Activo { get; set; }
        public int? CampaignID { get; set; }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    
}