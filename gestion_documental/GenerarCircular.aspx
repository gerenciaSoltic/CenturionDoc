<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="GenerarCircular.aspx.cs" Inherits="gestion_documental.GenerarCircular" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="Msj" Style="width: 100%"></asp:Label>
    <asp:HiddenField ID="hruta" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblescaner" Style="width: 100%"> </asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Generar documento">
        <br />
        <table border="0" style="width: 100%; text-align: left;" cellspacing="0">
            <tr>
                <td>
                    SELECCIONE EL TIPO DE CIRCULAR
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddl_circular_tipo" runat="server" Width="100%" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_circular_tipo_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Consecutivo:&nbsp;&nbsp;
                        <asp:Label ID="lb_consecutivo" runat="server" Text="000000001"></asp:Label>
                    </b>
                </td>
            </tr>
        </table>
        <table align="center">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Firma"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtFirma" runat="server" Width="356px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cargo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtCargo" runat="server" Width="353px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table border="0" style="width: 100%; text-align: left;" cellspacing="0">
            <tr>
                <td>
                    <asp:TextBox ID="txt_contenido_doc" runat="server" TextMode="MultiLine" Width="100%"
                        Height="352px"></asp:TextBox>
                    <%--<CKEditor:CKEditorControl ID="txt_contenido_doc" BasePath="~/ckeditor/" runat="server" ></CKEditor:CKEditorControl>--%>
                </td>
            </tr>
        </table>
        <hr />
        <table style="width: 100%" align="center">
            <tr align="center">
                <td>
                    <asp:Button ID="btn_previo" runat="server" Text="Vista Previa" OnClick="btn_previo_Click" />
                    <asp:Button ID="btn_guardar" runat="server" Text="Generar circular" OnClick="btn_guardar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
</asp:Content>
