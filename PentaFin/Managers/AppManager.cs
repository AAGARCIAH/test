using PentaFinances.Models;

namespace PentaFinances.Managers
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class AppManager
    {
        
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void SetUsuarios(string username, int tipouser, string nombre, string apellido)
        {
            var datos = new AppUsuarios
            {
                UserName = username,
                TipoUserId = tipouser,
                Nombre = nombre,
                Apellido = apellido
            };/*
            _att.AppUsuarios.Add(datos);
            _att.SaveChanges();*/
        }
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
}