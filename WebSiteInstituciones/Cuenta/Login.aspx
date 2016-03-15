<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Cuenta_Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Responsive Bootstrap Advance Admin Template</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

</head>
<body style="background-color: #E2E2E2;">
    <form id="form1" runat="server">
    <div class="container">
        <div class="row text-center " style="padding-top:100px;">
            <div class="col-md-12">
                <img src="../assets/img/logo-invoice.png" />
            </div>
        </div>
         <div class="row ">
               
                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                           
                            <div class="panel-body">
                                <form role="form">
                                    <hr />
                                    <h5>Entrar al Sistema de Instituciones</h5>
                                       <br />
                                     <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>
                                            <asp:TextBox ID="userName" runat="server" class="form-control" placeholder="Usuario "></asp:TextBox>
                                            <%--<input type="text" class="form-control" placeholder="Your Username " />--%>
                                        </div>
                                                                              <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                            <asp:TextBox ID="password" type="password" runat="server" class="form-control" placeholder="Password "></asp:TextBox>
                                            <%--<input type="password" class="form-control"  placeholder="Your Password" />--%>
                                        </div>
                                    <%--<div class="form-group">
                                            <label class="checkbox-inline">
                                                <input type="checkbox" /> Remember me
                                            </label>
                                            <span class="pull-right">
                                                   <a href="index.html" >Forget password ? </a> 
                                            </span>
                                        </div>--%>
                                     
                                     <%--<a href="index.html" class="btn btn-primary ">Login Now</a>--%>
                                    <asp:Button ID="loginBtn" class="btn btn-primary " runat="server" Text="Ingresar" OnClick="loginBtn_Click" />
                                    <hr />
                                    <%--Not register ? <a href="index.html" >click here </a> or go to <a href="index.html">Home</a> --%>
                                    </form>
                            </div>
                           
                        </div>
                
                
        </div>
    </div>
        </form>
</body>
</html>
