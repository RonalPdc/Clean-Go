using System.Configuration;
using System.Data.SqlClient;

namespace Clean_Go_DataAccess.ConexionBD
{
    public class ConexionDB
    {
        public static string CadenaConexion
        {
            get { return ConfigurationManager.ConnectionStrings["CleanGoDB"].ConnectionString; }
        }

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
