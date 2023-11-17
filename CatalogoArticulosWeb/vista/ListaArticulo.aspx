<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="vista.ListaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-2">
                <asp:GridView ID="dgvArticulos" CssClass="table table-bordered" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="id" DataField="Id" Visible="false" />
                        <asp:BoundField HeaderText="Código" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Descripción"  DataField="Descripcion" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
