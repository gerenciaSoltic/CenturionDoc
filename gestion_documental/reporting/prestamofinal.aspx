<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prestamofinal.aspx.cs" Inherits="gestion_documental.reporting.prestamofinal" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="93%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="reporting\prestamo.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="obtenerprestamo" 
            TypeName="gestion_documental.DataAccessLayer.prestamoconsul">
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
