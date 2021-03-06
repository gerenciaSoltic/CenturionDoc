<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="informe.aspx.cs" Inherits="gestion_documental.informe" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
 
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1397px">
        <LocalReport ReportPath="Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
       
    </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetWorkflowByfecha" 
            TypeName="gestion_documental.DataAccessLayer.WorkFlowManagement">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="Fdesde" Type="String"></asp:Parameter>
                <asp:Parameter DefaultValue="" Name="Fhasta" Type="String"></asp:Parameter>
                <asp:Parameter DefaultValue="" Name="lnTipo" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
