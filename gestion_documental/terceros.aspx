<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terceros.aspx.cs" Inherits="gestion_documental.terceros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script type="text/javascript">
      function ValidNum(e) {

          var tecla = document.all ? tecla = e.keyCode : tecla = e.which;

          return ((tecla > 47 && tecla < 58));
      }
    </script>

    <style type="text/css">
        .style1
        {
            width: 302px;
        }
        .style2
        {
            width: 91px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
 <asp:Label ID="Label1" runat="server" Text="TERCEROS"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
  <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Width="100%">
        <br />
        <br />
        <div style="width: 99%" align="center">
            <table align ="center" style="border: thin groove #000000">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Tipo Doc."></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLTipoDoc" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddldTipoDoc" runat ="server" SetFocusOnError="true" ControlToValidate ="DDLTipoDoc" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Terceros" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label2" runat="server" Text="Documento"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TxtNit" runat="server" ontextchanged="TxtNit_TextChanged" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtNit" runat ="server" SetFocusOnError="true"  ControlToValidate ="TxtNit" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Terceros" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revTxtNit" ControlToValidate="TxtNit" ErrorMessage="*numeros " ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Codigo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsucursal" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table align="center" >
                <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Primer Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Segundo Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Primer Apellido"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label13" runat="server" Text="Segundo Apellido"></asp:Label>
                    </td>
                
                </tr>
                <tr>
                
                
                    <td>
                        <asp:TextBox ID="TxtNombre1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNombre2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtApellido1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtApellido2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTxtNombre" runat ="server" SetFocusOnError="true" ControlToValidate ="TxtNombre1" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Terceros" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table align = "center" >
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Dirección"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDireccion" runat="server" Width="478px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTxtDireccion" runat ="server" SetFocusOnError="true" ControlToValidate ="TxtDireccion" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Terceros" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table align ="center">
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Teléfono"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txttelefono" runat="server" Width="216px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtMail" runat="server" Width="236px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*mail no valido" ControlToValidate="TxtMail" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <table align ="center" >
                <tr>
                    <td>
                        <asp:Label ID="lblDpto" runat="server" Text="Departamento"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="dropdown" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlDepartamento_SelectedIndexChanged" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvddlDepartamento" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlDepartamento" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Terceros" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblMunicipio" runat="server" Text="Municipio"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMunicipio" CssClass="dropdown" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvddlMunicipio" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlMunicipio" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Terceros" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table>
            <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Tipo de Cliente"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="ckprivado" runat="server" AutoPostBack="True" 
                    oncheckedchanged="ckprivado_CheckedChanged" Text="Privado" />
            </td>
             <td>
                 <asp:CheckBox ID="ckpublico" runat="server" AutoPostBack="True" 
                     oncheckedchanged="ckpublico_CheckedChanged" Text="Publico" />
            </td>
            </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%" align="center">
                <tr align="center">
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Añadir" onclick="Button1_Click" CausesValidation="true" ValidationGroup="Terceros"  />
                        <asp:Button ID="Button3" runat="server" Text="Buscar" onclick="Button3_Click" />
                        <asp:Button ID="Button5" runat="server" Text="Limpiar" 
        onclick="Button5_Click" />
                        <asp:Button ID="Button4" runat="server" Text="Salir" onclick="Button4_Click" 
        Width="63px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <hr />
        <div>
            <div style="width: 100%" align = "center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" 
        DataKeyNames="id,nit,nombre,direccion,telefono,email,nombre1,nombre2,apellido1,apellido2,sucursal" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridView1_SelectedIndexChanged"  OnRowDataBound="GridView1_RowDataBound"
        onrowdeleted="GridView1_RowDeleted"  OnRowDeleting="GridView1_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nit" HeaderText="Documento" />
                        <asp:BoundField DataField="verifica" HeaderText="VR" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="email" HeaderText="E-mail" />
                        <asp:BoundField DataField="nomdepto" HeaderText="Departamento" />
                        <asp:BoundField DataField="nommuni" HeaderText="Municipio" />
                        <asp:BoundField DataField="sector" HeaderText="TIPO" />
                        <asp:BoundField DataField="sucursal" HeaderText="Sucursal" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="Top" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
