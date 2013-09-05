using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Threading;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

	public WebService()
	{
	}

	public int LanguageId
	{
		get
		{
			return Thread.CurrentThread.CurrentUICulture.LCID;
		}
	}



	public static void SendEmail(string fromEmail, string toEmail, string subject, string totalMessage)
	{
		System.Net.Mail.MailMessage Emailmessage = new System.Net.Mail.MailMessage(fromEmail, toEmail, subject, totalMessage.ToString());
		Emailmessage.IsBodyHtml = true;

		System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
		client.Send(Emailmessage);

	}


}