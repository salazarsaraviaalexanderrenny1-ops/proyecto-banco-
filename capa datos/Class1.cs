using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using trabajo_practico_banco.CapaEntidad;

namespace trabajo_practico_banco.CapaDatos
{
    public static class Db
    {
        public static string Cadena
        {
            get
            {
                ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["BancoMySql"];
                if (config == null) throw new ConfigurationErrorsException("Falta la cadena de conexión BancoMySql en App.config.");
                return config.ConnectionString;
            }
        }
    }

    public class CD_Usuario
    {
        public bool IniciarSesion(Usuario usuario)
        {
            const string sql = "SELECT COUNT(*) FROM usuarios WHERE name = @name AND pass = @pass";
            using (MySqlConnection conexion = new MySqlConnection(Db.Cadena))
            using (MySqlCommand comando = new MySqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@name", usuario.Nombre);
                comando.Parameters.AddWithValue("@pass", usuario.Clave);
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar()) == 1;
            }
        }
    }
}
