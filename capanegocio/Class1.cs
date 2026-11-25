using trabajo_practico_banco.CapaEntidad;
using trabajo_practico_banco.CapaDatos;

namespace trabajo_practico_banco.CapaNegocio
{
    public class CN_Usuario
    {
        private readonly CD_Usuario datos = new CD_Usuario();

        public bool IniciarSesion(string nombre, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(clave)) return false;
            Usuario usuario = new Usuario { Nombre = nombre.Trim(), Clave = clave };
            return datos.IniciarSesion(usuario);
        }
    }
}
