<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FerreteriaTorres.Web._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body id="Fondo">
    <form id="form1" runat="server">
        <div>
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style4" colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="4">
                        <img alt="" class="auto-style2" src="Imagenes/Logo.png" /></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        <asp:Timer ID="Timer1" runat="server" Interval="5500" OnTick="Timer1_Tick">
                        </asp:Timer>
                    </td>
                    <td colspan="2" style="width: 15%">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                    </td>
                    <td style="width: 40%">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" class="auto-style5"><strong>Realizado Por:</strong></td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style5"><strong>Diego Fernando Alvarez Varela</strong></td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style5"><strong>Jhoan Sebastian Castillo Usuriaga</strong></td>
                </tr>
            </table>
        </div>
    </form>
</body>
   <style>
       #Fondo
       {
           background-color:#000000;
       }
       .auto-style1 {
           width: 100%;
       }
       .auto-style2 {
           width: 599px;
           height: 410px;
       }
       .auto-style3 {
           text-align: center;
       }
       .auto-style4 {
           color: #FFFFFF;
           font-size: x-large;
           font-family: "COMIC Sans MS";
           text-align: center;
       }
       .auto-style5 {
           color: #FFFFFF;
       }
   </style>

</html>
