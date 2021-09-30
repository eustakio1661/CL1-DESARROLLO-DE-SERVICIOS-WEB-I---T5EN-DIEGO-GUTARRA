using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DSW1_EL1_GUTARRA_DIEGO.Entity
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string apeEmpleado { get; set; }
        public string nomEmpleado { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecNac { get; set; }
        public string dirEmpleado { get; set; }
        public int idDistrito { get; set; }
        public string fonoEmpleado { get; set; }
        public int idCargo { get; set; }
        public DateTime fecContrata { get; set; }

    }
}