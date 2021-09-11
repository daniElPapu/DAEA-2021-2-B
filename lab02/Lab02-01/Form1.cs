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
    public partial class frmLogin : Form
    {
        Dictionary<string, string> users = new Dictionary<string, string>();
        bool borrar = true;
        public frmLogin()
        {
            users.Add("John Doe", "123456");
            users.Add("Jane Doe", "123456");
            users.Add("Joe Doe", "123456");
            users.Add("Jenna Doe", "123456");
            InitializeComponent();
        }
        

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            String key = txtUsuario.Text;
            String password = txtPasword.Text;
            if (this.users.ContainsKey(key) && this.users[key].Equals(password)) {
                    Form2 principal = new Form2();
                    principal.Show();
                    this.Hide();
            }else{
                lblMensaje.Text = "Nombre de Usuario o COntaseña incorrectos";
                borrar = false;
                txtPasword.Text = "";
            }
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (lblMensaje.Text != "") {
                lblMensaje.Text = "";
            }
        }

        private void txtPasword_TextChanged(object sender, EventArgs e)
        {
            if (this.borrar && lblMensaje.Text != "")
            {
                lblMensaje.Text = "";
                borrar = true;
            }
        }

    }
}
