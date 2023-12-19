using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PentaFinances.Managers;

namespace PentaFinances.Controllers
{
    public class DocsController : Controller
    {
        //CLASS============================================================================================================================
        //CODE BRINGED BY THE GLORY ULTRAMARINES CHAPTER
        //CODING BY: CAPTAIN DANIEL FUENTES DFR
        //PROJECT PENTA FINANCES
        // GET: /Docs/
        private readonly ComprasManager.DocsManager _manager = new ComprasManager.DocsManager();
        private readonly ComprasManager manager = new ComprasManager();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public JsonResult UpCotizacion()
        {
            if (Request.Files.Count <= 0) return Json("No files selected.");
            try
            {
                //  Get all files from Request object  
               HttpFileCollectionBase files = Request.Files;
                int folio = string.IsNullOrEmpty(Request.Form["Folio"]) ? 0 : int.Parse(Request.Form["Folio"]);
                string tipo = Request.Form["Tipo"];
                for (int i = 0; i < files.Count; i++)
                {


                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split('\\');
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    string uploadName = Path.GetFileName(fname);

                    //SE GUARDA EL ARCHIVO DE MANERA LOCAL
                    string path = Path.Combine(Server.MapPath("~/Content/"), uploadName);
                    file.SaveAs(path);
                    
                    //SE GUARDA EN LA RUTA QUE SERA COMPARTIDA PARA AMBAS DIRECCIONES 35 Y 36
                    string rwname = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\ProveedoresDocs\\" + uploadName;
                    System.IO.File.Copy(path, rwname, true);

                    try
                    {
                        //_manager.SetCotizacion(folio,tipo, uploadName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                   

                    return Json(uploadName);
                }
                return Json("Error");
            }
            catch (Exception ex)
            {
                return Json("Error" + ex.Message);
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [HttpPost]
        public JsonResult GetCotizacion(int folio,string tipo)
        {
            try
            {
                string evidence = _manager.GetCotizacion(folio,tipo);
                string archivo = "Pdf" + folio + "_" + tipo + ".pdf";
                string path = Path.Combine(Server.MapPath("~/Content/"), archivo);
                
                //FIRST IT ERASE THE FILE TO CREATE LATER
                System.IO.File.Delete(path);
                
                //ITS SAVED IN CONTENT FOLDER IN TEMPORAL FORM AND ITS RENAMED
                System.IO.File.Copy(evidence, path, true);
                
                return Json("../Content/"+archivo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [HttpPost]
        public JsonResult GetForma(int folio)
        {
            try
            {
                string evidence = _manager.GetFormaPago(folio);
                string archivo = "Pdf" + folio + "_" + ".pdf";
                //string archivo = evidence;
                string path = Path.Combine(Server.MapPath("~/Content/"), archivo);

                //FIRST IT ERASE THE FILE TO CREATE LATER
                System.IO.File.Delete(path);

                //ITS SAVED IN CONTENT FOLDER IN TEMPORAL FORM AND ITS RENAMED
                System.IO.File.Copy(evidence, path, true);

                return Json("../Content/" + archivo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [HttpPost]
        public JsonResult DelForma(int id)
        {
            try
            {
                string result = manager.DelForma(id);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public JsonResult UpFormaPago()
        {
            if (Request.Files.Count <= 0) return Json("No files selected.");
            try
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                int folio = string.IsNullOrEmpty(Request.Form["Folio"]) ? 0 : int.Parse(Request.Form["Folio"]);
                string tipo = Request.Form["Tipo"];
                for (int i = 0; i < files.Count; i++)
                {


                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split('\\');
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    string uploadName = Path.GetFileName(fname);

                    int val = manager.SaveDataFile(folio, uploadName);

                    if(val > 0) 
                    {
                        //SE GUARDA EL ARCHIVO DE MANERA LOCAL
                        string path = Path.Combine(Server.MapPath("~/Content/"), uploadName);
                        file.SaveAs(path);

                        //SE GUARDA EN LA RUTA QUE SERA COMPARTIDA PARA AMBAS DIRECCIONES 35 Y 36
                        string rwname = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\\FacturasDocs\\" + uploadName;
                        System.IO.File.Copy(path, rwname, true);

                        try
                        {
                            //_manager.SetCotizacion(folio,tipo, uploadName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    
                    }

                    return Json(uploadName);
                }
                return Json("Error");
            }
            catch (Exception ex)
            {
                return Json("Error");
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public ActionResult Comprobante()
        {
            try
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                //int folio = string.IsNullOrEmpty(Request.Form["Folio"]) ? 0 : int.Parse(Request.Form["Folio"]);


                for (int i = 0; i < files.Count; i++)
                {


                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split('\\');
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }


                    string uploadName = Path.GetFileName(fname);

                    //int val = manager.SaveDataFile(folio, uploadName);

                        //SE GUARDA EL ARCHIVO DE MANERA LOCAL
                        string path = Path.Combine(Server.MapPath("~/Content/"), uploadName);
                        file.SaveAs(path);

                        //SE GUARDA EN LA RUTA QUE SERA COMPARTIDA PARA AMBAS DIRECCIONES 35 Y 36
                        string rwname = @"\\\\10.200.154.35\\PentafonSSL\\FinancesDocs\\\Comprobantes\\" + uploadName;
                        System.IO.File.Copy(path, rwname, true);

                        try
                        {
                            //_manager.SetCotizacion(folio,tipo, uploadName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                    return Json(uploadName);
                }

                return Json("Error");
            }
            catch (Exception ex)
            {
                return Json("Error");
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [HttpPost]
        public JsonResult GetComprobante(int folio)
        {
            try
            {
                string evidence = manager.GetComprobante(folio);
                string archivo = "Pdf" + folio  + ".pdf";
                string path = Path.Combine(Server.MapPath("~/Content/"), archivo);

                //FIRST IT ERASE THE FILE TO CREATE LATER
                System.IO.File.Delete(path);

                //ITS SAVED IN CONTENT FOLDER IN TEMPORAL FORM AND ITS RENAMED
                System.IO.File.Copy(evidence, path, true);

                return Json("../Content/" + archivo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        //CLASS============================================================================================================================
    }

}
