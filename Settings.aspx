<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Player.Settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Settings</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-static-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <!--<a class="navbar-brand" href="#">WebSiteName</a>-->
                </div>
                <ul class="nav navbar-nav">
                    <li><a href="Admin.aspx">Metadata</a></li>
                    <li><a href="User.aspx">Users</a></li>
                    <li class="active"><a href="Settings.aspx">Settings</a></li>
                </ul>
            </div>
        </nav>

        <div class="container">
            <div class="form-check">
                <asp:CheckBox runat="server" ID="chkIsLogin" class="form-check-input" Checked="true" Text="Enable Login" TextAlign="Right" />

            </div>

            <div class="form-group">
                <asp:Button runat="server" type="button" class="btn btn-default" Text="Update" ID="btnUpdate" OnClientClick="javascript:confirm('Are you sure to update?');" OnClick="btnUpdate_Click"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
