using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;
using Entity;
using System.Configuration;
using System.IO;

namespace RecaudoGUI
{
    public partial class CargueReporte : Form
    {
        IList<ReporteRecaudo> reporteRecaudos = new List<ReporteRecaudo>();        
        ReporteRecaudoService reporteRecaudo;
        RespuestaConsultaReporte respuestaConsulta = new RespuestaConsultaReporte();

        public CargueReporte()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DESKTOP-2HFRPRB"].ConnectionString;            
            reporteRecaudo= new ReporteRecaudoService(connectionString);
            InitializeComponent();
        }

        private void CargueReporteBtn_Click(object sender, EventArgs e)
        {
            reporteRecaudos.Clear();
            string linea = string.Empty;            
            var fileContent = string.Empty;
            var filepath = string.Empty;
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = "C:\\";
                fileDialog.Filter = "txt files(*.txt)|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = fileDialog.FileName;
                    var fileStream = fileDialog.OpenFile();

                    using (StreamReader lector = new StreamReader(fileStream))
                    {

                        //fileContent = lector.ReadToEnd();
                        while ((linea = lector.ReadLine()) != null)
                        {

                            String[] datos = linea.Split(';');
                            ReporteRecaudo reporte = new ReporteRecaudo();
                            reporte.IdentificacionAgente = datos[0];
                            reporte.Mes = datos[1];
                            reporte.Vigencia = datos[2];                            
                            reporte.TipoEstampilla = datos[3];
                            reporte.ValorRecaudo = Convert.ToDecimal(datos[4]);                            
                            reporte.IdentificacionContratisa = datos[5];
                            reporte.NombreContratista = datos[6];

                            reporteRecaudos.Add(reporte);
                        }

                        lector.Close();

                    }
                    foreach (var item in reporteRecaudos)
                    {
                        reporteRecaudo.Guardar(item);
                    }
                }
            }            
            MessageBox.Show(fileContent, "Mensaje de Guardado" + filepath, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            respuestaConsulta = reporteRecaudo.Consultar();
            
        }

        private void consultar()
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
    }
