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
                        <td class="auto-style7" style="width: 40%"><strong>Tipo De Equipo:</strong></td>
                        <td class="auto-style8" style="width: 40%">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="222px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="width: 40%"><strong></strong></td>
                        <td class="auto-style8" style="width: 40%">&nbsp;</td>
                    </tr>
                </table>
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
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
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
    </style>
</asp:Content>

