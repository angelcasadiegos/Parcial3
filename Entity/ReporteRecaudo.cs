using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ReporteRecaudo
    {
        public string IdentificacionAgente { get; set; }
        public string NombreContratista { get; set; }
        public string IdentificacionContratisa { get; set; }
        public string TipoEstampilla { get; set; }
        public decimal ValorRecaudo { get; set; }
        public string Mes{ get; set; }        
        public string Vigencia { get; set; }

        public ReporteRecaudo()
        {

        }   



        
    }
}
