<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmClientes.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web12" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style4"><strong>Cliente</strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
                    <tr>
                        <td class="auto-style7"><strong>Tipo De Documento:</strong></td>
                        <td class="auto-style5">
                            <asp:DropDownList ID="ddlTipoDoc" runat="server" Width="205px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Numero De Documento:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtNroDoc" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Tipo De Cliente:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:DropDownList ID="ddlTipoCliente" runat="server" Width="207px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Dirección:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:GridView ID="grvDatos" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Red" Width="100%">
                    <RowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlOpciones" runat="server">
                    <asp:Menu ID="mnuOpciones" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" ForeColor="Red" Orientation="Horizontal" RenderingMode="Table" Width="100%">
                        <Items>
                            <asp:MenuItem Text="Agregar" Value="opcAgregar"></asp:MenuItem>
                            <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                            <asp:MenuItem Text="Eliminar" Value="opcEliminar"></asp:MenuItem>
                            <asp:MenuItem Text="Consultar" Value="opcConsultar"></asp:MenuItem>
                            <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                            <asp:MenuItem Text="Adiccionar Dirección" Value="opcAdiccDire"></asp:MenuItem>
                            <asp:MenuItem Text="Modificar Dirección" Value="opcModDire"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="Black" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" Width="50%" />
                        <StaticMenuItemStyle HorizontalPadding="20px" Font-Bold="True" />
                    </asp:Menu>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Departamento:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:DropDownList ID="ddlDepartamento" runat="server" Width="230px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Ciudad:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:DropDownList ID="ddlCiudad" runat="server" Width="229px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Correo Electronico:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtCorreoElec" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Fecha De Creado:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtFechaCreado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Creado Por:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtCreadoPor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Red" Width="100%">
                    <RowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style9">
               <asp:Label ID="lblMsj" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <img alt="" class="auto-style10" src="Imagenes/Loguito.JPG" /></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            color: #CC0000;
            font-family: "comic Sans MS";
            font-size: x-large;
            text-align: center;
        }
        .auto-style5 {
            width: 40%;
            height: 31px;
            text-align: left;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style7 {
            width: 40%;
            height: 31px;
            text-align: right;
        }
        .auto-style8 {
            text-align: left;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style10 {
            width: 150px;
            height: 61px;
            float: right;
        }
        .auto-style11 {
            height: 31px;
        }
    </style>
</asp:Content>

