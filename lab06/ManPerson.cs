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
namespace lab06
{
    public partial class ManPerson : Form
    {
        SqlConnection con;
        DataSet ds = new DataSet();
        DataTable tablePerson = new DataTable();
        public ManPerson()
        {
            InitializeComponent();
        }

        private void ManPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=DESKTOP-4UPQ8HT\\SQLEXPRESS01;Database=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            //llenamos el dataset con una tabla llamada Person
            adapter.Fill(ds, "Person");

            //Asignamos esa tabla a un dataset a un objeto Table
            //Para trabajar directamente en él
            tablePerson = ds.Tables["Person"];

            dgvListado.DataSource = tablePerson;
            dgvListado.Update();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertPerson", con);

            cmd.Parameters.Add("@LastName", SqlDbType.VarChar,50, "LastName");
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn="HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn= "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            //creamos una fila nueva la cual insertaremos en la base de datos
            //Esta fila debe tener la estructura correspondiente
            DataRow fila = tablePerson.NewRow();
            fila["LastName"] = txtApellido.Text;
            fila["FirstName"] = txtNombre.Text;
            fila["HireDate"] = dtpHire.Value;
            fila["EnrollmentDate"] = dtpEnrollment.Value;

            //U(na vez tenemos la fila la agregamos a la tabla Person del Dataset
            tablePerson.Rows.Add(fila);

            //Actualizamos el dataset con la tabla person
            adapter.Update(tablePerson);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UpdatePerson", con);

            cmd.Parameters.Add("@PersonID", SqlDbType.VarChar).SourceColumn = "PersonID";
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).SourceColumn = "LastName";
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).SourceColumn = "FirstName";
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            //creamos un array de DataRow el cual almacenara la fila que coincida con el resultado de la busqueda de persona ID
            //A cada campo de la fila, le asignamos el valor modificado.
            DataRow[] fila = tablePerson.Select("PersonID = '"+ txtPersonID.Text+"'");
            fila[0]["LastName"] = txtApellido.Text;
            fila[0]["FirstName"] = txtNombre.Text;
            fila[0]["HireDate"] = dtpHire.Value;
            fila[0]["EnrollmentDate"] = dtpEnrollment.Value;

            //Actualizamos el dataset con la tabla person
            adapter.Update(tablePerson);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DeletePerson", con);
            cmd.Parameters.Add("@PersonID", SqlDbType.VarChar).SourceColumn = "PersonID";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            //Buscamos la fila a eliminar
            DataRow[] fila = tablePerson.Select("PersonID = '" + txtPersonID.Text + "'");

            //Eliminamos  de la tabla de la fila especificada
            tablePerson.Rows.Remove(fila[0]);

            // actualizamos el dataset con la tabal modificada
            adapter.Update(tablePerson);
        }

        private void btnOrderByLastName_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.Sort = "LastName ASC"; 
            dgvListado.DataSource = dv;
        }

        private void btnOrderByPersonID_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "PersonID = '"+ txtPersonID.Text+"'";
            dgvListado.DataSource = dv;
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0) {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                txtApellido.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();

                String hireDate = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                if (String.IsNullOrEmpty(hireDate))
                    dtpHire.Checked = false;
                else
                    dtpHire.Text = hireDate;
                String enrollmentDate = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                if (String.IsNullOrEmpty(hireDate))
                    dtpEnrollment.Checked = false;
                else
                    dtpEnrollment.Text = enrollmentDate;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "PersonID = '" + txtPersonID.Text + "' OR FirstName = '" + txtNombre.Text + "' OR LastName = '" + txtApellido.Text + "'";
            dgvListado.DataSource = dv;
        }
    }
}
