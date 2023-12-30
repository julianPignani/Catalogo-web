<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="vista.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-5 d-flex justify-content-center align-items-center ">
        <%--<div class="row justify-content-center">--%>
            <div class="col-md-6 mt-auto d-flex flex-column">
                <div class="card">
                    <div class="card-header bg-success text-white">
                        <h3 class="text-center">Inicio de Sesión</h3>
                    </div>
                    <div class="card-body">
                        <div class="form-group m-3">
                            <label for="lblUser" class="form-label">Email</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" REQUIRED />
                        </div>
                        <div class="form-group m-3">
                            <label for="lblPass">Password:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password" REQUIRED/>
                        </div>
                        <div class="form-group m-3">
                            <asp:Button Text="Ingresar" ID="btnIngresar" Onclick="btnIngresar_Click" CssClass="btn btn-success btn-block" runat="server" />
                            <a href="Bienvenida.aspx" class="btn btn-danger">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
   
       
</asp:Content>
