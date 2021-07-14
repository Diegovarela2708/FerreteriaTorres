<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmConsultar.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web110" %>
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
                        <td class="auto-style6" style="width: 40%"><strong>Id alquiler:</strong></td>
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
                        <td class="auto-style6" style="width: 40%"><strong>Número documento:</strong></td>
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
                        <td class="auto-style6" style="width: 40%"><strong>Creado por:</strong></td>
                        <td class="auto-style7" style="width: 40%">
                            <asp:TextBox ID="txtCreadoPor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" colspan="2">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grvDatos" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Red" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="strIdEquipo" DataFormatString="{0:N2}" HeaderText="Id Equipo">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strDescripcion" HeaderText="Descripción">
                        <ItemStyle HorizontalAlign="Justify" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strCaracteristicas" HeaderText="Características">
                        <ItemStyle HorizontalAlign="Justify" />
                        </asp:BoundField>
                        <asp:BoundField DataField="intCantidad" DataFormatString="{0:N2}" HeaderText="Cantidad">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="fltVrUnit" DataField="fltVrUnit" DataFormatString="{0:C2}" HeaderText="Vr Unit">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fltPorcentajeDes" DataFormatString="{0:P2}" HeaderText="% Desct">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fltVrDescuento" DataFormatString="{0:C2}" HeaderText="Vr Desct">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fltVrIva" DataFormatString="{0:C2}" HeaderText="Vr Iva">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaEntrega" DataFormatString="{0:yyyy-mm-d}" HeaderText="F. Entrega" />
                        <asp:BoundField DataField="FechaDevolucion" DataFormatString="{0:yyyy-mm-d HH:MM}" HeaderText="F. Devolucion" />
                    </Columns>
                    <RowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
                <td class="auto-style8">
                                <h2 class="auto-style6"><strong>Totales:&nbsp; </strong></h2>
                </td>
            </tr>
        <tr>
                <td class="auto-style6">
                                <asp:Label ID="Label1" runat="server" Text="Total Bruto:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblfltTotalBruto" runat="server" Text=""></asp:Label></td>
            </tr>
        <tr>
                <td class="auto-style6">
                                <asp:Label ID="Label2" runat="server" Text="Total Iva:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblfltTotalIva" runat="server" Text=""></asp:Label></td>
            </tr>
        <tr>
                <td class="auto-style6">
                                <asp:Label ID="Label3" runat="server" Text="Total Descuentos:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblfltTotaDescuento" runat="server" Text=""></asp:Label></td>
            </tr>
        <tr>
                <td class="auto-style6">
                                <asp:Label ID="Label4" runat="server" Text="Total Neto:">            </asp:Label>
                                <asp:Label ID="lblfltTotalNeto" runat="server" Text=""></asp:Label></td>
            </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="lblMsj" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
