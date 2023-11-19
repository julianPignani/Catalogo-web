<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="vista.ListaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2><u>Listado de Artículos</u></h2>
                <asp:GridView ID="dgvArticulos" CssClass="table table-bordered text-center" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                       OnPageIndexChanging="dgvArticulos_PageIndexChanging"  AllowPaging="true" PageSize="5" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="id" DataField="Id" Visible="false" />
                        <asp:BoundField HeaderText="Código"  DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:CommandField HeaderText="Acción"  ShowSelectButton="true" SelectText="Modificar" />
                    </Columns>
                </asp:GridView>
                <div>
                    <a href="FormularioArticulo.aspx" class="btn btn-primary" >Agregar</a>
                </div>
</asp:Content>
