<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historiaslaborales.aspx.cs"
    Inherits="gestion_documental.historiaslaborales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function imprime() {
            /*
            document.getElementById("button1").style.visibility = 'hidden'
            document.getElementById("button2").style.visibility = 'hidden'
            document.getElementById("button3").style.visibility = 'hidden'
            */
            window.print();
            /*
            document.getElementById("button1").style.visibility = 'visible'
            document.getElementById("button2").style.visibility = 'visible'
            document.getElementById("button3").style.visibility = 'visible'
            */
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
    <div align="center">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" Height="10%" Width="10%" ImageAlign="Middle"
                        ImageUrl="~/Images/Escudo Alcaldia Municipal.png" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="DOCUMENTOS CARGADOS POR FECHA"
                        Font-Names="Tahoma" Font-Size="Larger"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table align="center">
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Desde la Fecha" Font-Bold="True" Font-Names="Tahoma"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaDesde" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFechaDesde" runat="server"
                        Format="yyyy-MM-dd" />
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Hasta la Fecha" Font-Bold="True" Font-Names="Tahoma"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtFechaHasta" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFechaHasta" runat="server"
                        Format="yyyy-MM-dd" />
                </td>
            </tr>
        </table>
        <hr />
        <table align="center">
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Consultar" OnClick="Button1_Click" />
                    <input id="Button3" type="button" value="Cerrar" onclick="javascript:cerrar()" />
                </td>
            </tr>
        </table>
        <hr />
        <div align="center" style="width: 100%">
        </div>
    </div>
    <hr />
    </form>
</body>
</html>
