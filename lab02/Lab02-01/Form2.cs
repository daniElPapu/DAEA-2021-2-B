using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void mnuManUsuarios_Click(object sender, EventArgs e)
        {
            manUsuario frm = new manUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuManProductos_Click(object sender, EventArgs e)
        {
            manProductos frm = new manProductos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManCategorias_Click(object sender, EventArgs e)
        {
            manCategorias frm = new manCategorias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManProveedores_Click(object sender, EventArgs e)
        {
            manProveedores frm = new manProveedores();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManClientes_Click(object sender, EventArgs e)
        {
            manClientes frm = new manClientes();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
