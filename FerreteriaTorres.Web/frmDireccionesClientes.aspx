<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmDireccionesClientes.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web13" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" cellpadding="3" class="auto-style1">
        <tr>
            <td class="auto-style4"><strong>Dirección Cliente</strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>IdDirección:</strong></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtIdDire" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Numero De Documento:</strong></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtNroDoc" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Ciudad:</strong></td>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 40%"><strong>Dirección</strong></td>
                        <td style="width: 40%">
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
            <td>
                <asp:Panel ID="pnlOpciones" runat="server">
                    <asp:Menu ID="mnuOpciones" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" ForeColor="Red" Orientation="Horizontal" RenderingMode="Table" Width="100%">
                        <DynamicItemTemplate>
                            <%# Eval("Text") %>
                        </DynamicItemTemplate>
                        <Items>
                            <asp:MenuItem Text="Modificar Dirección" Value="opcModificarDire"></asp:MenuItem>
                            <asp:MenuItem Text="Modificar Ciudad" Value="opcModificarCiu"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="Black" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" Width="50%" />
                        <StaticMenuItemStyle HorizontalPadding="160px" />
                    </asp:Menu>
                </asp:Panel>
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
            <td class="auto-style6">
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
            font-size: x-large;
            font-family: "comic Sans MS";
            text-align: center;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            height: 30px;
            text-align: center;
        }
        .auto-style10 {
            width: 150px;
            height: 61px;
            float: right;
        }
        </style>
</asp:Content>

