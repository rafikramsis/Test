using System;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Net;
using System.IO;

public class Utilities
{
    #region Properties

    public static string WebsiteUrl
    {
        get
        {
            return WebConfigurationManager.AppSettings["WebsiteUrl"];
        }
    }

    public static int DefaultLanguage
    {
        get
        {
            return Convert.ToInt32(WebConfigurationManager.AppSettings["DefaultLanguage"]);
        }
    }

    public static int CurrentLanguage
    {
        get
        {
            if (HttpContext.Current.Session["CurrentLanguage"] == null)
                HttpContext.Current.Session["CurrentLanguage"] = DefaultLanguage;

            return Convert.ToInt32(HttpContext.Current.Session["CurrentLanguage"]);
        }
    }

    public static string FrontendVirtualPath
    {
        get
        {
            return WebConfigurationManager.AppSettings["FrontendVirtualPath"];
        }
    }

    public static string FrontendPhysicalPath
    {
        get
        {
            return WebConfigurationManager.AppSettings["FrontendPhysicalPath"];
        }
    }

    #endregion

    /// <summary>
    /// Returns the first 5 characters of a GUID as a random string.
    /// </summary>
    /// <returns></returns>
    public static string GetRandomString()
    {
        return Guid.NewGuid().ToString().Substring(0, 5);
    }

    public static string Truncate(string text, int length)
    {
        return Truncate(text, length, true);
    }
    public static string Truncate(string text, int length, bool appendTrailingDots)
    {
        if (String.IsNullOrEmpty(text))
            return String.Empty;
        else if (text.Length > length)
        {
            int spaceIndex = text.IndexOf(' ', length);
            if (spaceIndex > -1)
                return text.Substring(0, spaceIndex) + (appendTrailingDots? "..." : string.Empty);
            else
                return text;
        }
        else
            return text;
    }

    public static string TextToListItems(string text)
    {
        string[] items = text.Replace("<br/>", "|").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new StringBuilder(items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            sb.Append("<li>").Append(items[i]).Append("</li>");
        }
        return sb.ToString();
    }

    public static string TruncateListItems(string text, int count, int maximumCharacters)
    {
        // clean up a bit
        text = text.Replace("<p>", string.Empty).Replace("</p>", string.Empty).Replace("<br /><br />", "<br />"); ;
        string[] items;
        if (text.IndexOf("<li>") == -1)
            items = text.Replace("<br />", "|").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        else
        {
            text = text.Replace("<ul>", string.Empty).Replace("</ul>", string.Empty);
            items = text.Replace("<li>", "|").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        StringBuilder sb = new StringBuilder(items.Length);
        int totalChars = 0;
        for (int i = 0; i < count && i < items.Length; i++)
        {
            totalChars += items[i].Length;
            if (maximumCharacters > 0 && totalChars > maximumCharacters)
            {
                break;
            }
            if (items[i].Trim().Length > 0)
                sb.Append("<li>").Append(items[i]).Append("</li>");
        }
        return sb.ToString();
    }

    public string DownloadWebPage(string Url)
    {
        // Open a connection
        HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(Url);

        // You can also specify additional header values like 
        // the user agent or the referer:
        WebRequestObject.UserAgent = ".NET Framework/2.0";
        WebRequestObject.Referer = "http://www.FunkGurus.com/";

        // Request response:
        WebResponse Response = WebRequestObject.GetResponse();

        // Open data stream:
        Stream WebStream = Response.GetResponseStream();

        // Create reader object:
        StreamReader Reader = new StreamReader(WebStream);

        // Read the entire stream content:
        string PageContent = Reader.ReadToEnd();

        // Cleanup
        Reader.Close();
        WebStream.Close();
        Response.Close();

        return PageContent;
    }
}
