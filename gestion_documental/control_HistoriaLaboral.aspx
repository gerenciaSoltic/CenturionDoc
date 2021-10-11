<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="control_HistoriaLaboral.aspx.cs" Inherits="gestion_documental.control_HistoriaLaboral" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .style5
        {
            height: 29px;
        }
        .style6
        {
            width: 140px;
        }
        .style8
        {
            width: 133px;
        }
        .style9
        {
            width: 63px;
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
            width: 533px;
        }
        .style13
        {
            width: 89px;
        }
        .style14
        {
            width: 155px;
        }
    </style>
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
        <asp:Image ID="imagen" runat="server" src="../images/escudosantander.jpg" style="height: 96px; width: 100px" />
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
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text=" HISTORIA LABORAL" 
            style="font-size: small; font-family: Arial; text-align: center;"></asp:Label>
    </td>
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
        <asp:Label ID="Label6" runat="server" Text="Versión:  0" 
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
    <td>
        <asp:Label ID="Label10" runat="server" Text="PRIMER NOMBRE: " 
            style="font-family: Arial"></asp:Label>
    </td>
    <td class="style11">
        <asp:TextBox ID="txtprimernombre" runat="server"  Width="153px" ></asp:TextBox>
    </td>
    <td>
        <asp:Label ID="Label18" runat="server" Text="SEGUNDO NOMBRE:" 
            style="font-family: Arial"></asp:Label>
    </td>
     <td>
    
         <asp:TextBox ID="txtsegundonombre" runat="server"  Width="153px"></asp:TextBox>
    
    </td>
    </tr>
      <tr>
    <td>
        <asp:Label ID="Label19" runat="server" Text="PRIMER APELLIDO: " 
            style="font-family: Arial"></asp:Label>
    </td>
    <td class="style11">
        <asp:TextBox ID="txtprimerapellido" runat="server"  Width="153px" ></asp:TextBox>
    </td>
    <td>
        <asp:Label ID="Label20" runat="server" Text="SEGUNDO APELLIDO:" 
            style="font-family: Arial"></asp:Label>
    </td>
     <td>
    
         <asp:TextBox ID="txtsegundoapellido" runat="server"  Width="153px"></asp:TextBox>
    
    </td>
    </tr>
      <tr>
    <td>
        <asp:Label ID="Label22" runat="server" Text="NUMERO DE DOCUMENTO: " 
            style="font-family: Arial"></asp:Label>
    </td>
    <td class="style11">
    
        <asp:TextBox ID="txtdocumento" runat="server"  Width="153px"></asp:TextBox>
    
    </td>
    <td>
        <asp:Label ID="Label23" runat="server" Text="CARPETA :" style="font-family: Arial"></asp:Label>
          </td>
     <td>
    
         <asp:TextBox ID="txtcarpeta" runat="server"></asp:TextBox>
          </td>
    </tr>
    </table>
    <table align="center">
     <tr>
    <td class="style5">
        <asp:Label ID="Label12" runat="server" Text="FUNCIONARIO: " 
            style="font-family: Arial"></asp:Label>
    </td>
     <td class="style5">
    
         <asp:TextBox ID="txtfuncionario" runat="server"  Width="467px"></asp:TextBox>
    
    </td>
    <td class="style14">
    </td>
    <td>
    
       
    
    </td>
    </tr>
    <tr>
    <td class="style5">
        <asp:Label ID="Label13" runat="server" Text="IDENTIDAD: " 
            style="font-family: Arial"></asp:Label>
    </td>
     <td class="style5">
    
         <asp:TextBox ID="txtidentidad" runat="server"  Width="469px"></asp:TextBox>
    
    </td>
    </tr>
    </table>
    <table align="center">
    <tr>
    <td class="style9">
    
        <asp:Label ID="SERI" runat="server" 
            style="font-size: medium; font-family: Arial" 
            Text="SERIE: "></asp:Label>
    
    </td>
     <td>
    
         <asp:DropDownList ID="ddlserie" runat="server"  Width="317px" 
             AutoPostBack="True" onselectedindexchanged="ddlserie_SelectedIndexChanged">
         </asp:DropDownList>
    
    </td>
    <td class="style8"></td>
    <td class="style10">
    
        <asp:Label ID="Label17" runat="server" 
            style="font-size: medium; font-family: Arial" 
            Text="SUBSERIE: "></asp:Label>
    
    </td>
     <td>
    
         <asp:DropDownList ID="ddlsubserie" runat="server"  Width="317px">
         </asp:DropDownList>
    
    </td>
    </tr>
    </table>
    <br />
    <div align="center">
        <asp:TextBox ID="txtbucar" runat="server" AutoPostBack="True" 
            ontextchanged="txtbucar_TextChanged" Visible="False"></asp:TextBox>
    </div>
    <table align="center" class="style12">
    <tr>
    <td class="style6">
        <asp:Button ID="btcrear" runat="server" Height="27px" Text="CREAR" 
            Width="89px" onclick="btcrear_Click" />
    </td>
    <td class="style6">
        <asp:Button ID="bteditar" runat="server" Height="27px" Text="EDITAR" 
            Width="89px" onclick="bteditar_Click" />
    </td>
    <td class="style6">
    <asp:Button ID="btbuscar" runat="server" Height="27px" Text="BUSCAR" 
            Width="89px" onclick="btbuscar_Click" />
       </td>
    <td class="style6">
        <asp:Button ID="bteliminar" runat="server" Height="27px" Text="ELIMINAR" OnClientClick="return confirm('Esta Seguro de Eliminar Este Registro?');"
            Width="89px" onclick="bteliminar_Click" Visible="False" />
    </td>
     <td class="style13">
        <asp:Button ID="btimprimir" runat="server" Height="27px" Text="IMPRIMIR"   
             Width="89px" onclick="btimprimir_Click"/>
    </td>
    <td class="style13">
        <asp:Button ID="Button1" runat="server" Text="SALIR" Width="89px" Height="27px"
            onclick="Button1_Click" />
    </td>
    <td class="style13">
        <asp:Button ID="Button2" runat="server" Text="LIMPIAR" Width="89px" 
            Height="27px" onclick="Button2_Click" />
    </td>

    </tr>
    </table>
    </div>
    <hr style="height: -12px" />
    
    <div align="center">
        <asp:Label ID="Label14" runat="server" Text="HISTORIA LABORAL" 
            style="font-family: Arial; font-weight: 700;"></asp:Label>
    <br />
    <br />
        <asp:GridView ID="gvhojadevida" runat="server" style="font-family: Arial" 
            AutoGenerateColumns="False" Width="970px">
            <Columns>
                <asp:TemplateField HeaderText="FECHA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfechahojadevida" runat="server"  Width="150px" Text='<%# Eval("fecha")%>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtfechahojadevida" ErrorMessage="FOMATO DE FECHA NO VALIDO" 
                            
                            
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$" 
                            Font-Size="XX-Small" ForeColor="Red"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TIPO DOCUMENTAL">
                    <ItemTemplate>
                        <asp:DropDownList ID="txttipodocumentalhojadevida"  Width="670px" 
                            runat="server" SelectedValue='<%# Eval("tipodocumental") %>' 
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
                <asp:TemplateField HeaderText="FOLIO(S)">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfolioshojadevida" runat="server" Width="170px" 
                            Height="35px" Text='<%# Eval("folios")%>' 
                            ontextchanged="txtfolioshojadevida_TextChanged"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CARPETA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcarpetahojadevida" runat="server" Width="70px" Height="35px" Text='<%# Eval("carpeta")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <br />
        <asp:CheckBox ID="ckaddfilahoja" runat="server" style="font-family: Arial" 
            Text="ADDFILA" AutoPostBack="True" 
            oncheckedchanged="ckaddfilahoja_CheckedChanged" />
    </div>
    <hr />
   
    <div align="center" id ="div2" runat"server">
      <asp:Label ID="Label15" runat="server" Text="ESCALAFON" 
            style="font-family: Arial; font-weight: 700;"></asp:Label>
    <br />
    <br />
        <asp:GridView ID="gvescalafon" runat="server" style="font-family: Arial" 
            AutoGenerateColumns="False" Width="970px">
            <Columns>
                <asp:TemplateField HeaderText="FECHA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfechascalafon" runat="server"  Width="170px" Text='<%# Eval("fecha")%>'></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtfechascalafon" ErrorMessage="FOMATO DE FECHA NO VALIDO" 
                            
                            
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$" 
                            Font-Size="XX-Small" ForeColor="Red"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TIPO DOCUMENTAL">
                    <ItemTemplate>
                        <asp:DropDownList ID="txttipodocumentalscalafon" Width="670px" Height="35px" runat="server" 
                            SelectedValue='<%# Eval("tipodocumental") %>' DataSourceID="ObjectDataSource1" 
                            DataTextField="nombre" DataValueField="id">
                           
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                            SelectMethod="obtenertipoesca" 
                            TypeName="gestion_documental.DataAccessLayer.tipodocumentoconsul">
                        </asp:ObjectDataSource>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FOLIO(S)">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfoliosscalafon" runat="server" Width="170px" Height="35px" 
                            Text='<%# Eval("folios")%>'
                            ontextchanged="txtfoliosscalafon_TextChanged"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CARPETA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcarpetascalafon" runat="server" Width="70px" Height="35px" Text='<%# Eval("carpeta")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <br />
        <asp:CheckBox ID="ckescalafon" runat="server" style="font-family: Arial" 
            Text="ADDFILA" AutoPostBack="True" 
            oncheckedchanged="ckescalafon_CheckedChanged" />
    </div>
    <hr />
    
    <div align="center">
     <asp:Label ID="Label16" runat="server" Text="PRESTACIONES SOCIALES" 
            style="font-family: Arial; font-weight: 700;"></asp:Label>
    <br />
    <br />
        <asp:GridView ID="gvprestacionessociales" runat="server" style="font-family: Arial" 
            AutoGenerateColumns="False" Width="970px">
            <Columns>
                <asp:TemplateField HeaderText="FECHA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfechaprestacionessociales" runat="server"  Width="170px" Text='<%# Eval("fecha")%>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="txtfechaprestacionessociales" ErrorMessage="FOMATO DE FECHA NO VALIDO" 
                            
                            
                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$" 
                            Font-Size="XX-Small" ForeColor="Red"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TIPO DOCUMENTAL">
                    <ItemTemplate>
                      <asp:DropDownList ID="txttipodocumentalprestacionessociales" Width="670px" 
                            runat="server" SelectedValue='<%# Eval("tipodocumental") %>' Height="35px"
                            DataSourceID="ObjectDataSource1" DataTextField="nombre" DataValueField="id">
                         
                       </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                            SelectMethod="obtenertipopres" 
                            TypeName="gestion_documental.DataAccessLayer.tipodocumentoconsul">
                        </asp:ObjectDataSource>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FOLIO(S)">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfoliosprestacionessociales" runat="server" Width="170px" 
                            Height="35px" Text='<%# Eval("folios")%>' 
                            ontextchanged="txtfoliosprestacionessociales_TextChanged"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CARPETA">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcarpetaprestacionessociales" runat="server" Width="70px" Height="35px" Text='<%# Eval("carpeta")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <br />
        <asp:CheckBox ID="ckpretacion" runat="server" Text="ADDFILA" 
            AutoPostBack="True" oncheckedchanged="ckpretacion_CheckedChanged" 
            style="font-family: Arial" />
    </div>
    </form>
</body>
</html>
