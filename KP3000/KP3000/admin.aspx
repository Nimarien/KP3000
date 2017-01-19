<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="KP3000.admin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-md-2">
        </div>

        <div class="col-md-8">
            <div class="well well-lg">

                Väkommen <asp:label id="adminlogin" runat="server"></asp:label>

                <form class="form" runat="server">
                    <%--knappar--%>
                </form>
            </div>
        </div>

        <div class="col-md-2">
        </div>

    </div>


</asp:Content>
