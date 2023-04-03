using CRUD.Dominio.CasoUso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Vista.Vista
{
    public partial class Productos : Form
    {
        CD_Productos objetoCD = new CD_Productos();
        private int IdProducto = 0;
        private bool Editar = false;
        string Rpta = "";
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarForm()
        {
            txtDescripcion.Clear();
            txtMarca.Text = "";
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtNombre.Clear();
            errorIcon.Clear();
        }

        private void MostrarProductos()
        {
            dtProductos.DataSource = objetoCD.Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarEditarProductos();
        }

        private void GuardarEditarProductos()
        {
            //INSERTAR
            if (!Editar)
            {
                try
                {
                    if (txtNombre.Text == string.Empty || txtDescripcion.Text == string.Empty || txtMarca.Text == string.Empty || txtPrecio.Text == string.Empty || txtCantidad.Text == string.Empty)
                    {
                        this.MensajeError("Hay campos sin llenar");
                        errorIcon.SetError(txtNombre, "Campo requerido");
                        errorIcon.SetError(txtDescripcion, "Campo requerido");
                        errorIcon.SetError(txtMarca, "Campo requerido");
                        errorIcon.SetError(txtPrecio, "Campo requerido");
                        errorIcon.SetError(txtCantidad, "Campo requerido");
                    }
                    else
                    {
                        Rpta = objetoCD.Insertar(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text));
                        if (Rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se inserto correctamente!");
                            MostrarProductos();
                            limpiarForm();
                        }
                        else
                        {
                            this.MensajeError(Rpta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
            //EDITAR
            if (Editar)
            {                
                try
                {
                    objetoCD.Actualizar(IdProducto, txtNombre.Text, txtDescripcion.Text, txtMarca.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text));
                    this.MensajeOk("Se edito correctamente!");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                    btnEditar.Enabled = true;
                    btnGuardar.Text = "Guardar";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtProductos.SelectedRows.Count > 0)
                {
                    Editar = true;
                    txtNombre.Text = dtProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtMarca.Text = dtProductos.CurrentRow.Cells["Marca"].Value.ToString();
                    txtDescripcion.Text = dtProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtPrecio.Text = dtProductos.CurrentRow.Cells["Precio"].Value.ToString();
                    txtCantidad.Text = dtProductos.CurrentRow.Cells["Cantidad"].Value.ToString();
                    IdProducto = Convert.ToInt32(dtProductos.CurrentRow.Cells["IdProducto"].Value.ToString());
                    btnEditar.Enabled = false;
                    btnGuardar.Text = "Editar";
                }
                else
                {
                    MessageBox.Show("seleccione una fila por favor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtProductos.SelectedRows.Count > 0)
                {
                    IdProducto = Convert.ToInt32(dtProductos.CurrentRow.Cells["IdProducto"].Value.ToString());
                    objetoCD.Eliminar(IdProducto);
                    this.MensajeOk("Eliminado correctamente!");

                    MostrarProductos();
                }
                else
                {
                    MessageBox.Show("seleccione una fila por favor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
