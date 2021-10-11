<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muestraRadicado.aspx.cs" Inherits="gestion_documental.muestraRadicado" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1187px">
            <LocalReport ReportPath="RepRadicado.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetRadicado" 
            TypeName="gestion_documental.DataAccessLayer.RadicadosManagement">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetRadicado" 
            TypeName="gestion_documental.DataAccessLayer.RadicadosManagement">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
