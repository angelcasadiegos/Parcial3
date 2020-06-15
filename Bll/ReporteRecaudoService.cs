using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;

namespace Bll
{
    public class ReporteRecaudoService
    {
        private ReporteRecaudoRepository recaudoRepository;
        private readonly ConnectionManager conexion;

        public ReporteRecaudoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            recaudoRepository = new ReporteRecaudoRepository(conexion);

        }
        public string Guardar(ReporteRecaudo reporteRecaudo)
        {
            {
                try
                {
                    conexion.Open();
                    recaudoRepository.Guardar(reporteRecaudo);
                    conexion.Close();
                    return $"Se guardaron los datos satisfactoriamente";
                }
                catch (Exception e)
                {
                    return $"Error de la Aplicacion: {e.Message}";
                }
                finally { conexion.Close(); }
            }
        }

        public RespuestaConsultaReporte Consultar()
        {
            RespuestaConsultaReporte respuesta = new RespuestaConsultaReporte();
            try
            {

                conexion.Open();
                respuesta.reportes = recaudoRepository.ConsultarReportes();
                conexion.Close();
                if (respuesta.reportes.Count > 0)
                {
                    respuesta.Mensaje = "Se consultan los Datos";
                }
                else
                {
                    respuesta.Mensaje = "No hay datos para consultar";
                }
                respuesta.Error = false;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Error de la Aplicacion: {e.Message}";
                respuesta.Error = true;
                return respuesta;
            }
            finally { conexion.Close(); }

        }



    }
}
