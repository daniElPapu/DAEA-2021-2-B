﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class clsDAOPerson : clsDAO
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            conn.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            conn.Close();

            return dt;
        }
        public DataTable GetByName(String name)
        {
            DataTable dt = new DataTable();
            conn.Open();
            String sql = "BuscarPersonaNombre";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName",name);

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            conn.Close();

            return dt;
        }
    }
}

