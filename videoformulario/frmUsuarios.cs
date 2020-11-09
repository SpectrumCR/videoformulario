using System;
using System.Data;
using System.Windows.Forms;
using videoformulario.Dato;


namespace videoformulario
{
    public partial class frmUsuarios : Form
    {
        DataTable tabla;
        Usuario dato = new Usuario();
        public frmUsuarios()
        {
            InitializeComponent();
            Iniciar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                Guardar();
                Iniciar();
                Limpiar();
                Consultar();
            }
            else
            {
                MessageBox.Show("Debe ingresar datos en la caja de texto Nombre");
                txtNombre.Focus();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Iniciar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Edad");
            grilla.DataSource = tabla;
        }
        private void Guardar()
        {
            DataRow row = tabla.NewRow();
            row["Nombre"] = txtNombre.Text;
            row["Edad"] = txtEdad.Text;
            tabla.Rows.Add(row);
            dato.GuardarArchivo(tabla);
        }
        private void Consultar()
        {
            foreach (var item in dato.LeerArchivo())
            {
                DataRow fila = tabla.NewRow();
                fila["Nombre"] = item.Nombre;
                fila["Edad"] = item.Edad;
                tabla.Rows.Add(fila);
            }
        }
        private void Limpiar()
        {
            txtNombre.Text="";
            txtEdad.Text = "";
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            Iniciar();
            Limpiar();
            Consultar();
        }
    }
}
