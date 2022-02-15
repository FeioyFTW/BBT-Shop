<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BubbleTea.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span>Profile</span></p>
                    <h1 class="mb-0 bread">Profile</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-8 ftco-animate">
                    <div class="billing-form">
                        <h3 class="mb-4 billing-heading">Your Profile</h3>
                        <div class="row align-items-end">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblName" runat="server" Text="Name">
                                        <asp:Label ID="oldName" runat="server" Text="" CssClass="form-control" />
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Visible="false" />
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email">
                                        <asp:Label ID="oldEmail" runat="server" Text="" CssClass="form-control" />
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Visible="false" />
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary py-3 px-4" OnClick="Edit_Click">Edit</asp:LinkButton>
                            </div>
                            <div class="col-md-6">
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary py-3 px-4" OnClick="Save_Click" Visible="false">Save</asp:LinkButton>
                            </div>
                            <div class="col-md-6">
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary py-3 px-4" OnClick="Cancel_Click" Visible="false">Cancel</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
