using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace DSW1_EL1_GUTARRA_DIEGO.Services
{
    public interface IDaoEmpleado<T>
    {
        void InsertarEmpleado(T e);
        void ActualizarEmpleado(T e);
        void BajaEmpleado(T e);
        List<T> ListarEmpleados();
        T BuscarEmpleado(int id);
    }
}