<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BubbleTea.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Checkout</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span>Checkout</span></p>
                    <h1 class="mb-0 bread">Checkout</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-8 ftco-animate">
                    <div class="billing-form">
                        <h3 class="mb-4 billing-heading">Billing Details</h3>
                        <div class="row align-items-end">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblName" runat="server" Text="Name">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="country">State / Country</label>
                                    <div class="select-wrap">
                                        <div class="icon"><span class="ion-ios-arrow-down"></span></div>
                                        <select name="" id="" class="form-control">
                                            <option value="SG">Singapore</option>
                                            <option value="MY">Malaysia</option>
                                            <option value="PH">Philippines</option>
                                            <option value="IN">Indonesia</option>
                                            <option value="VN">Vietnam</option>
                                            <option value="BU">Burma</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="streetaddress">Street Address</label>
                                    <input type="text" class="form-control" placeholder="House number & street name">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="postcodezip">Postcode / ZIP *</label>
                                    <input type="text" class="form-control" placeholder="">
                                </div>
                            </div>
                            <div class="w-100"></div>
                        </div>

                        <hr />

                        <h3 class="mb-4 billing-heading">Payment Details</h3>
                        <div class="row align-items-end">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblCCN" runat="server" Text="Credit Card Number">
                                        <asp:TextBox ID="txtCCN" runat="server" CssClass="form-control" />
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSC" runat="server" Text="Security Code">
                                        <asp:TextBox ID="txtSC" runat="server" CssClass="form-control" />
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblEx" runat="server" Text="Expiry Date" Type="Month">
                                        <asp:TextBox ID="txtEx" runat="server" CssClass="form-control" />
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="w-100"></div>
                        </div>

                    </div>
                    <!-- END -->



                    <div class="row mt-5 pt-3 d-flex">
                        <div class="col-md-12 d-flex">
                            <div class="cart-detail cart-total bg-light p-3 p-md-4">
                                <h3 class="billing-heading mb-4">Cart Total</h3>
                                <p class="d-flex total-price">
                                    <span>Total</span>
                                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <asp:LinkButton ID="btnOrder" runat="server" CssClass="btn btn-primary py-3 px-4" OnClick="btnOrder_Click">Place an order</asp:LinkButton>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
