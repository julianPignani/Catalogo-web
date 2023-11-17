<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Catálogo de Artículos</h2>
        <p>Explora nuestra variedad completa de productos.</p>

        <div class="row row-cols-1 row-cols-md-3 g-4">
           
            <% foreach (dominio.Articulo articulo in ListaArticulos)
                { %>
            <div class="col">
                <div class="card h-100">
                    <img src="<%: articulo.ImagenUrl %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: articulo.Nombre %></h5>
                        <p class="card-text"><%: articulo.Descripcion %></p>
                        <a href="VerDetalle.aspx?id=<%: articulo.Id %>" class="btn btn-primary">Ver Detalle</a>
                    </div>
                </div>
            </div>

            <%  } %>
        </div>
    </div>
</asp:Content>
