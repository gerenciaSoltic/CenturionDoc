<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HojaControlContratos.aspx.cs" Inherits="gestion_documental.HojaControlContratos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            width: 151px;
        }
        .style3
        {
            width: 90px;
        }
        .style6
        {
            width: 140px;
        }
        .style10
        {
            width: 100px;
        }
        .style11
        {
            width: 196px;
        }
        .style12
        {
            width: 529px;
            height: 35px;
        }
        .style13
        {
            width: 89px;
        }
        .style14
        {
            width: 167px;
        }
        .style15
        {
            width: 218px;
        }
    </style>
      <script language="javascript" type="text/javascript">
          function detectar_tecla()
          {
            if (keyCode==13) 
              {
               alert('enter');
               return false;
              }
          }
</script>
</head>
<body style="font-family: Aldhabi">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager  runat="server" ID="MenuUserControlScriptManager" EnablePageMethods="true" AsyncPostBackTimeout = "36000">
</asp:ToolkitScriptManager >
    <div>
    <div align="center">
        <asp:Label ID="lbusuario" runat="server" Text="."></asp:Label>
    </div>
    <table align="center">
    <tr>
    <td align="center" class="style1">
        <asp:Label ID="Label1" runat="server" Text="República de Colombia" 
            Font-Overline="False" 
            style="font-family: 'Kunstler Script'; font-size: xx-large; font-weight: 700"></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="center">
        <asp:Image ID="imagen" runat="server" src="../images/escudosantander.jpg" 
            style="height: 96px; width: 100px" ImageUrl="~/Images/escudosantander.jpg" />
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Gobernación de Santander" 
            style="font-size: xx-large; font-family: 'Kunstler Script'; font-weight: 700"></asp:Label>
    </td>
    </tr>
    </table>
    <table align="center" style="border: thin double #000000">
    <tr>
    <td class="style2" 
            style="border-right-style: double; border-right-width: thin; border-right-color: #000000" align="center">
        &nbsp;<asp:Label ID="Label3" runat="server" Text="HOJA DE CONTROL" 
            style="font-size: small; font-family: Arial; text-align: right;"></asp:Label>
            &nbsp;&nbsp;CONTRATOS</td>
    <td class="style3" 
            style="border-right-style: double; border-right-width: thin; border-right-color: #000000">
        <asp:Label ID="Label4" runat="server" Text="Código:" 
            style="font-family: Arial; font-size: small; text-align: center;"></asp:Label>
         
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
        <asp:Label ID="Label8" runat="server" Text="AP-GD-RG-15" 
            style="font-family: Arial; font-size: small"></asp:Label>
    </td>
    <td style="border-right-style: double; border-right-width: thin; border-right-color: #000000">
        <asp:Label ID="Label5" runat="server" Text="Gestión Documental" 
            style="font-family: Arial; font-size: small"></asp:Label>
    </td>
    <td style="border-right-style: double; border-right-width: thin; border-right-color: #000000">
        <asp:Label ID="Label6" runat="server" Text="Versión:  2" 
            style="font-family: Arial; font-size: small"></asp:Label>
    </td>
    <td>
        <asp:Label ID="Label7" runat="server" Text="Pág.  1 de 1" 
            style="font-family: Arial; font-size: small"></asp:Label>
    </td>
    </tr>
    </table>
    </div>
    <br />
     <div>

      <table align="center">
      <tr>
     <td class="style14">
        <asp:Label ID="Label18" runat="server" Text="Numero Expediente:" 
            style="font-family: Arial"></asp:Label>
    </td>
   
     <td>
         <asp:TextBox ID="txtNumeroContrato" runat="server"  Width="290px" TabIndex="1"></asp:TextBox>
    

    </td>
    <td>
        <asp:Label ID="Label23" runat="server" Text="VOLUMEN :" style="font-family: Arial"></asp:Label>
          </td>
     <td>
    
         <asp:TextBox ID="txtcarpeta" runat="server" Width="119px" TabIndex="2"></asp:TextBox>
              <asp:Button ID="Button3" runat="server" Text="Traer" 
             onclick="Button3_Click" TabIndex="3" UseSubmitBehavior="False" />
          </td>
    </tr>
    
   
   </table> 
   <hr />

   <table>
    <tr>
    
    <td class="style14">
    
        <asp:Label ID="SERI" runat="server" 
            style="font-size: medium; font-family: Arial" 
            Text="SERIE: "></asp:Label>
    
    </td>
     <td>
    
         <asp:DropDownList ID="ddlserie" runat="server"  Width="317px" 
             AutoPostBack="True" onselectedindexchanged="ddlserie_SelectedIndexChanged" 
             TabIndex="4">
         </asp:DropDownList>
    
    </td>
    
    <td class="style10">
    
        <asp:Label ID="Label17" runat="server" 
            style="font-size: medium; font-family: Arial" 
            Text="SUBSERIE: "></asp:Label>
    
    </td>
     <td>
    
         <asp:DropDownList ID="ddlsubserie" runat="server"  Width="317px" TabIndex="5">
         </asp:DropDownList>
    
    </td>
    </tr>
    </table>
    <table align="center">
     
    <tr>
    <td>
        <asp:Label ID="Label10" runat="server" Text="DEPENDENCIA " 
            style="font-family: Arial"></asp:Label>
    </td>
       
    <td>
     <asp:DropDownList ID="ddlEnte" runat="server" Height="16px" Width="338px" 
            TabIndex="6">
         </asp:DropDownList>   
    </td>
   </tr>
     <tr>
         
    <td>
        <asp:Label ID="Label9" runat="server" Text="NOMBRE DEL PROPIETARIO" 
            style="font-family: Arial"></asp:Label>
    </td>

    <td class="style11">
        <asp:TextBox ID="txtNombreContratista" runat="server"  Width="337px" 
            TabIndex="7" ></asp:TextBox>
    </td>
    </tr>

   
    </table>
  
   
    <br />
   
    <table align="center" class="style12">
    <tr>
    <td class="style6">
        <asp:Button ID="btcrear" runat="server" Height="27px" Text="CREAR" 
            Width="89px" onclick="btcrear_Click" TabIndex="8" 
            UseSubmitBehavior="False" />
    </td>
    <td class="style6">
        <asp:Button ID="bteditar" runat="server" Height="27px" Text="EDITAR" 
            Width="89px" onclick="bteditar_Click" UseSubmitBehavior="False" />
    </td>
    <td class="style6">
        &nbsp;</td>
    
     <td class="style13">
        <asp:Button ID="btimprimir" runat="server" Height="27px" Text="IMPRIMIR"   
             Width="89px" onclick="btimprimir_Click" TabIndex="9" 
             UseSubmitBehavior="False"/>
    </td>
    <td class="style13">
        <asp:Button ID="Button1" runat="server" Text="SALIR" Width="89px" Height="27px"
            onclick="Button1_Click" UseSubmitBehavior="False" TabIndex="10" />
    </td>
    <td class="style13">
        <asp:Button ID="Button2" runat="server" Text="LIMPIAR" Width="89px" 
            Height="27px" onclick="Button2_Click" UseSubmitBehavior="False" 
            TabIndex="11" />
    </td>
    
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td>
    <td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td><td>
    </td>
     <td class="style6">
        <asp:Button ID="bteliminar" runat="server" Height="27px" Text="ELIMINAR" OnClientClick="return confirm('Esta Seguro de Eliminar Este Registro?');"
            Width="89px" onclick="bteliminar_Click" UseSubmitBehavior="False" 
             TabIndex="2000" />
    </td>
    </tr>
    </table>
    </div>
    <div>
    <table  align="center">
    <tr>
    <td class="style15">
        <asp:Button ID="Button4" runat="server" Text="Descargar Tipologia Seleccionada" 
            Width="291px" onclick="Button4_Click" UseSubmitBehavior="False" 
            TabIndex="12" />   
    </tr>
    </table>
    
    <hr style="height: -12px" />
    </div>
    <div align="center">
       
    <br />
    <br />
        <asp:GridView ID="gvhojadevida" runat="server" style="font-family: Arial" 
            AutoGenerateColumns="False" Width="970px" 
            onselectedindexchanged="gvhojadevida_SelectedIndexChanged" 
            onselectedindexchanging="gvhojadevida_SelectedIndexChanging" TabIndex="13">
            <Columns>
                <asp:TemplateField HeaderText="FECHA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfecha" runat="server"  Width="150px" Text='<%# Eval("fecha")%>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtfecha" ErrorMessage="FOMATO DE FECHA NO VALIDO" 
                            
                            
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$" 
                            Font-Size="XX-Small" ForeColor="Red"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TIPO DOCUMENTAL">
                    <ItemTemplate>
                        <asp:DropDownList ID="txttipodocumental"  Width="670px" 
                            runat="server" SelectedValue='<%# Eval("idtipologia") %>' 
                            DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                            DataValueField="id" Height="35px" >
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                            SelectMethod="obtenertipohisto" 
                            TypeName="gestion_documental.DataAccessLayer.tipodocumentoconsul">
                        </asp:ObjectDataSource>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
               <asp:TemplateField HeaderText="NÚMERO">
                    <ItemTemplate>
                        <asp:TextBox ID="txtNumero" runat="server" Width="170px" 
                            Height="35px" Text='<%# Eval("numero")%>' 
                            ></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FOLIO(S)">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfolios" runat="server" Width="170px" 
                            Height="35px" Text='<%# Eval("folios")%>' 
                            ontextchanged="txtfolioshojadevida_TextChanged"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VOLUMEN">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcarpeta" runat="server" Width="70px" Height="35px" Text='<%# Eval("carpeta")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="UBICAR" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    <br />
        <asp:CheckBox ID="ckaddfilahoja" runat="server" style="font-family: Arial" 
            Text="ADDFILA" AutoPostBack="True" 
            oncheckedchanged="ckaddfilahoja_CheckedChanged" />
    </div>
    <hr />
   
    
    </form>
</body>
</html>

