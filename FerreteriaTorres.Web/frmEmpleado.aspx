<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmEmpleado.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web14" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style4"><strong>Empleado</strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="3" cellspacing="3" class="auto-style1">
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Numero De Documento:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Tipo De Documento:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="205px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Nombres:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Apellidos:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Activo:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:CheckBox ID="chkActivo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Telefono:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Dirección:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Ciudad:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:DropDownList ID="ddlCiudad" runat="server" Width="213px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Departamento:</strong></td>
                        <td class="auto-style6" style="width: 40%">
                            <asp:DropDownList ID="ddlDepartamento" runat="server" Width="213px">
                            </asp:DropDownList>
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
                <asp:Panel ID="pnlOpciones" runat="server">
                    <asp:Menu ID="mnuOpciones" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" ForeColor="Red" Orientation="Horizontal" RenderingMode="Table" Width="100%">
                        <Items>
                            <asp:MenuItem Text="Agregar" Value="opcAgregar"></asp:MenuItem>
                            <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                            <asp:MenuItem Text="Eliminar" Value="opcEliminar"></asp:MenuItem>
                            <asp:MenuItem Text="Consultar" Value="opcConsultar"></asp:MenuItem>
                            <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                        </Items>
                        <StaticMenuItemStyle HorizontalPadding="60px" Font-Bold="True" />
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
                        <td class="auto-style5" style="width: 40%"><strong>Usuario:</strong></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Contraseña:</strong></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"><strong>Fecha De Creado:</strong></td>
                        <td class="auto-style8">
                            <asp:TextBox ID="txtFechaCreado" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Creado Por:</strong></td>
                        <td style="width: 40%">
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
                <asp:GridView ID="grvDatos" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Red" Width="100%">
                    <RowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
             <td class="auto-style9">
                <asp:Label ID="lblMsj" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <img alt="" class="auto-style10" src="Imagenes/Loguito.JPG" /></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
            font-family: "comic Sans MS";
            font-size: x-large;
            color: #CC0000;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            text-align: left;
        }
        .auto-style7 {
            text-align: right;
            width: 40%;
            height: 31px;
        }
        .auto-style8 {
            width: 40%;
            height: 31px;
        }
    .auto-style9 {
        text-align: center;
    }
        .auto-style10 {
            width: 150px;
            height: 61px;
            float: right;
        }
        </style>
</asp:Content>

