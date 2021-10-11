<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalidadDigitalizacion.aspx.cs" Inherits="gestion_documental.CalidadDigitalizacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    <asp:Label ID="lblmesj" runat="server" Text="Mensaje"></asp:Label>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="header">
                <asp:Panel ID="pnlButtons" runat="server">
                    <%--<asp:Button ID="btnback" runat="server" Text="Back to Settings" CssClass="Button"
                        OnClick="btnback_Click" />--%>
                </asp:Panel>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="300">
                <ProgressTemplate>
                    <div class="Progress">
                        <div style="position: absolute; top: 50%; left: 25%;">
                            <img alt="" src="Images/ajax-loader.gif" style="margin-left: 200px" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
           
                <h1>
                    Calidad de Digitalización </h1>
                <br />
                

                <div style="overflow: hidden;">
                            
                           

                            <div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvCalidad" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="caminocalidad,ruta,idDocumento" 
                                    OnSelectedIndexChanged="gvEnte_SelectedIndexChanged" 
                                    onrowcommand="gvCalidad_RowCommand" onrowdeleting="gvCalidad_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                                        <asp:BoundField DataField="EXPEDIENTE" HeaderText="EXPEDIENTE" />
                                        <asp:BoundField DataField="DOCUMENTO" HeaderText="Documento" />
                                       
                                        <asp:CommandField HeaderText="Opciones" CausesValidation="true" 
                                            ShowDeleteButton="True" ShowSelectButton="true" SelectText="Seleccionar" 
                                            DeleteText="Calidad">
         </asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
