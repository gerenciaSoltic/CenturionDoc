<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CorreoEntrante.aspx.cs" Inherits="gestion_documental.CorreoEntrante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/JavaScript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript">
        raisePostBack = function (clientID) {
            debugger;
            __doPostBack(clientID, "");
        }
    </script>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- TinyMCE -->
    <script type="text/javascript" src="../Scripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            skin: "o2k7",
            plugins: "autolink,lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,inlinepopups,autosave",

            // Theme options
            theme_advanced_buttons1: "newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example word content CSS (should be your site CSS) this one removes paragraph margins
            content_css: "css/word.css",

            // Drop lists for link/image/media/template dialogs
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js",

            // Replace values for the template plugin
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
    </script>
    <!-- /TinyMCE -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label runat="server" ID="title" Text="PlanSide" Style="width: 100%"/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="Msj" Style="width: 100%"> </asp:Label>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" width="100%" cellpadding="10"><tr><td>
    <asp:Panel ID="panelContenedor" runat="server" Width="100%" Height="100%" CssClass="" GroupingText="Correo Entrante">
        <asp:UpdatePanel ID="VerCorreoUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table width="100%" border="0" align="center">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="correosGridView" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" oninit="correosGridView_Init" 
                        onpageindexchanging="correosGridView_PageIndexChanging" 
                        onselectedindexchanged="correosGridView_SelectedIndexChanged" 
                        DataKeyNames="id,idemisor,fecha" 
                        onrowdatabound="correosGridView_RowDataBound" 
                        onrowdeleted="correosGridView_RowDeleted" 
                        onrowdeleting="correosGridView_DeleteEventHandler">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="descemisor" HeaderText="De" />
                            <asp:BoundField DataField="asunto" HeaderText="asunto" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                            <asp:CommandField ShowSelectButton="True" HeaderText="Ver" SelectText="Ver" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height:20px;"></td>
            </tr>
        </table>
        
        <table width="100%" border="0" style="margin:0px 15px 0px 15px;">
            <tr>
                <td colspan="2">
                    <textarea id="textoMensaje" runat="server" name="elm1" rows="15" cols="80" style="width:100%" readonly="true"></textarea>
                </td>

            </tr>
                <tr>
                    <td align="center" width="50%">
                    <table width="100px" style="width: 508px">
                        <tr>
            <td>
                <asp:Label ID="LblRadicado" runat="server" Text="Radicado:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtRadicado" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
    <td>

    <asp:Label ID="LblSerie" runat="server" Text="Serie:"></asp:Label>
    </td>

    <td>
        <asp:DropDownList ID="DdlSerie" runat="server" Width="328px" 
            AutoPostBack="True" DataTextField="SERIE" DataValueField="ID" Enabled="True" 
            onselectedindexchanged="DdlSerie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Llbl" runat="server" Text="SubSerie:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlSubserie" runat="server" Width="302px" 
            AutoPostBack="True" DataTextField="SUBSERIE" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlSubserie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="LblTipologia" runat="server" Text="Tipologia:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlTipologia" runat="server" Width="210px" 
            AutoPostBack="True" DataTextField="TIPOLOGIA" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlTipologia_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
      
    </tr>
    <tr>
    <td>
    <asp:Label ID="LblExpediente" runat="server" Text="Expediente:"></asp:Label>
    </td>
    <td>
    <asp:DropDownList ID="DdlExpediente" runat="server" Width="508px" Height="16px" 
            AutoPostBack="True" DataTextField="DESCRIPCION" DataValueField="ID" 
            Enabled="False" 
            onselectedindexchanged="DdlExpediente_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
        </table>
        <br />
        <div>
            <asp:GridView ID="gvindices" runat="server" AutoGenerateColumns="False" 
                Font-Size="Medium">
                <Columns>
                    <asp:BoundField DataField="atributo" HeaderText="Atributo" />
                    <asp:TemplateField HeaderText="Indice">
                        <ItemTemplate>
                            <asp:TextBox ID="txtatributo" runat="server" Text='<%# Eval("indice")%>' ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
                        <table width="100px">
                            <tr>
                                <td>
                                    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" 
                                        onclick="BtnRegistrar_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    
                    <td width="50%">
                        <asp:GridView ID="AdjuntosGridView" runat="server" AutoGenerateColumns="False" 
                            Border="0" CellPadding="3" CssClass="grid" GridLines="None" 
                            Height="100%" OnRowCommand="AdjuntosGridView_RowCommand" 
                            OnRowDataBound="AdjuntosGridView_RowDataBound" 
                            ShowHeaderWhenEmpty="True" Width="98%" DataKeyNames="archivo" 
                            onselectedindexchanged="AdjuntosGridView_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="archivo" HeaderText="Archivo" />
                            </Columns>
                            <RowStyle CssClass="gridRow" />
                            <HeaderStyle CssClass="HeaderGrid" ForeColor="WhiteSmoke" Height="35px" />
                        </asp:GridView>
                    </td>
                </tr>
           
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    </td></tr></table>
</asp:Content>
