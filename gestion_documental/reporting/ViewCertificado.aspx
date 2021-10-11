<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCertificado.aspx.cs" Inherits="gestion_documental.reporting.ViewCertificado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <style type="text/css">
        #Button2
        {
            width: 68px;
        }
        .style32
        {
            width: 257px;
            height: 71px;
        }
        .style33
        {
            width: 344px;
        }
        .style34
        {
            width: 371px;
        }
        .style36
        {
            width: 194px;
        }
        .style37
        {
            width: 526px;
        }
        .style38
        {
            width: 643px;
        }
        .style39
        {
            width: 196px;
        }
        .style40
        {
            height: 16px;
        }
        .style41
        {
            height: 16px;
            width: 120px;
        }
        .style42
        {
            width: 120px;
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
    <div>
     <input id="Button1" type="button" value="Imprimir" onclick="javascript:imprime()" />
        <asp:Button ID="Button2" runat="server" Text="Salir" onclick="Button2_Click" />
    </div>
     <div id="Div1" style="width:1575; height:1060px; border-color:Black; border-width:1px; border: 2px groove threedface;">
         <br />
         <div id="Print" style="width:1575; height:1060px; top: -20px;" align="center">
         <div align="center">
        <asp:Image ID="Image3" runat="server" Height="170px" 
                 ImageUrl="~/Images/titulosertificado.png" Width="685px" 
                 style="margin-top: 0px" />
       
            
         </div>
         
             <div style="background-image: url('../Images/marcadeagua.png'); background-repeat: no-repeat; background-position: center center">
             <div align="center">
             <div style="width: 609px; text-align: center" align="center">
                 <asp:Label ID="lbtitulo1" runat="server"
                     Text="LA COORDINADORA DEL GRUPO ADMINISTRACION DE DOCUMENTOS ADSCRITOS A LA  SECRETARIA DE LA GOBERNACION DE SANTANDER,  AUTORIZA MEDIANTE DECRETO DEPARTAMENTAL N°: 0447 DEL 29 DE DICIEMBRE DE 2004, PARA EXPEDIR CERTIFICADOS DE ESTUDIO" 
                     Font-Size="Small" Font-Names="Arial"></asp:Label>
             </div>
       
                 <asp:Label ID="Label2" runat="server" Text="CERTIFICA:" Font-Size="Small"></asp:Label>

                 <div style="width: 609px; text-align: justify">
                    <br />
                 <asp:Label ID="lbnombre" runat="server"
                     Text="Que FLORES CARREÑO ARMANDO Curso el grado CUARTO PRIMARIA en la JORNADA DIURNA durante el año 1987 en la INSTITUCION CONCENTRACION ESCOLAR ELOY VALENZUELA  del municipio de GIRON con el logro de los siguientes resultados: " 
                     Font-Size="Small"></asp:Label>
             </div>
             <br />
                 <asp:GridView ID="gvprincipal" runat="server" AutoGenerateColumns="False" 
                     onselectedindexchanged="gvprincipal_SelectedIndexChanged" Width="613px" 
                     Font-Size="Small">
                     <Columns>
                         <asp:BoundField DataField="asignatura" HeaderText="ASIGNATURAS">
                           <ItemStyle Width="70%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="calificacion" HeaderText="CALIFICACIONES" />
                     </Columns>
                 </asp:GridView>
                 
               
               <div style="width: 609px; text-align: justify">
              
                 <asp:Label ID="lblibro" runat="server"
                     Text="Copia tomada de las planillas de calificaciones remitidas por la Institución educativa y que reposan en el Grupo Administración de Documentos de la Gobernación de Santander, según libro 756 folio 0567." 
                     Font-Size="Small"></asp:Label>
                     <br />
                     <br />
                     <asp:Label ID="Label9" runat="server"
                     Text="Se anexa y anula recibo oficial de la Secretaria de Hacienda de la Gobernacion de Santander por concepto de Recaudo de estampillas por el valor de $7.810.00 distribuidas asi: $2.100.00 de Pro Hospital; $900.00 de Pro Desarrollo; $1.100.00 de Pro Electrificacion; $2.100.00 de Pro Cultura y $900.00 de Pro Anciano, $710.00 Ordenanza 012/05 y Decreto 005/06." 
                     Font-Size="Small"></asp:Label>
             </div>
             </div>
             <div align="center" >
           
                 <br />
                 <asp:Label ID="lbfecha" runat="server" 
                     Text="Expedido en Bucaramanga, el 09 de octubre de 2015." Font-Size="Small"></asp:Label>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <br />
               
                 &nbsp;&nbsp;&nbsp;
                 <asp:Label ID="Label11" runat="server" Text="Atentamente." Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
               
                 <table style="width: 587px">
                 <tr>
                 <td>
                  
                     <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/firma.png" 
                         Height="68px" />
                 </td>
                 <td class="style33">
                 
                 </td>
                 </tr>
                 </table>
                 <table>
                 <tr >
                 <td>
                 <asp:Label ID="Label12" runat="server" Text="MERCEDES MARTINEZ CORREO" 
                     Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 </td>
                 </tr>
                 <tr>
                 <td>
                  <asp:Label ID="Label13" runat="server" 
                     Text="Coordinadora Grupo Administracion de Documentos" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                 </td>
                 </tr>

                  <tr>
                 <td>
                 <asp:Label ID="lbproyecto" runat="server" 
                     Text="Proyectó: Maria Lourdes López Gasca - Profesional Universitario" 
                     Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 </td>
                 </tr>
                 </table>
                 
                 
                 
             </div>
           </div>
           
          <div align="center">
              <asp:Image ID="Image1" runat="server" Height="53px" Width="647px" 
                  ImageUrl="~/Images/piedepagina.png" />
          </div>
         </div>
      </div>
    </form>
</body>
</html>
