using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using gestion_documental.Utils;

namespace gestion_documental.UserControls
{
    public partial class MenuUserControl : System.Web.UI.UserControl
    {
        
        Usuarios usuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                deshabilitaMenus();
                usuario = new UsuariosManagement().GetUsuariosById(SessionDocumental.UsuarioInicioSession.CODIGO);
                habilitaMenus();
                
            }
        }
        protected void habilitaMenus()
        {
            int rol = usuario.ROL;
            RolPermisos permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Correo");
            if (permisos.Id != 0)
            {
                MenuCorreo.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Correo Entrante", "Correo");
                if (permisos != null && permisos.ACTIVO == 1) li11.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Correo Saliente", "Correo");
                if (permisos != null && permisos.ACTIVO == 1) li12.Visible = true;
                
            }
            permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Comunicaciones oficiales");
            if (permisos.Id != 0)
            {
                MenuComunicaciones.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Recepción de Comunicaciones oficiales", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li21.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Tramite de Comunicaciones oficiales", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li22.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Expedientes", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li23.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Digitalización de documentos", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li24.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Proceso de calidad de Digitalización", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li25.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Respuestas sin trámite", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li10.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Recibido a Conformidad", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li14.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Generar Circular", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li15.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Enviar Circular", "Comunicaciones oficiales");
                if (permisos != null && permisos.ACTIVO == 1) li16.Visible = true;

            }
            permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Inventario de Documentos");
            if (permisos.Id != 0)
            {
                MenuInventarios.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Transferencias de Expedientes", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li31.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Bajas de Expedientes", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li32.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Inventarios de Expedientes Por oficina Productora", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li33.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Inventario Historias Laborales", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li7.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Hoja de Control", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li8.Visible = true;

                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Hoja de Control Contratos", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li43.Visible = true;
                


                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Hoja de Ruta Por oficina Productora", "Inventario de Documentos");

                if (permisos != null && permisos.ACTIVO == 1) li20.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Inventario de Custodia", "Inventario de Documentos");

                if (permisos != null && permisos.ACTIVO == 1) li26.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Prestamos", "Inventario de Documentos");

                if (permisos != null && permisos.ACTIVO == 1) li27.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Terceros", "Inventario de Documentos");

               


                if (permisos != null && permisos.ACTIVO == 1) li34.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Subir Documentos Expediente", "Inventario de Documentos");
                if (permisos != null && permisos.ACTIVO == 1) li29.Visible = true;
            }
            permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Consultas");
            if (permisos.Id != 0)
            {
                MenuConsultas.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Buscador de Documentos", "Consultas");
                if (permisos != null && permisos.ACTIVO == 1) li41.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Consulta Work Flow", "Consultas");
                if (permisos != null && permisos.ACTIVO == 1) li42.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Consulta Work Flow Funcionario", "Consultas");
                if (permisos != null && permisos.ACTIVO == 1) li18.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Consulta de Documentos Recibidos", "Consultas");
                if (permisos != null && permisos.ACTIVO == 1) li1.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Consulta de Atenciones", "Consultas");
                if (permisos != null && permisos.ACTIVO == 1) li13.Visible = true;
            }
            permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Administración");
            if (permisos.Id != 0)
            {
                MenuAministracion.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Oficinas Productoras", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li51.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Cargos", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li52.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Usuarios", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li53.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Emisores", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li54.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Configuracion Correos", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li55.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Configuración Work Flow", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li56.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Configuración Correos", "Administración");
                //if (permisos != null && permisos.ACTIVO == 1) li56.Visible = true;
                //permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Configuración Disposiciónes Finales", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li57.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Tipos de Almacenamiento de documentos", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li58.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Localización Archivo de documentos", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li59.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Series", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li510.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Subseries", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li511.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Atributos de Busqueda General", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li512.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Tipologias", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li513.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Radicados", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li514.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Indices", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li515.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Tareas", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li516.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Sincronizar", "Administración");
                if (permisos != null && permisos.ACTIVO == 1) li19.Visible = true;

            }

            permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Informes");
            if (permisos.Id != 0)
            {
                MenuInformes.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Alarmas", "Informes");
                if (permisos != null && permisos.ACTIVO == 1) li61.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Disposición Final", "Informes");
                if (permisos != null && permisos.ACTIVO == 1) li62.Visible = true;
            }


            permisos = new RolpermisosManagement().GetRolPermisosByRolAndModulo(rol, "Certificados");
            if (permisos.Id != 0)
            {
                MenuCertificados.Visible = true;
                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Generar certificado", "Certificados");
                if (permisos.Id != 0)
                {
                    li4.Visible = true;
                }

                permisos = new RolpermisosManagement().GetRolPermisosByRolAndMenuModulo(rol, "Configurar certificado", "Certificados");
                if (permisos.Id != 0)
                {
                    li44.Visible = true;
                }
            }

        }
        protected void deshabilitaMenus()
        {
            MenuCorreo.Visible = false;
            MenuCorreo.Enabled = false;
            Menu.Panes[0].Visible = false;
            MenuCorreo.Style["visibility"] = "hidden";
            MenuCorreo.EnableViewState = false;
            li11.Visible = false;
            li12.Visible = false;
            MenuComunicaciones.Visible = false;
            MenuComunicaciones.Enabled = false;
            Menu.Panes[1].Visible = false;
            li21.Visible = false;
            li22.Visible = false;
            li23.Visible = false;
            li24.Visible = false;
            li25.Visible = false;
            li10.Visible = false;
            li14.Visible = false;
            li15.Visible = false;
            li16.Visible = false;

            
            MenuInventarios.Visible = true;
            MenuInventarios.Enabled = true;

            li31.Visible = false;
            li32.Visible = false;
            li33.Visible = false;
            li34.Visible = false;
            li5.Visible = false;
            li6.Visible = false;
            li7.Visible = false;
            li8.Visible = false;
            li29.Visible = false;
            li20.Visible = false;
            li26.Visible = false;
            li27.Visible = false;
            li43.Visible = false;
            li37.Visible = false;
            Menu.Panes[2].Visible = false;
            li31.Visible = false;
            li32.Visible = false;
            li33.Visible = false;
            li34.Visible = false;
            MenuConsultas.Visible = false;
            MenuConsultas.Enabled = false;
            Menu.Panes[3].Visible = false;
            li41.Visible = false;
            li42.Visible = false;
            li18.Visible = false;
            li1.Visible = false;
            li42.Visible = false;
            li2.Visible = false;
            li3.Visible = false;
            li13.Visible = false;
            li31.Visible = false;

            MenuCertificados.Visible = false;
            li4.Visible = false;
            li44.Visible = false;

            MenuAministracion.Visible = false;
            MenuAministracion.Enabled = false;
            Menu.Panes[4].Visible = false;
            li51.Visible = false;
            li52.Visible = false;
            li53.Visible = false;
            li54.Visible = false;
            li55.Visible = false;
            li56.Visible = false;
            li57.Visible = false;
            li58.Visible = false;
            li59.Visible = false;
            li510.Visible = false;
            li511.Visible = false;
            li512.Visible = false;
            li513.Visible = false;
            li514.Visible = false;
            li515.Visible = false;
            li516.Visible = false;
            li19.Visible = false;
            MenuInformes.Visible = false;
            MenuInformes.Enabled = false;
            Menu.Panes[5].Visible = false;
            li61.Visible = false;
            li62.Visible = false;


        }
    }
}