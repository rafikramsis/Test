<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingPopup.ascx.cs"
    Inherits="controls_LoadingPopup" %>
<div id="divLoadingPopup" class="loadingPopup" style="display: none;">
    <img id="imgLoading" runat="server" src="~/images/alerts/loader.gif" />
    <span id="loadingPopupText">loading, please wait...</span> <a href="javascript:fireAbort()"
        style="display: none;">Abort</a>
</div>
<script type="text/javascript">
    var onAbortHandler = null;
    function showLoading(loadingText, onAbort) {
        if (loadingText) {
            $("#loadingPopupText").html(loadingText);
        }
        if (onAbort)
            onAbortHandler = onAbort;
        $("#divLoadingPopup").modal({ containerCss: {
            height: 40,
            width: 510
        }
        });
    }

    function hideLoading() {
        $.modal.close();
    }
    function fireAbort() {
        $.modal.close();
        if (onAbortHandler != null)
            onAbortHandler();
    }
</script>
