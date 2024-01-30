<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Agrega el siguiente enlace para cargar Bootstrap desde un CDN -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-TX8e52RombbfZ6bI9YRNtUn6CGfnTdrnP6dGooxFPpqZGfcjbqGGtNr8dJBhZb1f" crossorigin="anonymous">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .detalle-btn {
            margin-left: 10px; /* Agrega un margen entre el corazón y el botón */
            margin-top: auto;
            margin-right: auto;
        }
    </style>

    <div class="container">
        <div class="container text-center mt-5 mb-3">
            <h1 class="display-4  text-primary m-3"><u>Explora Nuestro Catálogo de Artículos</u></h1>
        </div>
    </div>

    <div class="row justify-content-center mb-3" style="margin-left: 75px;">
        <div class="col-md-3">
            <asp:Label Text="Campo" ID="lblCampo" Style="color: black; font-weight: bold;" runat="server" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Nombre" />
                <asp:ListItem Text="Marca" />
                <asp:ListItem Text="Categoría" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:Label Text="Criterio" runat="server" Style="color: black; font-weight: bold;" ID="lblCriterio" />
            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:Label Text="Filtro" runat="server" ID="lblFiltro" Style="color: black; font-weight: bold;" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltrar" />
        </div>
        <div class="col-md-3" style="margin-top: 24px;">
            <asp:Button Text="Buscar" CssClass="btn btn-success mr-2 " ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
            <asp:Button Text="Actualizar" CssClass="btn btn-primary" ID="btnActualizar" OnClick="btnActualizar_Click" runat="server" />
        </div>

    </div>



    <%-- <% foreach (dominio.Articulo articulo in ListaArticulos)
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

            <%  } %> --%>
    <div class="row row-cols-1 row-cols-md-3 g-4 m-3 align-items-center">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 mb-3 d-flex flex-column">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top img-fluid" alt="..." style="height: 300px; object-fit: cover; object-position: center;">
                        <div class="card-body text-center">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text" style="color: red; font-weight: bold;"><%#Eval("Marca") %></p>
                            <p class="card-text"><%#Eval("Descripcion")  %></p>
                            <%--<a href="VerDetalle.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver Detalle</a>--%>  <%--otra forma de poder hacerlo--%>
                            <div class="d-flex justify-content-center">
                                <asp:Button Text="Ver detalle" CssClass="btn btn-primary" runat="server" ID="btnVerDetalle" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnVerDetalle_Click" />
                            </div>
                            <div class="d-flex justify-content-end">
                                <asp:Button runat="server" ID="btnFavorito" CssClass="btn btn-light ml-auto " Text="❤️" CommandArgument='<%#Eval("Id")%>' CommandName="FavoritoId" OnClick="btnFavorito_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <!-- Agrega el siguiente script para cargar jQuery y Bootstrap JS desde CDN -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-12Y9o1YYUnWy0XqBRsIkzD5f9AxNKUDqSWxW04jDIQU8e2F0Y8llv+KxUIdxWWea" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8sh+Wy61q39/cFDSjS10peP5gI0FkU1pbzm6V" crossorigin="anonymous"></script>

</asp:Content>
