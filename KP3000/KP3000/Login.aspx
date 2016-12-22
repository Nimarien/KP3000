<%@ Page Title="" Language="C#" MasterPageFile="~/KP3000.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KP3000.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="https://getbootstrap.com/examples/signin/signin.css" rel="stylesheet"/>


    <div class="container">
        <div class="jumbotron">
            <form class="form-signin">
                <h2 class="form-signin-heading">Logga in</h2>
            <label for="användarnamn" class="sr-only">Användarnamn</label>
            <input type="text" id="användarnamn" class="form-control" placeholder="Användarnamn" required autofocus/>
            <label for="lösen" class="sr-only">Password</label>
            <input type="password" id="lösen" class="form-control" placeholder="Lösenord" required/>
        
            <div class="checkbox">
                <label>
                    <input type="checkbox" value="komihåg"/> Kom ihåg mig
                </label>
            </div>
                <button class="btn btn-lg btn-primary btn-block" type="submit">Logga in</button>
            </form>
                
        
            <div class="row">


                    <div class="col-md-4"></div>
                    <div class="col-md-4""></div>
                    <div class="col-md-4"></div>
                </div>  
        </div>  
        
    </div>


</asp:Content>
