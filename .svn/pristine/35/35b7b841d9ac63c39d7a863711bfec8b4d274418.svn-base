using PentaFinances.Models;

namespace PentaFinances.Dtos
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    
    public class IngresosDto
    {
        public Campanas Campana { get; set; }
        public IngresoGeneralesDto Ingreso { get; set; }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class IngresoGeneralesDto
    {
        public GenericDto DiasServicio { get; set; }
        public GenericDto HorasServicio { get; set; }
        public GenericDto LlamadasAcd { get; set; }
        public GenericDto LlamadasIvr { get; set; }
        public GenericDto LlamadasEntrada { get; set; }
        public GenericDto LlamadasContestadas { get; set; }
        public GenericDto LlamadasFacturables { get; set; }
        public GenericDto LlamadasSalida { get; set; }
        public GenericDto Chat { get; set; }
        public GenericDto Sms { get; set; }
        public GenericDto Email { get; set; }
        public GenericDto NivelServicio { get; set; }
        public GenericDto Abandono { get; set; }
        public GenericDto Asa { get; set; }
        public GenericDto Aht { get; set; }
        public GenericDto Sph { get; set; }
        public GenericDto MinutosEntrada { get; set; }
        public GenericDto MinutosSalidaFijo { get; set; }
        public GenericDto MinutosSalidaCelular { get; set; }
        public GenericDto Ocupacion { get; set; }
        public GenericDto Adherencia { get; set; }
        public GenericDto Ausentismo { get; set; }
        public GenericDto Rotacion { get; set; }
        public GenericDto HorasConexion { get; set; }
        public GenericDto HorasPagadas { get; set; }

    }
    
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class GenericDto
    {
        public decimal Bi { get; set; }
        public decimal Op { get; set; }
        public decimal Ci { get; set; }
        
        // Factores Rentabilidad
        public decimal Pt { get; set; } //Presupuesto
        public decimal Fr { get; set; } //Forecast
        public decimal Re { get; set; } //Real Contable
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class IndicadoresEspecificosDto
    {
        public GenericDto Asignacion { get; set; }
        public GenericDto PorcAsignacion { get; set; }
        public GenericDto PorcHonorarios { get; set; }
        public GenericDto PorcRecuperacion { get; set; }
        public GenericDto PorcConversion { get; set; }
        public GenericDto Pedidos { get; set; }
        public GenericDto VentasUpsell { get; set; }
        public GenericDto UpsellPromedio { get; set; }
        public GenericDto Ventas { get; set; }
        public GenericDto PorcValidacion { get; set; }
        public GenericDto PorcActivacion { get; set; }

    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class IngresosIndEspDto
    {
        public Campanas Campana { get; set; }
        public IndicadoresEspecificosDto Indicadores { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class EstacionesEspecializadasDto
    {
        public GenericDto Nafin { get; set; }
        public GenericDto Proveedor { get; set; }
        public GenericDto Vip { get; set; }
        public GenericDto Credito { get; set; }
        public GenericDto KioscoVirtual { get; set; }
        public GenericDto Operativa { get; set; }
        public GenericDto Especializada { get; set; }
        public GenericDto SinDelantal { get; set; }
        public GenericDto ServicioImpresionEscaner { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     
    public class IngresosEstEspDto
    {
        public Campanas Campana { get; set; }
        public EstacionesEspecializadasDto Estaciones { get; set; }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    
}