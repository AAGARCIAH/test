using PentaFinances.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PentaFinances.ViewModels
{
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class ComprasVm
    {
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class SeguimientoSolicitudesDetallesVm
    {
        public int Folio { get; set; }
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        public int CampanaId { get; set; }
        public string Campana { get; set; }
        public int DepartamentoId { get; set; }
        public string Departamento { get; set; }
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
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class AgregarProveedoresVm
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        //Detalles Solicitud
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        public int CampanaId { get; set; }
        public int DepartamentoId { get; set; }
        public string UsuarioFinal { get; set; }
        public string EmailUsuarioFinal { get; set; }
        public string DetalledeSolicitud { get; set; }
        //public string Unidad { get; set; }
        //public string Marca { get; set; }
        //public string Modelo { get; set; }
        //public string ObjetivodeSolicitud { get; set; }
        //public string Impacto { get; set; }
        //public bool PosibleProveedor { get; set; }
        //public string NombreProveedorSugerido { get; set; }
        //public string EstadoSolicitud { get; set; }
        public string MotivoRechazo { get; set; }
        
        //Proveedor A
        public int IdProveedorA { get; set; }
        public string ProveedorA { get; set; }
        public string TipoProveedorA { get; set; }
        public string DescripcionA { get; set; }
        public decimal PrecioA { get; set; }
        public string TiempoEntregaA { get; set; }
        public string DocumentoCotizacionA { get; set; }
        public bool AsignadoA { get; set; }
        public bool PermiteCreditoA { get; set; }
        public int TiempoCreditoA { get; set; }
        public bool AnticipoA { get; set; }
        public int PorcentajeAnticipoA { get; set; }
        public string ComentarioAnticipoA { get; set; }
        public string TipoMonedaA { get; set; }
        public int IvaA { get; set; }
        //Proveedor B
        public int IdProveedorB{ get; set; }
        public string ProveedorB { get; set; }
        public string TipoProveedorB { get; set; }
        public string DescripcionB { get; set; }
        public decimal PrecioB { get; set; }
        public string TiempoEntregaB { get; set; }
        public bool AnticipoB { get; set; }
        public string ComentarioAnticipoB { get; set; }
        public int PorcentajeAnticipoB { get; set; }
        public string DocumentoCotizacionB { get; set; }
        public bool AsignadoB { get; set; }
        public bool PermiteCreditoB { get; set; }
        public int TiempoCreditoB { get; set; }
        public string TipoMonedaB { get; set; }
        public int IvaB { get; set; }
        //Proveedor C
        public int IdProveedorC { get; set; }
        public string ProveedorC { get; set; }
        public string TipoProveedorC { get; set; }
        public string DescripcionC { get; set; }
        public decimal PrecioC { get; set; }
        public string TiempoEntregaC { get; set; }
        public string DocumentoCotizacionC { get; set; }
        public bool AsignadoC { get; set; }
        public bool PermiteCreditoC { get; set; }
        public int TiempoCreditoC { get; set; }
        public bool AnticipoC { get; set; }
        public int PorcentajeAnticipoC { get; set; }
        public string ComentarioAnticipoC { get; set; }
        public string TipoMonedaC { get; set; }
        public int IvaC { get; set; }
        //Observaciones
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public int Actualizar { get; set; }
        public int IncluyeIva { get; set; }
        public int IncluyeIvaB { get; set; }
        public int IncluyeIvaC { get; set; }
        public string Tiposolicitud { get; set; }
        public string Empresa { get; set; }
        public string Proveedor { get; set; }
        public string Periodicidad { get; set; }
        public int idProveedorGnrlA { get; set; }
        public int idProveedorGnrlB { get; set; }
        public int idProveedorGnrlC { get; set; }

    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class FormaPagoVm
    {
        public int Folio { get; set; }
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        public int CampanaId { get; set; }
        public string Campana { get; set; }
        public int DepartamentoId { get; set; }
        public string Departamento { get; set; }
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
        public int ProveedorAsignadoId { get; set; }
        public string ProveedorAsignado { get; set; }
        public int? FormaPagoId { get; set; }
        public string FormaPago { get; set; }
        public string RazonSocial { get; set; }
        public bool? Credito { get; set; }
        public string Tiempo { get; set; }
        public int? BancoId { get; set; }
        public string Banco { get; set; }
        public string Cuenta { get; set; }
        public string Clabe { get; set; }
        public string FolioFactura { get; set; }
        public string NumRecibo { get; set; }
        public bool? EstatusFp { get; set; }
        public DateTime? FechaRegistroFp { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacionFp { get; set; }
        public DateTime? FechaUltimaActualizacionFp { get; set; }
        public bool? PermiteCredito { get; set; }
        public int? TiempoCredito { get; set; }

        public List<FilesPagosCompras> Files = new List<FilesPagosCompras>();
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class ConsultaSolicitudesVm
    {
        public int Folio { get; set; }
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        public int CampanaId { get; set; }
        public string Campana { get; set; }
        public int DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public string UsuarioFinal { get; set; }
        public string EmailUsuarioFinal { get; set; }
        public string DetalledeSolicitud { get; set; }
        public string Unidad { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string ObjetivodeSolicitud { get; set; }
        public string Impacto { get; set; }
        public bool? PosibleProveedor { get; set; }
        public string NombreProveedorSugerido { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string EstadoSolicitud { get; set; }
        public string MotivoRechazo { get; set; }
        public string Observaciones { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        //public int ProveedorAsignadoId { get; set; }
        //public string ProveedorAsignado { get; set; }
        public int? FormaPagoId { get; set; }
        public string FormaPago { get; set; }
        public string RazonSocial { get; set; }
        public bool? Credito { get; set; }
        public string Tiempo { get; set; }
        public int? BancoId { get; set; }
        public string Banco { get; set; }
        public string Cuenta { get; set; }
        public string Clabe { get; set; }
        public string FolioFactura { get; set; }
        public string NumRecibo { get; set; }
        public bool? EstatusFp { get; set; }
        public DateTime? FechaRegistroFp { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacionFp { get; set; }
        public DateTime? FechaUltimaActualizacionFp { get; set; }

        public string semaforo { get; set; }
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class ConsultaFolioDetallesVm
    {
        public int Folio { get; set; }
        public string Solicitante { get; set; }
        public string EmailSolicitante { get; set; }
        public int CampanaId { get; set; }
        public string Campana { get; set; }
        public int DepartamentoId { get; set; }
        public string Departamento { get; set; }
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
        public string MotivoRechazo { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string EstadoSolicitud { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? ProveedorAsignadoId { get; set; }
        public string ProveedorAsignado { get; set; }
        public bool Asignado { get; set; }
        public bool? PermiteCredito { get; set; }
        public int? TiempoCredito { get; set; }
        public decimal? Precio { get; set; }
        public string TipoMoneda { get; set; }
        public int? Iva { get; set; }
        public string TiempoEntrega { get; set; }
        public string ObservacionesProv { get; set; }
        public string DocumentoCotizacion { get; set; }
        public int? FormaPagoId { get; set; }
        public string FormaPago { get; set; }
        public string RazonSocial { get; set; }
        public bool? Credito { get; set; }
        public string Tiempo { get; set; }
        public int? BancoId { get; set; }
        public string Banco { get; set; }
        public string Cuenta { get; set; }
        public string Clabe { get; set; }
        public string FolioFactura { get; set; }
        public string NumRecibo { get; set; }
        public bool? EstatusFp { get; set; }
        public DateTime? FechaRegistroFp { get; set; }
        //Datos De Registro
        public string UsuarioUltimaActualizacionFp { get; set; }
        public DateTime? FechaUltimaActualizacionFp { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class SubtotalesComprasVm
    {
        public string Campana { get; set; }
        public string Subtotal { get; set; }
        public string SubtotalUSD { get; set; }
        public string Color { get; set; }
        public string TotalMXN { get; set; }
        public string TotalUSD { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class ResultLevantaSolicitudVm
    {
        public string Resultado { get; set; }
        public string Folio { get; set; }
    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public class ProveedoresVm
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string proveedor { get; set; }
        public string Anio { get; set; }
        public int Mes { get; set; }
        public bool Requisitos { get; set; }
        public bool Precio { get; set; }
        public bool Condiciones { get; set; }
        public bool Disponibilidad { get; set; }

    }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

}