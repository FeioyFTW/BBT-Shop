<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BubbleTea.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="css/Home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="home-section" class="hero">
        <div class="home-slider js-fullheight owl-carousel">
            <div class="slider-item js-fullheight">
                <div class="overlay"></div>
                <div class="container-fluid p-0">
                    <div class="row d-md-flex no-gutters slider-text js-fullheight align-items-center justify-content-end" data-scrollax-parent="true">
                        <asp:Image ID="itemImg1" CssClass="one-third order-md-last img" style="height: 500px; width: 350px;" runat="server" />
                        <div class="one-forth d-flex js-fullheight align-items-center ftco-animate" data-scrollax=" properties: { translateY: '70%' }">
                            <div class="text">
                                <span class="subheading">Bubble Tea</span>
                                <div class="horizontal">
                                    <h3 class="vr" style="background-image: url(images/divider.jpg);">Established Since 2000</h3>
                                    <h1 class="mb-4 mt-3">Get Your Own
                                        <br>
                                        <span>Sweet Treat</span></h1>
                                    <p>Singaporean's favourite all-time drink</p>

                                    <p><a href="Shop" class="btn btn-primary px-5 py-3 mt-3">Shop Now</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="slider-item js-fullheight">
                <div class="overlay"></div>
                <div class="container-fluid p-0">
                    <div class="row d-flex no-gutters slider-text js-fullheight align-items-center justify-content-end" data-scrollax-parent="true">
                        <asp:Image ID="itemImg2" CssClass="one-third order-md-last img" style="height: 500px; width: 350px;" runat="server" />
                        <div class="one-forth d-flex js-fullheight align-items-center ftco-animate" data-scrollax=" properties: { translateY: '70%' }">
                            <div class="text">
                                <span class="subheading">Bubble Tea</span>
                                <div class="horizontal">
                                    <h3 class="vr" style="background-image: url(images/divider.jpg);">Best Bubble Tea Shop</h3>
                                    <h1 class="mb-4 mt-3">Popular <span>Flavour</span> Available</h1>
                                    <p>Honey Series has just lauched</p>

                                    <p><a href="Shop" class="btn btn-primary px-5 py-3 mt-3">Shop Now</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <hr>
</asp:Content>
