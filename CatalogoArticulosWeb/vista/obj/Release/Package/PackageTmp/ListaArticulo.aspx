<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="vista.ListaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="container text-center mt-5 mb-3">
            <h1 class="display-4  text-primary m-3""><u>Listado de Artículos</u></h1>
        </div>
    </div>

    <div class="row mb-3">
        <div class="col-md-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" CssClass="font-weight-bold" />
                <asp:TextBox ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="filtro_TextChanged" runat="server" />
            </div>
        </div>
    </div>
    <div class="mb-3">
        <asp:CheckBox Text=" Filtrar Productos." CssClass="form-check-input ml-2" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
    </div>

    <%if (FiltroAvanzado)
        { %>

    <div class="row mb-3">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" CssClass="font-weight-bold" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" CssClass="font-weight-bold" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" ID="lblFiltroAvanzado" CssClass="font-weight-bold" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <div>
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" runat="server" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <% } %>
    <div class="mb-4" style="margin-bottom: 80px;">
        <asp:GridView ID="dgvArticulos" CssClass="table table-bordered table-condensed table-responsive table-hover text-center" 
            DataKeyNames="Id"  AutoGenerateColumns="false" 
            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" 
            OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="🖊️" />
            </Columns>
        </asp:GridView>
        <div class="mt-3">
            <a href="FormularioArticulo.aspx" style="z-index: 1000;" class="btn btn-primary">Agregar</a>
        </div>
    </div>
</asp:Content>
