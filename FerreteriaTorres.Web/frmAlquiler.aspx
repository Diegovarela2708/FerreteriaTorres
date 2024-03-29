﻿<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmAlquiler.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web11" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    &nbsp;<table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style20"><strong>Alquiler</strong></td>
        </tr>
        <tr>
            <td class="auto-style19"></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style8" style="width: 50%"><strong>
                            <asp:Label ID="lblIdAlquiler" runat="server" Text="IdAlquiler:"></asp:Label>
                        </strong></td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtIdAlquiler" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 50%"><strong>Número De Documento:</strong></td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtNroDocumento" runat="server" MaxLength="15"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="btnBuscarCliente" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Imagenes/Buscar.png" Height="29px" OnClick="btnBuscarCliente_Click" Width="28px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 50%"><strong>Nombre cliente:</strong></td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 50%"><strong>Fecha:</strong></td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtFCreado" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 50%"><strong aria-orientation="horizontal">Dirección Cliente:</strong></td>
                        <td style="width: 50%">
                            <asp:DropDownList ID="ddlDirecciones" runat="server" Width="213px">
                        </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:GridView ID="grvHistoria" runat="server" Width="100%" Font-Bold="True" ForeColor="Red" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" EmptyDataText="&lt;h2&gt;No tiene historial de alquiler&lt;/h2&gt;">
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style13"><strong>IdEquipo:</strong></td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtIdEquipo" runat="server" MaxLength="20"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="btnBuscarIdEquipo" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnBuscarIdEquipo_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Descripción:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Existencia:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtExistencia" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Valor unítario:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtVrUnitario" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Cantidad alquilada:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtCantidadAlquilada" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13"><strong>Porcentaje&nbsp; descuento:</strong></td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtPorcentajeDescuento" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Fecha&nbsp; entrega:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13"><strong>Fecha&nbsp; devolución:</strong></td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtFechaDevolucion" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style17">
                <asp:Panel ID="pnlOpciones" runat="server">
                    <asp:Menu ID="mnuOpciones" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Orientation="Horizontal" RenderingMode="Table" Width="100%" OnMenuItemClick="mnuOpciones_MenuItemClick">
                        <Items>
                            <asp:MenuItem Text="Agregar" Value="opcAgregar"></asp:MenuItem>
                            <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                            <asp:MenuItem Text="Cancelar" Value="opcCancelar"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="Black" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" Width="50%" />
                        <StaticMenuItemStyle Font-Bold="True" ForeColor="Red" HorizontalPadding="150px" />
                    </asp:Menu>

                </asp:Panel>
            </td>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grvDatos" runat="server" Width="100%" Font-Bold="True" ForeColor="Red" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" AutoGenerateColumns="False" EmptyDataText="&lt;h2&gt; No se ha agregado detalle&lt;/h2&gt;">
                        <Columns>
                            <asp:BoundField DataField="strIdEquipo" HeaderText="Id Equipo " />
                            <asp:BoundField DataField="strDescripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="intCantidad" DataFormatString="{0:N2}" HeaderText="Cantidad">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fltVrUnit" DataFormatString="{0:C2}" HeaderText="Vr Unitario">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fltPorcentajeDes" HeaderText="Descuento % " DataFormatString="{0:P2}" />
                            <asp:BoundField DataField="intImpuesto" HeaderText="Iva %" DataFormatString="{0:P2}" />
                            <asp:BoundField DataField="fltVrDescuento" DataFormatString="{0:C2}" HeaderText="Vr Descuento " />
                            <asp:BoundField DataField="fltVrIva" DataFormatString="{0:C2}" HeaderText="Vr Iva " />
                            <asp:BoundField DataField="FechaEntrega" DataFormatString="{0:y-MM-dd HH:mm}" HeaderText="Fecha Entrega " />
                            <asp:BoundField DataField="FechaDevolucion" DataFormatString="{0:y-MM-d HH:mm}" HeaderText="Fecha Devolución " />
                            <asp:BoundField DataField="fltVrBruto" DataFormatString="{0:C2}" HeaderText="Vr Bruto ">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fltVrNeto" DataFormatString="{0:C2}" HeaderText="Vr Neto ">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                    
                </td>
            </tr>
            <tr>
                <td>
                                &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                                <h2><strong>Totales:&nbsp; </strong></h2>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                                <asp:Label ID="Label1" runat="server" Text="Total Bruto:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblfltTotalBruto" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style8">
                                <asp:Label ID="Label2" runat="server" Text="Total Iva:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblfltTotalIva" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style8">
                                <asp:Label ID="Label3" runat="server" Text="Total Descuentos:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblfltTotaDescuento" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style8">
                                <asp:Label ID="Label4" runat="server" Text="Total Neto:">            </asp:Label>
                                <asp:Label ID="lblfltTotalNeto" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <strong>
                        <asp:Label ID="lblMsj" runat="server"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <img alt="" class="auto-style18" src="Imagenes/Loguito.JPG" /></td>
            </tr>
        </tr>
    </table>



</asp:Content>


<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
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
            height: 44px;
        }

        .auto-style8 {
            text-align: right;
        }

        .auto-style9 {
            height: 26px;
        }

        .auto-style12 {
            text-align: left;
        }

        .auto-style13 {
            text-align: right;
            width: 40%;
            height: 34px;
        }

        .auto-style14 {
            text-align: left;
            width: 40%;
            height: 34px;
        }

        .auto-style17 {
            height: 33px;
        }

        .auto-style18 {
            width: 150px;
            height: 60px;
            float: right;
        }

        .auto-style19 {
            height: 31px;
            text-align: center;
        }

        .auto-style20 {
            height: 31px;
            text-align: center;
            color: #CC0000;
            font-size: xx-large;
        }
        </style>
</asp:Content>



