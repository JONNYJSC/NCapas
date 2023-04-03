using CRUD.AccesoDatos.AccesoDatos;
using CRUD.Entidades.Entidades;
using System;
using System.Data;

namespace CRUD.Dominio.CasoUso
{
    public class CD_Productos
    {
        public DataTable Listar()
        {
            AC_Productos productos = new AC_Productos();
            return productos.ListarProductos();
        }

        public string Insertar(string Nombre, string Descipcion, string Marcas, decimal precio, int Cantidad)
        {
            AC_Productos productos = new AC_Productos();
            
            Producto Obj = new Producto();
            Obj.Nombre = Nombre;
            Obj.Descripcion = Descipcion;
            Obj.Marcas = Marcas;
            Obj.Precio = precio;
            Obj.Cantidad = Cantidad;
            return productos.Insertar(Obj);
        }

        public string Actualizar(int IdProducto, string Nombre, string Descipcion, string Marcas, decimal precio, int Cantidad)
        {
            AC_Productos productos = new AC_Productos();

            Producto Obj = new Producto();
            Obj.IdProducto = IdProducto;
            Obj.Nombre = Nombre;
            Obj.Descripcion = Descipcion;
            Obj.Marcas = Marcas;
            Obj.Precio = precio;
            Obj.Cantidad = Cantidad;
            return productos.Actualizar(Obj);
        }

        public string Eliminar(int Id)
        {
            AC_Productos productos = new AC_Productos();
            return productos.Eliminar(Id);
        }
    }
}
