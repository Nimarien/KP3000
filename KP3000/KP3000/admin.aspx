<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="KP3000.admin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="jumbotron">
    <h2>Väkommen <asp:label id="adminlogin" runat="server"></asp:label></h2>
    </div>

    <div class="row">
        <div class="col-md-2">
        </div>

        <div class="col-md-8">


            <div class="well well-lg">
                <div class=""></div>
                <form class="form" runat="server">
                    
                <div class="panel panel-primary">
                    <div class="panel-heading">Licensierade medarbetare</div>
                    <asp:GridView ID="GridLicensierade" DataKeyNames="NAMN, GODKÄNT, RESULTAT, DATUM" runat="server" UseAccessibleHeader="true"></asp:GridView>
                </div>
                    
                <div class="panel panel-primary">
                    <div class="panel-heading">OLicensierade medarbetare</div>
                    <asp:GridView ID="GridOlicensierade" DataKeyNames="NAMN, GODKÄNT, RESULTAT, DATUM" runat="server" UseAccessibleHeader="true"></asp:GridView>
                </div>
                    

                   


                </form>
            </div>
        </div>

        <div class="col-md-2">
        </div>

    </div>


</asp:Content>
