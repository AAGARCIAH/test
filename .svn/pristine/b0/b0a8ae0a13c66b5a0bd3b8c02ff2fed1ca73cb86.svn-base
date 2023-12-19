using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PentaFinances.Models
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class PentaFinContext : DbContext
    {
        public DbSet<AppUsuarios> AppUsuarios { get; set; }
        public DbSet<IngresoBi> IngresoBi { get; set; }
        public DbSet<IngresoOp> IngresoOp { get; set; }
        public DbSet<IngresoCi> IngresoCi { get; set; }
        public DbSet<IndicadoresEspecificosBi> IndicadoresEspecificosBi { get; set; }
        public DbSet<IndicadoresEspecificosOp> IndicadoresEspecificosOp { get; set; }
        public DbSet<IndicadoresEspecificosCi> IndicadoresEspecificosCi { get; set; }
        public DbSet<EstacionesEspecializadasBi> EstacionesEspecializadasBi { get; set; }
        public DbSet<EstacionesEspecializadasOp> EstacionesEspecializadasOp { get; set; }
        public DbSet<EstacionesEspecializadasCi> EstacionesEspecializadasCi { get; set; }
        //---DBSet Precios
        public DbSet<PrecioOp> PrecioOp { get; set; }
        public DbSet<PrecioCi> PrecioCi { get; set; }
        //---DBSet Costos
        //---------Costos Directos
        public DbSet<CostosDirectosPt> CostosDirectosPt { get; set; }
        public DbSet<CostosDirectosFr> CostosDirectosFr { get; set; }
        public DbSet<CostosDirectosCi> CostosDirectosCi { get; set; }
        public DbSet<CostosDirectosRe> CostosDirectosRe { get; set; }
        //---------Costos Indirectos
        public DbSet<CostosIndirectosPt> CostosIndirectosPt { get; set; }
        public DbSet<CostosIndirectosFr> CostosIndirectosFr { get; set; }
        public DbSet<CostosIndirectosCi> CostosIndirectosCi { get; set; }
        public DbSet<CostosIndirectosRe> CostosIndirectosRe { get; set; }
        //---------Ingresos Totales
        public DbSet<IngresosTotPt> IngresosTotPt { get; set; }
        public DbSet<IngresosTotFr> IngresosTotFr { get; set; }
        public DbSet<IngresosTotCi> IngresosTotCi { get; set; }
        public DbSet<IngresosTotRe> IngresosTotRe { get; set; }

        

        public PentaFinContext()
                : base("name=FinConn")
            {
                this.Configuration.LazyLoadingEnabled = true;
                Database.SetInitializer((IDatabaseInitializer<PentaFinContext>)null);
            }
    }



    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      
    public class AppUsuarios
    {
        [Key]
        public string UserName { get; set; }
        public int TipoUserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    [Table("IngresoBiDetalles", Schema = "dbo")]
    public class IngresoBi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal DiasServicio { get; set; }
        public decimal HorasServicio { get; set; }
        public decimal LlamadasAcd { get; set; }
        public decimal LlamadasIvr { get; set; }
        public decimal LlamadasEntrada { get; set; }
        public decimal LlamadasContestadas { get; set; }
        public decimal LlamadasFacturables { get; set; }
        public decimal LlamadasSalida { get; set; }
        public decimal Chat { get; set; }
        public decimal Sms { get; set; }
        public decimal Email { get; set; }
        public decimal NivelServicio { get; set; }
        public decimal Abandono { get; set; }
        public decimal Asa { get; set; }
        public decimal Aht { get; set; }
        public decimal Sph { get; set; }
        public decimal MinutosEntrada { get; set; }
        public decimal MinutosSalidaFijo { get; set; }
        public decimal MinutosSalidaCelular { get; set; }
        public decimal Ocupacion { get; set; }
        public decimal Adherencia { get; set; }
        public decimal Ausentismo { get; set; }
        public decimal Rotacion { get; set; }
        public decimal HorasConexion { get; set; }
        public decimal HorasPagadas { get; set; }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("IngresoOpDetalles", Schema = "dbo")]
    public class IngresoOp
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal DiasServicio { get; set; }
        public decimal HorasServicio { get; set; }
        public decimal LlamadasAcd { get; set; }
        public decimal LlamadasIvr { get; set; }
        public decimal LlamadasEntrada { get; set; }
        public decimal LlamadasContestadas { get; set; }
        public decimal LlamadasFacturables { get; set; }
        public decimal LlamadasSalida { get; set; }
        public decimal Chat { get; set; }
        public decimal Sms { get; set; }
        public decimal Email { get; set; }
        public decimal NivelServicio { get; set; }
        public decimal Abandono { get; set; }
        public decimal Asa { get; set; }
        public decimal Aht { get; set; }
        public decimal Sph { get; set; }
        public decimal MinutosEntrada { get; set; }
        public decimal MinutosSalidaFijo { get; set; }
        public decimal MinutosSalidaCelular { get; set; }
        public decimal Ocupacion { get; set; }
        public decimal Adherencia { get; set; }
        public decimal Ausentismo { get; set; }
        public decimal Rotacion { get; set; }
        public decimal HorasConexion { get; set; }
        public decimal HorasPagadas { get; set; }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("IngresoCiDetalles", Schema = "dbo")]
    public class IngresoCi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal DiasServicio { get; set; }
        public decimal HorasServicio { get; set; }
        public decimal LlamadasAcd { get; set; }
        public decimal LlamadasIvr { get; set; }
        public decimal LlamadasEntrada { get; set; }
        public decimal LlamadasContestadas { get; set; }
        public decimal LlamadasFacturables { get; set; }
        public decimal LlamadasSalida { get; set; }
        public decimal Chat { get; set; }
        public decimal Sms { get; set; }
        public decimal Email { get; set; }
        public decimal NivelServicio { get; set; }
        public decimal Abandono { get; set; }
        public decimal Asa { get; set; }
        public decimal Aht { get; set; }
        public decimal Sph { get; set; }
        public decimal MinutosEntrada { get; set; }
        public decimal MinutosSalidaFijo { get; set; }
        public decimal MinutosSalidaCelular { get; set; }
        public decimal Ocupacion { get; set; }
        public decimal Adherencia { get; set; }
        public decimal Ausentismo { get; set; }
        public decimal Rotacion { get; set; }
        public decimal HorasConexion { get; set; }
        public decimal HorasPagadas { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  

    [Table("IndicadoresEspecificosBiDetalles", Schema = "dbo")]
    public class IndicadoresEspecificosBi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Asignacion { get; set; }
        public decimal PorcAsignacion { get; set; }
        public decimal PorcHonorarios { get; set; }
        public decimal PorcRecuperacion { get; set; }
        public decimal PorcConversion { get; set; }
        public decimal Pedidos { get; set; }
        public decimal VentasUpsell { get; set; }
        public decimal UpsellPromedio { get; set; }
        public decimal Ventas { get; set; }
        public decimal PorcValidacion { get; set; }
        public decimal PorcActivacion { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    [Table("IndicadoresEspecificosOpDetalles", Schema = "dbo")]
    public class IndicadoresEspecificosOp
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Asignacion { get; set; }
        public decimal PorcAsignacion { get; set; }
        public decimal PorcHonorarios { get; set; }
        public decimal PorcRecuperacion { get; set; }
        public decimal PorcConversion { get; set; }
        public decimal Pedidos { get; set; }
        public decimal VentasUpsell { get; set; }
        public decimal UpsellPromedio { get; set; }
        public decimal Ventas { get; set; }
        public decimal PorcValidacion { get; set; }
        public decimal PorcActivacion { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      

    [Table("IndicadoresEspecificosCiDetalles", Schema = "dbo")]
    public class IndicadoresEspecificosCi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Asignacion { get; set; }
        public decimal PorcAsignacion { get; set; }
        public decimal PorcHonorarios { get; set; }
        public decimal PorcRecuperacion { get; set; }
        public decimal PorcConversion { get; set; }
        public decimal Pedidos { get; set; }
        public decimal VentasUpsell { get; set; }
        public decimal UpsellPromedio { get; set; }
        public decimal Ventas { get; set; }
        public decimal PorcValidacion { get; set; }
        public decimal PorcActivacion { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   
    
    [Table("EstacionesEspecializadasBiDetalles", Schema = "dbo")]
    public class EstacionesEspecializadasBi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Nafin { get; set; }
        public decimal Proveedor { get; set; }
        public decimal Vip { get; set; }
        public decimal Credito { get; set; }
        public decimal KioscoVirtual { get; set; }
        public decimal Operativa { get; set; }
        public decimal Especializada { get; set; }
        public decimal SinDelantal { get; set; }
        public decimal ServicioImpresionEscaner { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   

    [Table("EstacionesEspecializadasOpDetalles", Schema = "dbo")]
    public class EstacionesEspecializadasOp
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Nafin { get; set; }
        public decimal Proveedor { get; set; }
        public decimal Vip { get; set; }
        public decimal Credito { get; set; }
        public decimal KioscoVirtual { get; set; }
        public decimal Operativa { get; set; }
        public decimal Especializada { get; set; }
        public decimal SinDelantal { get; set; }
        public decimal ServicioImpresionEscaner { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   

    [Table("EstacionesEspecializadasCiDetalles", Schema = "dbo")]
    public class EstacionesEspecializadasCi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Nafin { get; set; }
        public decimal Proveedor { get; set; }
        public decimal Vip { get; set; }
        public decimal Credito { get; set; }
        public decimal KioscoVirtual { get; set; }
        public decimal Operativa { get; set; }
        public decimal Especializada { get; set; }
        public decimal SinDelantal { get; set; }
        public decimal ServicioImpresionEscaner { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   

    [Table("PrecioOpDetalles", Schema = "dbo")]
    public class PrecioOp
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Fijo { get; set; }
        public decimal Persona { get; set; }
        public decimal EstacionEspecializada { get; set; }
        public decimal Hora { get; set; }
        public decimal Minuto { get; set; }
        public decimal LlamadaEntrada { get; set; }
        public decimal LlamadaSalida { get; set; }
        public decimal Chat { get; set; }
        public decimal SMS { get; set; }
        public decimal Email { get; set; }
        public decimal Venta { get; set; }
        public decimal TicketVenta { get; set; }
        public decimal MinutosEntrada { get; set; }
        public decimal MinutosSalidaFijo { get; set; }
        public decimal MinutosSalidaCelular { get; set; }
        public decimal KioscoVirtual { get; set; }
        public decimal ServicioImpresiónyEscaner { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     

    [Table("PrecioCiDetalles", Schema = "dbo")]
    public class PrecioCi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Fijo { get; set; }
        public decimal Persona { get; set; }
        public decimal EstacionEspecializada { get; set; }
        public decimal Hora { get; set; }
        public decimal Minuto { get; set; }
        public decimal LlamadaEntrada { get; set; }
        public decimal LlamadaSalida { get; set; }
        public decimal Chat { get; set; }
        public decimal SMS { get; set; }
        public decimal Email { get; set; }
        public decimal Venta { get; set; }
        public decimal TicketVenta { get; set; }
        public decimal MinutosEntrada { get; set; }
        public decimal MinutosSalidaFijo { get; set; }
        public decimal MinutosSalidaCelular { get; set; }
        public decimal KioscoVirtual { get; set; }
        public decimal ServicioImpresiónyEscaner { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //Sección Modelos de Costo

    [Table("CostoPersonalCantOpDetalles", Schema = "dbo")]
    public class CostoPersonalCant
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal AgenteCDMX { get; set; }
        public decimal AgenteMorelia { get; set; }
        public decimal AgenteSD { get; set; }
        public decimal AgenteCAC { get; set; }
        public decimal Campo { get; set; }
        public decimal BO { get; set; }
        public decimal Validador { get; set; }
        public decimal SupervisorCDMX { get; set; }
        public decimal SupervisorMorelia{ get; set; }
        public decimal SupervisorMesaAyuda { get; set; }
        public decimal Coordinador { get; set; }
        public decimal GerenteCDMX { get; set; }
        public decimal GerenteMorelia { get; set; }
        public decimal Subdirector { get; set; }
        public decimal EstacionesCDMX { get; set; }
        public decimal EstacionesMorelia { get; set; }
        public decimal EstacionesVenezuela { get; set; }
        public decimal AgenteporSupervisor { get; set; }
        public decimal AgenteporEstacion { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   

    [Table("CostoPersonalCostOpDetalles", Schema = "dbo")]
    public class CostoPersonalCost
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal AgenteCDMX { get; set; }
        public decimal AgenteMorelia { get; set; }
        public decimal AgenteSD { get; set; }
        public decimal AgenteCAC { get; set; }
        public decimal Campo { get; set; }
        public decimal BO { get; set; }
        public decimal Validador { get; set; }
        public decimal SupervisorCDMX { get; set; }
        public decimal SupervisorMorelia { get; set; }
        public decimal SupervisorMesaAyuda { get; set; }
        public decimal Coordinador { get; set; }
        public decimal GerenteCDMX { get; set; }
        public decimal GerenteMorelia { get; set; }
        public decimal Subdirector { get; set; }
        public decimal EstacionesCDMX { get; set; }
        public decimal EstacionesMorelia { get; set; }
        public decimal EstacionesVenezuela { get; set; }
        public decimal AgenteporSupervisor { get; set; }
        public decimal AgenteporEstacion { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   

    [Table("CostosDirectosPtDetalles", Schema = "dbo")]
    public class CostosDirectosPt
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal NominaEspecial { get; set; }
        public decimal RentaEquipoComputo { get; set; }
        public decimal ServiciosOutsourcing { get; set; }
        public decimal ServiciosMaquilados { get; set; }
        public decimal SegurosyFianzasCuotas_Suscripciones { get; set; }
        public decimal Directo { get; set; }
        public decimal Otros { get; set; }
        public decimal Licencias { get; set; }
        public decimal AplicativoCitasSNE { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -   

    [Table("CostosDirectosFrDetalles", Schema = "dbo")]
    public class CostosDirectosFr
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal NominaEspecial { get; set; }
        public decimal RentaEquipoComputo { get; set; }
        public decimal ServiciosOutsourcing { get; set; }
        public decimal ServiciosMaquilados { get; set; }
        public decimal SegurosyFianzasCuotas_Suscripciones { get; set; }
        public decimal Directo { get; set; }
        public decimal Otros { get; set; }
        public decimal Licencias { get; set; }
        public decimal AplicativoCitasSNE { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("CostosDirectosCiDetalles", Schema = "dbo")]
    public class CostosDirectosCi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal NominaEspecial { get; set; }
        public decimal RentaEquipoComputo { get; set; }
        public decimal ServiciosOutsourcing { get; set; }
        public decimal ServiciosMaquilados { get; set; }
        public decimal SegurosyFianzasCuotas_Suscripciones { get; set; }
        public decimal Directo { get; set; }
        public decimal Otros { get; set; }
        public decimal Licencias { get; set; }
        public decimal AplicativoCitasSNE { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("CostosDirectosReDetalles", Schema = "dbo")]
    public class CostosDirectosRe
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal NominaEspecial { get; set; }
        public decimal RentaEquipoComputo { get; set; }
        public decimal ServiciosOutsourcing { get; set; }
        public decimal ServiciosMaquilados { get; set; }
        public decimal SegurosyFianzasCuotas_Suscripciones { get; set; }
        public decimal Directo { get; set; }
        public decimal Otros { get; set; }
        public decimal Licencias { get; set; }
        public decimal AplicativoCitasSNE { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("CostosIndirectosPtDetalles", Schema = "dbo")]
    public class CostosIndirectosPt
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal Depreciaciones { get; set; }
        public decimal AmortizacionesLicencias { get; set; }
        public decimal AmortizacionesServiciosMantenimiento { get; set; }
        public decimal EquipoOficina { get; set; }
        public decimal CompraEquipoComputo { get; set; }
        public decimal MantenimientoEquipoComputo { get; set; }
        public decimal Firewall_Dominio { get; set; }
        public decimal Diademas { get; set; }
        public decimal Renta { get; set; }
        public decimal Luz { get; set; }
        public decimal Agua { get; set; }
        public decimal Vigilancia { get; set; }
        public decimal Limpieza { get; set; }
        public decimal Edificio { get; set; }
        public decimal ServAudFiscal { get; set; }
        public decimal ServDeLegal { get; set; }
        public decimal servContables { get; set; }
        public decimal ServdeAdministrativos { get; set; }
        public decimal Corporativo { get; set; }
        public decimal Papeleria { get; set; }
        public decimal Diversos { get; set; }
        public decimal Nodeducibles { get; set; }
        public decimal IncentivosEmpleados { get; set; }
        public decimal Pasajes { get; set; }
        public decimal Despensa { get; set; }
        public decimal Alimentos_Consumos_Gastosviaje { get; set; }
        public decimal SMS_Carteo { get; set; }
        public decimal BaseDatos { get; set; }
        public decimal CertificacionPCI { get; set; }
        public decimal Indirecto { get; set; }
        public decimal OCC { get; set; }
        public decimal Cursos { get; set; }
        public decimal PacketLincencias_servidores_implementaciones { get; set; }
        public decimal Comisiones { get; set; }
        public decimal PerdidaUtilidadCambiaria { get; set; }
        public decimal Otrosgastos_Ingresos { get; set; }
        public decimal InteresesPagados_Ganados { get; set; }
        public decimal RentadeUPS { get; set; }
        public decimal RentadePlanta { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("CostosIndirectosFrDetalles", Schema = "dbo")]
    public class CostosIndirectosFr
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal Depreciaciones { get; set; }
        public decimal AmortizacionesLicencias { get; set; }
        public decimal AmortizacionesServiciosMantenimiento { get; set; }
        public decimal EquipoOficina { get; set; }
        public decimal CompraEquipoComputo { get; set; }
        public decimal MantenimientoEquipoComputo { get; set; }
        public decimal Firewall_Dominio { get; set; }
        public decimal Diademas { get; set; }
        public decimal Renta { get; set; }
        public decimal Luz { get; set; }
        public decimal Agua { get; set; }
        public decimal Vigilancia { get; set; }
        public decimal Limpieza { get; set; }
        public decimal Edificio { get; set; }
        public decimal ServAudFiscal { get; set; }
        public decimal ServDeLegal { get; set; }
        public decimal servContables { get; set; }
        public decimal ServdeAdministrativos { get; set; }
        public decimal Corporativo { get; set; }
        public decimal Papeleria { get; set; }
        public decimal Diversos { get; set; }
        public decimal Nodeducibles { get; set; }
        public decimal IncentivosEmpleados { get; set; }
        public decimal Pasajes { get; set; }
        public decimal Despensa { get; set; }
        public decimal Alimentos_Consumos_Gastosviaje { get; set; }
        public decimal SMS_Carteo { get; set; }
        public decimal BaseDatos { get; set; }
        public decimal CertificacionPCI { get; set; }
        public decimal Indirecto { get; set; }
        public decimal OCC { get; set; }
        public decimal Cursos { get; set; }
        public decimal PacketLincencias_servidores_implementaciones { get; set; }
        public decimal Comisiones { get; set; }
        public decimal PerdidaUtilidadCambiaria { get; set; }
        public decimal Otrosgastos_Ingresos { get; set; }
        public decimal InteresesPagados_Ganados { get; set; }
        public decimal RentadeUPS { get; set; }
        public decimal RentadePlanta { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("CostosIndirectosCiDetalles", Schema = "dbo")]
    public class CostosIndirectosCi
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal Depreciaciones { get; set; }
        public decimal AmortizacionesLicencias { get; set; }
        public decimal AmortizacionesServiciosMantenimiento { get; set; }
        public decimal EquipoOficina { get; set; }
        public decimal CompraEquipoComputo { get; set; }
        public decimal MantenimientoEquipoComputo { get; set; }
        public decimal Firewall_Dominio { get; set; }
        public decimal Diademas { get; set; }
        public decimal Renta { get; set; }
        public decimal Luz { get; set; }
        public decimal Agua { get; set; }
        public decimal Vigilancia { get; set; }
        public decimal Limpieza { get; set; }
        public decimal Edificio { get; set; }
        public decimal ServAudFiscal { get; set; }
        public decimal ServDeLegal { get; set; }
        public decimal servContables { get; set; }
        public decimal ServdeAdministrativos { get; set; }
        public decimal Corporativo { get; set; }
        public decimal Papeleria { get; set; }
        public decimal Diversos { get; set; }
        public decimal Nodeducibles { get; set; }
        public decimal IncentivosEmpleados { get; set; }
        public decimal Pasajes { get; set; }
        public decimal Despensa { get; set; }
        public decimal Alimentos_Consumos_Gastosviaje { get; set; }
        public decimal SMS_Carteo { get; set; }
        public decimal BaseDatos { get; set; }
        public decimal CertificacionPCI { get; set; }
        public decimal Indirecto { get; set; }
        public decimal OCC { get; set; }
        public decimal Cursos { get; set; }
        public decimal PacketLincencias_servidores_implementaciones { get; set; }
        public decimal Comisiones { get; set; }
        public decimal PerdidaUtilidadCambiaria { get; set; }
        public decimal Otrosgastos_Ingresos { get; set; }
        public decimal InteresesPagados_Ganados { get; set; }
        public decimal RentadeUPS { get; set; }
        public decimal RentadePlanta { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("CostosIndirectosReDetalles", Schema = "dbo")]
    public class CostosIndirectosRe
    {
        [Key]
        public int Id { get; set; }
        public string IdCampana { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal Gerencial { get; set; }
        public decimal Operacion { get; set; }
        public decimal Depreciaciones { get; set; }
        public decimal AmortizacionesLicencias { get; set; }
        public decimal AmortizacionesServiciosMantenimiento { get; set; }
        public decimal EquipoOficina { get; set; }
        public decimal CompraEquipoComputo { get; set; }
        public decimal MantenimientoEquipoComputo { get; set; }
        public decimal Firewall_Dominio { get; set; }
        public decimal Diademas { get; set; }
        public decimal Renta { get; set; }
        public decimal Luz { get; set; }
        public decimal Agua { get; set; }
        public decimal Vigilancia { get; set; }
        public decimal Limpieza { get; set; }
        public decimal Edificio { get; set; }
        public decimal ServAudFiscal { get; set; }
        public decimal ServDeLegal { get; set; }
        public decimal servContables { get; set; }
        public decimal ServdeAdministrativos { get; set; }
        public decimal Corporativo { get; set; }
        public decimal Papeleria { get; set; }
        public decimal Diversos { get; set; }
        public decimal Nodeducibles { get; set; }
        public decimal IncentivosEmpleados { get; set; }
        public decimal Pasajes { get; set; }
        public decimal Despensa { get; set; }
        public decimal Alimentos_Consumos_Gastosviaje { get; set; }
        public decimal SMS_Carteo { get; set; }
        public decimal BaseDatos { get; set; }
        public decimal CertificacionPCI { get; set; }
        public decimal Indirecto { get; set; }
        public decimal OCC { get; set; }
        public decimal Cursos { get; set; }
        public decimal PacketLincencias_servidores_implementaciones { get; set; }
        public decimal Comisiones { get; set; }
        public decimal PerdidaUtilidadCambiaria { get; set; }
        public decimal Otrosgastos_Ingresos { get; set; }
        public decimal InteresesPagados_Ganados { get; set; }
        public decimal RentadeUPS { get; set; }
        public decimal RentadePlanta { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("IngresosTotPtDetalles", Schema = "dbo")]
    public class IngresosTotPt
    {
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal IngresosTotales { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    [Table("IngresosTotFrDetalles", Schema = "dbo")]
    public class IngresosTotFr
    {
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal IngresosTotales { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    [Table("IngresosTotCiDetalles", Schema = "dbo")]
    public class IngresosTotCi
    {
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal IngresosTotales { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    [Table("IngresosTotReDetalles", Schema = "dbo")]
    public class IngresosTotRe
    {
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int RegYear { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal IngresosTotales { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
}