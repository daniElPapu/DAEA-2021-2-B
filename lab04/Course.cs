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

namespace lab04
{
    public partial class Course : Form
    {
        SqlConnection conn;
        public Course(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    String sql = "SELECT * from Course";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvListado.DataSource = dt;
                    dgvListado.Refresh();
                }
                else
                    MessageBox.Show("La conexión esta cerrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la conexión: \n" + ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    String firstName = txtTitle.Text;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "BuscarCursoTitulo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Title";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Value = firstName;

                    cmd.Parameters.Add(param);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvListado.DataSource = dt;
                    dgvListado.Refresh();
                }
                else
                    MessageBox.Show("La conexión esta cerrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la conexión: \n" + ex.ToString());
            }
        }
    }
}
