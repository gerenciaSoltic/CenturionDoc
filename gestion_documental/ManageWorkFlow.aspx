<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageWorkFlow.aspx.cs" Inherits="gestion_documental.ManageWorkFlow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <br />
            
                <br />
                <h1>
                    Work Flow</h1>
                <br />
                

                <div style="overflow: hidden;">
                            
                            <div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvWorkFlow" AutoGenerateColumns="False" EnableModelValidation="True"
                                    Width="100%" DataKeyNames="ID"  OnRowDeleting="gvWorkFlow_DeleteEventHandler" OnRowDataBound="gvShowWorkFlow_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="Id" />
                                        <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                                        <asp:BoundField DataField="RADICADO" HeaderText="Radicado" />
                                        <asp:BoundField DataField="IDENTEORIGEN" HeaderText="Ente Origen" />
                                        <asp:BoundField DataField="IDENTEDESTINO" HeaderText="Ente Destino" />
                                        <asp:BoundField DataField="DIAS" HeaderText="Dias" />
                                        <asp:BoundField DataField="OBSERVACION" HeaderText="Observacion" />
                                        <asp:BoundField DataField="IDTIPOLOGIA" HeaderText="Tipologia" />
                                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                                        <asp:BoundField DataField="IDDOCUMENTO" HeaderText="Documento" />
                                        <asp:BoundField DataField="IDEXPEDIENTE" HeaderText="Expediente" />
                                         <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="false" SelectText="Seleccionar" DeleteText="Eliminar">
         </asp:CommandField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>