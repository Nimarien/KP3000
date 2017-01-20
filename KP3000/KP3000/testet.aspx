<%@ Page Title="" Language="C#" MasterPageFile="~/Inloggad.Master" AutoEventWireup="true" CodeBehind="testet.aspx.cs" Inherits="KP3000.testet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
                <div class="col-md-2"></div>
            
                <div class="col-md-8">

                    <div class="well well-lg">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  

                        <div class="progress">
                            <div id="progressbar" class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" runat="server" text="0%">
                            </div>
                        </div>

                                  <div class="panel-group">
                                    <form class="panel panel-default" runat="server">
                                      <div class="panel-heading">
                                        <h4 class="panel-title">
                                          <a data-toggle="collapse" href="#collapse1">Fråga:  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></a>
                                        </h4>
                                      </div>
                                      <div id="collapse1" class="panel">
                                          
                                            <div style="padding-left: 20px;">
                                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="svar" />  
                                            </div>

                                            <div style="padding-left: 20px;">
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="svar" />
                                            </div>

                                            <div style="padding-left: 20px;">
                                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="svar" /> 
                                            </div>

                                          <asp:Button ID="Button1" OnClick="Button1_Click1" Enabled="false" CssClass="btn btn-default" runat="server" Text="föregående" Autopostback="true"/>
                                            
                                          <asp:Button ID="Button2" OnClick="Button2_Click" Enabled="true" CssClass="btn btn-default" runat="server" Text="nästa" Autopostback="true"/>                                                                                     

                                          <asp:Button ID="Button3" OnClick="Button3_Click" Enabled="false" CssClass="btn btn-success" runat="server" Text="Lämna in och rätta!" Autopostback="true"/>                          
                                      
                                        <div class="panel-footer">  
                                            
                                        </div>
                                          
                                       </div>
                                    </form>
                                </div>
                            </div>
                                               
                    </div>
  </div>

                <div class="col-md-2"></div>



</asp:Content>
