<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BubbleTea.Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Drink Details</title>
    <link rel="stylesheet" href="css/ProductDetails.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span class="mr-2"><a href="Shop">Product</a></span> <span>Product Single</span></p>
                    <h1 class="mb-0 bread">Product Single</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section">
        <div class="container">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <div class="row">
                <div class="col-lg-6 mb-5 ftco-animate">
                    <asp:Image ID="mainImg" runat="server" CssClass="img-fluid" />
                </div>
                <div class="col-lg-6 product-details pl-md-5 ftco-animate">
                    <h3>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </h3>
                    <div class="rating d-flex">
                        <p class="text-left mr-4">
                            <asp:Label ID="lblAvgRating" runat="server" CssClass="mr-2"></asp:Label>
                            <asp:Rating ID="Rating2"
                                runat="server"
                                CssClass="mr-4"
                                StarCssClass="ion-ios-star-outline"
                                WaitingStarCssClass="ion-ios-star"
                                FilledStarCssClass="ion-ios-star"
                                EmptyStarCssClass="ion-ios-star-outline">
                            </asp:Rating>

                        </p>
                        <p class="text-left mr-4">
                            <a href="#" class="mr-2" style="color: #000;">
                                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                                <span style="color: #bbb;">Rating</span></a>
                        </p>
                        <p class="text-left">
                            <a href="#" class="mr-2" style="color: #000;">
                                <asp:Label ID="lblSold" runat="server" Text=""></asp:Label>
                                <span style="color: #bbb;">Sold</span>
                            </a>
                        </p>
                    </div>
                    <p class="price">
                        <span>
                            $<asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
                        </span>

                    </p>
                    <div class="row mt-4">
                        <div class="w-100"></div>
                        <div class="input-group col-md-6 d-flex mb-3">
                            <span class="input-group-btn mr-2">
                                <asp:LinkButton ID="subQty" CssClass="quantity-left-minus btn" OnClick="subQty_Click" runat="server">
                                    <i class="ion-ios-remove"></i>
                                </asp:LinkButton>
                            </span>
                            <asp:TextBox ID="quantity" CssClass="form-control input-number" value="1" min="1" max="100" runat="server"></asp:TextBox>
                            <span class="input-group-btn ml-2">
                                <asp:LinkButton ID="addQty" CssClass="quantity-right-plus btn" OnClick="addQty_Click" runat="server">
                                    <i class="ion-ios-add"></i>
                                </asp:LinkButton>
                            </span>
                        </div>
                        <div class="arrows">
                            <asp:LinkButton ID="backArrow" runat="server" CssClass="ion-ios-arrow-back" OnClick="backClick"></asp:LinkButton>
                            <asp:LinkButton ID="forwardArrow" runat="server" CssClass="ion-ios-arrow-forward" OnClick="forwardClick"></asp:LinkButton>
                        </div>
                        <div class="brrrr"></div>
                    </div>
                    <p>
                        <asp:LinkButton ID="Cart" CssClass="btn btn-black py-3 px-5" runat="server" OnClick="Cart_Click">Add to Cart</asp:LinkButton>
                    </p>
                    <div class="brrrr"></div>
                </div>
            </div>
            <hr />
            <h2>Ratings</h2>

            <div class="well well-sm">
                <div class="row" id="post-review-box">
                    <div class="text-right">
                        <asp:Rating ID="Rating1"
                            runat="server"
                            StarCssClass="ion-ios-star-outline"
                            WaitingStarCssClass="ion-ios-star"
                            FilledStarCssClass="ion-ios-star"
                            EmptyStarCssClass="ion-ios-star-outline">
                        </asp:Rating>
                        <asp:TextBox runat="server" ID="txtreview" TextMode="MultiLine" CssClass="form-control animated" Columns="50" Rows="5"></asp:TextBox>
                        <asp:LinkButton ID="submitReview" CssClass="btn btn-success btn-lg" runat="server" OnClick="btnSubmitClick">Save</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <section class="bg-light">
        <div class="container">
            <div class="row justify-content-center mb-3 pb-3">
                <div class="col-md-12 heading-section text-center ftco-animate">
                    <h2 class="mb-4">Related Products</h2>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="RelatedProducts" runat="server">
                    <ItemTemplate>
                        <div class="col-sm col-md-6 col-lg ftco-animate">
                            <div class="product">
                                <a href="Details?ProdID= + <%#Eval("ID")%>" class="img-prod">
                                    <img class="img-fluid" src="<%#Eval("ImgLink") %>" alt="Colorlib Template">
                                </a>
                                <div class="text py-3 px-3">
                                    <h3><a href="Details?ProdID= + <%#Eval("ID")%>"><%#Eval("Name") %></a></h3>
                                    <div class="d-flex">
                                        <div class="pricing">
                                            <p class="price"><span><%#Eval("Price") %></span></p>
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
    </section>

</asp:Content>
