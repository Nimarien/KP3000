<%@ Page Title="" Language="C#" MasterPageFile="~/Inloggad.Master" AutoEventWireup="true" CodeBehind="inloggad.aspx.cs" Inherits="KP3000.inloggad" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
    <h2>Väkommen <asp:label id="userinlog" runat="server"></asp:label></h2>
    </div>




    <div class="row">
        <div class="col-md-2">
        </div>

        <div class="col-md-8">
            
            <div class="well well-lg">

                Senast godkända resultat:

                <asp:Label ID="testlabel" runat="server" Text="Label"></asp:Label>

            </div>

            <div class="well well-lg">

                Nu är du inloggad! här ska du få lite val på vad du kan göra.

                <form class="form" runat="server">
                <asp:Button class="btn btn-primary" ID="btnGörTest" onclick="btnGörTest_Click" runat="server" Text="Gör test!" AutoPostBack="true"/> 
                </form>
            </div>
        </div>

        <div class="col-md-2">
        </div>

    </div>

</asp:Content>
