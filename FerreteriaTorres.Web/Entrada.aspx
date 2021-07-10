<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="FerreteriaTorres.Web.Entrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 60%;
        }
    </style>
</head>
<body id="Fondo">
    <form id="form1" runat="server">
        <!-- <div id="center"> -->
            <div id=" wrapper">
                <div style="width:0.1%"; height:100%; id="formcontent">
                    <table  align="center" class="auto-style1" id = "main">
                <tr>
                    <td class="auto-style3" style="text-align: left">
                        <strong>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="auto-style5" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario" BackColor="Black" Font-Bold="True" ForeColor="Red" Width="70%"></asp:TextBox>
                   
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="text-start"><strong>
                        <asp:Label ID="lblContraseña" runat="server" CssClass="auto-style5" Text="Contraseña:" ForeColor="Black"></asp:Label>
                        <div class="text-center">
                        <asp:TextBox ID="txtContraseña" CssClass="form-control" TextMode="Password" runat="server" placeholder="Contraseña" Width="70%" BackColor="Black" ForeColor="Red"></asp:TextBox>
                        </div>
                        </strong></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                    </td>
                    <br />
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnIngresar" CssClass="btn btn-primary btn-dark"  runat="server" Text="Iniciar Sesión" BackColor="Red" BorderColor="Red" Font-Bold="True" ForeColor="Black" OnClick="btnIngresar_Click" Width="30%" />
                    </td>
                </tr>
            </table>
                </div>
                
            </div>
            
      <!--  </div> -->
    </form>
</body>
    <style>
        #Fondo
        {
            background-image:url(Imagenes/imagen11.jpg);  
            
        }

       #main 
       { 
           position: center; left: 50%; width: 720px; margin-left: 450px; height: 300px; top: -270px 
       }



        .wrapper
        {
            display:  flex;
            align-items: center;
            flex-direction: column;
            justify-content: center;
            width: 100%;
            min-height: 100%;
            padding: 20px;
        }

        #formcontent 
        {
            -webkit-border-radius: 10px 10px 10px 10px;
            border-radius: 10px 10px 10px 10px;
            background: #ffffff;
            padding: 30px;
            width: 90%;
            max-width: 450px;
            position: page;
            padding: 0px;
            -webkit-box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
            box-shadow: 0 50px 60px 0 rgba(0,0,0,0.3);
            text-align: center;
            position:absolute; top: 35%; width: 98%; height: 1px; overflow: visible 
        }

        #btnIngresar
    


        .auto-style3 {
            text-align: left;
            height: 39px;
        }


        .auto-style5 {
            color: #000000;
            font-size: x-large;
        }


    </style>
</html>
