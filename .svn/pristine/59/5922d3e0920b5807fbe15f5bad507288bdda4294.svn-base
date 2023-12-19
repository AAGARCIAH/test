using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security;
using System.Web;

namespace PentaFinances.Models
{
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class PentaFinComprasContext : DbContext
    {
        public DbSet<ApUsuarios> ApUsuarios { get; set; }
        public DbSet<CatalogoCampanas> CatalogoCampanas { get; set; }
        public DbSet<CatalogoDepartamentos> CatalogoDepartamentos { get; set; }
        public DbSet<CatalogoFormasPago> CatalogoFormasPago { get; set; }
        public DbSet<CatalogoBancos> CatalogoBancos { get; set; }
        public DbSet<SolicitudesDetalles> SolicitudesDetalles { get; set; }
        public DbSet<SeguimientoSolicitudesDetalles> SeguimientoSolicitudesDetalles { get; set; }
        public DbSet<ProveedoresAgregadosSolicitudesDetalles> ProveedoresAgregadosSolicitudesDetalles { get; set; }
        public DbSet<PagosComprasDetalles> PagosComprasDetalles { get; set; }
        public DbSet<EncuestaSolicitanteProveedorDetalles> EncuestaSolicitanteProveedorDetalles { get; set; }
        public DbSet<EncuestaComprasSolicitudesDetalles> EncuestaComprasSolicitudesDetalles { get; set; }
        public DbSet<CatalogoDirectores> CatalogoDirectores { get; set; }
        public DbSet<CatalogoNivelUsuarios> CatalogoNivelUsuarios { get; set; }
        public DbSet<CtrlValidacionesDireccion> CtrlValidacionesDireccion { get; set; }
        public DbSet<FilesPagosCompras> FilesPagosCompras { get; set; }
        public DbSet<tbl_ProveedorRecurrenteCompras> tbl_ProveedorRecurrenteCompras { get; set; }
        public DbSet<tbl_AprobacionSolicitud> tbl_AprobacionSolicitud { get; set; }
        public DbSet<tbl_ComprobantePago> tbl_ComprobantePago { get; set; }
        public DbSet<EncuestaSatPentaFinances> EncuestaSatPentaFinances { get; set; }
        public DbSet<EvaluacionProveedores> EvaluacionProveedores { get; set; }
        public DbSet<envioMailActivosNuevos> envioMailActivosNuevos { get; set; }
        public DbSet<proveedores> proveedores { get; set; }
        

        public PentaFinComprasContext()
            : base("name=FinConn")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer((IDatabaseInitializer<PentaFinComprasContext>)null);
        }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      
    public class ComprasModel
    {
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA DONDE SE GUARDAN LOS USUARIOS Y SUS CORREOS
    [Table("tbl_AppUsuarios")]
    public class ApUsuarios
    {
        [Key]
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Estatus { get; set; }
        public Int32 DepartamentoId { get; set; }
        public int? NivelId { get; set; }
        public int? DirectorId { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CATALOGO CAMPAÑAS
    [Table("cat_CampanasCompras")]
    public class CatalogoCampanas
    {
        [Key]
        public int Id { get; set; }
        public string Campana { get; set; }
        public bool Estatus { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CATALOGO DEPARTAMENTOS
    [Table("cat_DepartamentosCompras")]
    public class CatalogoDepartamentos
    {
        [Key]
        public int Id { get; set; }
        public string Departamento { get; set; }
        public bool Estatus { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CATALOGO FORMAS DE PAGO
    [Table("cat_FormasPagoCompras")]
    public class CatalogoFormasPago
    {
        [Key]
        public int Id { get; set; }
        public string FormaPago { get; set; }
        public bool Estatus { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CATALOGO BANCOS
    [Table("cat_BancosCompras")]
    public class CatalogoBancos
    {
        [Key]
        public int Id { get; set; }
        public string Banco { get; set; }
        public bool Estatus { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA SOLICITUDES DE COMPRA (SOLICITANTE)
    [Table("tbl_SolicitudesdeCompra")]
    public class SolicitudesDetalles
    {
        [Key]
        public int Folio { get; set; }
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        [Required(ErrorMessage = "La Campaña es requerida")]
        public int CampanaId { get; set; }
        public int DepartamentoId { get; set; }
        public string UsuarioFinal { get; set; }
        public string EmailUsuarioFinal { get; set; }
        public string DetalledeSolicitud { get; set; }
        public string Unidad { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string ObjetivodeSolicitud { get; set; }
        public string Impacto { get; set; }
        public bool PosibleProveedor { get; set; }
        public string NombreProveedorSugerido { get; set; }
        public string Observaciones { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        //Actualización Campo Caja Chica
        public bool? CajaChica { get; set; }
        //NUEVOS CAMPOS
        public string BeneficioCuantitativo { get; set; }
        public string BeneficioCualitativo { get; set; }
        public string RetornoInversion { get; set; }
        //NUEVOS CAMPOS (RECURRENTE)
        public string Recurrente { get; set; }
        [NotMapped]
        public bool Recurrente_TEMP { get; set; }
        [NotMapped]
        public string ProveedorR { get; set; }
        [NotMapped]
        public string DescripcionR { get; set; }
        [NotMapped]
        public decimal Precio { get; set; }
        [NotMapped]
        public int? TiempoEntrega { get; set; }
        [NotMapped]
        public string DocumentoCotizacion { get; set; }
        [NotMapped]
        public string PermiteCredito { get; set; }
        [NotMapped]
        public bool PermiteCredito_TEMP { get; set; }
        [NotMapped]
        public int? TiempoCredito { get; set; }
        [NotMapped]
        public string TipoMoneda { get; set; }
        [NotMapped]
        public int? Iva { get; set; }
        //Comprobante
        [NotMapped]
        public string Comprobante { get; set; }
        public string TipoSolicitud { get; set; }
        [NotMapped]
        public bool Factura { get; set; }
        public decimal CostoTotalFactura { get; set; }
        public string TipoMonedaFactura { get; set; }
        public string NoFactura { get; set; }

    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA SOLICITUDES DE COMPRA (COMPRAS)
    [Table("tbl_ComprasDetalles")]
    public class SeguimientoSolicitudesDetalles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Folio { get; set; }
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        public int CampanaId { get; set; }
        public int DepartamentoId { get; set; }
        public string UsuarioFinal { get; set; }
        public string EmailUsuarioFinal { get; set; }
        public string DetalledeSolicitud { get; set; }
        public string Unidad { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string ObjetivodeSolicitud { get; set; }
        public string Impacto { get; set; }
        public bool PosibleProveedor { get; set; }
        public string NombreProveedorSugerido { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string MotivoRechazo { get; set; }
        public string Observaciones { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        //Actualización Campo Caja Chica
        public bool? CajaChica { get; set; }
        //NUEVOS CAMPOS
        public string BeneficioCuantitativo { get; set; }
        public string BeneficioCualitativo { get; set; }
        public string RetornoInversion { get; set; }
        public string Recurrente { get; set; }
        [NotMapped]
        public string Comprobante { get; set; }
        public string TipoSolicitud { get; set; }
        public decimal CostoTotalFactura { get; set; }
        public string TipoMonedaFactura { get; set; }
        public string NoFactura { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA PROVEEDORES DE UNA SOLICITUD
    [Table("tbl_ProveedoresAsignadosCompras")]
    public class ProveedoresAgregadosSolicitudesDetalles
    {
        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public string Proveedor { get; set; }
        public string TipoProveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string TiempoEntrega { get; set; }
        public string DocumentoCotizacion { get; set; }
        public bool Asignado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public bool PermiteCredito { get; set; }
        public int? TiempoCredito { get; set; }
        public string TipoMoneda { get; set; }
        public int Iva { get; set; }
        public int IncluyeIva { get; set; }
        public int Anticipo { get; set; }
        public string ComentarioAnticipo { get; set; }
        public int IdProveedor { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA DETALLES PAGOS DE UNA COMPRA
    [Table("tbl_PagosCompras")]
    public class PagosComprasDetalles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Folio { get; set; }
        public int ProveedorAsignadoId { get; set; }
        public int FormaPagoId { get; set; }
        public string RazonSocial { get; set; }
        public bool Credito { get; set; }
        public string Tiempo { get; set; }
        public int BancoId { get; set; }
        public string Cuenta { get; set; }
        public string Clabe { get; set; }
        public string FolioFactura { get; set; }
        public string NumRecibo { get; set; }
        //public string Observaciones { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA ENCUESTA SOLICITANTE-PROVEEDOR
    public class EncuestaSolicitanteProveedorDetalles
    {
        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public string Campana { get; set; }
        public string Departamento { get; set; }
        public string BienServicioEsloqueNecesitaba { get; set; }
        public int CalificacionProveedor { get; set; }
        public string ContinuariasconProveedor { get; set; }
        public string ComoCalificacriasTiempoRespuesta { get; set; }
        public string Observaciones { get; set; }
        public string ComentariosObservaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA ENCUESTA COMPRAS
    public class EncuestaComprasSolicitudesDetalles
    {
        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public string Campana { get; set; }
        public string Departamento { get; set; }
        public int TiempodeRespuesta { get; set; }
        public int CumplimientoTecnicoServicio { get; set; }
        public int Costo { get; set; }
        public int TiempoEntrega { get; set; }
        public int Calidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CATALOGO DIRECTORES
    [Table("cat_Directores")]
    public class CatalogoDirectores
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Director { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CATALOGO NIVEL DE USUARIOS
    [Table("cat_NivelUsuarios")]
    public class CatalogoNivelUsuarios
    {
        [Key]
        public int Id { get; set; }
        public string Nivel { get; set; }
        public bool Activo { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //TABLA CONTROL DE VALIDACIONES DIRECCION (CASCADA)
    [Table("tbl_CtrlValidacionesDireccion")]
    public class CtrlValidacionesDireccion
    {
        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public bool ValidaGerencia { get; set; }
        public bool ValidaDirFinanzas { get; set; }
        public bool ValidaDirGeneral { get; set; }
        public bool ValidaPresidencia { get; set; }
        public bool EnvioMailGerencia { get; set; }
        public bool EnvioMailDirFinanzas { get; set; }
        public bool EnvioMailDirGeneral { get; set; }
        public bool EnvioMailPresidencia { get; set; }
        public int EstadoSolicitudId { get; set; }
        public int? AprobadoRechazado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioValidaRechaza { get; set; }
        public DateTime? FechaValidacionRechazo { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_FilesPagosCompras")]
    public class FilesPagosCompras
    {
        [Key]
        public int id { get; set; }
        public int Folio { get; set; }
        public string nameFile { get; set; }
        public string ruta { get; set; }
        public DateTime fechaCarga { get; set; }
        public bool estatus { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_ProveedorRecurrenteCompras")]
    public class tbl_ProveedorRecurrenteCompras
    {
        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int? TiempoEntrega { get; set; }
        public bool PermiteCredito { get; set; }
        public int? TiempoCredito { get; set; }
        public string TipoMoneda { get; set; }
        public int? Iva { get; set; }
        public string DocumentoCotizacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_AprobacionSolicitud")]
    public class tbl_AprobacionSolicitud
    {
        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime FAprobacion { get; set; }
        public int EstadoSolicitudId { get; set; }
        public bool Estatus { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_ComprobantePago")]
    public class tbl_ComprobantePago
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Folio { get; set; }
        public string Comprobante { get; set; }
        public string Extension { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_EncuestaSatPentaFinances")]
    public class EncuestaSatPentaFinances
    {

        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public int TiempoDeRespuesta { get; set; }
        public int CumplioExpectativas { get; set; }
        public int TiempoDeEntrega { get; set; }
        public string Comentarios { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UserFinance { get; set; }
        public string TipoProducto { get; set; }
        [NotMapped]
        public string Proveedor { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_EvaluacionProveedores")]
    public class EvaluacionProveedores
    {

        [Key]
        public int Id { get; set; }
        public string proveedor { get; set; }
        public string Anio { get; set; }
        public int Mes { get; set; }
        public bool Requisitos { get; set; }
        public bool Precio { get; set; }
        public bool Condiciones { get; set; }
        public bool Disponibilidad { get; set; }
        public int IdProveedor { get; set; }

    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("tbl_envioMailActivosNuevos")]
    public class envioMailActivosNuevos
    {

        [Key]
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    [Table("cat_proveedores")]
    public class proveedores
    {

        [Key]
        public int Id { get; set; }
        public string Empresa { get; set; }
        public int ClaveProveedor { get; set; }
        public string Nombre { get; set; }
        public string Periodicidad { get; set; }
        public bool Activo { get; set; }
    }

}