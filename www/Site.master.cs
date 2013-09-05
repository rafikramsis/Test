using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    public int LanguageId
    {
        get
        {
            return Thread.CurrentThread.CurrentUICulture.LCID;
        }
    }

    public int DefaultLanguageId
    {
        get
        {
            return 2057;
        }
    }

    public string TwoLetterISOLanguageName
    {
        get
        {
            string isoName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower();
            return isoName == "en" ? string.Empty : isoName;
        }
    }

    StringBuilder sb = new StringBuilder();

    string emptyLink = "javascript:{}";
    protected void Page_Load(object sender, EventArgs e)
    {
        //setup language Links

        // get the url of other language flags
        StringBuilder url = new StringBuilder(Request.RawUrl.ToLower());
        url = url.Replace("/de/", string.Empty)
                 .Replace("/ru/", string.Empty);

        string queryString = Request.Url.Query;

        //remove any query string
        string pathToTranslate = url.ToString();
        int i = pathToTranslate.IndexOf('?');
        if (i > -1)
        {
            pathToTranslate = pathToTranslate.Substring(0, i);
        }
        if (Request.IsLocal)
        {
            pathToTranslate = pathToTranslate.Replace("/www", string.Empty).Replace(".aspx", string.Empty).Replace("default", string.Empty);
        }
        queryString = (queryString.Length > 0) ? "?" + queryString.Replace("?", "") : string.Empty;
        if (!(pathToTranslate.Replace("/", string.Empty).Length == 2))
        {
            lnkEnglish.HRef = string.Format("~/{0}{1}", pathToTranslate, queryString);

            lnkRussian.HRef = string.Format("~/ru/{0}{1}", pathToTranslate, queryString);
        }

        if (Thread.CurrentThread.CurrentUICulture.Name.Length > 0)
        {
            string language = Thread.CurrentThread.CurrentUICulture.Name;



            switch (language)
            {
                case "ru-RU":

                    lnkRussian.HRef = emptyLink;
                    lnkRussian.Attributes["class"] = "selected";
                    lnkEnglish.Attributes["class"] = "";
                    //spnActiveLanguage.InnerText = "Русский";
                    break;
                default:
                    lnkEnglish.HRef = emptyLink;
                    lnkEnglish.Attributes["class"] = "selected";
                    lnkRussian.Attributes["class"] = "";
                    //spnActiveLanguage.InnerText = "English";
                    break;
            }
        }
    }

    protected string GetLocalizedUrl(string path)
    {
        if (path.StartsWith("~/"))
            path = path.Replace("~/", "");
        try
        {
            string prefix = (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en" ? string.Empty : Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
            if (path.Contains('/'))
            {
                string url = "~/" + prefix + "/";
                url += path;
                return ResolveUrl(url);
            }
            return ResolveUrl(string.Format("~/{0}/{1}", prefix, path));

        }
        catch
        {
            // return the same path untranslated if no resources found
            return path;
        }
    }
}
