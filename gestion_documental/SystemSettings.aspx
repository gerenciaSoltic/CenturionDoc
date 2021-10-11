<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SystemSettings.aspx.cs" Inherits="gestion_documental.SystemSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="header">
                <asp:Panel ID="pnlButtons" runat="server">
                    <%--<asp:Button ID="btnback" runat="server" Text="Back to Settings" CssClass="Button"
                        OnClick="btnback_Click" />--%>
                </asp:Panel>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="300">
                <ProgressTemplate>
                    <div class="Progress">
                        <div style="position: absolute; top: 50%; left: 25%;">
                            <img alt="" src="Images/ajax-loader.gif" style="margin-left: 200px" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:TabContainer ID="tcSettings" runat="server" ActiveTabIndex="7" 
                Width="100%">
                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Series">
                    <ContentTemplate>
                        <br />
                        <h1>
                            Series</h1>
                        <br />
                        <div style="overflow: hidden;">
                            <div class="Log" style="width: 48%; float: left;">
                                <asp:GridView runat="server" ID="gvSerie" AutoGenerateColumns="False" EnableModelValidation="True"
                                    Width="100%" DataKeyNames="id" OnSelectedIndexChanged="gvSerie_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="Id" />
                                        <asp:BoundField DataField="SERIE" HeaderText="Serie" />
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="width: 48%; float: right;">
                                <table style="margin: 0 auto;">

                                    <tr>
                                        <td>
                                            Serie:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSerie" />
                                        </td>
                                    </tr>
                                   <tr><td></td>
                                        <td   align="left">
                                         <asp:RequiredFieldValidator ID="rfvSerie" runat ="server" SetFocusOnError="true" ControlToValidate ="txtSerie" CssClass="errorMessage" ErrorMessage="Please enter Serie !" ValidationGroup="Serie"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btnAddSerie" Text="Add" CssClass="submitButton" CausesValidation="true" ValidationGroup="Serie"
                                                OnClick="btnAddSerie_Click" />
                                            <asp:Button ID="btnModelClear" runat="server" CssClass="cancelButton" Text="Clear"
                                                OnClick="btnClearSerie_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="SubSerie">
                    <ContentTemplate>
                        <br />
                        <h1>
                            SubSeries</h1>
                        <br />
                        <div style="overflow: hidden;">
                            <div class="Log" style="width: 48%; float: left;">
                                <asp:GridView runat="server" ID="gvSubSerie" AutoGenerateColumns="False" EnableModelValidation="True"
                                    Width="100%" DataKeyNames="id" OnSelectedIndexChanged="gvSubSerie_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="Id" />
                                        <asp:BoundField DataField="IDSERIE" HeaderText="Serie" />
                                        <asp:TemplateField HeaderText="Serie" SortExpression="Serie">
                                            <asp:ItemTemplate>
                                                <asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "serie.ID")%>'/>
                                            </asp:ItemTemplate>
                                         </asp:TemplateField>
                                        <asp:BoundField DataField="SUBSERIE" HeaderText="SubSerie" />
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="width: 48%; float: right;">
                                <table style="margin: 0 auto;">
                                    
                                    <tr>
                                        <td>
                                            Serie<asp:RequiredFieldValidator ID="rfvddlSerie" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="SubSerie" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSerie" runat="server" CssClass="dropdown"></asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            SubSerie:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSubSerie" />
                                        </td>
                                    </tr>
                                   <tr><td></td>
                                        <td   align="left">
                                         <asp:RequiredFieldValidator ID="rfvddlSubSerie" runat ="server" SetFocusOnError="true" ControlToValidate ="txtSubSerie" CssClass="errorMessage" ErrorMessage="Please enter SubSerie !" ValidationGroup="SubSerie"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btnAddSubSerie" Text="Add" CssClass="submitButton" CausesValidation="true" ValidationGroup="SubSerie"
                                                OnClick="btnAddSubSerie_Click" />
                                            <asp:Button ID="btnClearSubSerie" runat="server" CssClass="cancelButton" Text="Clear"
                                                OnClick="btnClearSubSerie_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>

            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>