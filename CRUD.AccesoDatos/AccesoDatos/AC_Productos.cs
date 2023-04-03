using System.Data.SqlClient;
using System.Data;
using System;
using CRUD.AccesoDatos.Conexion;
using System.Collections.Generic;
using CRUD.Entidades.Entidades;

namespace CRUD.AccesoDatos.AccesoDatos
{
    public class AC_Productos
    {
        private readonly dbConexion conexion = new dbConexion();
        private SqlDataReader leer;
        private readonly DataTable tabla = new DataTable();
        private readonly SqlCommand comando = new SqlCommand();

        public DataTable ListarProductos()
        {
            try
            {
                const string query = @"dbo.Sp_MostrarProductos";
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                return tabla;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.CerrarConexion();

            }
        }

        public string Insertar(Producto Obj)
        {
            string Rpta = "";
            try
            {
                const string query = @"dbo.Sp_InsetarProductos";
                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Obj.Nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Descripcion",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Obj.Descripcion
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Marca",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Obj.Marcas
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Precio",
                        SqlDbType = SqlDbType.Decimal,
                        Value = Obj.Precio
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Cantidad",
                        SqlDbType = SqlDbType.Int,
                        Value = Obj.Cantidad
                    },
                };
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddRange(parameters.ToArray());
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Ingresar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return Rpta;
        }

        public string Actualizar(Producto Obj)
        {
            string Rpta = "";
            try
            {
                const string query = @"Sp_EditarProductos";
                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@IdProducto",
                        SqlDbType = SqlDbType.Int,
                        Value = Obj.IdProducto
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Obj.Nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Descripcion",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Obj.Descripcion
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Marca",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Obj.Marcas
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Precio",
                        SqlDbType = SqlDbType.Decimal,
                        Value = Obj.Precio
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Cantidad",
                        SqlDbType = SqlDbType.Int,
                        Value = Obj.Cantidad
                    },
                };
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddRange(parameters.ToArray());
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Ingresar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();

            }
            return Rpta;
        }

        public string Eliminar(int Id)
        {
            string Rpta = "";
            try
            {
                const string query = @"Sp_ProductoEliminar";
                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@IdProducto",
                        SqlDbType = SqlDbType.Int,
                        Value = Id
                    },
                };
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddRange(parameters.ToArray());
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Eliminar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();

            }

            return Rpta;
        }
    }
}
