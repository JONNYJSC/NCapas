using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD.AccesoDatos.Conexion
{
    public class dbConexion
    {
        private readonly static string devServerConnectionStr = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private readonly SqlConnection devConexion = new SqlConnection(devServerConnectionStr);

        public SqlConnection AbrirConexion()
        {
            if (devConexion.State == ConnectionState.Closed)
                devConexion.Open();
            return devConexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (devConexion.State == ConnectionState.Open)
                devConexion.Close();
            return devConexion;
        }
    }
}
