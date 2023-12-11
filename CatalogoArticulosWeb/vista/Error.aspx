<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="vista.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center flex-grow-1">
        <div class="text-center">
            <h1 class="display-1">¡Oops!</h1>
            <asp:Label Text="text" ID="lblMensaje" runat="server" CssClass="m-3"  Font-Bold />
            <br />
            <a href="Login.aspx" class="btn btn-primary m-3">Volver a la página de Login</a>
        </div>
    </div>
</asp:Content>
