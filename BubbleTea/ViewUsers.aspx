<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="BubbleTea.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>View Users</title>
    <link rel="stylesheet" href="css/EUsers.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span>Edit Users</span></p>
                    <h1 class="mb-0 bread">Edit Users</h1>
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
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Email</th>
                                    <th>Verification</th>
                                    <th>&nbsp</th>
                                    <th>&nbsp</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr class="text-center">

                                            <td class="acc-id">
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                            </td>

                                            <td class="acc-name">
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                <asp:TextBox ID="tbName" runat="server" Text='<%#Eval("Name") %>' Visible="false"></asp:TextBox>
                                            </td>

                                            <td class="acc-email">
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                                <asp:TextBox ID="tbEmail" runat="server" Text='<%#Eval("Email") %>' Visible="false"></asp:TextBox>
                                            </td>

                                            <td class="acc-vf">
                                                <asp:Label ID="lblVf" runat="server" Text='<%#Eval("Verify") %>'></asp:Label>
                                                <asp:TextBox ID="tbVf" runat="server" Text='<%#Eval("Verify") %>' Visible="false"></asp:TextBox>
                                            </td>

                                            <td class="product-remove">
                                                <a href='RemoveAcc?ID=<%#Eval("ID")%>'><span class="ion-ios-close"></span></a>
                                            </td>

                                            <td class="product-edit">
                                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" OnClick="OnEdit"/>
                                                <asp:LinkButton ID="btnSave" runat="server" Text="Save |" Visible="false" OnClick="OnUpdate"/>
                                                <asp:LinkButton ID="btnCancel" runat="server" Text=" Cancel" Visible="false" OnClick="OnCancel" />
                                            </td>
                                        </tr>
                                        <!-- END TR-->
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
