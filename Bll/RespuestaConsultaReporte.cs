using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class RespuestaConsultaReporte
    {

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<ReporteRecaudo> reportes { get; set; }
    }

        public class ResponseClienteBusqueda
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public ReporteRecaudo reporteRecaudo { get; set; }
        }
    
}
