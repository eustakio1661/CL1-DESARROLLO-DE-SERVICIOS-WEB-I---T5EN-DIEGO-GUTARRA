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
    public class EmpleadoDAO : IDaoEmpleado<Empleado>
    {
        public void ActualizarEmpleado(Empleado e)
        {
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_actualizarEmpleado", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idEmpleado", e.idEmpleado);
            cmd.Parameters.AddWithValue("@apellido", e.apeEmpleado);
            cmd.Parameters.AddWithValue("@nombre", e.nomEmpleado);
            cmd.Parameters.AddWithValue("@fecNac", e.fecNac);
            cmd.Parameters.AddWithValue("@direccion", e.dirEmpleado);
            cmd.Parameters.AddWithValue("@idDistrito", e.idDistrito);
            cmd.Parameters.AddWithValue("@fonoEmpleado",e.fonoEmpleado);
            cmd.Parameters.AddWithValue("@idCargo", e.idCargo);
            cmd.Parameters.AddWithValue("@fecContrata", e.fecContrata);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { cn.Close(); }
        }

        public void BajaEmpleado(Empleado e)
        {
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_empleadoBaja", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idEmpleado", e.idEmpleado);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { cn.Close(); }
        }

        public Empleado BuscarEmpleado(int id)
        {
            Empleado reg = null;
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_empleadodatos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idEmpleado", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    reg = new Empleado()
                    {
                        idEmpleado = Convert.ToInt32(dr[0]),
                        apeEmpleado = dr[1].ToString(),
                        nomEmpleado = dr[2].ToString(),
                        fecNac = Convert.ToDateTime(dr[3]),
                        dirEmpleado = dr[4].ToString(),
                        idDistrito = Convert.ToInt32(dr[5]),
                        fonoEmpleado = dr[6].ToString(),
                        idCargo = Convert.ToInt32(dr[7]),
                        fecContrata = Convert.ToDateTime(dr[8])
                    };
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { cn.Close(); }
            return reg;
        }

        public void InsertarEmpleado(Empleado e)
        {
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_agregarEmpleado", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@apellido", e.apeEmpleado);
            cmd.Parameters.AddWithValue("@nombre", e.nomEmpleado);
            cmd.Parameters.AddWithValue("@fecNac", e.fecNac);
            cmd.Parameters.AddWithValue("@direccion", e.dirEmpleado);
            cmd.Parameters.AddWithValue("@idDistrito", e.idDistrito);
            cmd.Parameters.AddWithValue("@fonoEmpleado", e.fonoEmpleado);
            cmd.Parameters.AddWithValue("@idCargo", e.idCargo);
            cmd.Parameters.AddWithValue("@fecContrata", e.fecContrata);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
                
            }
            finally { cn.Close(); }
        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("usp_listadoEmpleado", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empleado reg = new Empleado()
                    {
                        idEmpleado = Convert.ToInt32(dr[0]),
                        apeEmpleado = dr[1].ToString(),
                        nomEmpleado = dr[2].ToString(),
                        fecNac = Convert.ToDateTime(dr[3]),
                        dirEmpleado = dr[4].ToString(),
                        idDistrito = Convert.ToInt32(dr[5]),
                        fonoEmpleado = dr[6].ToString(),
                        idCargo = Convert.ToInt32(dr[7]),
                        fecContrata = Convert.ToDateTime(dr[8])
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