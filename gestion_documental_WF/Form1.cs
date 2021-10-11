using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace gestion_documental_WF
{
    public partial class Form1 : Form
    {
        string NomUsuario;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_carga_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                string RutaServicio = ConfigurationManager.AppSettings["RutaServicio"].ToString();
                WebServiceGestionDocumental.WebServiceGestionDocumental service = new WebServiceGestionDocumental.WebServiceGestionDocumental();
                service.Url = RutaServicio;

                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                        byte[] ArchivoData = new byte[fs.Length];
                        fs.Read(ArchivoData, 0, System.Convert.ToInt32(fs.Length));
                        fs.Close();

                        string[] nombre = fs.Name.Split('\\');
                        string vf_nombre = nombre[nombre.Length - 1];

                        string vf_result = service.CargaArchivos(ArchivoData, vf_nombre, NomUsuario);
                        if (vf_result != null)
                        { MessageBox.Show("Error Enviando El Archivo : " + vf_nombre + " : " + vf_result); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                MessageBox.Show("Los Archivos ha sido enviados con exito al servidor");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NomUsuario = ConfigurationManager.AppSettings["NomUsuario"].ToString();
            lbl_usuario.Text = "USUARIO : " + NomUsuario;
        }
    }
}
