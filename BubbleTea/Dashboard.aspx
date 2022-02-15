<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BubbleTea.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" href="css/Dashboard.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="Home">Home</a></span> <span class="mr-2">Dashboard</span></p>
                    <h1 class="mb-0 bread">Dashboard</h1>
                </div>
            </div>
        </div>
    </div>

    <br />
    <hr />
    <h2 class="heading mb-4">Total amount sold for each Drink</h2>
    <asp:Chart ID="Chart1" runat="server" Height="420px" Width="1250px">
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Bar">
                <Points>

                </Points>
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Drink Name">
                </AxisX>
                <AxisY Title="Quantity Sold">
                </AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    
    <br />
    <h2 class="heading mb-4">Total profit from each Drink</h2>
    <asp:Chart ID="Chart2" runat="server" Height="420px" Width="1250px">
        <Series>
            <asp:Series Name="Series2" ChartArea="ChartArea2" ChartType="Line">
                <Points>

                </Points>
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea2">
                <AxisX Title="Drink Name">
                </AxisX>
                <AxisY Title="Amount Earned ($)">
                </AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

    <br />
</asp:Content>
