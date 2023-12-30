<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="vista.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenedor principal -->
    <div class="container mt-5">
        <div class="row">
            <!-- Lista de productos -->
            <div class="col-md-4">
                <div class="card">
                    <img src="imagen_del_producto.jpg" class="card-img-top" alt="Producto">
                    <div class="card-body">
                        <h5 class="card-title">Nombre del Producto</h5>
                        <p class="card-text">Descripción breve del producto.</p>
                        <button class="btn btn-primary" onclick="mostrarDetalles()">Ver Detalles</button>
                    </div>
                </div>
            </div>

            <!-- Detalles del producto -->
            <div class="col-md-8" id="detallesProducto" style="display: none;">
                <img src="imagen_del_producto_grande.jpg" class="img-fluid" alt="Producto Grande">
                <div>
                    <!-- Mostrar características del producto aquí -->
                    <h3>Características</h3>
                    <ul>
                        <li>Característica 1: Valor</li>
                        <li>Característica 2: Valor</li>
                        <!-- ... -->
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script>
        function mostrarDetalles() {
            document.getElementById("detallesProducto").style.display = "block";
        }
    </script>
</asp:Content>
