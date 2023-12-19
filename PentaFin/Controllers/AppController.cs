﻿using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using PentaFinances.Models;
using PentaFinances.Managers;

namespace PentaFinances.Controllers
{
    public class AppController : Controller
    {
        //
        // GET: /App/
        DataContextAdminDesarrollo _admin = new DataContextAdminDesarrollo();
        PentaFinContext _db = new PentaFinContext();
        ComprasManager _manager = new ComprasManager();
        ComprasController _ctr = new ComprasController();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult PartialMenu()
        {
            var menus =
               _admin.MenusPermisos.Where(
                   a => a.ApplicationName == Membership.ApplicationName && a.UserName == User.Identity.Name).ToList();
            ViewBag.Menus =
                menus.Select(a => new ListMenus { Id = a.MenuId, Menu = a.MenuName, Url = a.MenuUrl }).GroupBy(b => new { b.Url, b.Id, b.Menu }).Select(g => g.First()).ToList();
            ViewBag.Submenus =
                menus.Select(
                    a =>
                        new ListSubMenus
                        {
                            Id = a.SubMenuId,
                            Submenu = a.SubMenuName,
                            Url = a.SubMenuUrl,
                            MenuId = a.MenuId
                        }).GroupBy(b => new { b.Id, b.Submenu, b.Url, b.MenuId }).Select(f => f.First()).Distinct().ToList();

            return PartialView();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult Home()
        {
           
            if (User.Identity.IsAuthenticated == false)
            {
               
                return RedirectToAction("Login", "App");
            }
            else
            {
                return View();
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public ActionResult Login()
        {

            //_manager.EnvioEncuesta();
            //MembershipUser mu = Membership.GetUser("JGARCIAF");
            //mu.ChangePassword(mu.ResetPassword(), "Jgarciaf/2023");

            /****
             cgarcia@pentafon.com	cgarcia

            //****/
            //var user = Membership.GetUser("");
            //FormsAuthentication.SetAuthCookie("JGARCIAF", true);
            //string usuario = "IMONTES";
            //Membership.DeleteUser("psalinas");
            //Membership.CreateUser(usuario, "Imontes/2023");
            //Membership.CreateUser("SJIMENEZ", "Sjimenez/2023", "sjimenez@pentafon.com");
            //Roles.CreateRole("ComprasFinanzas");
            //Rol: Developer
            //Rol: Finanzas
            //Rol: Solicitante
            //Rol: Compras
            //Rol: Aprobador
            //Rol: AprobadorDirFin
            //Rol: AprobadorDirGral
            //Rol: AprobadorPresidencia
            //Rol: ReportesCompras
            //Rol: ComprasFinanzas
            ////Roles.AddUserToRole(usuario, "ClienteAxa");
            //Roles.AddUserToRole(usuario, "Compras");
            //Roles.AddUserToRole(usuario, "Solicitante");
            //Roles.AddUserToRole(usuario, "ReportesCompras");
            //manager.SetUsuarios(usuario, 2, "Venezuela", "Generic");

            //Roles.RemoveUserFromRole("mgonzalez", "Aprobador");
            //Roles.RemoveUserFromRole(usuario, "Compras");
            //Roles.RemoveUserFromRole("mgonzalez", "ReportesCompras");


            if (true)
            {
                return RedirectToAction("Home", "App");
            }

            return View();
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public JsonResult GetInicio(string user, string pass)
        {
            string resultado = "";

            if (Membership.ValidateUser(user, pass))
            {
                //var usuario = _db.AppUsuarios.Where(a => a.UserName == user).SingleOrDefault();
                Session.Timeout = 4000;
                /*Session["User"] = usuario.UserName;
                Session["TipoUserId"] = usuario.TipoUserId;
                Session["Nombre"] = usuario.Nombre + " " + usuario.Apellido;
                */
                Session["User"] = user;
                resultado = "exito";
                FormsAuthentication.SetAuthCookie(user, false);
                RedirectToAction("Home", "App");
            }
            else
            {
                resultado = "error";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);


        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        [HttpPost]
        public ActionResult closeSession()
        {
            Session["User"] = null;
            Session["TipoUserId"] = null;
            Session["Nombre"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "App");
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}
