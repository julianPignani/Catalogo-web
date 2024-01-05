<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="vista.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color:red;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        //Validaciones con JS.
        function validarCampos() {
            var txtNombre = document.getElementById("txtNombre");
            var txtApellido = document.getElementById("txtApellido");
            var txtFechaNac = document.getElementById("txtFechaNac");

            // Remueve clases de validación previas
            txtNombre.classList.remove("is-invalid", "is-valid");
            txtApellido.classList.remove("is-invalid", "is-valid");
            txtFechaNac.classList.remove("is-invalid", "is-valid");

            // Realiza la validación
            if (txtNombre.value.trim() === '') {
                // Agrega clase de invalidación
                txtNombre.classList.add("is-invalid");
                return false;
            } else {
                // Agrega clase de validación
                txtNombre.classList.add("is-valid");
            }

            if (txtApellido.value.trim() === '') {
                // Agrega clase de invalidación
                txtApellido.classList.add("is-invalid");
                return false;
            } else {
                // Agrega clase de validación
                txtApellido.classList.add("is-valid");
            }

            if (txtFechaNac.value.trim() === '') {
                // Agrega clase de invalidación
                txtFechaNac.classList.add("is-invalid");
                return false;
            } else {
                // Agrega clase de validación
                txtFechaNac.classList.add("is-valid");
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox cssClass="form-control" ID="txtEmail" runat="server" Enabled="false" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox cssClass="form-control" ID="txtNombre" ClientIDMode="Static" runat="server" Enabled="false" />
                <asp:RequiredFieldValidator ErrorMessage="El campo es requerido." ControlToValidate="txtNombre" CssClass="validacion" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox cssClass="form-control" ID="txtApellido" ClientIDMode="Static" runat="server" Enabled="false"/>
                <asp:RequiredFieldValidator ErrorMessage="El campo es requerido." CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox cssClass="form-control" ID="txtFechaNac" ClientIDMode="Static" runat="server" Enabled="false" TextMode="Date" />
                <asp:RequiredFieldValidator ErrorMessage="El campo es requerido" CssClass="validacion" ControlToValidate="txtFechaNac" runat="server" />
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" disabled="disabled" />
            </div>
            <div class="mb-3">
                <asp:Image imageurl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq9zZ0dsOIYyjwZdkWKTE_kuxtRplsy9dexPnXEzCsMRNXXATXEmrELQz9i7z1aeStYJI&usqp=CAU"
                    cssclass="img-fluid img-thumbnail mb-3" ID="imgNuevoPerfil" runat="server" Style="width:250px; height:250px;" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button text="Guardar" ID="btnGuardar" cssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" Visible="false" OnClientClick="return validarCampos()" />
            <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-warning"  OnClick="btnModificar_Click" runat="server" />
            <a href="Default.aspx" class="btn btn-danger">Cancelar</a>
        </div>
    </div>


</asp:Content>
