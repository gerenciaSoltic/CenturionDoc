using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.Windows.Forms;


namespace gestion_documental
{
    class Correo
    {
      MailMessage  correos= new MailMessage();
      SmtpClient envios = new SmtpClient();

      public string  enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta,string servidorsaliente)
      {
          string Correcto = "";
          try
          {
            correos.To.Clear();
            correos.Body = "";
            correos.Subject = "";
            correos.Body = mensaje;
            correos.Subject = asunto;
            correos.IsBodyHtml = false;


            string[] vector0 = destinatario.Split(';');

            for (int i = 0; i < vector0.Count(); i++)
            {
                correos.To.Add(vector0[i]);
            }

           
            if(ruta.Equals("")==false)
            {

                string[] vector = ruta.Split(',');

                for (int i = 0; i < vector.Count(); i++)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(vector[i]);
                    correos.Attachments.Add(archivo);
                }
            }

            correos.From = new MailAddress(emisor);
            envios.Credentials = new NetworkCredential(emisor, password);

            //Datos importantes no modificables para tener acceso a las cuentas

            envios.Host = servidorsaliente.Split(':')[0];
                        
            envios.Port = Convert.ToInt32(servidorsaliente.Split(':')[1]);
            envios.EnableSsl = true;

            envios.Send(correos);
            Correcto = "SI";
            
          }
          catch(Exception ex)
          {
              Correcto = "NO";
          }
          return Correcto;
      }
    }
}
