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

namespace Lab05
{
    public partial class manPersona : Form
    {
        SqlConnection con;
        public manPersona()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void manPersona_Load(object sender, EventArgs e)
        {
            String server = "DESKTOP-4UPQ8HT\\SQLEXPRESS01";
            String str = "Server="+server+";DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            string sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
                MessageBox.Show("Se ha modificado el registro correctamente");
            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            string sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
                MessageBox.Show("Se ha eliminado el registro correctamente");
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            string sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado nueva persona con el código: " + codigo);
            con.Close();
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0) {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                txtHireDate.Text = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                txtEnrollmentDate.Text = dgvListado.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            con.Open();
            string sp = "BuscarPorCualquiera";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cualquiera", txtBusqueda.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }
    }
}
