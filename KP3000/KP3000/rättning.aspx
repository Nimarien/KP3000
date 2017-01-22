<%@ Page Language="C#" MasterPageFile="~/Inloggad.Master" AutoEventWireup="true" CodeBehind="rättning.aspx.cs" Inherits="KP3000.rättning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
                <div class="col-md-2"></div>

                <div class="col-md-8">

                    <div class="well well-lg">

                        <h2>RESULTAT</h2>

                            <div id="svarbra" class="alert alert-success" role="alert" runat="server">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </div>
                            
                            <div id="svardåligt" class="alert alert-danger" role="alert" runat="server">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </div>

                        <form class="form" runat="server">

                            <div class="panel panel-default">
                              <div class="panel-heading">
                                <h3 class="panel-title">Sammanfattning</h3>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                              </div>
                              <div class="panel-body">
                                 <asp:GridView ID="Gridden" DataKeyNames="Del, procent, godkänd" runat="server"></asp:GridView>
                              </div>
                            </div>

                             <div class="panel panel-default">
                              <div class="panel-heading">
                                <h3 class="panel-title">Frågor</h3>
                              </div>
                              <div class="panel-body">
                                <asp:Label ID="Label2" runat="server" Text="här är frågorna du svarat felaktigt på:"></asp:Label>
                              
                                  <asp:GridView ID="Gridden2" runat="server"></asp:GridView>
                                  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                              
                              
                              </div>
                            </div>
      


                        </form>
                    </div>

                    


                </div>

                <div class="col-md-2"></div>

            </div>

</asp:Content>