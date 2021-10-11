<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuUserControl.ascx.cs" Inherits="gestion_documental.UserControls.MenuUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ToolkitScriptManager runat="server" ID="MenuUserControlScriptManager" EnablePageMethods="true" AsyncPostBackTimeout="36000">
</asp:ToolkitScriptManager>

<asp:Panel runat="server" ID="menuprincipal" CssClass="contentMenu" BorderColor="#02223A"
    BorderWidth="2">
    <asp:Accordion ID="Menu" runat="server" SelectedIndex="-1" HeaderCssClass="headerAcordeon"
        HeaderSelectedCssClass="headerAcordeonSelected" ContentCssClass="contenidoAcordeon"
        AutoSize="None" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40"
        RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>

            <asp:AccordionPane runat="server" ID="MenuCorreo">
                <Header>
                    Correo
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="PanelMenuAdmin" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>

                        <ul class="listaMenu">

                            <li runat="server" id="li11"><a href="CorreoEntrante.aspx"><span class="buttonItem">Correo Entrante</span></a></li>
                            <hr />

                            <li runat="server" id="li12"><a href="Corrsal.aspx"><span class="buttonItem">Correo Saliente</span></a></li>
                            <li runat="server" id="li40"><a href="listacorsal.aspx"><span class="buttonItem">Listado Correo Enviado</span></a></li>
                        </ul>
                    </asp:Panel>
                </Content>
            </asp:AccordionPane>
            <asp:AccordionPane runat="server" ID="MenuComunicaciones">
                <Header>
                    Comunicaciones oficiales
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel1" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li21"><a href="RecepDocFisico.aspx"><span class="buttonItem">Recepción y Envío de Comunicaciones oficiales</span></a></li>
                            <li runat="server" id="li22"><a href="TramiteDocumento.aspx"><span class="buttonItem">Tramite de Comunicaciones oficiales</span></a></li>
                            <li runat="server" id="li23"><a href="ManageExpediente.aspx"><span class="buttonItem">Expedientes</span></a></li>
                            <li runat="server" id="li24"><a href="digitaliza.aspx"><span class="buttonItem">Digitalización de documentos</span></a></li>
                            <li runat="server" id="li25"><a href="CalidadDigitalizacion.aspx"><span class="buttonItem">Proceso de calidad de Digitalización</span></a></li>
                            <li runat="server" id="li10"><a href="Respuestasintramite.aspx"><span class="buttonItem">Respuestas sin trámite</span></a></li>
                            <li runat="server" id="li14"><a href="RecibidoConformidad.aspx"><span class="buttonItem">Recibido a Conformidad</span></a></li>
                            <li runat="server" id="li15"><a href="GenerarCircular.aspx"><span class="buttonItem">Generar Circular</span></a></li>
                            <li runat="server" id="li16"><a href="EnviarCircular.aspx"><span class="buttonItem">Enviar Circular</span></a></li>


                        </ul>
                    </asp:Panel>


                </Content>
            </asp:AccordionPane>
            <asp:AccordionPane runat="server" ID="MenuInventarios">
                <Header>
                    Inventario de Documentos
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel6" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li31"><a href="transferencia.aspx"><span class="buttonItem">Transferencias de Expedientes</span></a></li>
                            <li runat="server" id="li32"><span class="buttonItem">Bajas de Expedientes</span></a></li>
                            <li runat="server" id="li33"><span class="buttonItem">Inventarios de Expedientes Por oficina Productora</span></a></li>
                            <li runat="server" id="li34"><a href="HojaRuta.aspx"><span class="buttonItem">Hoja de Ruta Por oficina Productora</span></a></li>
                            <li runat="server" id="li5"><a href="InventarioNormal.aspx"><span class="buttonItem">Inventario Normal</span></a></li>
                            <li runat="server" id="li6"><a href="InventarioContratacion.aspx"><span class="buttonItem">Inventario Contratacion</span></a></li>
                            <li runat="server" id="li7"><a href="InventarioHistoriaslaborales.aspx"><span class="buttonItem">Inventario Historias Laborales</span></a></li>
                            <li runat="server" id="li8"><a href="control_HistoriaLaboral.aspx"><span class="buttonItem">Hoja de Control Laboral</span></a></li>
                            <li runat="server" id="li43"><a href="HojaControlContratos.aspx"><span class="buttonItem">Hoja de Control Contratos</span></a></li>
                            <li runat="server" id="li29"><a href="cargue.aspx"><span class="buttonItem">Subir Documentos Expediente</span></a></li>
                            <li runat="server" id="li37"><a href="unirpdfs.aspx"><span class="buttonItem">Unir</span></a></li>
                            <hr />

                            <li runat="server" id="li20"><a href="inventarioCustodia.aspx"><span class="buttonItem">Inventario de Custodia</span></a></li>

                            <li runat="server" id="li26"><a href="prestamo.aspx"><span class="buttonItem">Prestamos</span></a></li>
                            <li runat="server" id="li27"><a href="terceros.aspx"><span class="buttonItem">Terceros</span></a></li>


                        </ul>
                    </asp:Panel>


                </Content>
            </asp:AccordionPane>
            <asp:AccordionPane runat="server" ID="MenuConsultas">
                <Header>
                    Consultas
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel2" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li41"><a href="BuscadorArchivos.aspx"><span class="buttonItem">Buscador de Documentos</span></a></li>
                            <li runat="server" id="li1"><a href="ConsultaRecepcion.aspx?informe=RepoVentanilla.rdlc" target="_blank"><span class="buttonItem">Consulta de Documentos Recibidos</span></a></li>
                            <li runat="server" id="li42"><a href="ConsultaWorkFlow.aspx"><span class="buttonItem">Consulta Work Flow</span></li>
                            <li runat="server" id="li18"><a href="ConsultaWorkFlowFuncionario.aspx"><span class="buttonItem">Consulta Work Flow Funcionarios</span></li>
                            <li runat="server" id="li2"><a href="InformeTRD.aspx"><span class="buttonItem">Consulta de Series -  Subseries - Tipologias</span></a></li>
                            <li runat="server" id="li3"><a href="InfWorkFlow.aspx"><span class="buttonItem">Consulta de Configuracíon WorkFlow</span></a></li>
                            <li runat="server" id="li13"><a href="ConsultaAtenciones.aspx"><span class="buttonItem">Consulta de Atenciones</span></a></li>
                        </ul>
                    </asp:Panel>
                </Content>
            </asp:AccordionPane>
            <asp:AccordionPane runat="server" ID="MenuAministracion">
                <Header>
                    Administración
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel4" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li51"><a href="ManageEnte.aspx"><span class="buttonItem">Oficinas Productoras</span></a></li>
                            <li runat="server" id="li52"><a href="ManageCargos.aspx"><span class="buttonItem">Cargos</span></li>
                            <li runat="server" id="li53"><a href="Manageusuarios.aspx"><span class="buttonItem">Usuarios</span></a></li>
                            <li runat="server" id="li17"><a href="camclave.aspx"><span class="buttonItem">Cambiar contraseña</span></a></li>
                            <li runat="server" id="li54"><a href="ManageEmiRecep.aspx"><span class="buttonItem">Emisores</span></a></li>
                            <li runat="server" id="li55"><a href="ManageConfiCor.aspx"><span class="buttonItem">Configuración Correos</span></a></li>

                            <hr>

                            <li runat="server" id="li56"><a href="ManageConfigwf.aspx"><span class="buttonItem">Configuración Work Flow</span></a></li>
                            <li runat="server" id="li57"><span class="buttonItem">Configuración Disposiciónes Finales</span></li>
                            <hr>
                            <li runat="server" id="li58"><a href="ManageUnidades.aspx"><span class="buttonItem">Tipos de Almacenamiento de documentos</span></li>
                            <li runat="server" id="li59"><a href="ManageSitioArchivo.aspx"><span class="buttonItem">Localización Archivo de documentos</span></li>

                            <hr>
                            <li runat="server" id="li510"><a href="ManageSerie.aspx"><span class="buttonItem">Series</span></a></li>
                            <li runat="server" id="li511"><a href="ManageSubSerie.aspx"><span class="buttonItem">Subseries</span></a></li>
                            <li runat="server" id="li512"><a href="ManageAtributos.aspx"><span class="buttonItem">Atributos de Busqueda General</span></a></li>

                            <li runat="server" id="li513"><a href="ManageTipologia.aspx"><span class="buttonItem">Tipologias</span></a></li>
                            <hr>
                            <li runat="server" id="li514"><a href="ManageRadicados.aspx"><span class="buttonItem">Radicados</span></a></li>
                            <li runat="server" id="li515"><a href="ManageIndices.aspx"><span class="buttonItem">Indices</span></a></li>

                            <li runat="server" id="li516"><a href="ManageTareas.aspx"><span class="buttonItem">Tareas</span></a></li>
                            <hr />
                            <li runat="server" id="li19"><a href="Sincronizacion.aspx"><span class="buttonItem">Sincronizar</span></a></li>
                            <hr />
                            <li runat="server" id="li38"><a href="GenWorkflow.aspx"><span class="buttonItem">Agendar WorKflow</span></a></li>

                            <hr />
                            <li runat="server" id="li45"><a href="ManageProcesos.aspx"><span class="buttonItem">Procesos</span></a></li>
                            <li runat="server" id="li46"><a href="ManageActividad.aspx"><span class="buttonItem">Actividad</span></a></li>
                            <li runat="server" id="li47"><a href="ManageDocumentoActividad.aspx"><span class="buttonItem">Documento Actividad</span></a></li>
                        </ul>
                    </asp:Panel>
                </Content>
            </asp:AccordionPane>
            <asp:AccordionPane runat="server" ID="MenuInformes">
                <Header>
                    Informes
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel3" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li61"><a href="Alarmas.aspx" target="_blank"><span class="buttonItem">Alarmas</span></li>
                            <li runat="server" id="li62"><span class="buttonItem">Disposición Final</span></li>
                            <li runat="server" id="li28"><a href="ConsultaRecepcion.aspx?informe=RepoInforme.rdlc" target="_blank"><span class="buttonItem">Informe de Atenciones</span></a></li>
                            <li runat="server" id="li30"><a href="ConsultaRecepcion.aspx?informe=RepoPQRS.rdlc" target="_blank"><span class="buttonItem">Informe de PQRS</span></a></li>
                            <li runat="server" id="li35"><a href="ConsultaRecepcion.aspx?informe=RepoSIA.rdlc" target="_blank"><span class="buttonItem">Informe SIA</span></a></li>
                            <li runat="server" id="li36"><a href="ConsultaRecepcion.aspx?informe=RepoVentanillaVir.rdlc" target="_blank"><span class="buttonItem">Informe Ventanilla Virtual</span></a></li>
                            <li runat="server" id="li9"><a href="historiaslaborales.aspx?informe=RepoHistorialaboral.rdlc" target="_blank"><span class="buttonItem">Historias Laborales</span></a></li>
                            <li runat="server" id="li39"><a href="Estadisticas.aspx" target="_blank"><span class="buttonItem">Estadistica</span></a></li>

                        </ul>
                    </asp:Panel>
                </Content>
            </asp:AccordionPane>
            <asp:AccordionPane runat="server" ID="MenuCertificados">
                <Header>
                   Certificados
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel7" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li4"><a href="CertificadosEducacion.aspx"><span class="buttonItem">Generar certificado</span></li>
                            <li runat="server" id="li44"><a href="configcertificado.aspx"><span class="buttonItem">Configurar certificado</span></li>

                        </ul>
                    </asp:Panel>
                </Content>
            </asp:AccordionPane>

            <asp:AccordionPane runat="server" ID="AccordionPane1">
                <Header>
                    Salir
                </Header>
                <Content>
                    <asp:Panel runat="server" ID="Panel5" CssClass="contentMenu" Height="100%">
                        <table>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                        </table>
                        <ul class="listaMenu">
                            <li runat="server" id="li71"><a href="Default.aspx"><span class="buttonItem">Cerrar Sesión</span></li>

                        </ul>
                    </asp:Panel>
                </Content>
            </asp:AccordionPane>

        </Panes>
    </asp:Accordion>
</asp:Panel>
