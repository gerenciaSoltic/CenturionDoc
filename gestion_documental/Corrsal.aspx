<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Corrsal.aspx.cs" Inherits="gestion_documental.Corrsal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/JavaScript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript">
       
    </script>

   
    <style type="text/css">
       
        .style1
        {
            width: 26%;
        }
       
    </style>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label runat="server" ID="title" Text="PlanSide" Style="width: 100%"/>
    <asp:HiddenField ID="HiddenField1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="Msj" Style="width: 100%"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" cellpadding="10" width="100%">
        <tr>
            <td>
                <asp:Panel ID="PanelGeneral" runat="server" Width="100%" Height="100%" CssClass="panel" GroupingText="Correo Saliente">
                    <table width="100%" border="0" cellspacing="10">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="ParaLabel" runat="server" Width="40px" CssClass="label" Text="Para"></asp:Label>
                            </td>
                            <td width="90%">
                                <asp:DropDownList ID="DdlEmisor" runat="server" Height="16px" 
                                    Width="425px" 
                                    onselectedindexchanged="DdlEmisor_SelectedIndexChanged" 
                                    ontextchanged="DdlEmisor_TextChanged">
                                </asp:DropDownList>
                                <asp:Button ID="Button1" runat="server" Text="Agregar" 
                                    onclick="Button1_Click" />
                                
                            </td>
                            
                        </tr>
                       
                        <tr>
                        <td>
                        <asp:Label ID="Label1" runat="server" Text="Correo" CssClass="label" Font-Size="Smaller"></asp:Label> 
                        </td>
                        <td>
                        
                                   
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="424px" 
                                    AutoPostBack="True" Height="114px" TextMode="MultiLine"></asp:TextBox>
                        
                        </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="AsuntoLabel" runat="server" Width="40px" CssClass="label" Text="Asunto"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AsuntoTextBox" Width="100%" runat="server" CssClass="textBox" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                         </table>
                        <table>
                        <tr>
                            <td colspan="2">
                                <textarea id="Mensaje" runat="server" name="elm1" rows="15" cols="80" style="width: 100%" ></textarea>
                            </td>
                        </tr>
                        <tr>
                           
                            </td>
                        </tr>
                        <tr>
                    <td align="center" class="style1">
                    <table width="100px" style="width: 508px">
                        <tr>
            <td>
                <asp:Label ID="LblRadicado" runat="server" Text="Radicado:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtRadicado" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
    <td>

    <asp:Label ID="LblSerie" runat="server" Text="Serie:"></asp:Label>
    </td>

    <td>
        <asp:DropDownList ID="DdlSerie" runat="server" Width="328px" 
            AutoPostBack="True" DataTextField="SERIE" DataValueField="ID" Enabled="True" 
            onselectedindexchanged="DdlSerie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Llbl" runat="server" Text="SubSerie:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlSubserie" runat="server" Width="302px" 
            AutoPostBack="True" DataTextField="SUBSERIE" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlSubserie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="LblTipologia" runat="server" Text="Tipologia:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlTipologia" runat="server" Width="210px" 
            AutoPostBack="True" DataTextField="TIPOLOGIA" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlTipologia_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
      
    </tr>
    <tr>
    <td>
    <asp:Label ID="LblExpediente" runat="server" Text="Expediente:"></asp:Label>
    </td>
    <td>
    <asp:DropDownList ID="DdlExpediente" runat="server" Width="508px" Height="16px" 
            AutoPostBack="True" DataTextField="DESCRIPCION" DataValueField="ID" 
            Enabled="False" 
            onselectedindexchanged="DdlExpediente_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
     <td height="10px" colspan="2">
     
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                   
                      
                    <ContentTemplate>
                        <asp:FileUpload runat="server" ID="fuImagem" />
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Adjuntar" />
                    </Triggers>
                        
                </asp:UpdatePanel>
    </td>
    <td>
                 <asp:Button ID="Adjuntar"  runat="server" Text="Adjuntar" 
                     onclick="Adjuntar_Click" />   
           </td>    
   </tr>
      </table>
      <table>
      <tr>
      <td>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
              CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="Archivo" HeaderText="Archivo" />
                  <asp:CommandField ShowSelectButton="True" />
                  <asp:CommandField ShowDeleteButton="True" />
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
      </table>
      <hr />
     <table>   
                            <tr>
                                <td align="center" colspan="2">
                                    <table width="200px">
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnEnviar" runat="server" onclick="BtnEnviar_Click" 
                                                    Text="Enviar" Width="246px" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSalir" runat="server" Text="Salir" onclick="btnSalir_Click" 
                                                    Width="244px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="10px">
                                </td>
                            </tr>
                        </caption>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
   
</asp:Content>

