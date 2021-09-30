using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSW1_EL1_GUTARRA_DIEGO.Entity;
using DSW1_EL1_GUTARRA_DIEGO.Services;
using DSW1_EL1_GUTARRA_DIEGO.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace DSW1_EL1_GUTARRA_DIEGO.Models
{
    public class DistritoDAO:IDaoDistrito<Distrito>
    {
        public List<Distrito> ListarDistrito()
        {
            List<Distrito> lista = new List<Distrito>();
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_listadoDistrito", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Distrito reg = new Distrito()
                    {
                        idDistrito = Convert.ToInt32(dr[0]),
                        descripcion = dr[1].ToString()
                    };
                    lista.Add(reg);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }
    
    }
}