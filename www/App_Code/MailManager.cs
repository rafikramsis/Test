using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.IO;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Linq;
using System.Web.Configuration;

public class MailManager
{
    public static void SendMail(string messageTemplateFileName, Dictionary<string, string> keysValuePairCollection, string subject, string toAddress,
        string cc = "", string replyTo = "")
    {
        string templatePath = HttpContext.Current.Server.MapPath("~/App_Data/MailTemplates/" + messageTemplateFileName);
        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException("Message Template File Not Found");
        }
        StringBuilder sbTemplate = new StringBuilder(File.ReadAllText(templatePath));

        string key = string.Empty;
        foreach (KeyValuePair<string, string> keyValuePair in keysValuePairCollection)
        {
            key = "#" + keyValuePair.Key + "#";

            if (!sbTemplate.ToString().Contains(key))
                throw new System.Exception(string.Format("this key - {0} - does not exist in the current template", key));

            sbTemplate = sbTemplate.Replace(key, keyValuePair.Value);
        }

        //Create Mail Message Object with content that you want to send with mail.
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmail"]);

        if (toAddress.Contains(","))
        {
            var _toAddress = toAddress.Split(new char[] { ',' });
            foreach (string address in _toAddress)
            {
                mailMessage.To.Add(address);
            }
        }
        else
        {
            mailMessage.To.Add(toAddress);
        }

        mailMessage.Subject = subject;
        mailMessage.Body = sbTemplate.ToString();
        if (!string.IsNullOrEmpty(cc))
            mailMessage.CC.Add(cc);
        mailMessage.IsBodyHtml = true;
        if (!string.IsNullOrEmpty(replyTo))
        {
            mailMessage.ReplyToList.Add(replyTo);
        }

        //NetworkCredential mailAuthentication = new NetworkCredential(FromAddress, FromPassword);
        //System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(SmptServer, SmtpPort);

        ////Enable SSL
        //mailClient.EnableSsl = true;
        //mailClient.UseDefaultCredentials = false;
        //mailClient.Credentials = mailAuthentication;

        // Send
        SmtpClient mailClient = new SmtpClient();
        mailClient.Send(mailMessage);
    }

    public static void SendContactUs(string name, string email, string phone, string message, string subject)
    {
        string toAddress = WebConfigurationManager.AppSettings["ContactUsEmail"];
        Dictionary<string, string> keysValues = new Dictionary<string, string>();

        keysValues.Add("Name", name);
        keysValues.Add("Email", email);
        keysValues.Add("Phone", phone);
        keysValues.Add("Message", message);

        MailManager.SendMail("contact-us.html", keysValues, subject, toAddress, "rafikramsis@gmail.com");
    }


    #region Bulk Mail

    private static void SendBulkMail(string messageTemplateFileName, Dictionary<string, string> keysValuePairCollection, List<string> mailList, string subject, string replyTo = "")
    {
        // create message body
        string templatePath = HttpContext.Current.Server.MapPath("~/App_Data/MailTemplates/" + messageTemplateFileName);
        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException("Message Template File Not Found");
        }
        StringBuilder sbTemplate = new StringBuilder(File.ReadAllText(templatePath));
        string key = string.Empty;
        foreach (KeyValuePair<string, string> keyValuePair in keysValuePairCollection)
        {
            key = "#" + keyValuePair.Key + "#";

            if (!sbTemplate.ToString().Contains(key))
                throw new System.Exception(string.Format("this key - {0} - does not exist in the current template", key));

            sbTemplate = sbTemplate.Replace(key, keyValuePair.Value);
        }

        // send bulk email
        System.Net.Mail.SmtpClient smtpClient = null;
        //NetworkCredential mailAuthentication = new NetworkCredential(FromAddress, FromPassword);
        MailMessage mailMessage = null;
        Object state = null;
        foreach (string toAddress in mailList)
        {
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmail"]);
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = sbTemplate.ToString();
            mailMessage.IsBodyHtml = true;

            if (!string.IsNullOrEmpty(replyTo))
            {
                mailMessage.ReplyToList.Add(replyTo);
            }

            //smtpClient = new System.Net.Mail.SmtpClient(SmptServer, SmtpPort);
            smtpClient = new SmtpClient();
            state = mailMessage;
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            //Enable SSL
            //smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = mailAuthentication;

            // Send
            smtpClient.SendAsync(mailMessage, state);
        }

    }

    static void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        MailMessage mail = e.UserState as MailMessage;

        if (e.Cancelled || e.Error != null)
        {
            LogNotification(string.Format("Error while sending mail to {0} on {1}", mail.To[0].Address, DateTime.Now));
        }
        else
        {
            LogNotification(string.Format("Mail sent successfully to {0} on {1}", mail.To[0].Address, DateTime.Now));

        }
    }

    static private void LogNotification(string message)
    {
        string logPath = HttpContext.Current.Server.MapPath("~/App_Data/maillog.txt");
        using (StreamWriter sw = new StreamWriter(logPath, true))
        {
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }
    }

    #endregion
}