<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/KP3000.Master" CodeBehind="WebForm1.aspx.cs" Inherits="KP3000.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kompetensportalen</title>
</head>
<body>



    <link href="Content/bootstrap.css" rel="stylesheet" />
    <form id="form1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h2>Välkomna till våran skitsida, den kommer bli sjukt snygg en dag!</h2>
        </div>  

            <div class="row">

                <div class="col-md-4" style="background-color:lightgray; border: solid 1px;">kolumn 1</div>

                <div class="col-md-4">kolumn 2</div>

                <div class="col-md-4">kolumn 3</div>
            </div>  

            <div class="row">
                <div class="col-md-4">kolumn 1</div>

                <div class="col-md-4">kolumn 2</div>

                <div class="col-md-4">kolumn 3</div>

            </div>
        
    </div>

    </form>
</body>
</html>
