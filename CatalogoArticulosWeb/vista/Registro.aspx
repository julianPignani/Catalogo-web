<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="vista.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 d-flex justify-content-center align-items-center ">
        <%--<div class="row justify-content-center">--%>
        <div class="col-md-6 mt-auto d-flex flex-column">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h3 class="text-center">Regístrate</h3>
                </div>
                <div class="card-body">
                    <div class="form-group m-3">
                        <label for="lblUser" class="form-label">Email</label>
                        <div class="input-group">
                            <span class="input-group-text" id="inputGroupPrepend2">@</span>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                        </div>
                        <div class="form-group m-3">
                            <asp:Label runat="server" ID="lblError" ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group m-3">
                        <label for="lblPass">Password:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password" />
                    </div>
                    <div class="form-group m-3">
                        <asp:Button Text="Registrarse" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" CssClass="btn btn-primary btn-block" runat="server" />
                        <a href="Bienvenida.aspx">Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
