<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmEquipos.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web15" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" class="auto-style4">
        <tr>
            <td class="auto-style5"><strong>Equipos</strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style9"><strong>IdEquipo:</strong></td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtIdEquipo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Descripción:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11"><strong>Tipo De Equipo:</strong></td>
                        <td class="auto-style12">
                            <asp:DropDownList ID="rblTipoEquipo" runat="server" Width="222px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Activo:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:CheckBox ID="chkActivo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Valor Unitario:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtVrUnitario" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Valor Prestamo:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtVrPrestamo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Impuesto:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtImpuesto" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Cantidad En Existencia:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtCantExistencia" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Marca:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:DropDownList ID="rblMarca" runat="server" Width="228px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9"><strong>Caracteristicas:</strong></td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtCaracteristicas" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Creado Por:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtCreadoPor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Fecha De Creado:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtFechaCreado" runat="server"></asp:TextBox>
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
                        <StaticMenuItemStyle HorizontalPadding="60px" />
                    </asp:Menu>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:GridView ID="GridView1" runat="server" Font-Bold="True" Width="100%">
                    <HeaderStyle ForeColor="Red" />
                    <RowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style15"></td>
        </tr>
        <tr>
            <td>
                <img alt="" class="auto-style13" src="Imagenes/Loguito.JPG" /></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            width: 98%;
        }
        .auto-style5 {
            text-align: center;
            font-family: "comic Sans MS";
            font-size: x-large;
            color: #CC0000;
        }
        .auto-style6 {
            width: 100%;
            border: 3px solid #000000;
        }
        .auto-style7 {
            text-align: right;
        }
        .auto-style8 {
            text-align: left;
        }
        .auto-style9 {
            text-align: right;
            width: 40%;
            height: 31px;
        }
        .auto-style10 {
            text-align: left;
            width: 40%;
            height: 31px;
        }
        .auto-style11 {
            text-align: right;
            width: 40%;
            height: 34px;
        }
        .auto-style12 {
            text-align: left;
            width: 40%;
            height: 34px;
        }
        .auto-style13 {
            width: 151px;
            height: 60px;
            float: right;
        }
        .auto-style14 {
            height: 161px;
        }
        .auto-style15 {
            height: 26px;
        }
    </style>
</asp:Content>

