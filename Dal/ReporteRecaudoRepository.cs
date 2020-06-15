using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace Dal
{
    public class ReporteRecaudoRepository
    {

        private readonly SqlConnection _connection;
        IList<ReporteRecaudo> reporteRecaudos = new List<ReporteRecaudo>();
        public ReporteRecaudoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(ReporteRecaudo reporteRecaudo)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into ReporteRecaudos(IdentificacionAgente, Mes, Vigencia, TipoEstampilla, ValorRecaudo, IdentificacionContratista, NombreContratista)
                                        VALUES (@IdentificacionAgente,@Mes,@Vigencia,@TipoEstampilla,@ValorRecaudo,@IdentificacionContratista,@NombreContratista)";
                command.Parameters.AddWithValue("@IdentificacionAgente", reporteRecaudo.IdentificacionAgente);
                command.Parameters.AddWithValue("@Mes", reporteRecaudo.Mes);
                command.Parameters.AddWithValue("@Vigencia", reporteRecaudo.Vigencia);
                command.Parameters.AddWithValue("@TipoEstampilla", reporteRecaudo.TipoEstampilla);
                command.Parameters.AddWithValue("@ValorRecaudo", reporteRecaudo.ValorRecaudo);
                command.Parameters.AddWithValue("@IdentificacionContratista", reporteRecaudo.IdentificacionContratisa);
                command.Parameters.AddWithValue("@NombreContratista", reporteRecaudo.NombreContratista);
                var filas = command.ExecuteNonQuery();
            }
        }

        private ReporteRecaudo Mapear(SqlDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            ReporteRecaudo reporteRecaudo = new ReporteRecaudo();
            reporteRecaudo.IdentificacionAgente = (string)dataReader["IdentificacionAgente"];
            reporteRecaudo.Mes = (string)dataReader["Mes"];
            reporteRecaudo.Vigencia = (string)dataReader["Vigencia"];
            reporteRecaudo.TipoEstampilla = (string)dataReader["TipoEstampilla"];
            reporteRecaudo.ValorRecaudo = (decimal)dataReader["ValorReacuado"];
            reporteRecaudo.IdentificacionContratisa = (string)dataReader["IdentificacionContratista"];
            reporteRecaudo.NombreContratista = (string)dataReader["NombreContratista"];
            return reporteRecaudo;
        }

        public IList<ReporteRecaudo> ConsultarReportes()
        {
            SqlDataReader dataReader;
            List<ReporteRecaudo> reporteRecaudos = new List<ReporteRecaudo>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from ReporteRecaudos";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReporteRecaudo reporte = Mapear(dataReader);
                        reporteRecaudos.Add(reporte);
                    }
                }
            }
            return reporteRecaudos;
        }


        
    }
}
