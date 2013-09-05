<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Newsletter.ascx.cs" Inherits="Controls_Newsletter" %>
<input id="txtName" class="nameInput watermarkOn" value="Your Name" />
<input id="txtEmail" class="emailInput watermarkOn" value="Your Email" />
<input class="homeNewsletterBtn" onclick="javascript:return invokeNewsletterSignup();" type="image"
    src="images/btn-subscribe-subfooter-home.png" />
<div class="clear">
</div>
<br />
To review previous newsletters please check our <a class="underLine" href="newsletter-archive.aspx">newsletter
    archive</a>

<script type="text/javascript">
    function invokeNewsletterSignup() {
        var txtEmail = document.getElementById('txtEmail');
        var txtName = document.getElementById('txtName');
        signupNewsletter(txtName, txtEmail);
        return false;
    }
</script>

