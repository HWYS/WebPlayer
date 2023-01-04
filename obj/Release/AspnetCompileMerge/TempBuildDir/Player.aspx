<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Player.aspx.cs" Inherits="Player.Player" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <link rel="stylesheet" href="CSS/Style.css"/>
    <link href="https://unpkg.com/video.js/dist/video-js.min.css" rel="stylesheet"/>
    <script src="https://unpkg.com/video.js/dist/video.min.js"></script>
    <link href="https://unpkg.com/@videojs/themes@1/dist/fantasy/index.css" rel="stylesheet"/>
</head>
<body class="bg-dark" onload="changeChannel();">
    <form id="form1" runat="server">
        <asp:HiddenField ID="metaData" runat="server" />
        <div class="container">
            <div class="container-flex d-flex justify-content-center p-3 ">
                <img class="bg-dark" src="Images/logo.png" height="110" width="90" />
                <!--<p>Resize this responsive page to see the effect!</p> -->
            </div>

            <div class="row justify-content-center">
                <div class="col-lg-3 text-white">
                    <h5>Select channel to watch:
                    </h5>
                </div>
                <!--<option class="dropdown-item">World Cup 1</option>
                        <option class="dropdown-item">World Cup 2</option> -->
                <!--<option class="dropdown-item">Hub Premier 3</option>
                        <option class="dropdown-item">Hub Premier 4</option>-->
                <div class="col-lg-3">
                    <asp:DropDownList runat="server" class="DropDownListStyle form-control  bg-secondary text-white" ID="channelDropDown" AutoPostBack="True"
                        ViewStateMode="Enabled" onchange="changeChannel();">
                    </asp:DropDownList>
                </div>

                <div class="col-lg-6">
                    <img runat="server" height="70" width="124" class="float-right" id="channelLogo" />
                </div>
            </div>

            <div class="row justify-content-center">
                <div id="divOne" class="col-lg">
                    <!--<video width="100%" data-dashjs-player autoplay src="https://ucdn.starhubgo.com/bpk-tv/ONEHD/default/manifest.mpd" controls id="playerOne"></video>-->

                    <video runat="server" class="video-js vjs-theme-fantasy vjs-16-9" controls id="player"></video>

                </div>

            </div>

            <asp:HiddenField ID="hidMetaData" runat="server" ClientIDMode="Static" />
        </div>
    </form>


    <script src="https://cdn.jsdelivr.net/hls.js/latest/hls.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"> </script>
    
    <script type="text/javascript" language="javascript">
        var player = document.getElementById("<%= player.ClientID %>");
        var select = document.getElementById("<%= channelDropDown.ClientID %>");
        
        var metaData = JSON.parse(document.getElementById("<%= hidMetaData.ClientID %>").value);
        function changeChannel() {

            playVideo(metaData[select.selectedIndex]);

        };
    </script>

    <script type="text/javascript" language="javascript">
        var channelLogo = document.getElementById("<%= channelLogo.ClientID %>");
        var src, type;
        function playVideo(item) {
            //alert('Hello');
            console.log(item);
            var myPlayer = videojs('player');
            //getMetaData(index);
            channelLogo.src = item.logoSrc;
            src = isIOS() ? item.hlsSrc : item.dashSrc;
            type = isIOS() ? "application/x-mpegURL" : "application/dash+xml";
            myPlayer.src({ src: src, type: type });

        }

        function isIOS() {
            const ua = navigator.userAgent;
            if (/android/i.test(ua)) {
                return false;
            }
            else if (/iPad|iPhone|iPod/.test(ua)) {
                return true;
            }
            return false;
        }
    </script>
</body>
</html>
