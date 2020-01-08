using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace oopfinal
{
    class dbopr:Connection
    {
        public  DataTable display (string Qurey)
        {
            SqlDataAdapter  cmd = new SqlDataAdapter(Qurey,getconnection());
            DataTable dt = new DataTable ();
            
            cmd.Fill(dt);
            return dt;
        }

        public void id(string Qurey)
        {
            SqlCommand cmd = new SqlCommand(Qurey,getconnection());
            cmd.ExecuteNonQuery();
        }
    }
}
