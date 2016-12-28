<%@ Page Title="" Language="C#" MasterPageFile="~/KP3000.Master" AutoEventWireup="true" CodeBehind="testet.aspx.cs" Inherits="KP3000.testet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
                <div class="col-md-2"></div>

                <div class="col-md-8">

                    <div class="well well-lg">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  
                            <div class="well well-lg">
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

                                
                                <form class="radio" runat="server">
                                    <div>
                                      <asp:RadioButton ID="RadioButton1" runat="server" />  
                                        </div>
                                    <div>
                                      <asp:RadioButton ID="RadioButton2" runat="server" />
                                        </div>
                                    <div>
                                      <asp:RadioButton ID="RadioButton3" runat="server" /> 
                                        </div>
                                </form>
                            </div>
                                               
                    </div>




                </div>

                <div class="col-md-2"></div>

            </div>


</asp:Content>
