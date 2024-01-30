<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Favorito.aspx.cs" Inherits="vista.Favorito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container text-center mt-5 mb-3">
            <h1 class="display-4  text-primary m-3"><u>Mis artículos favoritos</u></h1>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4 m-3 align-items-center">
        <asp:Repeater ID="repFavorito" runat="server" EnableViewState="true">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 mb-3 d-flex flex-column">
                        <img src="<%#Eval("ImagenUrl")%>" ID="imgArticulo" class="card-img-top img-fluid" alt="..." style="height: 300px; object-fit: cover; object-position: center;">
                        <div class="card-body text-center">
                            <h4 class="card-title"><%#Eval("Nombre")%></h4>
                            <p class="card-text" style="color: red; font-weight: bold;"><%#Eval("Marca") %></p>
                            <p class="card-text"><%#Eval("Descripcion")  %></p>
                            <div class="d-flex justify-content-center">
                                <asp:Button Text="Deshacer" CssClass="btn btn-danger" ID="btnDeshacer" OnClick="btnDeshacer_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
