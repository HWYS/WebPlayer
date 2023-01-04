<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Player.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users</title>
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
                    <li ><a href="Admin.aspx">Metadata</a></li>
                    <li class="active"><a href="User.aspx">Users</a></li>
                    <li><a href="Settings.aspx">Settings</a></li>
                </ul>
            </div>
        </nav>

        <div class="container">
            <div class="form-group">
                <label for="txtUserName">User Name:</label>
                <asp:TextBox runat="server" ID="txtUserName" placeholder="User Name" class="form-control" />
            </div>

            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" placeholder="Password" class="form-control" />
            </div>

            <div class="form-group">
                <label for="txtRetypePassword">Retype Password:</label>
                <asp:TextBox TextMode="Password" runat="server" ID="txtRetypePassword" placeholder="Retype Password" class="form-control" />
            </div>

            <div class="form-check">
                <asp:CheckBox runat="server" ID="chkIsAdmin" class="form-check-input" Checked="false" Text="Admin Account" TextAlign="Right" />

            </div>

            <div class="form-group">
                <asp:Button runat="server" type="button" class="btn btn-primary" Text="Save" ID="btnSave" OnClientClick="return checkValidation();" OnClick="btnSave_Click"></asp:Button>
                <asp:Button runat="server" type="button" class="btn btn-default" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click"></asp:Button>
            </div>

            <asp:HiddenField runat="server" ID="hidID" />

            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" class="table table-striped">
                <Columns>
                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("userName") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Admin Account">
                        <ItemTemplate>
                            <asp:CheckBox Checked='<%# Eval("isAdmin") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' OnCommand="deleteUser" Text="Delete" OnClientClick="javascript:confirm('Are you sure to delete?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </form>

    <script type="text/javascript">
            function checkValidation() {
                var userName = document.getElementById("<%= txtUserName.ClientID %>").value;
                var password = document.getElementById("<%= txtPassword.ClientID %>").value;
                var retypePassword = document.getElementById("<%= txtRetypePassword.ClientID %>").value;

                if (userName.length <= 0) {
                    alert('Please enter User Name');
                    return false;
                }
                else if (password <= 0) {
                    alert('Please enter Password');
                    return false;
                }
                else if (retypePassword <= 0) {
                    alert('Please enter Retype Password');
                    return false;
                }

                if (password != retypePassword) {
                    alert('Password and Retype Password do not match');
                    return false;
                }
                return true;
            }
    </script>
</body>
</html>
