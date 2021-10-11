<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfiguraPag1.aspx.cs" Inherits="gestion_documental.ConfiguraPag1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            height: 127px;
            width: 45%;
        }
        .style3
        {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server"> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
<h3>
                        Selección Formato para Impresión</h3>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server" GroupingText="Formatos Disponibles">
<table class="style1" style="text-align:center">
            <tr>
                <td colspan="2">
                   
                </td>
            </tr>
            <tr>
                <td>
                    <img alt="" class="style2" src="Images2/PrevIzqSup.png" width="40%" /><asp:RadioButton 
                        ID="rbtn1" runat="server" GroupName="formato" />
                </td>
                <td>
                    <img alt="" class="style2" src="Images2/PrevDerSup.PNG" width="40%" /><asp:RadioButton 
                        ID="rbtn2" runat="server" GroupName="formato" />
                </td>
                <td>
                 <img alt="" class="style2" src="Images2/label.PNG" />
                    <asp:RadioButton 
                        ID="rbtn5" runat="server" GroupName="formato" />
                
                </td>
            </tr>
            <tr>
                <td>
                    <img alt="" class="style2" src="Images2/PrevIzqInf.png" width="40%" /><asp:RadioButton 
                        ID="rbtn3" runat="server" GroupName="formato" />
                </td>
                <td>
                    <img alt="" class="style2" src="Images2/PrevDerInf.png" width="40%" /><asp:RadioButton 
                        ID="rbtn4" runat="server" GroupName="formato" />
                </td>
            </tr>
           
        </table>
       <div align="center" style="height: 28px">
                <br />
                <br />
                    <asp:Button ID="btnAceptar" runat="server" onclick="clic_aceptar" 
                            Text="Aceptar" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Salir" 
                        onclick="cancelar" />

                   
       </div>
         
    
    

    <asp:HiddenField ID="hiddIdworkflow" runat="server" />
    </asp:Panel>
</asp:Content>
