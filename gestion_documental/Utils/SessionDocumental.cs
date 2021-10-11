using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;

namespace gestion_documental.Utils
{
    public class SessionDocumental
    {

        
        private static HttpSessionState Session
        {
            get
            {
                var actual = HttpContext.Current;
                if (actual == null)
                {
                    throw new Exception("Http session no esta  disponible");
                }
                var sesion = actual.Session;
                if (sesion == null)
                {
                    throw new Exception(" session no esta  disponible");
                }
                return sesion;
            }
        }


        public static Usuarios UsuarioInicioSession
        {
            get
            {
                Usuarios retorno = Session["UsuarioInicioSession"] as Usuarios;
                return retorno;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("UsuarioInicioSession");
                }
                else
                {
                    Session["UsuarioInicioSession"] = value;
                }
            }
        }
        public static List<gestion_documental.BusinessObjects.CorreoEntrante> CorreosElectronicos
        {
            get
            {
                List<gestion_documental.BusinessObjects.CorreoEntrante> retorno = Session["CorreosElectronicos"] as List<gestion_documental.BusinessObjects.CorreoEntrante>;
                if (retorno == null)
                {
                    retorno = new List<gestion_documental.BusinessObjects.CorreoEntrante>();
                    Session["CorreosElectronicos"] = retorno;
                }
                return retorno;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("CorreosElectronicos");
                }
                else
                {
                    Session["CorreosElectronicos"] = value;
                }
            }
        }

        public static int? CountMensajes
        {
            get
            {
                int? retorno = Session["CountMensajes"] as int?;
                if (!retorno.HasValue)
                {
                    retorno = 0;
                    Session["CountMensajes"] = retorno;
                }
                return retorno;
            }

            set
            {
                if (!value.HasValue)
                {
                    Session.Remove("CountMensajes");
                }
                else
                {
                    Session["CountMensajes"] = value;
                }
            }
        }
        public static gestion_documental.BusinessObjects.CorreoEntrante CorreoVer
        {
            get
            {
                gestion_documental.BusinessObjects.CorreoEntrante correoVer = Session["CorreoVer"] as gestion_documental.BusinessObjects.CorreoEntrante;
                return correoVer;
            }
            set
            {
                if (value == null)
                {
                    Session.Remove("CorreoVer");
                }
                else
                {
                    Session["CorreoVer"] = value;
                }
            }
        }
        public static gestion_documental.BusinessObjects.CorreoEntrante CorreoReenvio
        {
            get
            {
                gestion_documental.BusinessObjects.CorreoEntrante reenvio = Session["CorreoReenvio"] as gestion_documental.BusinessObjects.CorreoEntrante;
                return reenvio;
            }
            set
            {
                if (value == null)
                {
                    Session.Remove("CorreoReenvio");
                }
                else
                {
                    Session["CorreoReenvio"] = value;
                }
            }
        }
        public static List<Adjuntos> ArchivosPorCorreo
        {
            get
            {
                List<Adjuntos> archivos = Session["ArchivosPorCorreo"] as List<Adjuntos>;
                if (archivos == null)
                {
                    archivos = new List<Adjuntos>();
                }
                return archivos;
            }
            set
            {
                if (value == null)
                {
                    Session.Remove("ArchivosPorCorreo");
                }
                else
                {
                    Session["ArchivosPorCorreo"] = value;
                }
            }
        }
        #region Recep Documento Fisico
        public static Radicados ObjRadicado
        {
            get
            {
                Radicados radicado = Session["ObjRadicado"] as Radicados;
                return radicado;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("ObjRadicado");
                }
                else
                {
                    Session["ObjRadicado"] = value;
                }
            }
        }
        public static Documentos ObjDocumento
        {
            get
            {
                Documentos documento = Session["ObjDocumento"] as Documentos;
                return documento;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("ObjDocumento");
                }
                else
                {
                    Session["ObjDocumento"] = value;
                }
            }
        }
        public static EmiRecep ObjEmisorOrigen
        {
            get
            {
                EmiRecep emiOrigen = Session["ObjEmisorOrigen"] as EmiRecep;
                return emiOrigen;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("ObjEmisorOrigen");
                }
                else
                {
                    Session["ObjEmisorOrigen"] = value;
                }
            }
        }
        public static EmiRecep ObjEmisorDestino
        {
            get
            {
                EmiRecep emiDestino = Session["ObjEmisorDestino"] as EmiRecep;
                return emiDestino;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("ObjEmisorDestino");
                }
                else
                {
                    Session["ObjEmisorDestino"] = value;
                }
            }
        }


        public static Workflow ObjWorkflow        {
            get
            {
                Workflow Workflow = Session["Workflow"] as Workflow;
                return Workflow;
            }

            set
            {
                if (value == null)
                {
                    Session.Remove("ObjWorkflow");
                }
                else
                {
                    Session["ObjWorkflow"] = value;
                }
            }
        }

        #endregion
    }
}