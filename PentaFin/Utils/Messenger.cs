using Newtonsoft.Json;
using PentaFinances.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace PentaFinances.Utils
{
    public class Messenger
    {
        //CLASS============================================================================================================================
        //CODE BRINGED BY THE GLORY ULTRAMARINES CHAPTER
        //CODING BY: CAPTAIN DANIEL FUENTES DFR
        //PROJECT PENTA FINANCES
        //private string ultramail = "compras@pentafon.com";
        //private string ultramail = "rhadmin_com@pentafon.com";
        // private string password = "BGUu/=MS9";
        //private string password = "BGUu/=MS9";
        // private string password = "rh4dm1n_c0m2019#";
        //private string password = "C0mr$4ss2021";


        private string ultramail = "compras@pentafon.com";
        private string password = "C0mr$4ss2021";
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string SendMail(string subject, string header, string content, string to, List<string> cc)
        {
            string mail;
            mail = "<html>";
            mail += "<table>";
            mail += "<label>" + header + "</label></td></tr>";
            mail += "<tr><td colspan='2' style='width: 300px;font-weight: bold;'>";
            mail += "<tr><td colspan='2'>" + content + "</td></tr>";
            mail += "<br>";
            mail += "</table>";
            mail += "<br><br>";
            mail += "</html>";
            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://appext.pentafon.com/ApiPentafon/Mailing/BasicSend");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        Host = "smtp.office365.com",
                        port = "587",
                        mailaddress = "compras@pentafon.com",
                        emailpassword = "C0mr$4ss2021",
                        mailTo = to,
                        cc = cc,
                        mailTitle = subject,
                        mailMessage = mail
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (streamReader != null)
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
                //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                return httpResponse.StatusDescription;
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;

                    using (Stream data = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(data);
                        Console.Write(sr.ReadToEnd());
                        throw new Exception(sr.ReadToEnd());
                    }
                }
            }
            //return "OK";
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string SendMailToApprove(string subject, string header, string content, string to, List<string> _cc = null)
        {
            List<string> cc = new List<string>();
            if (_cc != null)
                cc = _cc;

            string mail;
            mail = "<html>";
            mail += "<table>";
            mail += "<label>" + header + "</label></td></tr>";
            mail += "<tr><td colspan='2' style='width: 300px;font-weight: bold;'>";
            mail += "<tr><td colspan='2'>" + content + "</td></tr>";
            mail += "<br>";
            mail += "</table>";
            mail += "<br><br>";
            mail += "</html>";
            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://appext.pentafon.com/ApiPentafon/Mailing/BasicSend");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";


                //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        Host = "smtp.office365.com",
                        port = "587",
                        mailaddress = "compras@pentafon.com",
                        emailpassword = "C0mr$4ss2021",
                        mailTo = to,
                        cc = cc,
                        mailTitle = subject,
                        mailMessage = mail
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (streamReader != null)
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
                //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                return httpResponse.StatusDescription;
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;

                    using (Stream data = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(data);
                        Console.Write(sr.ReadToEnd());
                        throw new Exception(sr.ReadToEnd());
                    }
                }
            }


            //return "OK";
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public string Post(string subject, string header, string content, string to, List<string> cc  = null)
        {
            string mail;
            mail = "<html>";
            mail += "<table>";
            mail += "<label>" + header + "</label></td></tr>";
            mail += "<tr><td colspan='2' style='width: 300px;font-weight: bold;'>";
            mail += "<tr><td colspan='2'>" + content + "</td></tr>";
            mail += "<br>";
            mail += "</table>";
            mail += "<br><br>";
            mail += "</html>";
            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://appext.pentafon.com/ApiPentafon/Mailing/BasicSend");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        Host = "smtp.office365.com",
                        port = "587",
                        mailaddress = "compras@pentafon.com",
                        emailpassword = "C0mr$4ss2021",
                        mailTo = to,
                        cc = cc,
                        mailTitle = subject,
                        mailMessage = mail
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (streamReader != null)
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
                //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                return httpResponse.StatusDescription;
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;

                    using (Stream data = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(data);
                        Console.Write(sr.ReadToEnd());
                        throw new Exception(sr.ReadToEnd());
                    }
                }
            }

            //return "OK";
        }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //============================================================================================================================

    }
}