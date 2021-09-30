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
    public class ProductoDAO : IDaProducto<Producto>
    {
  
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_listadoProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto reg = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        nomProducto = dr[1].ToString(),
                        IdCategoria = Convert.ToInt32(dr[2]),
                        IdProveedor = Convert.ToInt32(dr[3]),
                        CantUnidad = dr[4].ToString(),
                        PrecioUnidad = Convert.ToDecimal(dr[5]),
                        stock = Convert.ToInt32(dr[6])
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

        public List<Producto> ListarProductos(string nombre, int idCategoria)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_buscarProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomProducto", nombre);
            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto reg = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        nomProducto = dr[1].ToString(),
                       
                        IdCategoria = Convert.ToInt32(dr[2]),
                        IdProveedor = Convert.ToInt32(dr[3]),
                        CantUnidad = dr[4].ToString(),
                        PrecioUnidad = Convert.ToDecimal(dr[5]),
                        stock = Convert.ToInt32(dr[6])
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