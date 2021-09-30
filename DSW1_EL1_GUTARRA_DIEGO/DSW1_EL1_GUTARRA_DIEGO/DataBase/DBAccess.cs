using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DSW1_EL1_GUTARRA_DIEGO.DataBase
{
    public class DBAccess
    {
        public static SqlConnection getConecta()
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Negocios2021"].ConnectionString);
            return cn;
        }
    }
}