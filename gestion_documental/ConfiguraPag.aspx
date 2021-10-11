<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfiguraPag.aspx.cs" Inherits="gestion_documental.ConfiguraPag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 225px;
            height: 291px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table class="style1">
            <tr>
                <td colspan="2">
                    <h3>
                        Selección Formato para Impresión</h3>
                </td>
            </tr>
            <tr>
                <td>
                    <img alt="" class="style2" src="Images2/PrevIzqSup.png" /><asp:RadioButton 
                        ID="rbtn1" runat="server" GroupName="formato" />
                </td>
                <td>
                    <img alt="" class="style2" src="Images2/PrevDerSup.PNG" /><asp:RadioButton 
                        ID="rbtn2" runat="server" GroupName="formato" />
                </td>
            </tr>
            <tr>
                <td>
                    <img alt="" class="style2" src="Images2/PrevIzqInf.png" /><asp:RadioButton 
                        ID="rbtn3" runat="server" GroupName="formato" />
                </td>
                <td>
                    <img alt="" class="style2" src="Images2/PrevDerInf.png" /><asp:RadioButton 
                        ID="rbtn4" runat="server" GroupName="formato" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <asp:Button ID="btnAceptar" runat="server" onclick="clic_aceptar" 
        Text="Aceptar" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </form>
</body>
</html>
