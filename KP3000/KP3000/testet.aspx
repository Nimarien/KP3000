<%@ Page Title="" Language="C#" MasterPageFile="~/Inloggad.Master" AutoEventWireup="true" CodeBehind="testet.aspx.cs" Inherits="KP3000.testet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
                <div class="col-md-2"></div>

                <div class="col-md-8">

                    <div class="well well-lg">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  
                                
<%--                                <form class="radio" runat="server">
                                    <div class="radiobuttons">
                                    <div>
                                      <asp:RadioButton ID="RadioButton1" runat="server" GroupName="svar" />  
                                    </div>
                                    <div>
                                      <asp:RadioButton ID="RadioButton2" runat="server" GroupName="svar" />
                                    </div>
                                    <div>
                                      <asp:RadioButton ID="RadioButton3" runat="server" GroupName="svar" /> 
                                    </div>
                                    </div>
                                            <button type="button" class="btn btn-default">
                                                <span class="glyphicon glyphicon-step-backward" aria-hidden="true"></span> Föregående
                                            </button>
                                            <button type="button" class="btn btn-default">
                                                <span class="glyphicon glyphicon-step-forward" aria-hidden="true"></span> Nästa
                                            </button>
                                </form>--%>

                                  <div class="panel-group">
                                    <form class="panel panel-default" runat="server">
                                      <div class="panel-heading">
                                        <h4 class="panel-title">
                                          <a data-toggle="collapse" href="#collapse1">Fråga 1: <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></a>
                                        </h4>
                                      </div>
                                      <div id="collapse1" class="panel-collapse collapse">
                                          
                                            <div style="padding-left: 20px;">
                                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="svar" />  
                                            </div>

                                            <div style="padding-left: 20px;">
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="svar" />
                                            </div>

                                            <div style="padding-left: 20px;">
                                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="svar" /> 
                                            </div>

                                            <button type="button" class="btn btn-default">
                                                <span class="glyphicon glyphicon-step-backward" aria-hidden="true"></span> Föregående
                                            </button>
                                            <button type="button" class="btn btn-default">
                                                <span class="glyphicon glyphicon-step-forward" aria-hidden="true"></span> Nästa
                                            </button>

                                        <div class="panel-footer">  
                                            <span class="label label-success">Rätt</span>
                                        </div>

                                       </div>
                                    </form>
                                </div>
                            </div>
                                               
                    </div>

        </div>

                <div class="col-md-2"></div>



</asp:Content>
