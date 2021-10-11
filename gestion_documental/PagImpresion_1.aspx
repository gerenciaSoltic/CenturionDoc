<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagImpresion_1.aspx.cs" Inherits="gestion_documental.PagImpresion_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>        .style1
        {
            
            width: 263px;
            height: 129px;
        }
         .lbl
        {
            border-top-style: groove;
          
            font-size:12px;
            font-weight:bold;
            font-family:Arial;
                      
        }
        #table{ font-size: x-small; background-image: url('Images2/formRad4ss.png'); background-repeat: no-repeat;}
        
        .tabladiv{
		border:1px solid black;
        padding: 0px 0px;
        padding-left:50px;
		width:250px;
		 /* compatibilidad con mozilla  */
        }



        .style2
        {
            height: 1162px;
        }
        .style3
        {
            width: 971px;
        }
        .style4
        {
            height: 1162px;
            width: 971px;
        }



    </style>
    <link rel="stylesheet" type="text/css" href="Styles/print.css" media="print"/>
    <script language="javascript" type="text/javascript" >
        function imprime() {
            window.print();
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
    <asp:HiddenField ID="hiddIdworkFlow" runat="server" />
    <asp:HiddenField ID="hiddFormato" runat="server" />
    <div>
        <div id="navigation">
            
            <input id="Button1" type="button" value="Imprimir" onclick="javascript:imprime()" />
            <input id="Button2" type="button" value="Cerrar" onclick="javascript:cerrar()" onclick="return Button2_onclick()" />
            </div>
        <div style="border-style: none; width:1000px; height:1200px; border-color:#FFFFFF; ">
        
       
            <table style="width:100%; height: 1200px; margin-top: 0px;">
                <tr>
                    <td >
                        

                        <div runat="server" id='tabladiv_1' class="tabladiv"  style="position: relative; z-index: inherit; top: -100px">

                            <asp:Image ID="Image1" runat="server" Height="6%" ImageAlign="Middle" 
                                ImageUrl="~/Images/Escudo Alcaldia Municipal.png" Width="10%" />
                                <asp:Label ID="lblALCALDIA1" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="ALCALDIA DE LEBRIJA" Width="153px"></asp:Label>

                        <table runat="server" class="style1" id='table' style="padding: 0px; margin: 0px; border-width: 0px; border-style: none; border-spacing: 0px;"
                           >
			   
				
		

                            <tr>
                                <td style="font-size: 12px; font-weight: bolder;" >
                                    Radicado</td>
                                <td >
                                    <asp:Label ID="lblRadicado_1" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="Ent123455645" Width="153px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Fecha -Hora:</td>
                                <td>
                                 <asp:Label ID="lblFecha_1" runat="server"  CssClass="lbl" 
                                        Text="07/03/2013" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Remite:</td>
                                <td>
                                 <asp:Label ID="lblRemite_1" runat="server"  CssClass="lbl" 
                                        Text="HERRAMIENTAS" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Destinatario:</td>
                                <td>
                                 <asp:Label ID="lblDestinatario_1" runat="server"  CssClass="lbl" 
                                        Text="101-OFICINA JURIDICA" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Anexos:</td>
                                <td>
                                 <asp:Label ID="lblAnexos_1" runat="server"  CssClass="lbl" 
                                        Text="3" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px">
                                    Folios:</td>
                                <td>
                                 <asp:Label ID="lblFolios_1" runat="server"  CssClass="lbl" 
                                        Text="5" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            
                        </table>
                        </div>


                    </td>
                    <td class="style3">
                        
                        
                         
                         
                    </td>
                    <td>
                        <div runat="server" id='tabladiv_2' class="tabladiv" 
                            style="position: relative; z-index: auto; top: -100px;">


                         <asp:Image ID="Image2" runat="server" Height="6%" ImageAlign="Middle" 
                                ImageUrl="~/Images/Escudo Alcaldia Municipal.png" Width="10%" />
                                <asp:Label ID="Label1" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="ALCALDIA DE LEBRIJA" Width="153px"></asp:Label>

                        <table runat="server" class="style1" id='table5' style="padding: 0px; margin: 0px; border-width: 0px; border-style: none; border-spacing: 0px;"
                        >
			  
			
                            <tr>
                                <td style="font-size: 11px; font-weight: bolder;" >
                                    Radicado</td>
                                <td >
                                    <asp:Label ID="lblRadicado_2" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="Ent123455645" Width="153px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Fecha -Hora:</td>
                                <td>
                                 <asp:Label ID="lblFecha_2" runat="server"  CssClass="lbl" 
                                        Text="07/03/2013" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Remite:</td>
                                <td>
                                 <asp:Label ID="lblRemite_2" runat="server"  CssClass="lbl" 
                                        Text="HERRAMIENTAS" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 11px" >
                                    Destinatario:</td>
                                <td>
                                 <asp:Label ID="lblDestinatario_2" runat="server"  CssClass="lbl" 
                                        Text="101-OFICINA JURIDICA" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Anexos:</td>
                                <td>
                                 <asp:Label ID="lblAnexos_2" runat="server"  CssClass="lbl" 
                                        Text="3" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px">
                                    Folios:</td>
                                <td>
                                 <asp:Label ID="lblFolios_2" runat="server"  CssClass="lbl" 
                                        Text="5" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            
                        </table>
                        </div>
                    </td>
                </tr>
                
                <tr>
                    <td>
                       <div runat="server" id='tabladiv_3' class="tabladiv" style="position: relative; z-index: auto; top: 350px">

                         <asp:Image ID="Image3" runat="server" Height="6%" ImageAlign="Middle" 
                                ImageUrl="~/Images/Escudo Alcaldia Municipal.png" Width="10%" />
                                <asp:Label ID="Label2" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="ALCALDIA DE LEBRIJA" Width="153px"></asp:Label>

                        <table runat="server" class="style1" id='table2' style="padding: 0px; margin: 0px; border-width: 0px; border-style: none; border-spacing: 0px;">
                           

                            <tr>
                                <td style="font-size: 12px; font-weight: bolder;" >
                                    Radicado</td>
                                <td >
                                    <asp:Label ID="lblRadicado_3" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="Ent123455645" Width="153px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Fecha -Hora:</td>
                                <td>
                                 <asp:Label ID="lblFecha_3" runat="server"  CssClass="lbl" 
                                        Text="07/03/2013" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Remite:</td>
                                <td>
                                 <asp:Label ID="lblRemite_3" runat="server"  CssClass="lbl" 
                                        Text="HERRAMIENTAS" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Destinatario:</td>
                                <td>
                                 <asp:Label ID="lblDestinatario_3" runat="server"  CssClass="lbl" 
                                        Text="101-OFICINA JURIDICA" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Anexos:</td>
                                <td>
                                 <asp:Label ID="lblAnexos_3" runat="server"  CssClass="lbl" 
                                        Text="3" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px">
                                    Folios:</td>
                                <td>
                                 <asp:Label ID="lblFolios_3" runat="server"  CssClass="lbl" 
                                        Text="5" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            
                        </table>
                        </div>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        <div runat="server" id='tabladiv_4' class="tabladiv" style="position: relative; z-index: auto; top: 350px">

                             <asp:Image ID="Image4" runat="server" Height="6%" ImageAlign="Middle" 
                                ImageUrl="~/Images/Escudo Alcaldia Municipal.png" Width="10%" />
                                <asp:Label ID="Label3" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="ALCALDIA DE LEBRIJA" Width="153px"></asp:Label>

                        <table runat="server" class="style1" id='table3' style="padding: 0px; margin: 0px; border-width: 0px; border-style: none; border-spacing: 0px;"
                           >
                            

                            <tr>
                                <td style="font-size: 12px; font-weight: bolder;" >
                                    Radicado</td>
                                <td >
                                    <asp:Label ID="lblRadicado_4" runat="server" BorderStyle="None"  CssClass="lbl" 
                                        Text="Ent123455645" Width="153px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Fecha -Hora:</td>
                                <td>
                                 <asp:Label ID="lblFecha_4" runat="server"  CssClass="lbl" 
                                        Text="07/03/2013" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Remite:</td>
                                <td>
                                 <asp:Label ID="lblRemite_4" runat="server"  CssClass="lbl" 
                                        Text="HERRAMIENTAS" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Destinatario:</td>
                                <td>
                                 <asp:Label ID="lblDestinatario_4" runat="server"  CssClass="lbl" 
                                        Text="101-OFICINA JURIDICA" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px" >
                                    Anexos:</td>
                                <td>
                                 <asp:Label ID="lblAnexos_4" runat="server"  CssClass="lbl" 
                                        Text="3" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px">
                                    Folios:</td>
                                <td>
                                 <asp:Label ID="lblFolios_4" runat="server"  CssClass="lbl" 
                                        Text="5" Width="153px"></asp:Label>
                                    </td>
                            </tr>
                            
                        </table>
                        </div>
                    </td>
                </tr>
            </table>
           
        </div>
       
     
    </div>
    </form>
</body>
</html>
