<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="vista.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4 mx-auto" style="max-width: 840px; height: 500px; background-color: #f8f9fa; border-radius: 15px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
    <div class="row g-1">
        <div class="col-md-5 d-flex align-items-center justify-content-center mb-0"">
            <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq9zZ0dsOIYyjwZdkWKTE_kuxtRplsy9dexPnXEzCsMRNXXATXEmrELQz9i7z1aeStYJI&usqp=CAU"
                CssClass="img-fluid img-thumbnail" ID="imgDetalle" runat="server" Style="width:330px; height:300px; margin:60px 0 0.5px 0;" />
        </div>
        <div class="col-md-7">
            <div class="card-body">
                <div class="mb-3 ">
                    <h3 class="card-title"><u>Detalle del Artículo</u></h3>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Nombre" CssClass="form-label font-weight-bold" style="color: black; font-weight: bold;" runat="server" />
                    <asp:TextBox ID="txtNombre" CssClass="form-control font-weight-bold" style="color: black; font-weight: bold;" runat="server" Enabled="false" />
                </div>
                <div class="mb-3">
                    <asp:Label Text="Marca" CssClass="form-label font-weight-bold" style="color: black; font-weight: bold;" runat="server" />
                    <asp:TextBox id="txtMarca" CssClass="form-control" style="color: black; font-weight: bold;" runat="server" Enabled="false" />
                </div>
                <div class="mb-3">
                    <asp:Label Text="Descripcion" CssClass="form-label font-weight-bold" style="color: black; font-weight: bold;" runat="server" />
                    <asp:TextBox id="txtDescripcion" TextMode="MultiLine" CssClass="form-control font-weight-bold" style="color: black; font-weight: bold;" runat="server" Enabled="false" />
                </div>
                <div class="mb-3">
                    <asp:Label Text="Precio" CssClass="form-label" style="color: black; font-weight: bold;" runat="server" />
                    <asp:TextBox id="txtPrecio" CssClass="form-control" style="color: black; font-weight: bold;" runat="server" Enabled="false" />
                </div>
            </div>
        </div>
    </div>
    <div class="mb-3 mt-auto text-center">
        <a href="Default.aspx" class="btn btn-primary btn-lg" >Regresar</a>
    </div>
</div>
</asp:Content>
