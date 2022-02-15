<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ForgotPwd.aspx.cs" Inherits="BubbleTea.ForgotPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Forgot Password</title>
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
						Forget Password
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Username is required">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input100" Placeholder="Username"></asp:TextBox>
						<span class="focus-input100"></span>
                        <asp:TextBox ID="txtPwd" Type="password" runat="server" CssClass="input100" Placeholder="New Password" Visible="false"></asp:TextBox>
					</div>
				
					<div class="container-login100-form-btn">
						<asp:LinkButton ID="pwdBtn" CssClass="login100-form-btn" runat="server" OnClick="btn_Click">Change Password</asp:LinkButton>
						<asp:LinkButton ID="changeBtn" CssClass="login100-form-btn" runat="server" OnClick="change_Click" Visible="false">Change Password</asp:LinkButton>
                    </div>

					<div class="text-center p-t-136">
						<asp:LinkButton ID="return" CssClass="txt2" runat="server" OnClick="return_Click">
							Return to Login
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
