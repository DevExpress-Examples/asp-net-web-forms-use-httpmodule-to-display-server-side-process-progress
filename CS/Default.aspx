<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTimer" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to track progress of server side processing on the client side(using HttpModule)</title>
</head>
<body>
    <script type="text/javascript">

        function onCompletedCallback(s, e) {
            timer.mocpProgressURL = "default.aspx?proc=" + e.result;
            timer.SetEnabled(true);
        }

        function callbackStart(s, e) {
            s.SetEnabled(false);
            cbak.PerformCallback();
        }

        function refreshProgress(s, e) {
            var request = createXMLHttpRequest();
            if (request) {
                var url = s.mocpProgressURL;
                request.onreadystatechange = function() {
                    if (request.readyState == request.DONE && request.status == 200) {
                        var progress = request.responseText;
                        if (progress == "100") {
                              btn.SetEnabled(true);
                              timer.SetEnabled(false);
                        }
                        var status = request.status;
                        pbar.SetPosition(progress);
                    }
                };
                request.open("GET", url, true);
                request.send();
            }
        }

        function createXMLHttpRequest() {
            try { return new XMLHttpRequest(); } catch (e) { }
            try { return new ActiveXObject("Msxml2.XMLHTTP"); } catch (e) { }
            try { return new ActiveXObject("Microsoft.XMLHTTP"); } catch (e) { }
            alert("XMLHttpRequest is not supported");
            return null;
        }

    </script>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxCallback ID="cbak" runat="server" ClientInstanceName="cbak" OnCallback="cbak_Callback" >
            <ClientSideEvents CallbackComplete="function(s, e) { onCompletedCallback(s, e); }" />
        </dx:ASPxCallback>
        <dx:ASPxProgressBar ID="pbar" runat="server" Height="21px" Width="200px" EnableClientSideAPI="true" ClientInstanceName="pbar"></dx:ASPxProgressBar>
        <dx:ASPxButton ID="btn" runat="server" Text="Start" AutoPostBack="false" EnableClientSideAPI="true" ClientInstanceName="btn">
            <ClientSideEvents Click="function(s, e) { callbackStart(s, e); }" />
        </dx:ASPxButton>
        <dx:ASPxTimer ID="timer" runat="server" ClientInstanceName="timer" Interval="777" Enabled="false">
            <ClientSideEvents Tick="function(s, e) { refreshProgress(s, e); }"/>
        </dx:ASPxTimer>
    </div>
    </form>
</body>
</html>
