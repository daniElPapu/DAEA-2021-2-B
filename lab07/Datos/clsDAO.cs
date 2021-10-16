using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
    public class clsDAO
    {
        public SqlConnection conn;

        public clsDAO()
        {
            string str = "Server=DESKTOP-4UPQ8HT\\SQLEXPRESS01;Database=School;Integrated Security=true";
            conn = new SqlConnection(str);
        }
    }
}