using System.Configuration;
using System.Data.SqlClient;

namespace Clean_Go_DataAccess.ConexionBD
{
    public class ConexionDB
    {
        private static readonly ConexionDB instancia = new ConexionDB();

        private readonly string connectionString;

        private ConexionDB()
        {
            connectionString = "Data Source=AsusRond;" + "Initial Catalog=CleanGoDB;" +"Integrated Security=True;" +"TrustServerCertificate=True;";
        }

        public static ConexionDB Instancia
        {
            get
            {
                return instancia;
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}

