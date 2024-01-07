<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    
        <ContentTemplate>
            <div class="container">
                <div class="container text-center mt-5">
                    <h1 class="display-4  text-primary m-3"><u>Explora Nuestro Catálogo de Artículos</u></h1>
                </div>
            </div>

            <div class="row justify-content-center mb-3">
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
                <div class="col-md-1 align-self-end">
                    <asp:Button Text="Buscar" CssClass="btn btn-success" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    

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
    <div class="row row-cols-1 row-cols-md-4 g-4 m-3">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 d-flex flex-column">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt="...">
                        <div class="card-body text-center">
                            <h4 class="card-title"><%#Eval("Nombre")%></h4>
                            <p class="card-text" style="color: red; font-weight: bold;"><%#Eval("Marca") %></p>
                            <p class="card-text"><%#Eval("Descripcion")  %></p>
                            <%--<a href="VerDetalle.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver Detalle</a>--%>  <%--otra forma de poder hacerlo--%>
                            <asp:Button Text="Ver detalle" CssClass="btn btn-primary mt-auto" runat="server" ID="btnVerDetalle" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnVerDetalle_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
