using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace oopfinal
{
    class Connection
    {
        public SqlConnection con;
        public SqlConnection getconnection()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-HS1VMOJ\SHAROZ;Initial Catalog=voiceattendance;Integrated Security=True");
            con.Open();
            return con;
                
        }
    }
}
