<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArchivoRecepcion.aspx.cs" Inherits="gestion_documental.ArchivoRecepcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 89px;
        }

        .style3 {
            width: 266px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="lblescaner" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Enabled="False" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="Enviar correo electrónico"
                    Font-Bold="True" />
            </td>
        </tr>
    </table>
    <hr />
    <div align="center">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Proceso"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProceso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Actividad"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlActividad" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Asignar" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <asp:Panel ID="DivContenidoCargarDocumento" runat="server" Enabled="false">
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Documentos a Cargar"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDocumentoActividad" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center" style="border: thin groove #000000">
            <table>
                <tr>
                    <td class="style8" colspan="4">
                        <asp:Button ID="btnescaner" runat="server" OnClick="btnescaner_Click" Text="Escanear" />
                        <asp:TextBox ID="txtDoc" runat="server" AutoPostBack="True" Width="491px"></asp:TextBox>
                        <asp:ImageButton ID="btnPrevio" runat="server" Height="30px" ImageUrl="~/Images/Preview-icon.png"
                            OnClick="btnPrevio_Click" Width="29px" />
                        <asp:Button ID="Button5" runat="server" Text="Adjuntar" OnClick="Button5_Click" Width="96px" />
                    </td>
                </tr>
            </table>
        </div>
         <div>
            <br />
            <br />
            <div align="center" style="border: thin groove #000000">
                <asp:Label ID="LabelT" runat="server" Text="Anexar Archivo Dgital"></asp:Label>

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Nuevo Documento:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                                <ContentTemplate>
                                    <asp:FileUpload ID="file_upload" runat="server" Height="30px" Width="300px" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnFileUpload" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Button ID="btnFileUpload" runat="server" Text="Adjuntar archivo"                                OnClick="btnFileUpload_Click1"  />
                        </td>

                    </tr>
                </table>
            </div>
        </div>
        <div>
            <asp:GridView ID="gvDocumento" runat="server" AutoGenerateColumns="False" Width="1081px"
                                    CellPadding="4"
                                    ForeColor="#333333" GridLines="None" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="TIPODOC" HeaderText="Tipo Documento" />
                                        <asp:BoundField DataField="NOMBREDOC" HeaderText="Nombre Documento" />
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
        </div>
        <table align="center">

            <tr>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="Otro Radicado"
                        OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <!--
    <div align="center" id = "Carga" visible = "false">
        <br />
        <br />
        <hr />
        <asp:Label ID="Label21" runat="server" Text="ARCHIVO DIGITAL ANEXO"></asp:Label>
        <br />
        <br />
        <table id= "TCarga" visible ="false" >
            <tr>
                <td class="style3">
                    <asp:Label ID="Label33" runat="server" Text="Carpeta:"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btn_cargar" runat="server" Text="Cargar" OnClick="btn_cargar_Click"
                        Width="89px" />
                </td>
                <td>
                    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click"
                        Width="89px" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grd_archivos" runat="server" AutoGenerateColumns="false" 
                        Width="452px">
                        <Columns>
                            <asp:BoundField DataField="archivo" HeaderText="ARCHIVO" ReadOnly="True">
                                <ItemStyle Font-Names="Trebuchet MS" />
                                <HeaderStyle Width="100%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style1">
                </td>
                <td>
                    <asp:Button ID="btn_registrar" runat="server" Text="Registrar" OnClick="btn_registrar_Click"
                        Width="89px" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    -->
       
    </asp:Panel>
</asp:Content>
