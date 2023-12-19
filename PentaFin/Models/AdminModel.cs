using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PentaFinances.Models
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class DataContextAdminDesarrollo : DbContext
        {
            public DbSet<cat_Menu> catMenu { get; set; }

            public DbSet<cat_SubMenu> catSubMenu { get; set; }

            public DbSet<vw_Apps_Menus_Permissions> MenusPermisos { get; set; }
            public DataContextAdminDesarrollo()
                : base("name=MemberShipProvider")
            {
                this.Configuration.LazyLoadingEnabled = true;
                Database.SetInitializer((IDatabaseInitializer<DataContextAdminDesarrollo>)null);
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class cat_Menu
        {
            [Key]
            public int MenuId { get; set; }

            public string MenuName { get; set; }

            public string MenuDesc { get; set; }

            public string MenuUrl { get; set; }

            public int StatusId { get; set; }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class cat_SubMenu
        {
            [Key]
            public int SubMenuId { get; set; }

            public int MenuId { get; set; }

            public string SubMenuName { get; set; }

            public string SubmenuDesc { get; set; }

            public string SubmenuUrl { get; set; }

            public int StatusId { get; set; }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class Users
        {
            [Key]
            [Required]
            [DisplayName("Usuario")]
            public string UserName { get; set; }

            [DataType(DataType.Password)]
            [Required]
            [DisplayName("Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class vw_Apps_Menus_Permissions
        {
            [Key]
            public string Id { get; set; }
            public string MenuName { get; set; }
            public int MenuId { get; set; }
            public string MenuUrl { get; set; }
            public string SubMenuName { get; set; }
            public int SubMenuId { get; set; }
            public string SubMenuUrl { get; set; }
            public string ApplicationName { get; set; }
            public string RoleName { get; set; }
            public string UserName { get; set; }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class ListMenus
        {
            public int Id { get; set; }
            public string Menu { get; set; }
            public string Url { get; set; }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public class ListSubMenus
        {
            public int Id { get; set; }
            public string Submenu { get; set; }
            public string Url { get; set; }
            public int MenuId { get; set; }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    
}