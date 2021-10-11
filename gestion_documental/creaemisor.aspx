<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creaemisor.aspx.cs" Inherits="gestion_documental.creaemisor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <br />
            
                <br />
                <h1>
                    Emisores / Receptores</h1>
                <br />
                <div style="overflow: hidden;">
                    
                    <div style="width: 100%; float: right;">
                        <table style="margin: 0 auto;">
                                    
                            <tr>
                                <td>
                                    Nit<asp:RequiredFieldValidator ID="rfvtxtNit" runat ="server" SetFocusOnError="true" ControlToValidate ="txtNit" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNit" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Descripcion<asp:RequiredFieldValidator ID="rvftxtDescripcion" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDescripcion" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDescripcion" Width="423px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    DireccionFisica<asp:RequiredFieldValidator ID="rvftxtDireccionFisica" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDireccionFisica" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDireccionFisica" Width="424px" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Pais<asp:RequiredFieldValidator ID="rfvddlPais" runat ="server" SetFocusOnError="true" ControlToValidate="ddlPais" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPais" runat="server" CssClass="dropdown" Width="242px"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Departamento<asp:RequiredFieldValidator ID="rvfddlDepartamento" runat ="server" SetFocusOnError="true" ControlToValidate="ddlDepartamento" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="dropdown" 
                                        Width="245px" AutoPostBack="True" 
                                        onselectedindexchanged="ddlDepartamento_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Municipio<asp:RequiredFieldValidator ID="fvrddlMunicipio" runat ="server" SetFocusOnError="true" ControlToValidate="ddlMunicipio" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="dropdown" 
                                        Height="16px" Width="238px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Email<asp:RequiredFieldValidator ID="rvftxtEmail" runat ="server" SetFocusOnError="true" ControlToValidate ="txtEmail" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmail" Height="24px" Width="438px" />
                                </td>
                            </tr>

                            

                            
                            <tr>
                                <td>
                                    Telefono<asp:RequiredFieldValidator ID="rvftxtTelefono" runat ="server" SetFocusOnError="true" ControlToValidate ="txtTelefono" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTelefono" Width="247px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Codigo Usuario:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="dropdown" 
                                        Height="16px" Width="300px"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Tipo Emisor<asp:RequiredFieldValidator ID="rvfddlTipoEmisor" runat ="server" SetFocusOnError="true" ControlToValidate="ddlTipoEmisor" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue="0"></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoEmisor" runat="server" CssClass="dropdown" 
                                        Width="300px"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    ConfiCor:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlConfiCor" runat="server" CssClass="dropdown" 
                                        Width="300px"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    Oficina productora:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEnte" runat="server" CssClass="dropdown" Width="300px"></asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    Cargo:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCargo" runat="server" CssClass="dropdown" 
                                        Height="19px" Width="300px"></asp:DropDownList>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Radicado:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRadicado" runat="server" CssClass="dropdown" 
                                        Height="26px" Width="300px"></asp:DropDownList>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                            
                                </td>
                                <td align="center">
                                    <asp:Button runat="server" ID="btnAddEmiRecep" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="EmiRecep"
                                        OnClick="btnAddEmiRecep_Click" />
                                    <asp:Button ID="btnClearEmiRecep" runat="server" CssClass="cancelButton" Text="Limpiar"
                                        OnClick="btnClearEmiRecep_Click" />
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    <div class="Log" style="width: 100%; float: left;">
                    </div>

                    
                </div>
     
    </div>
    </form>
</body>
</html>
