<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="vista.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox cssClass="form-control" ID="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox cssClass="form-control" ID="TextNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox cssClass="form-control" ID="TextApellido" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox cssClass="form-control" ID="TextFechaNac" runat="server" />
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:image imageurl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq9zZ0dsOIYyjwZdkWKTE_kuxtRplsy9dexPnXEzCsMRNXXATXEmrELQz9i7z1aeStYJI&usqp=CAU" 
               cssclass="img-fluid img-thumbnail mb-3" ID="imgNuevoPerfil" runat="server"/>
        </div>
      </div>
            
        <div class="row">
            <div class="col-md-4">
                <asp:Button text="Guardar" ID="btnGuardar" cssClass="btn btn-primary" runat="server" />
                <a href="Default.aspx" class="btn btn-danger">Cancelar</a>
            </div>
        </div>

    
</asp:Content>
