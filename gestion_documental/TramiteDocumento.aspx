<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TramiteDocumento.aspx.cs" Inherits="gestion_documental.TramiteDocumento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Msj" TagName="Mensajes" Src="~/Mensajes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2 {
            width: 220px;
        }

        .style3 {
            width: 713px;
        }

        .style4 {
            width: 211px;
        }

        .style5 {
            width: 146px;
        }

        .botones {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="Msj" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        function mpeMensajeOnOk() {

            var TxtObserva = document.getElementById("TxtObserva");

            TxtObserva.value = "";
            TxtObserva.focus();

        }
    </script>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Trámite de Documentos" BorderStyle="Solid">
        <table width="50%">
            <tr>
                <td width="30%">Buscar Radicado:
                </td>
                <td width="10%" align="center">Buscar Fecha:
                </td>
                <td width="10%" align="center"></td>
            </tr>
            <tr>
                <td width="30%" align="center">

                    <asp:TextBox ID="txt_buscar" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td width="10%" align="center">
                    <asp:TextBox ID="Txt_Fecha" runat="server" Width="100%"></asp:TextBox>
                    <asp:CalendarExtender
                        ID="CalendarExtender1"
                        TargetControlID="Txt_Fecha"
                        runat="server" Format="yyyy-MM-dd" />


                    <td width="10%" align="center">
                        <asp:Button ID="btn_buscar" runat="server" Text="Buscar"
                            CssClass="botones" OnClick="btn_buscar_Click" Width="100%" Height="30px" />
                    </td>
                    <td>Busqueda Por clave
        
                    </td>
                    <td>
                        <asp:TextBox ID="TxtClave" runat="server"></asp:TextBox>
                    </td>
            </tr>


        </table>





        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="ArchivoNuevo" runat="server" />
                <asp:GridView runat="server" ID="gvPendientes" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="True" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None"
                    OnPageIndexChanging="gvPendientes_PageIndexChanging" OnSelectedIndexChanged="gvPendientes_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Seleccionar" ShowCancelButton="False" ShowSelectButton="True" />
                        <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                        <asp:BoundField DataField="ENTEORIGEN" HeaderText="DE" />
                        <asp:BoundField DataField="SEMAFORO" HeaderText="TIPO COM." />
                        <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                        <asp:BoundField DataField="EMIRECEP" HeaderText="EMISOR" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" />
                        <asp:BoundField DataField="DIAS" HeaderText="DIAS" />
                        <asp:BoundField DataField="radicado" HeaderText="Radicado" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <hr />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label22" runat="server" Text="PROCESO: " Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LbProceso" runat="server" Text="" ></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="ACTIVIDAD: " Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LbActividad" runat="server" Text="" ></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <asp:Label ID="Label4" runat="server" Text="TRAMITE" Font-Bold="True"></asp:Label>
                    <tr>
                        <td>
                            <asp:Label ID="LblRadicado" runat="server" Text="Radicado:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRadicado" runat="server" Enabled="False" Width="152px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="LbelEstado" runat="server" Text="Estado Nuevo:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlEstados" runat="server" Width="302px" AutoPostBack="True"
                                Enabled="False" OnSelectedIndexChanged="DdlEstados_SelectedIndexChanged" OnTextChanged="DdlEstados_TextChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="LblEnviar" runat="server" Text="Enviar A:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdLEnviar" runat="server" Width="302px" Enabled="False" AutoPostBack="True"
                                DataTextField="FUNCIONARIO" DataValueField="IDemirecep">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Asignar Tarea :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlTarea" runat="server" Width="292px" Height="20px" AutoPostBack="True"
                                DataTextField="DESCRIPCION" DataValueField="IDTAREAS">
                            </asp:DropDownList>
                        </td>
                        <td class="style5">
                            <asp:Label ID="Label5" runat="server" Text="Tiempo en Dias :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtDias" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="DATOS DEL EMISOR" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Documento"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDocumento" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" Width="659px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Teléfono"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefono" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Dirección"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDireccion" runat="server" Enabled="False" Width="659px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table align="center">
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Correo Electrónico"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMail" runat="server" Enabled="False" Width="706px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr />

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="DATOS DEL EMISOR INICIAL" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Documento"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDocumentoInicial" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombreInicial" runat="server" Width="659px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="Teléfono"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefonoinicial" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Dirección"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDireccionInicial" runat="server" Enabled="False" Width="659px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <table align="center">
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="Correo Electrónico"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailInicial" runat="server" Enabled="False" Width="706px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <hr />


                <div>
                    TEXTO DEL CORREO
                
                    <asp:TextBox ID="txtTextoCorreo" runat="server" Height="173px" Width="1071px"
                        TextMode="MultiLine"></asp:TextBox>
                </div>

                <hr />
                <table>
                    <asp:Label ID="Label6" runat="server" Text="DOCUMENTO DEL TRAMITE" Font-Bold="True"></asp:Label>
                    <tr>
                        <td>
                            <asp:Label ID="LblSerie" runat="server" Text="Serie:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlSerie" runat="server" Width="328px" AutoPostBack="True"
                                DataTextField="SERIE" DataValueField="ID" Enabled="False" OnSelectedIndexChanged="DdlSerie_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Llbl" runat="server" Text="SubSerie:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlSubserie" runat="server" Width="302px" AutoPostBack="True"
                                DataTextField="SUBSERIE" DataValueField="ID"
                                OnSelectedIndexChanged="DdlSubserie_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="LblTipologia" runat="server" Text="Tipologia:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlTipologia" runat="server" Width="210px" AutoPostBack="True"
                                DataTextField="TIPOLOGIA" DataValueField="ID"
                                OnSelectedIndexChanged="DdlTipologia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LblExpediente" runat="server" Text="Expediente:"></asp:Label>
                            <asp:DropDownList ID="DdlExpediente" runat="server" Width="577px" Height="25px" AutoPostBack="True"
                                DataTextField="DESCRIPCION" DataValueField="ID"
                                OnSelectedIndexChanged="DdlExpediente_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button8" runat="server" Text="Actualizar Documento" Enabled="False"
                                OnClick="Button8_Click" />
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Nuevo Documento:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                                <ContentTemplate>
                                    <asp:FileUpload ID="ImageButton2" runat="server" Height="30px" Width="300px" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="Button6" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Label ID="Label24" runat="server" Text="Documento a cargar:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="328px" DataTextField="NOMBREDOCUMENTO" DataValueField="ID">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button6" runat="server" Text="Adjuntar archivo" OnClick="Button6_Click1" />
                        </td>
                </table>
                <hr />
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="Descargar plantilla" OnClick="Button5_Click1" />
                        </td>
                        <td>
                            <asp:Button ID="Button7" runat="server" Text="Firmar" OnClick="Button5_Click1" Width="185px" />
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Lista de Documentos Del Trámite:"></asp:Label>
                        </td>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1081px"
                                    CellPadding="4" DataKeyNames="documento,camino,iddocumentos,idserie,idsubserie,idtipologia,nomserie,nomsubserie,nomtipologia,idexpediente,nomexpediente"
                                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="documentoactividad.NOMBREDOCUMENTO" HeaderText="Serie" />
                                        <asp:BoundField DataField="nomserie" HeaderText="Serie" />
                                        <asp:BoundField DataField="nomsubserie" HeaderText="Subserie" />
                                        <asp:BoundField DataField="nomtipologia" HeaderText="Tipologia" />
                                        <asp:BoundField HeaderText="Documento" DataField="documento" />
                                        <asp:BoundField HeaderText="versión" DataField="version" />
                                        <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Resumen Respuesta del funcionario" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TxtRespuesta" runat="server" Height="148px" Width="1017px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                </table>
                <hr />
                <hr />
                <div align="center">
                    <asp:GridView ID="gvindice" runat="server" AutoGenerateColumns="False" DataKeyNames="">
                        <Columns>
                            <asp:BoundField DataField="atributo" HeaderText="atributo" />
                            <asp:TemplateField HeaderText="Descripcion">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdescripcion" runat="server" Text='<%# Eval("indice")%>' Height="22px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btactualizarindices" runat="server" Text="Actualizar" OnClick="btactualizarindices_Click"
                                    Visible="False" Width="139px" />
                            </td>
                            <td></td>
                            <td>
                                <asp:Button ID="btneliminar" runat="server" Text="Eliminar Indices" OnClick="btneliminar_Click"
                                    Visible="False" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </div>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td class="style4"></td>
                        <td class="style3">
                            <asp:ListBox ID="lista" runat="server" Visible="False" Width="550px"></asp:ListBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="style4"></td>
                        <td class="style3">
                            <asp:TextBox ID="TxtIndice" runat="server" Width="301px" Visible="False"></asp:TextBox>
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Adicionar Indice"
                                UseSubmitBehavior="False" Visible="False" />
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Quitar Indice"
                                Visible="False" />
                        </td>
                        <td></td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td align="justify">
                            <asp:Label ID="LblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                            <asp:TextBox ID="TxtObserva" runat="server" Height="30px" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td class="style2"></td>
                        <td>
                            <asp:Button ID="BtnRegistrar" runat="server" OnClick="BtnRegistrar_Click" Text="Registrar"
                                Width="139px" />
                        </td>
                        <td>
                            <asp:Button ID="BtnRegistrarCorreo" runat="server"
                                OnClick="BtnRegistrarCorreo_Click" Text="Registrar y Enviar por Correo Electrónico"
                                Width="301px" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="margin-left: 0px"
                                Text="Salir" Width="134px" />
                        </td>
                    </tr>
                </table>
                <hr />
                <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: ;">
                    <table border="0" width="275px" style="margin: 0px; padding: 0px; background-color: #0033CC; color: #FFFFFF;">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label8" runat="server" Text="¡ Atención !" />
                            </td>
                            <td width="12%">
                                <asp:Label ID="LblCerrar" runat="server" Text="| x |" />
                                <%--<asp:ImageButton ID="btnCerrar" runat="server"

                    Style="vertical-align: top;" ImageAlign="Right" onclick="btnCerrar_Click" 
                        Height="18px" Width="18px" ToolTip="Cerrar" 
                        ImageUrl="~/Images/delete_16x16.png" />--%>
                            </td>
                        </tr>
                    </table>
                    <div style="border-style: double">
                        <asp:Image ID="imgIcono" runat="server" ImageUrl="~/Images/info_16x16.png" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" ImageAlign="Middle" />
                        &nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Proceso Exitoso ..." />
                    </div>
                    <div align="center" style="border-style: double">
                        <asp:Button ID="btnAceptarMensaje" runat="server" Text="Aceptar" OnClick="btnAceptarMensaje_Click" />
                    </div>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeMensaje" runat="server" TargetControlID="label7" PopupControlID="pnlMensaje"
                    BackgroundCssClass="FondoAplicacion" OkControlID="" OnOkScript="mpeMensajeOnOk()" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <%--llamada de control de usuario--%>    <%--    <asp:UpdatePanel ID="upPnlPage" runat="server">
        <ContentTemplate>
            <Msj:Mensajes ID="omb" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
