<%@ Page Language="C#" MasterPageFile="~/Inloggad.Master" AutoEventWireup="true" CodeBehind="rättning.aspx.cs" Inherits="KP3000.rättning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
                <div class="col-md-2"></div>

                <div class="col-md-8">

                    <div class="well well-lg">

                        här är ditt resultat

                        <form class="form" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        
                            <div>
                                <asp:GridView ID="Gridden" DataKeyNames="" runat="server"></asp:GridView>
                            </div>
                        </form>
                    </div>

                    


                </div>

                <div class="col-md-2"></div>

            </div>

</asp:Content>