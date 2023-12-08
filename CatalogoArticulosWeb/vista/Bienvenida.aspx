<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Bienvenida.aspx.cs" Inherits="vista.Bienvenida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="carouselExampleDark" class="carousel carousel-dark slide">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active" data-bs-interval="10000">
                <img src="https://www.sony.com.ar/image/7179b15fa957563d895189432c5d11ab?fmt=png-alpha&wid=960" class="d-block mx-auto img-fluid" style="width: 1000px; height: 600px;" alt="Auriculares Sony">
                <div class="carousel-caption d-flex flex-column justify-content-end align-items-start text-danger">
                    <h5 class="mb-0">Auriculares Sony</h5>
                    <p class="mb-0">Inalámbricos WH-CH150.</p>
                </div>
            </div>
            <div class="carousel-item" data-bs-interval="2000">
                <img src="https://i.blogs.es/7adce5/samsung-lle0zrqrsfnkfwbq/1366_2000.jpg"class="d-block mx-auto img-fluid" style="width: 1000px; height: 600px;" alt="Monitor Samsung" >
                <div class="carousel-caption d-flex flex-column justify-content-end align-items-start text-danger">
                    <h5 class="mb-0">Monitor Samsung</h5>
                    <p class="mb-0">Full HD serie T55.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="https://media.c5n.com/p/514f2ddfc80bc9754fce0749c5610396/adjuntos/326/imagenes/000/222/0000222175/1200x675/smart/playstation-5-slim.jpg" class="d-block mx-auto img-fluid" style="width: 1000px; height: 600px;" alt="Monitor Samsung" >
                <div class="carousel-caption d-flex flex-column justify-content-end align-items-start text-danger">
                    <h5 class="mb-0">PlayStation 5</h5>
                    <p class="mb-0">¡¡¡Con un juego de regalo!!!.</p>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>


</asp:Content>
