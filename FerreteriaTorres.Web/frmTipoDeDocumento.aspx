<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmTipoDeDocumento.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web19" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
               <tr>
            <td class="auto-style5"><strong>Tipo De Documento</strong></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong>Tipo De Cliente:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:DropDownList ID="ddlTipoCliente" runat="server" Width="190px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12"><strong>Descripción:</strong></td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12"><strong>Fecha De Creado</strong>:</td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtFechaCreado" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12"><strong>Creado Por</strong>:</td>
                        <td class="auto-style13">
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
                <asp:GridView ID="grvDatos" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Red" Width="100%" Font-Bold="True">
                    <RowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
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
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style11">
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
        .auto-style5 {
            font-size: x-large;
            font-family: "comic Sans MS";
            color: #CC0000;
            text-align: center;
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
            height: 26px;
        }
        .auto-style10 {
            width: 150px;
            height: 61px;
            float: right;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style12 {
            text-align: right;
            width: 40%;
            height: 34px;
        }
        .auto-style13 {
            text-align: left;
            width: 40%;
            height: 34px;
        }
    </style>
</asp:Content>


