using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PentaFinances.Utils
{
    public class Utilities
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstMeses()
        {
            List<SelectListItem> listameses = new List<SelectListItem>();

            listameses.Add(new SelectListItem
            {
                Text = "Enero",
                Value = "1",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Febrero",
                Value = "2",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Marzo",
                Value = "3",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Abril",
                Value = "4",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Mayo",
                Value = "5",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Junio",
                Value = "6",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Julio",
                Value = "7",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Agosto",
                Value = "8",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Septiembre",
                Value = "9",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Octubre",
                Value = "10",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Noviembre",
                Value = "11",
            });

            listameses.Add(new SelectListItem
            {
                Text = "Diciembre",
                Value = "12",
            });

            return listameses;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public List<SelectListItem> LstAnios()
        {
            List<SelectListItem> listaanios = new List<SelectListItem>();

            for (int y = 0; y < 10; y++) {

                int anioactual = DateTime.Now.Year;
                anioactual = anioactual - y;
                string aniostr = anioactual.ToString();

                listaanios.Add(new SelectListItem
                {
                    Text = aniostr,
                    Value = aniostr,
                });
            
            }

            return listaanios;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Utilidades Módulo de Compras
        public List<SelectListItem> LstSiNo()
        {
            List<SelectListItem> listsino = new List<SelectListItem>();

            listsino.Add(new SelectListItem
                {
                    Text = "Si",
                    Value = "true"
                });

            listsino.Add(new SelectListItem
            {
                Text = "No",
                Value = "0"
            });

            return listsino;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstSolicitante()
        {
            List<SelectListItem> listsolicitante = new List<SelectListItem>();

           listsolicitante.Add(new SelectListItem
            {
                Text = "MANUEL GONZALEZ",
                Value = "MANUEL GONZALEZ"
            });

            listsolicitante.Add(new SelectListItem
            {
                Text = "JORGE MENDOZA",
                Value = "JORGE MENDOZA"
            });

            listsolicitante.Add(new SelectListItem
            {
                Text = "MARIANA AVILA",
                Value = "MARIANA AVILA"
            });

            listsolicitante.Add(new SelectListItem
            {
                Text = "JUAN BAUTISTA",
                Value = "JUAN BAUTISTA"
            });

            return listsolicitante;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public List<SelectListItem> LstMailSol()
        {
            List<SelectListItem> listmailsol = new List<SelectListItem>();
           
            listmailsol.Add(new SelectListItem
            {
                Text = "mgonzaez",
                Value = "mgonzaez"
            });

            listmailsol.Add(new SelectListItem
            {
                Text = "jmendoza",
                Value = "jmendoza"
            });

            listmailsol.Add(new SelectListItem
            {
                Text = "mavila",
                Value = "mavila"
            });

            listmailsol.Add(new SelectListItem
            {
                Text = "jbautista",
                Value = "jbautista"
            });

            return listmailsol;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstCampanas()
        {
            List<SelectListItem> listcampanas = new List<SelectListItem>();

            listcampanas.Add(new SelectListItem
            {
                Text = "MOVISTAR",
                Value = "MOVISTAR"
            });

            listcampanas.Add(new SelectListItem
            {
                Text = "AT&T",
                Value = "AT&T"
            });

            listcampanas.Add(new SelectListItem
            {
                Text = "SRE",
                Value = "SRE"
            });

            listcampanas.Add(new SelectListItem
            {
                Text = "NAFIN",
                Value = "NAFIN"
            });

            listcampanas.Add(new SelectListItem
            {
                Text = "SEGURO POPULAR",
                Value = "SEGURO POPULAR"
            });

            return listcampanas;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstDeptos()
        {
            List<SelectListItem> listdeptos = new List<SelectListItem>();

            listdeptos.Add(new SelectListItem
            {
                Text = "FINANZAS",
                Value = "FINANZAS"
            });

            listdeptos.Add(new SelectListItem
            {
                Text = "RRHH",
                Value = "RRHH"
            });

            listdeptos.Add(new SelectListItem
            {
                Text = "SISTEMAS",
                Value = "SISTEMAS"
            });

            listdeptos.Add(new SelectListItem
            {
                Text = "CALIDAD",
                Value = "CALIDAD"
            });

            listdeptos.Add(new SelectListItem
            {
                Text = "OTRO",
                Value = "OTRO"
            });

            return listdeptos;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstFormaPago()
        {
            List<SelectListItem> listformapago = new List<SelectListItem>();

            listformapago.Add(new SelectListItem
            {
                Text = "TRANSFERENCIA BANCARIA",
                Value = "TRANSFERENCIA BANCARIA"
            });

            listformapago.Add(new SelectListItem
            {
                Text = "CHEQUE",
                Value = "CHEQUE"
            });

            listformapago.Add(new SelectListItem
            {
                Text = "EFECTIVO",
                Value = "EFECTIVO"
            });


            return listformapago;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstEstadoSolicitud()
        {
            List<SelectListItem> listestadosol = new List<SelectListItem>();

            //listestadosol.Add(new SelectListItem
            //{
            //    Text = "SOLICITADO",
            //    Value = "SOLICITADO"
            //});

            listestadosol.Add(new SelectListItem
            {
                Text = "CONTINUAR PROCESO DE SELECCIÓN DE PROVEEDORES",
                Value = "2"
            });

            listestadosol.Add(new SelectListItem
            {
                Text = "RECHAZAR",
                Value = "3"
            });


            return listestadosol;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public List<SelectListItem> LstCalificacion()
        {
            List<SelectListItem> listcalif = new List<SelectListItem>();
            
            for(int i=7; i<=10; i++) {
                listcalif.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
                }
            return listcalif;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}