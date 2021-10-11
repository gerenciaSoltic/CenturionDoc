<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unirpdfs.aspx.cs" Inherits="gestion_documental.unirpdfs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>UNIR DOCUMENTOS PDFS</title>
<script src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script src="jquery.MultiFile.js" type="text/javascript"></script>
</head>

<body>
<form id="form1" runat="server">
<div align ="center">
<table>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="UNIR DOCUMENTOS PDFS" 
        Font-Size="Larger"></asp:Label>
   
</td>
</tr>
</table>
 <asp:Label ID="Label2" runat="server" Text="Seleccione el documento"></asp:Label>
<asp:FileUpload ID="file_upload" class="multi" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload"
onclick="btnUpload_Click" />
<br />
<br />
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="documento" ForeColor="#333333" 
        GridLines="None" onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="documento" HeaderText="Documento" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
   <br />
 
    <asp:Button ID="Button2" runat="server" Text="Quitar" onclick="Button2_Click" />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Nombre del nuevo Documento"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Unir..." 
        onclick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Errores en el proceso.." Visible="False"></asp:Label>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
</div>
</form>
</body>
</html>