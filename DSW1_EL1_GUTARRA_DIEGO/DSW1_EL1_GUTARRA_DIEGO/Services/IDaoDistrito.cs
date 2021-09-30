using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace DSW1_EL1_GUTARRA_DIEGO.Services
{
    public interface IDaoDistrito<T>
    {
        List<T> ListarDistrito();
    }
}