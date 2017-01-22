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
                    
                <div class="panel panel-primary" runat="server">
                    <div class="panel-heading">Icke anställda (Licenstest)</div>
                    <asp:GridView ID="GridLicensierade" DataKeyNames="namn, datumgodkänt, antalrätt, antalfel, testdatum" runat="server"></asp:GridView>
                </div>
                    
                <div class="panel panel-primary" runat="server">
                    <div class="panel-heading">Medarbetare (ÅKU-test)</div>
                    <asp:GridView ID="GridOlicensierade" DataKeyNames="namn, datumgodkänt, antalrätt, antalfel, testdatum" runat="server"></asp:GridView>
                </div>
                    

                   


                </form>
            </div>
        </div>

        <div class="col-md-2">
        </div>

    </div>


</asp:Content>
