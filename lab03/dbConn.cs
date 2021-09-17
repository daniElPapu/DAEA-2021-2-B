using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab03
{
    public partial class dbConn : Form
    {
        SqlConnection conn;
        public dbConn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text;
            string bd = txtBD.Text;
            string usuario = txtUsuario.Text;
            string pwd = txtContraseña.Text;

            string str = "Server=" + servidor + ";Database=" + bd+";";

            if (chkAutenticacion.Checked)
                str += "Integrated Security=true";
            else
                str += "User Id=" + usuario + ";Password=" + pwd + ";";
            //Conexión
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado satisfactoriamente");
                btnDesconectar.Enabled = true;
            }
            catch (Exception ex){
                MessageBox.Show("Error al conectar al servidor: \n"+ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)                
                    MessageBox.Show("Estado del servidor: " + conn.State 
                        + "\nVersión del servidor: "+ conn.ServerVersion +
                        "\nBase de Datos: "+ conn.Database);
                else
                    MessageBox.Show("Estado del servidor: " + conn.State);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible determinar el estado del servidor: \n" + ex.ToString());
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed) { 
                    conn.Close();
                    MessageBox.Show("Conexión cerrada satisfactoriamente");
                }
                else
                    MessageBox.Show("La conexión ya está cerrada" + conn.State);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cerra la conexión: \n" + ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutenticacion.Checked) {
                txtUsuario.Enabled = false;
                txtContraseña.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtContraseña.Enabled = true;
            }
        }
    }
}
