using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace CrudCore1.Datos
{
    public class Conexion
    {
        private string cadenasSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenasSQL = builder.GetConnectionString("CadenaSQL")
            ?? throw new Exception("Cadena de conexión no encontrada.");

        }

        public string getCadenaSQL() 
        {
            return cadenasSQL;
        }
    }
}
