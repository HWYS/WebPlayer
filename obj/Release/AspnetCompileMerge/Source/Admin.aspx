<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Player.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Metadata</title>
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
                    <li class="active"><a href="Admin.aspx">Metadata</a></li>
                    <li><a href="User.aspx">Users</a></li>
                    <li><a href="Settings.aspx">Settings</a></li>
                </ul>
            </div>
        </nav>
        <div class="container">

            <div class="form-group">
                <label for="txtChannelName">Channel Name:</label>
                <asp:TextBox runat="server" ID="txtChannelName" placeholder="Channel Name" class="form-control" />
            </div>

            <div class="form-group">
                <label for="txtDashUrl">Dash URL:</label>
                <asp:TextBox runat="server" ID="txtDashUrl" placeholder="Dash URL" class="form-control" />
            </div>

            <div class="form-group">
                <label for="txtHlsURL">HLS URL:</label>
                <asp:TextBox runat="server" ID="txtHlsURL" placeholder="HLS URL" class="form-control" />
            </div>

            <div class="form-group">
                <label for="txtLogoURL">Logo URL:</label>
                <asp:TextBox runat="server" ID="txtLogoURL" placeholder="Logo URL" class="form-control" />
            </div>

            <div class="form-check">
                <asp:CheckBox runat="server" ID="chkIsActive" class="form-check-input" Checked="true" Text="Active" TextAlign="Right" />

            </div>

            <div class="form-group">
                <asp:Button runat="server" type="button" class="btn btn-primary" Text="Save" ID="btnSave" OnClientClick="return checkValidation();" OnClick="btnSave_Click"></asp:Button>
                <asp:Button runat="server" type="button" class="btn btn-default" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click"></asp:Button>
            </div>

            <asp:HiddenField runat="server" ID="hidID" />

            <asp:GridView ID="gvMetaData" runat="server" AutoGenerateColumns="False" class="table table-striped">
                <Columns>
                    <asp:TemplateField HeaderText="Channel Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ChannelName") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dash URL">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DashSrc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="HLS URL">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("HlsSrc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="LOGO URL" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LogoSrc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' OnCommand="editMetaData" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' OnCommand="deleteMetaData" Text="Delete" OnClientClick="javascript:confirm('Are you sure to delete?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

        <script type="text/javascript">
            function checkValidation() {
                var channelName = document.getElementById("<%= txtChannelName.ClientID %>").value;
                var dashURL = document.getElementById("<%= txtDashUrl.ClientID %>").value;
                var hlsURL = document.getElementById("<%= txtHlsURL.ClientID %>").value;
                var logoURL = document.getElementById("<%= txtLogoURL.ClientID %>").value;

                if (channelName.length <= 0) {
                    alert('Please enter Channel Name');
                    return false;
                }
                else if (dashURL.length <= 0) {
                    alert('Please enter Dash URL');
                    return false;
                }
                else if (hlsURL.length <= 0) {
                    alert('Please enter HLS URL');
                    return false;
                }
                else if (logoURL.length <= 0) {
                    alert('Please enter Logo URL');
                    return false;
                }
                return true;
            }
        </script>
    </form>
</body>
</html>
