<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenWorkflow.aspx.cs" Inherits="gestion_documental.GenWorkflow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 36px;
        }
        .style2
        {
            width: 445px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Agendar Workflow
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">

<table align="center">
 
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Para"></asp:Label>

</td>
<td>
 <asp:DropDownList ID="Ddlmidestino" runat="server" Height="16px" Width="353px">
    </asp:DropDownList>

</td>
 
 <td>
    <asp:Label ID="Label2" runat="server" Text="Asunto"></asp:Label>

</td>
<td>
    <asp:TextBox ID="txtAsunto" runat="server" Height="55px" Width="340px" 
        TextMode="MultiLine"></asp:TextBox>
</td>

</tr>

<tr>
<td class="style1">
    <asp:Label ID="Label3" runat="server" Text="Tarea"></asp:Label>

</td>
<td class="style1">
 <asp:DropDownList ID="DdlTarea" runat="server" Height="16px" Width="352px">
    </asp:DropDownList>

</td>
 
 <td class="style1">
    <asp:Label ID="Label4" runat="server" Text="Fecha Inicial"></asp:Label>

</td>
<td class="style1">
    <asp:TextBox ID="txtFechaInicial" runat="server" Height="19px" Width="208px"></asp:TextBox>
     <asp:CalendarExtender ID = "CalendarExtender1" TargetControlID = "txtFechaInicial" runat = "server" Format="yyyy-MM-dd" />
     <asp:Label ID="Label8" runat="server" Text="Dias"></asp:Label>
     <asp:TextBox ID="txtDias" runat="server"></asp:TextBox>   
</td>
    
    
</tr>

<tr>
<td>
    <asp:Label ID="Label5" runat="server" Text="Repetir"></asp:Label>

</td>
<td>
 <asp:DropDownList ID="DdlRepetir" runat="server" Height="16px" Width="298px">
    </asp:DropDownList>
    <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
</td>
    
 
 <td>
    <asp:Label ID="Label6" runat="server" Text="Ultima Fecha de Ejecución"></asp:Label>

</td>
<td>
    <asp:TextBox ID="txtUltimaFecha" runat="server" Enabled="False" Height="26px" 
        Width="334px"></asp:TextBox>
     <asp:CalendarExtender ID = "CalendarExtender2" TargetControlID = "txtUltimaFecha" runat = "server" Format="yyyy-MM-dd" />
        
</td>

</tr>
<tr>
<td>
  Aviso de Revisión Para
</td>
<td>
<asp:DropDownList ID="ddlEmirevision" runat="server" Height="16px" Width="297px">
    </asp:DropDownList>

</td>
<td>
<asp:Label ID="lblDocumento" runat="server" Text="DOCUMENTO"></asp:Label>

</td>
<td>
    <asp:TextBox ID="txtDocumento" runat="server" Enabled="False" Width="342px"></asp:TextBox>
    </td>
</tr>

</table >
<hr />
 <asp:HiddenField ID="CaminoDoc" runat="server" />

<table align="center">
   
<tr>
<td class="style2">
<asp:Label ID="Label7" runat="server" Text="Adjuntar este archivo"></asp:Label>

  

 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                                <ContentTemplate>
                                     <asp:FileUpload ID="FileUpload1" runat="server" Width="775px" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="Button1" />
                                </Triggers>
                            </asp:UpdatePanel>


  
 
    <asp:Button ID="Button1" runat="server" Text="Adjuntar Archivo" 
        onclick="Button1_Click" />

</td>
</tr>
    
</table>
<hr />
<table align="center">
<tr>
 <td align="center">
                                            <asp:Button runat="server" ID="btnAddEnte" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="Ente"
                                                OnClick="btnAddEnte_Click" />
                                            <asp:Button ID="btnEnteClear" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearEnte_Click" />
                                            <asp:Button ID="Btn_Salir" runat="server" CssClass="cancelButton" Text="Salir" 
                                                onclick="Btn_Salir_Click"/>
                                        </td>
                                        </tr>
</table>
<hr />
<div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvEnte" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="id" 
                                    OnSelectedIndexChanged="gvEnte_SelectedIndexChanged" 
                                    OnRowDeleting="gvEnte_DeleteEventHandler" 
                                    OnRowDataBound="gvShowEnte_RowDataBound" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Para" HeaderText="Para" />
                                        <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                                        <asp:BoundField DataField="Repetir" HeaderText="Repetir" />
                                        <asp:BoundField DataField="caminodoc" HeaderText="Archivo" />
                                        <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="true" SelectText="Seleccionar" DeleteText="Eliminar">
         </asp:CommandField>
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
</asp:Content>
