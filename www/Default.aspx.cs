using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendContact_Click(object sender, EventArgs e)
    {
        //try
        //{    //Al Saraya
            MailManager.SendContactUs(txtName.Value, txtEmail.Value, txtPhone.Value, txtMessage.Value, "New Contact Request From Our Site");
            string script = string.Format("<script type='text/javascript'>alert({0});clearForm();</script>", GetLocalResourceObject("SentSuccessfully"));
            ClientScript.RegisterClientScriptBlock(GetType(), "Done", script);
		//}
		//catch
		//{
		//	string script = string.Format("<script type='text/javascript'>alert({0});clearForm();</script>", GetLocalResourceObject("SendFiled"));
		//	ClientScript.RegisterClientScriptBlock(GetType(), "Error", script);
		//	Server.ClearError();
		//}

    }
}