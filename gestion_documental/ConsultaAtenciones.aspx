<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaAtenciones.aspx.cs" Inherits="gestion_documental.ConsultaAtenciones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 
    <div align ="center">
        <%--        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  
        </asp:ToolkitScriptManager>--%>
     <table align="center">  
            <tr>
          <td align="center">
              <asp:Image ID="Image1" runat="server" Height="10%" Width="10%" 
                  ImageAlign="Middle" ImageUrl="~/Images/Escudo Alcaldia Municipal.png" />
              </td>
            </tr>
         
          <tr>
          <td align="center">
              &nbsp;</td>
            </tr>
            <tr>
            <td align="center">
        <asp:Label ID="Label1" runat="server" Text="Consulta de Recepción de Documentos" 
            Font-Names="Tahoma" Font-Size="Larger"></asp:Label>
            </td>
            </tr>
      </table>
    </div>
    <div style="width: 1012px">
    <table align="center">
        
    
    <tr>
    <td>
    <asp:Label ID="Label4" runat="server" Text="Desde la Fecha" Font-Bold="True" 
            Font-Names="Tahoma"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtFechaDesde" runat="server"></asp:TextBox>
    <asp:CalendarExtender   
    ID = "CalendarExtender1"   
    TargetControlID = "txtFechaDesde"   
    runat = "server" Format="yyyy-MM-dd" />
    </td>
    <td>
    <asp:Label ID="Label5" runat="server" Text="Hasta la Fecha" Font-Bold="True" 
            Font-Names="Tahoma"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="TxtFechaHasta" runat="server"></asp:TextBox>
    <asp:CalendarExtender   
    ID = "CalendarExtender2"   
    TargetControlID = "txtFechaHasta"   
    runat = "server" Format="yyyy-MM-dd" />
    </td>
    
    </tr>

    </table>
    <table align="center">
    <tr>
        
    <td >
    <asp:Label ID="Label3" runat="server" Text="Tipo de correspondencia" 
            Font-Names="Calibri"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlTipo" runat="server" Height="31px" Width="243px">
        </asp:DropDownList>

    </td>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Grupo de Comunicaciones"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DDLgrupocom" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DDLgrupocom_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
     <td class="style22">
                <asp:Label ID="LblSemaforo" runat="server" Text="Tipo de Comunicación"></asp:Label>
               </td>
               <td>
            <asp:DropDownList ID="DmpSemaforo" runat="server" Height="16px" Width="183px" 
                       AutoPostBack="True">
            </asp:DropDownList>
                   <asp:Button ID="Button2" runat="server" Text="Agregar" 
                       onclick="Button2_Click" />
                   <asp:Button ID="Button4" runat="server" Text="Agregar Todos" 
                       onclick="Button4_Click" />
            </td>
    </tr>
 
    </table>
    <table align = "center">
    <tr>
    <td>
    
        <asp:Label ID="Label6" runat="server" Text="Tipos de comunicación a Listar"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        <asp:ListBox ID="LstTipoCom" runat="server" Width="433px" AutoPostBack="True"></asp:ListBox>    
        </td>

        <td>
            <asp:Label ID="Label7" runat="server" Text="Radicado"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtRadicado" runat="server" Width="306px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button5" runat="server" Text="Quitar" onclick="Button5_Click" />
    </td>
    </tr>

    
    </table>
    <table align = "center">
    <tr>
    <td>
        <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" 
            onclick="BtnConsultar_Click" />
          
            <input id="Button3" type="button" value="Cerrar" onclick="javascript:cerrar()" />
    </td>
    </tr>
    
    </table>
    <hr />
    <div align="center" style="width: 100%">
        <br />
        <table style="width: 100%">
            <tr>
                <td>



                </td>
            </tr>
        </table>
        </div>
    </div>
   
        <div>
     

             
                    <asp:GridView ID="GrvAtenciones" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onselectedindexchanged="GrvAtenciones_SelectedIndexChanged" 
                  Width="100%" AllowPaging="True" 
                  onpageindexchanging="GrvAtenciones_PageIndexChanging" PageSize="5" Height="80%" 
                        DataKeyNames="idcadena">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="De" HeaderText="De" />
                            <asp:BoundField DataField="Para" HeaderText="Para" />
                            <asp:BoundField DataField="Semaforo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Radicado" HeaderText="Radicado" />
                            <asp:BoundField DataField="Folios" HeaderText="F" />
                            <asp:BoundField DataField="Observacion" HeaderText="Asunto" />
                            <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                            <asp:BoundField DataField="Fecharespuesta" HeaderText="FecResp" />
                            <asp:BoundField DataField="Radicado2" HeaderText="RadResp" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                ImageUrl="~/Images/document_16x16.png" NavigateUrl="camino" Target="_blank">HyperLink</asp:HyperLink>
                        </EmptyDataTemplate>
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

    <div overflow-x:scroll ; overflow-y: scroll>

    <asp:Panel ID="Panel1" runat="server" style=" display:;  background:white; width:70%; height:60%" BorderColor="Blue" BorderStyle="Double">
     
            <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btnCerrar" runat="server" onclick="btnCerrar_Click" 
                                    style="margin-left: 361px" Text="Cerrar" Width="52px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">


                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="1">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="Folios" HeaderText="Folios" 
                                            FooterStyle-HorizontalAlign="Center" >
                                        <FooterStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                        <asp:TemplateField HeaderText="Vizualiza" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink3" runat="server" 
                                                    ImageUrl="~/Images/document_16x16.png" NavigateUrl='<%# Eval("camino") %>' 
                                                    Target="_blank">HyperLink</asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <EmptyDataTemplate>
                                        <asp:HyperLink ID="HyperLink2" runat="server" 
                                            ImageUrl="~/Images/document_16x16.png" NavigateUrl="camino" Target="_blank" 
                                            ToolTip="Ver Documento">HyperLink</asp:HyperLink>
                                    </EmptyDataTemplate>
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
             </table>

                  <asp:HiddenField ID="HiddenField1" runat="server" />
                  <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" 
                      DynamicServicePath="" Enabled="True" PopupControlID="Panel1" 
                      TargetControlID="HiddenField1">
                  </asp:ModalPopupExtender>
          
    </asp:Panel>

        </div>
        <br />
        <br />
    </div>
    
    

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 61px;
        }
    </style>
</asp:Content>

