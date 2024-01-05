<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="vista.ListaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2><u>Listado de Artículos</u></h2>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" Font-Bold runat="server" />
                <asp:TextBox ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="filtro_TextChanged" runat="server" />
            </div>
        </div>
    </div>
    <div class="mb-3">
        <asp:CheckBox Text=" Filtrar Productos." CssClass="form-check-input margin-left: 10px;" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
    </div>

    <%if (FiltroAvanzado)
        { %>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" Font-Bold ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" Font-Bold runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" ID="lblFiltroAvanzado" Font-Bold runat="server" />
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
    <div style="margin-bottom: 80px;">
        <asp:GridView ID="dgvArticulos" CssClass="table table-bordered text-center" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
            OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5" runat="server">
            <Columns>
                <asp:BoundField HeaderText="id" DataField="Id" Visible="false" />
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar o Eliminar" />
            </Columns>
        </asp:GridView>
        <div>
            <a href="FormularioArticulo.aspx" style="z-index: 1000;" class="btn btn-primary">Agregar</a>
        </div>
    </div>
</asp:Content>
