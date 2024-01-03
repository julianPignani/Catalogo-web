<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="container text-center mt-5">
            <h1 class="display-4 font-bold text-primary m-3" ><u>Explora Nuestro Catálogo de Artículos</u></h1>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4 m-3">

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

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 d-flex flex-column">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top img-fluid w-100 object-fit-cover" alt="...">
                        <div class="card-body text-center   ">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")  %></p>
                            <%--<a href="VerDetalle.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver Detalle</a>--%>  <%--otra forma de poder hacerlo--%>
                            <asp:Button Text="Ver detalle" CssClass="btn btn-primary" runat="server" ID="btnVerDetalle" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnVerDetalle_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
