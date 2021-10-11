<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="True" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html  xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=IE8"/>
	<title>INICIO - Centurión Doc</title>
<!--Adobe Edge Runtime-->
    <script type="text/javascript" charset="utf-8" src="index_edgePreload.js"></script>
    <style>
        .edgeLoad-centurion { visibility:hidden; }
    </style>
<!--Adobe Edge Runtime End-->
    

</head>
<body style="margin:0;padding:0;height:100%;">
	<div id="Stage" class="centurion">
	    
        <div id="Stage_fondo" class="edgeLoad-centurion"></div>
        <div id="Stage_Group" class="edgeLoad-centurion">
            <div id="Stage_Rectangle" class="edgeLoad-centurion" align = "center">
                <br />

                <asp:Label ID="Label3" runat="server" Text="Acceso al Sistema" Style="font-family: Calibri" Font-Size="Medium" Font-Bold="True"></asp:Label>
            <br />
              
             <form runat="server" >
             <asp:HiddenField ID="TxtRadicado" runat="server">
    </asp:HiddenField>
            <table style="width: 100%; height: 100%; top: auto; right: auto; bottom: auto; left: auto">
            <tr>
            <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
            </td>
            <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
                <asp:Label ID="Label1" runat="server" Text="Usuario" Style="font-family: Calibri"></asp:Label>
            </td>
            <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
                <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
            </td>

            <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
            </td>
            </tr>
            <tr>
            <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
            </td>
            <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">

                <asp:Label ID="Label2" runat="server" Text="Contraseña" Style="font-family: Calibri"></asp:Label>
                </td>
                <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
                <asp:TextBox ID="TxtClave" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width: 25%; height: 25%; top: auto; right: auto; bottom: auto; left: auto">
                            </td>
            </tr>
            </table>
            <br />

                <asp:Button ID="Button1" runat="server" Text="Acceder" 
                    onclick="Button1_Click" />
            
            </form>
            
            </div>
            <div id="Stage_RectangleCopy" class="edgeLoad-centurion"></div>
            <div id="Stage_logo_doc" class="edgeLoad-centurion"></div>
        </div>
    </div>
</body>
</html>
