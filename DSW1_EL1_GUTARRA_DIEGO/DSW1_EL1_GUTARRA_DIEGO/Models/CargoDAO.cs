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
    public class CargoDAO: IDaoCargo<Cargo>
    {
        public List<Cargo> ListarCargo()
        {
            List<Cargo> lista = new List<Cargo>();
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_listadoCargo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cargo reg = new Cargo()
                    {
                        idCargo = Convert.ToInt32(dr[0]),
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