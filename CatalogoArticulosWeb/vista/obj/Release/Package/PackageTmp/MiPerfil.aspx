<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="vista.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 15px;
        }
    </style>

    <script type="text/javascript">
        // Función JavaScript para mostrar un mensaje
        var mostrarMensajeSuccess = false;

        function validarCampos() {
            var txtNombre = document.getElementById("txtNombre");
            var txtApellido = document.getElementById("txtApellido");

            // Remueve clases de validación previas
            txtNombre.classList.remove("is-invalid", "is-valid");
            txtApellido.classList.remove("is-invalid", "is-valid");


            // Realiza la validación
            var validacionExitosa = true;

            if (txtNombre.value.trim() === '') {
                // Agrega clase de invalidación
                txtNombre.classList.add("is-invalid");
                validacionExitosa = false;
            } else {
                // Agrega clase de validación
                txtNombre.classList.add("is-valid");
            }

            if (txtApellido.value.trim() === '') {
                // Agrega clase de invalidación
                txtApellido.classList.add("is-invalid");
                validacionExitosa = false;
            } else {
                // Agrega clase de validación
                txtApellido.classList.add("is-valid");
            }


            // Si la validación del lado del cliente es exitosa, permitir la operación de guardado
            if (validacionExitosa) {
                mostrarMensajeSuccess = true;
                return true;
            } else {
                return false;
            }
        }


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 class="display-4 text-primary m-3"><u>Mi Perfil</u></h1>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3 mt">
                 <label class="form-label"><strong>Email</strong></label>
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" Enabled="false" />
            </div>
            <div class="mb-1">
                <label class="form-label"><strong>Nombre</strong></label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" ClientIDMode="Static" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El campo es requerido." ControlToValidate="txtNombre" CssClass="validacion" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label"><strong>Apellido</strong></label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" ClientIDMode="Static" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El campo es requerido." CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
            </div>
            <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary mb-2" OnClick="btnGuardar_Click" runat="server" OnClientClick="return validarCampos();" />
            <a href="Default.aspx" class="btn btn-danger mb-2">Cancelar</a>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label"><strong>Imagen Perfil</strong></label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq9zZ0dsOIYyjwZdkWKTE_kuxtRplsy9dexPnXEzCsMRNXXATXEmrELQz9i7z1aeStYJI&usqp=CAU"
                    CssClass="img-fluid img-thumbnail mb-3" ID="imgNuevoPerfil" runat="server" Style="width: 250px; height: 250px;" />
            </div>
        </div>
    </div>



</asp:Content>
