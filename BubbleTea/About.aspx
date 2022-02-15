﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BubbleTea.Home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>About Us</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span>About</span></p>
                    <h1 class="mb-0 bread">About Us</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section testimony-section">
        <div class="container">
            <div class="row justify-content-center mb-5 pb-3">
                <div class="col-md-7 heading-section ftco-animate">
                    <h2 class="mb-4">Our Story</h2>
                    <p>
                        Mr Robert Hess was a avid Tea Lover. Together with his wife, they travelled across the globe trying all different kinds of tea, from Chai Tea in India to English Breakfast Tea in UK. 
                        However, the tea that stuck out was a cup of Bubble Tea from Taiwan. It was the best tasting tea they had tasted, with it being a perfect blend of sweetness and tea, and with a mouthful of chewy boba with each sip. 
                        With that experience, they decided to bring it over to their home, Singapore, allowing us to share what they had felt.
                    </p>

                    <img src="data:image/jpeg;base64,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"
                        style="display: block; margin-left: auto; margin-right: auto; width: 50%" />
                </div>
            </div>
        </div>
    </section>
    <hr>
</asp:Content>
