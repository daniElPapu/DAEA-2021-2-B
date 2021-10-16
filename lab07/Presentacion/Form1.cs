using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Negocio.clsNegPerson np = new Negocio.clsNegPerson();
            dt = np.GetAll();

            dgDatos.DataSource = dt;
            dgDatos.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Negocio.clsNegPerson np = new Negocio.clsNegPerson();
            String name = txtNombre.Text;
            dt = np.GetByName(name);

            dgDatos.DataSource = dt;
            dgDatos.Refresh();
        }
    }
}
