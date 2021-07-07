<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmTipoDeEquipos.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web18" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">

    <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style5"><strong>Tipo De Equipo</strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style9" style="width: 40%"><strong>IdEquipo:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtEquipo" runat="server"></asp:TextBox>
                        &nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageAlign="AbsMiddle" ImageUrl="~/Imagenes/Imagenn.png" Width="33px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9" style="width: 40%"><strong>Descripción:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
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
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlOpciones" runat="server">
                    <asp:Menu ID="Menu1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Orientation="Horizontal" RenderingMode="Table" Width="100%">
                        <Items>
                            <asp:MenuItem Text="Agregar" Value="opcAgregar"></asp:MenuItem>
                            <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                            <asp:MenuItem Text="Eliminar" Value="opcEliminar"></asp:MenuItem>
                            <asp:MenuItem Text="Consultar" Value="opcConsultar"></asp:MenuItem>
                            <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="Black" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" Width="50%" />
                        <StaticMenuItemStyle HorizontalPadding="60px" Width="20px" />
                    </asp:Menu>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <strong>
                <asp:Label ID="lblMsj" runat="server"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td>
                <img alt="" class="auto-style11" src="Imagenes/Loguito.JPG" /></td>
        </tr>

    </table>

</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            text-align: center;
            font-size: x-large;
            color: #CC0000;
            font-family: "comic Sans MS";
        }
        .auto-style6 {
            width: 100%;
            border: 3px solid #000000;
        }
        .auto-style8 {
            text-align: left;
        }
        .auto-style9 {
            text-align: right;
        }
        .auto-style10 {
            height: 26px;
        }
        .auto-style11 {
            width: 151px;
            height: 61px;
            float: right;
        }
        .auto-style12 {
            text-align: center;
            height: 31px;
        }
    </style>
</asp:Content>
