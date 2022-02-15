<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BubbleTea.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Register</title>

    <meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">

	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">

	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/Login.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt">
					<img src="imgs/Logo.png" alt="IMG">
				</div>

				<div class="login100-form validate-form">
					<span class="login100-form-title">
						Member Register
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Name is required">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input100" Placeholder="Name" AutoComplete="Off"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input100" Placeholder="Email" AutoComplete="Off"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate = "Password is required">
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="input100" Type="password" Placeholder="Password" AutoComplete="Off"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>
					
					<div class="container-login100-form-btn">
						<asp:LinkButton ID="registerBtn" CssClass="login100-form-btn" runat="server" OnClick="btnRegister_Click">Register</asp:LinkButton>
                    </div>

					<div class="text-center p-t-120">
						<asp:LinkButton ID="createBtn" CssClass="txt2" runat="server" OnClick="createBtn_Click">
							Already Created Account?
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                        </asp:LinkButton>
                    </div>
				</div>
			</div>
		</div>
	</div>
	
	

	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="vendor/select2/select2.min.js"></script>
	<script src="vendor/tilt/tilt.jquery.min.js"></script>
	<script >
		$('.js-tilt').tilt({
			scale: 1.1
		})
    </script>
	<script src="js/main.js"></script>

</asp:Content>
