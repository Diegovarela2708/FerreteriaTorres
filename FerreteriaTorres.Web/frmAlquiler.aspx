<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmAlquiler.aspx.cs" Inherits="FerreteriaTorres.Web.Formulario_web11" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">



    &nbsp;<table align="center" cellpadding="3" cellspacing="3" class="auto-style1">
       <tr>
            <td class="auto-style5"><strong>Alquiler</strong></td>
        </tr>
        <tr>
            <td class="auto-style20"></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <table align="center" cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style8" style="width: 25%"><strong>Numero De Documento:</strong></td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtNroDocumento" runat="server" MaxLength="15"></asp:TextBox>
                        &nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Imagenes/Buscar.jpg" />
                        </td>
                        <td class="auto-style8" style="width: 15%"><strong>Fecha:</strong></td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
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
                <asp:GridView ID="grvDatos" runat="server" Width="100%" Font-Bold="True" ForeColor="Red" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px">
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="3" cellspacing="3" class="auto-style6">
                    <tr>
                        <td class="auto-style11"><strong>Dirección Cliente:</strong></td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtDireCliente" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>IdAlquiler:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtIdAlquiler" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13"><strong>IdEquipo:</strong></td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtIdEquipo" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Descripción:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Cantidad:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Valor Unitario:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtValorUnitario" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Cantidad Alquilada:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtCantidadAlquilada" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13"><strong>Porcentaje De Descuento:</strong></td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtPorcentajeDescuento" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8" style="width: 40%"><strong>Fecha De Entrega:</strong></td>
                        <td class="auto-style12" style="width: 40%">
                            <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13"><strong>Fecha De Devolución:</strong></td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtFechaDevolucion" runat="server"></asp:TextBox>
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
                            <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                            <asp:MenuItem Text="Eliminar" Value="opcEliminar"></asp:MenuItem>
                            <asp:MenuItem Text="Consultar" Value="opcConsultar"></asp:MenuItem>
                            <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="Black" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" Width="50%" />
                        <StaticMenuItemStyle Font-Bold="True" ForeColor="Red" HorizontalPadding="60px" />
                    </asp:Menu>
                    
                </asp:Panel>
            </td>
            <tr>
            <td>&nbsp;</td>
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


<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
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
        .auto-style10 {
            width: 40%;
            height: 31px;
            text-align: left;
        }
        .auto-style11 {
            width: 40%;
            height: 31px;
            text-align: right;
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
    }
    </style>
</asp:Content>



