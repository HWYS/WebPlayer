<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Player.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title>Login</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet"
            integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa"
            crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="vh-100 d-flex justify-content-center align-items-center ">
            <div class="col-md-5 p-5 shadow-sm border rounded-5 border-primary bg-white">
                <h2 class="text-center mb-4 text-primary">Login</h2>
                <div class="container">
                    <div class="mb-3">
                        <label for="txtUserName" class="form-label">User Name</label>
                        <asp:TextBox type="username" name="email" class="form-control border border-primary" ID="txtUserName" aria-describedby="emailHelp" runat="server"/>
                    </div>
                    <div class="mb-3">
                        <label for="txtPassword" class="form-label">Password</label>
                        <asp:TextBox type="password" name="password" class="form-control border border-primary" ID="txtPassword" runat="server"/>
                    </div>
                    
                    <div class="d-grid">
                        <!--<button class="btn btn-primary" onclick="doLogIn()" type="submit">Login</button>-->
                    </div>

                    <div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="return checkValidation();" OnClick="btnLogin_Click" ></asp:Button>
                    </div>
                </div>
                
            </div>
        </div>
    </form>

    <script type="text/javascript">
        function checkValidation() {
            
            var userName = document.getElementById("<%= txtUserName.ClientID %>").value;
            var password = document.getElementById("<%= txtPassword.ClientID %>").value;

            if (userName.length <= 0) {
                alert('Please enter User Name');
                return false;
            }
            else if (password.length <=0) {
                alert('Please enter Password');
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
