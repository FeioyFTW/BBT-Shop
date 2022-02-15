<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BubbleTea.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Search</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span>Search</span></p>
                    <h1 class="mb-0 bread">Search</h1>
                </div>
            </div>
        </div>
    </div>

        <section class="ftco-section bg-light">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-lg-10 order-md-last">
                    <div class="row">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-6 col-md-6 col-lg-4 ftco-animate">
                                    <div class="product">
                                        <a href="Details?ProdID= + <%#Eval("ID")%>" class="img-prod">
                                            <img class="img-fluid" src='<%#Eval("ImgLink") %>' alt="Colorlib Template">
                                        </a>
                                        <div class="text py-3 px-3">
                                            <h3><a href="Details?ProdID= + <%#Eval("ID")%>"><%#Eval("Name") %></a></h3>
                                            <div class="d-flex">
                                                <div class="pricing">
                                                    <p class="price"><span><%#Eval("Price") %></span>
                                                </div>
                                                <div class="rating">
                                                    <p class="text-right">
                                                        <a href="#"><span class="ion-ios-star-outline"></span></a>
                                                        <a href="#"><span class="ion-ios-star-outline"></span></a>
                                                        <a href="#"><span class="ion-ios-star-outline"></span></a>
                                                        <a href="#"><span class="ion-ios-star-outline"></span></a>
                                                        <a href="#"><span class="ion-ios-star-outline"></span></a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col-md-4 col-lg-2 sidebar">
                    <div class="sidebar-box-2">
                        <h2 class="heading mb-2">
                            <asp:LinkButton ID="AllLink" OnClick="All_Click" runat="server">All Tea</asp:LinkButton></h2>
                    </div>
                    <div class="sidebar-box-2">
                        <h2 class="heading mb-4">Tea</h2>
                        <ul>
                            <li>
                                <asp:LinkButton ID="MilkLink" OnClick="Milk_Click" runat="server">Milk Tea</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="BrewLink" OnClick="Brew_Click" runat="server">Brewed Tea</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="FruitLink" OnClick="Fruit_Click" runat="server">Fruit Tea</asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="sidebar-box-2">
                        <h2 class="heading mb-4">Fancy Tea</h2>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LatteLink" OnClick="Latte_Click" runat="server">Tea Latte</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="MousseLink" OnClick="Mousse_Click" runat="server">Mousse Tea</asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="sidebar-box-2">
                        <h2 class="heading mb-2">
                            <asp:LinkButton ID="HoneyLink" OnClick="Honey_Click" runat="server">Honey Series</asp:LinkButton></h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
