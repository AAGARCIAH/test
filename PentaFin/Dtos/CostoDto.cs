using PentaFinances.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PentaFinances.Dtos
{
    public class CostoDto
    {
        public Campanas Campana { get; set; }
        public CostosPersonalCantDto Costos { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class CostosPersonalCantDto
    {
        public GenericDto AgenteCDMX { get; set; }
        public GenericDto AgenteMorelia { get; set; }
        public GenericDto AgenteSD { get; set; }
        public GenericDto AgenteCAC { get; set; }
        public GenericDto Campo { get; set; }
        public GenericDto BO { get; set; }
        public GenericDto Validador { get; set; }
        public GenericDto SupervisorCDMX { get; set; }
        public GenericDto SupervisorMorelia { get; set; }
        public GenericDto SupervisorMesaAyuda { get; set; }
        public GenericDto Coordinador { get; set; }
        public GenericDto GerenteCDMX { get; set; }
        public GenericDto GerenteMorelia { get; set; }
        public GenericDto Subdirector { get; set; }
        public GenericDto EstacionesCDMX { get; set; }
        public GenericDto EstacionesMorelia { get; set; }
        public GenericDto EstacionesVenezuela { get; set; }
        public GenericDto AgenteporSupervisor { get; set; }
        public GenericDto AgenteporEstacion { get; set; }

    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    //Sección Dtos Costos Directos

    public class CostosDirectosDto
    {
        public Campanas Campana { get; set; }
        public CostosDirectosPtDto CostosDirectos { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    public class CostosDirectosPtDto
    {
        public GenericDto Gerencial { get; set; }
        public GenericDto Operacion { get; set; }
        public GenericDto NominaEspecial { get; set; }
        public GenericDto RentaEquipoComputo { get; set; }
        public GenericDto ServiciosOutsourcing { get; set; }
        public GenericDto ServiciosMaquilados { get; set; }
        public GenericDto SegurosyFianzasCuotas_Suscripciones { get; set; }
        public GenericDto Directo { get; set; }
        public GenericDto Otros { get; set; }
        public GenericDto Licencias { get; set; }
        public GenericDto AplicativoCitasSNE { get; set; }

    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    

    
    //Sección Dtos Costos Indirectos

    public class CostosIndirectosDto
    {
        public Campanas Campana { get; set; }
        public CostosIndirectosStrDto CostosIndirectos { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    public class CostosIndirectosStrDto
    {
        public GenericDto Gerencial { get; set; }
        public GenericDto Operacion { get; set; }
        public GenericDto Depreciaciones { get; set; }
        public GenericDto AmortizacionesLicencias { get; set; }
        public GenericDto AmortizacionesServiciosMantenimiento { get; set; }
        public GenericDto EquipoOficina { get; set; }
        public GenericDto CompraEquipoComputo { get; set; }
        public GenericDto MantenimientoEquipoComputo { get; set; }
        public GenericDto Firewall_Dominio { get; set; }
        public GenericDto Diademas { get; set; }
        public GenericDto Renta { get; set; }
        public GenericDto Luz { get; set; }
        public GenericDto Agua { get; set; }
        public GenericDto Vigilancia { get; set; }
        public GenericDto Limpieza { get; set; }
        public GenericDto Edificio { get; set; }
        public GenericDto ServAudFiscal { get; set; }
        public GenericDto ServDeLegal { get; set; }
        public GenericDto servContables { get; set; }
        public GenericDto ServdeAdministrativos { get; set; }
        public GenericDto Corporativo { get; set; }
        public GenericDto Papeleria { get; set; }
        public GenericDto Diversos { get; set; }
        public GenericDto Nodeducibles { get; set; }
        public GenericDto IncentivosEmpleados { get; set; }
        public GenericDto Pasajes { get; set; }
        public GenericDto Despensa { get; set; }
        public GenericDto Alimentos_Consumos_Gastosviaje { get; set; }
        public GenericDto SMS_Carteo { get; set; }
        public GenericDto BaseDatos { get; set; }
        public GenericDto CertificacionPCI { get; set; }
        public GenericDto Indirecto { get; set; }
        public GenericDto OCC { get; set; }
        public GenericDto Cursos { get; set; }
        public GenericDto PacketLincencias_servidores_implementaciones { get; set; }
        public GenericDto Comisiones { get; set; }
        public GenericDto PerdidaUtilidadCambiaria { get; set; }
        public GenericDto Otrosgastos_Ingresos { get; set; }
        public GenericDto InteresesPagados_Ganados { get; set; }
        public GenericDto RentadeUPS { get; set; }
        public GenericDto RentadePlanta { get; set; }

    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class CostosFiller { 
    public CostosDirectosPt pt {get;set;}
    public CostosDirectosFr fr { get; set; }
    public CostosDirectosCi ci { get; set; }
    public CostosDirectosRe re { get; set; }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
}