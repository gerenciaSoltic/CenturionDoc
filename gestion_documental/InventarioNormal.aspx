<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventarioNormal.aspx.cs" Inherits="gestion_documental.InventarioNormal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 409px;
            height: 101px;
        }
        .style2
        {
            height: 101px;
        }
        .style3
        {
            width: 227px;
        }
        .style4
        {
            width: 85px;
        }
        .style5
        {
            width: 144px;
        }
        .style6
        {
            width: 171px;
        }
        .style7
        {
            width: 209px;
        }
        .style8
        {
            width: 522px;
        }
        .style9
        {
            width: 58px;
        }
        .style13
        {
            height: 23px;
        }
        .style14
        {
            width: 261px;
            height: 23px;
        }
        .style17
        {
            height: 23px;
            width: 111px;
        }
        .style18
        {
            width: 227px;
            height: 42px;
        }
        .style20
        {
            width: 302px;
        }
        .style21
        {
            width: 302px;
            height: 42px;
        }
        .style22
        {
            height: 25px;
        }
        .style23
        {
            width: 302px;
            height: 25px;
        }
        .style24
        {
            width: 90px;
        }
        #Button2
        {
            width: 68px;
        }
        .style25
        {
            width: 72px;
        }
        .style27
        {
            width: 118px;
        }
        .style28
        {
            width: 95px;
        }
        .style29
        {
            width: 4px;
        }
        .style31
        {
            width: 143px;
        }
        .style32
        {
            width: 81px;
        }
    </style>
     <script language="javascript" type="text/javascript" >
         function imprime() {
             printDiv();
         }
         function printDiv() {
             //Get the HTML of div
             var divElements = document.getElementById("Print").innerHTML;
             //Get the HTML of whole page
             var oldPage = document.body.innerHTML;

             //Reset the page's HTML with div's HTML only
             document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

             //Print Page
             window.print();

             //Restore orignal HTML
             document.body.innerHTML = oldPage;


         }
         function cerrar() {
             window.close();
         }
         function Button2_onclick() {

         }
       


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="navigation">
            <table align="center">
            <tr>
            <td class="style24">
              <input id="Button1" type="button" value="Imprimir" onclick="javascript:imprime()" />
            </td>
             <td  class="style24">
             <asp:Button ID="Button4" runat="server" Text="Salir" Width="68px" 
                     onclick="Button4_Click" />
            </td>
             <td class="style24">
             <asp:Button ID="btnuevo" runat="server" Text="Nuevo" onclick="btnuevo_Click" 
                     Width="68px" />
            </td>
             <td class="style24">
              <asp:Button ID="btgrabar" runat="server" Text="Crear" 
                onclick="btgrabar_Click" Width="68px" />
            </td>
            <td class="style24">
                <asp:Button ID="btbuscar" runat="server" Text="Buscar" Width="68px" 
                    onclick="btbuscar_Click" />
            </td>
             <td class="style24">
                 <asp:Button ID="bteditar" runat="server" Text="Editar" onclick="bteditar_Click" 
                     Width="68px" OnClientClick="return confirm('Esta Seguro de Editar Este Inventario?');"/>
             </td>
             <td class="style24">
                 <asp:Button ID="bteliminar" runat="server" Text="Eliminar" 
                     onclick="bteliminar_Click" OnClientClick="return confirm('Esta Seguro de Eliminar Este Inventario?');" />
             </td>
              <td class="style24">
                  <asp:Button ID="btentidadproductora" runat="server" Text="Entidad Productora" 
                      onclick="btentidadproductora_Click" />
              </td>
               <td class="style24">
                   <asp:Button ID="btunidadadministrativa" runat="server" 
                       Text="Unidad Administrativa" onclick="btunidadadministrativa_Click" />
               </td>
                <td class="style24">

                    <asp:Button ID="btoficinaproductora" runat="server" Text="Oficina Productora" 
                        onclick="btoficinaproductora_Click" />
                </td>
 
                <td>
                    <asp:Button ID="btimprimisticker" runat="server" Text="Sticker Caja" Width="130px" 
                        onclick="btimprimisticker_Click" />
                
                    <asp:Button ID="btimprimirstickercarpeta" runat="server" Text="Sticker Carpeta" 
                        onclick="btimprimirstickercarpeta_Click" />
                    <asp:Button ID="Button3" runat="server" Width="130px"  Text="Sticker Interior" 
                        onclick="Button3_Click" />
                </td>
            </tr>
            <tr>
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
            <td align="center">
            <asp:CheckBox ID="cktodo" runat="server" 
                        oncheckedchanged="cktodo_CheckedChanged" Text="Todo" />
            </td>
            </tr>
            </table>
          
             </div>
   <br />
   <div id="Div1" style="width:1575; height:1060px; border-color:Black; border-width:1px; border: 2px groove threedface;">
         <br />
         <div id="Print" style="width:1575; height:1060px;">

    <table align="center">
    <tr>
    <td class="style2">
        <asp:Image ID="imagenempresa" runat="server" src="../images/Logo-ISSO.png" 
            style="height: 96px; width: 170px" />
    </td>
    <td class="style1" align="center">
        <asp:Label ID="lbnombreempresa" runat="server" 
            Text=" " Font-Bold="True" 
            Font-Italic="False" Font-Names="Aparajita" Font-Overline="False" 
            Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
    </td>
    <td class="style2">
        <asp:Image ID="imagenempresa0" runat="server" src="../images/escudo.jpg" 
            style="height: 96px; width: 170px" />
    </td>
    </tr>
    </table>
    <br />
    <table align="center">
    <tr>
    <td class="style8" style="border: medium double #333333">
    <table>
    <td class="style22">
        <asp:Label ID="Label15" runat="server" Text="PROYECTO"></asp:Label>
    </td>
       
     <td class="style23">
     
         <asp:DropDownList ID="DDLproyecto" runat="server" Height="19px" Width="301px" 
             AutoPostBack="True" onselectedindexchanged="DDLproyecto_SelectedIndexChanged">
         </asp:DropDownList>
     
    </td>
    <tr >
    <td class="style3">
        <asp:Label ID="Label1" runat="server" Text="ENTIDAD PRODUCTORA: "></asp:Label>
    </td>
     <td class="style20">
         <asp:DropDownList ID="DDLentidadproductora" runat="server" Height="19px" 
             Width="299px" AutoPostBack="True" 
             onselectedindexchanged="DDLentidadproductora_SelectedIndexChanged">
         </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td class="style18">
        <asp:Label ID="Label2" runat="server" Text="UNIDAD ADMINISTRATIVA: "></asp:Label>
    </td>
     <td class="style21">
         <asp:DropDownList ID="DDlunidadadministrativa" runat="server" Height="17px" 
             Width="298px" AutoPostBack="True" 
             onselectedindexchanged="DDlunidadadministrativa_SelectedIndexChanged">
         </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td class="style3">
        <asp:Label ID="Label3" runat="server" Text="OFICINA PRODUCTORA: "></asp:Label>
    </td>
     <td class="style20">
         <asp:DropDownList ID="DDLoficinaproductora" runat="server" Width="295px" 
             AutoPostBack="True" 
             onselectedindexchanged="DDLoficinaproductora_SelectedIndexChanged">
         </asp:DropDownList>
    </td>
    </tr>
    </table>
    <table>
    <tr>
    <td class="style4">
        <asp:Label ID="Label4" runat="server" Text="OBJETO: "></asp:Label>
    </td>
    <td class="style5">
        <asp:CheckBox ID="ckgestion" runat="server" Text="GESTION" TextAlign="Left" 
            AutoPostBack="True" oncheckedchanged="ckgestion_CheckedChanged" />
    </td>
    <td class="style6">
        <asp:CheckBox ID="cktransferencia" runat="server" Text="TRANSFERENCIA" 
            TextAlign="Left" AutoPostBack="True" 
            oncheckedchanged="cktransferencia_CheckedChanged" />
    </td>
    <td>
        <asp:CheckBox ID="ckeliminacion" runat="server" Text="ELIMINACION" 
            TextAlign="Left" AutoPostBack="True" 
            oncheckedchanged="ckeliminacion_CheckedChanged" />
    </td>
    </tr>
    </table>
    </td>
    <td class="style9">
    </td>
    <td style="border: medium double #333333">
    <div align="center">
     <asp:Label ID="Label5" runat="server" Text="REGISTRO DE ENTRADA"></asp:Label>
    </div>
    <table>
    <tr>
    <td align="center">
        <asp:Label ID="Label7" runat="server" Text="AÑO"></asp:Label>
    </td>
    <td align="center">
        <asp:Label ID="Label8" runat="server" Text="MES"></asp:Label>
    </td>
    <td align="center">
        <asp:Label ID="Label9" runat="server" Text="DIA"></asp:Label>
    </td>
    <td class="style7" align="center">
        <asp:Label ID="Label10" runat="server" Text="NT"></asp:Label>
    </td>
    </tr>
    <tr>
     <td>
         <asp:TextBox ID="txtano" runat="server" Width="47px"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox ID="txtmes" runat="server" Width="47px"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox ID="txtdia" runat="server" Width="47px"></asp:TextBox>
    </td>
    <td class="style7">
        <asp:TextBox ID="txtnt" runat="server"  Width="209px"></asp:TextBox>
    </td>
    </tr>
    </table>
    <div align="center">
        <asp:Label ID="Label6" runat="server" Text="NT: NUMERO DE TRANSFERENCIA"></asp:Label>
    </div>
    </td>
    </tr>
    </table>
    <div align="center">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label18" runat="server" Text="Observación"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtcedula1" runat="server"></asp:TextBox>
    </td>
    <td>
        &nbsp;</td>
    <td class="style31">
        &nbsp;</td>
         <td>
        <asp:Label ID="Label19" runat="server" Text="Fecha"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtfechabuscar1" runat="server"></asp:TextBox>
    </td>
    
    <td class="style29">
        &nbsp;</td>
    <td class="style32">
    
        &nbsp;</td>
    <td>
        <asp:Label ID="Label20" runat="server" Text="Desde la Caja"></asp:Label>
    </td>
    
    <td>
        <asp:TextBox ID="txtcaja1" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:Label ID="Label21" runat="server" Text="Hasta la Caja"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtcaja2" runat="server"></asp:TextBox>
    </td>
    </tr>
    </table>
      <div align="center">
          <asp:Label ID="Label22" runat="server" Text="Cantidad de registros"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="lbcantidad" runat="server" Text="0"></asp:Label>
    </div>
    </div>
    <br />
    <div align="center">
        <asp:GridView ID="GVPRINCIPAL" runat="server" AutoGenerateColumns="False" 
            Width="89%" Height="19px" 
            onselectedindexchanged="GVPRINCIPAL_SelectedIndexChanged" OnRowDataBound="GVPRINCIPAL_RowDataBound"
            OnRowDeleting="GVPRINCIPAL_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="CAJA">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckcaja" runat="server" AutoPostBack="True" 
                            oncheckedchanged="ckcaja_CheckedChanged" />
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ADD ROW">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckfila" runat="server" AutoPostBack="True" oncheckedchanged="ckfila_CheckedChanged" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COPI ROW">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckcopiarfila" runat="server" 
                            oncheckedchanged="ckcopiarfila_CheckedChanged" AutoPostBack="True" />
                    </ItemTemplate>
                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Caja">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcaja" runat="server" Width="50px" Text='<%# Eval("caja")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="N° Orden">
                    <ItemTemplate>
                        <asp:TextBox ID="txtnumeroorden" runat="server"  Width="50px" Text='<%# Eval("numeroorden")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcodigo" runat="server"  Width="50px" Text='<%# Eval("codigo")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre Serie">
                    <ItemTemplate >
                        <asp:TextBox ID="txtnombreserie" runat="server"  Width="230px" Text='<%# Eval("nombreserie")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Inicio">
                    <ItemTemplate>
                        <asp:TextBox ID="txtfechainicio" runat="server"  Width="50px" Text='<%# Eval("fechainicio")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Final">
                 <ItemTemplate>
                        <asp:TextBox ID="txtfechafinal" runat="server"  Width="50px" Text='<%# Eval("fechafinal")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Unidad Caja">
                 <ItemTemplate>
                        <asp:TextBox ID="txtunidadcaja" runat="server"  Width="50px" Text='<%# Eval("unidadcaja")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unidad Carpeta">
                 <ItemTemplate>
                        <asp:TextBox ID="txtunidadcarpeta" runat="server"  Width="50px" Text='<%# Eval("unidadcarpeta")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unidad Tom">
                 <ItemTemplate>
                        <asp:TextBox ID="txtunidadtom" runat="server"  Width="50px" Text='<%# Eval("unidadtom")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unidad Otros">
                 <ItemTemplate>
                        <asp:TextBox ID="txtunidadotros" runat="server"  Width="50px" Text='<%# Eval("unidadotros")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="N° Folios">
                 <ItemTemplate>
                        <asp:TextBox ID="txtnumerofolios" runat="server"  Width="50px" 
                            Text='<%# Eval("numerofolios")%>'   ontextchanged="txtnumerofolios_TextChanged"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Soporte">
                 <ItemTemplate>
                        <asp:TextBox ID="txtsoporte" runat="server"  Width="50px" Text='<%# Eval("soporte")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Volumen">
                 <ItemTemplate>
                        <asp:TextBox ID="txtvolumen" runat="server"  Width="60px" Text='<%# Eval("volumen")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observacion">
                 <ItemTemplate>
                        <asp:TextBox ID="txtobservacion" runat="server"  Width="300px" Text='<%# Eval("observacion")%>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText=".">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcolor" runat="server" Text='<%# Eval("color")%>' 
                             Width="10px" Enabled="False"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cksticker" runat="server" 
                            oncheckedchanged="cksticker_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:TextBox ID="txtid" runat="server" Width="10px" Text='<%# Eval("id")%>' 
                            Enabled="False"  ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle Height="20px" />
         
        </asp:GridView>
    </div>
    <br />
    <br />
    <table align="center" style="width: 1413px">
    <tr>
    <td class="style14" align="center" 
            style="border-top-color: #000000; border-top-width: medium; border-top-style: double">
        <asp:Label ID="Label11" runat="server" Text="Elaboró"></asp:Label>
    </td>
    <td class="style17">
    </td>
    <td align="center"class="style14" style="border-top-color: #000000; border-top-width: medium; border-top-style: double">
        <asp:Label ID="Label12" runat="server" Text="Responsable Archivo Oficina"></asp:Label>
    </td>
    <td class="style13">
    </td>
    <td class="style14"  align="center" style="border-top-color: #000000; border-top-width: medium; border-top-style: double">
        <asp:Label ID="Label13" runat="server" Text="Responsable Archivo Central"></asp:Label>
    </td>
    <td class="style13">
    </td>
    <td class="style14" align="center" style="border-top-color: #000000; border-top-width: medium; border-top-style: double">
        <asp:Label ID="Label14" runat="server" Text="Fecha"></asp:Label>
    </td>
    </tr>
    </table>
    <br />
    <div align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                    <ContentTemplate>
                        <asp:FileUpload runat="server" ID="fuImagem"   />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsubir" />
                    </Triggers>
                </asp:UpdatePanel>
                <table>
                <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="hojas"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txthojaini" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txthojafin" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>

                <br />
        <asp:Button ID="btnsubir" runat="server" Text="Subir Archivo" 
                    onclick="btnsubir_Click" />
            </div>
    <div>
      
      
        <br />
       
        <div align ="center">
           <asp:Panel ID="Panel2" runat="server" 
                style=" display:none;  background:white; width:80%; height:60%" 
                BorderColor="Blue" BorderStyle="Double" 
                >
     <br />
       
        <table align="center">
        <tr>
        <td class="style25">
            <asp:Label ID="lbnombrepanel" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtnombrepanel" runat="server" Width="212px"></asp:TextBox>
        </td>
        <td>
        </td>
        <td class="style28">
            <asp:Label ID="lbpabrepanel" runat="server" Text="Proyecto"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DDLpanel" runat="server" Width="250px" Height="23px" >
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        </tr>
        </table>
        <br />
        <table align="center">
        <tr>
        <td class="style27">
            <asp:Button ID="btncrear" runat="server" Text="Crear" Width="100px" 
                onclick="btncrear_Click" />
        </td>
         <td class="style27">
             <asp:Button ID="btnbuscar" runat="server" Text="Buscar" Width="100px" 
                 onclick="btnbuscar_Click" />
        </td>
         <td class="style27">
             <asp:Button ID="btneliminar" runat="server" Text="Eliminar" Width="100px" 
                 onclick="btneliminar_Click" />
        </td>
         <td class="style27">
             <asp:Button ID="btneditar" runat="server" Text="Editar" Width="100px" 
                 onclick="btneditar_Click" />
        </td>
         <td class="style27">
             <asp:Button ID="btcerrar" runat="server" Text="Cerrar" Width="100px" 
                 onclick="btcerrar_Click" />
        </td>
        </tr>
        </table>
       <br />
           <asp:GridView ID="gvpanel" runat="server" CellPadding="4" ForeColor="#333333" 
               GridLines="None" onselectedindexchanged="gvpanel_SelectedIndexChanged" 
                OnPageIndexChanging="gvpanel_PageIndexChanging"
                Height="16px" AllowPaging="True" Width="922px" DataKeyNames="id,nombre,padre" 
                   AllowSorting="True">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <asp:CommandField ShowSelectButton="True" />
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
           <asp:Label ID="Label16" runat="server" Text="."></asp:Label>
           <asp:ModalPopupExtender ID="Label9_ModalPopupExtender" runat="server" 
               DynamicServicePath="" Enabled="True" PopupControlID="Panel2" 
               TargetControlID="Label9">
           </asp:ModalPopupExtender>
       </asp:Panel>

        </div>
     
    </div>
    </div>
    </div>
   
    </form>
</body>
</html>