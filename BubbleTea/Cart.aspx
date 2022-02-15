<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BubbleTea.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Shopping Cart</title>
    <link rel="stylesheet" href="css/Cart.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span>Cart</span></p>
                    <h1 class="mb-0 bread">My Cart</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section ftco-cart">
        <div class="container">
            <div class="row">
                <div class="col-md-12 ftco-animate">
                    <div class="cart-list">
                        <table class="table">
                            <thead class="thead-primary">
                                <tr class="text-center">
                                    <th>&nbsp;</th>
                                    <th>&nbsp;</th>
                                    <th>Product</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr class="text-center">
                                            <td class="product-remove"><a href="RemoveCart?ID=<%#Eval("ID")%>"><span class="ion-ios-close"></span></a></td>

                                            <td class="image-prod">
                                                <img src="<%#Eval("ImgLink") %>" class="img" />
                                            </td>

                                            <td class="product-name">
                                                <h3><%#Eval("Name") %></h3>
                                            </td>

                                            <td class="price">$<%#Eval("Price") %></td>

                                            <td class="quantity">
                                                <%#Eval("Quantity") %>
                                            </td>

                                            <td class="total">$<%#Eval("Subtotal") %></td>
                                        </tr>
                                        <!-- END TR-->
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col col-lg-5 col-md-6 mt-5 cart-wrap ftco-animate">
                    <div class="cart-total mb-3">
                        <h3>Cart Totals</h3>
                        <hr>
                        <p class="d-flex total-price">
                            <span>Total</span>
                            <asp:Label ID="txtSubtotal" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <p class="text-center">
                        <asp:LinkButton ID="CheckoutBtn" runat="server" CssClass="btn btn-primary py-3 px-4" OnClick="CheckoutBtn_Click">Proceed to Checkout</asp:LinkButton>
                    </p>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
