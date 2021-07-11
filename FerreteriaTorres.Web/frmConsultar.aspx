﻿<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmConsultar.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web110" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .nuevoEstilo1 {
            font-family: "comic Sans MS";
        }
        .auto-style5 {
            text-align: center;
            font-family: "comic Sans MS";
            font-size: x-large;
            color: #CC0000;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style7 {
            text-align: left;
        }
        .auto-style8 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style5"><strong>Consultar</strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>idAlquiler:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtIdAlquiler" runat="server"></asp:TextBox>
                        &nbsp;<asp:ImageButton ID="btnBuscarIdAlquiler" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Imagenes/Buscar.png" Height="24px" OnClick="btnBuscarIdAlquiler_Click" Width="25px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Fecha:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Número De Documento:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Nombre:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Dirección:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="width: 40%"><strong>Creado Por:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtCreadoPor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" colspan="2">
                            <asp:Button ID="btnConsultar" runat="server" Font-Bold="True" Text="Consultar" ForeColor="#CC0000" />
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>