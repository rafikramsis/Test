using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Configuration;
using System.Web.UI;
using SD.LLBLGen.Pro.ORMSupportClasses;

public enum NotificationType : int
{
    Success = 0,
    Error = 1,
    Warning = 2
}

public abstract class PageBase : System.Web.UI.Page
{
    protected const int DefaultLanguageId = 2057;
    protected string languageIso = "en";

    public PageBase()
    {
    }

    protected bool ViewStateEnabled
    {
        get
        {
            return Page.EnableViewState;
        }
        set
        {
            Page.EnableViewState = value;
        }
    }


    public int LanguageId
    {
        get
        {
            return Thread.CurrentThread.CurrentUICulture.LCID;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (!CheckQueryStrings())
        {
            // all required query strings have not been specified
            RedirectToPage("Error.aspx");
        }

        if (!CheckQueryStringValues())
        {
            // one or more query string values are invalid
            RedirectToPage("Error.aspx");
        }
    }



    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
    }

    protected override void InitializeCulture()
    {
        //
        string domain = Request.Url.GetComponents(UriComponents.Path, UriFormat.SafeUnescaped);
        string language;
        string[] fragments = domain.Split(new char[] { '/' });
        string culture = "en-GB";
        int fragmentIndex = 0;
        if (Request.RawUrl.Contains("/www"))
            fragmentIndex = 1;
        if (Request.IsLocal)
            language = fragments.ToList()[fragmentIndex];
        else
            language = fragments.First();

        switch (language)
        {
            case "it":
                culture = "it-IT";
                break;
            case "de":
                culture = "de-DE";
                break;
            case "fr":
                culture = "fr-FR";
                break;
            case "ru":
                culture = "ru-RU";
                break;
            default:
                culture = "en-GB";
                break;
        }
        Response.Cookies["SelectedCulture"].Value = culture;
        Response.Cookies["SelectedCulture"].Expires = DateTime.Today.AddYears(1);
        SetCulture(culture);


        Page.Culture = Page.UICulture = culture;
        Page.LCID = new CultureInfo(culture).LCID;

        base.InitializeCulture();
    }

    private void SetCulture(string culture)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

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

   
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    #region Query String Methods

    /// <summary>
    /// When overriden, returns a list of all required query string keys
    /// </summary>
    /// <returns></returns>
    protected virtual List<string> RequiredQueryStrings()
    {
        return null;
    }

    /// <summary>
    /// When overriden, checks the actual values of query strings
    /// </summary>
    /// <returns></returns>
    protected virtual bool CheckQueryStringValues()
    {
        return true;
    }

    /// <summary>
    /// Verifies the required query string are actually present
    /// </summary>
    /// <returns></returns>
    protected bool CheckQueryStrings()
    {
        List<string> values = RequiredQueryStrings();

        if (values == null || values.Count == 0)
        {
            return true;
        }
        else
        {
            foreach (string value in values)
            {
                if (Request.QueryString[value] == null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    #endregion

    #region Redirection Methods

    /// <summary>
    /// Redirects the application to the specified page, and ignores the 
    /// erroneous error that is sometimes thrown
    /// </summary>
    /// <param name="url"></param>
    protected void RedirectToPage(string url)
    {
        try
        {
            Response.Redirect(url);
        }
        catch
        {
            // catch the ThreadAbortException that is occasionally thrown by ASP.NET
        }
    }

    /// <summary>
    /// Redirects to another page and carries over all current 
    /// query string keys and values
    /// </summary>
    /// <param name="url"></param>
    protected void RedirectToPageWithQueryStrings(string url)
    {
        string queryStringList = string.Empty;

        if (!string.IsNullOrEmpty(queryStringList))
        {
            // rebuild the query string list
            for (int i = 0; i < Request.QueryString.Count; i++)
            {
                queryStringList += string.Format("{0}={1}&",
                    Request.QueryString.GetKey(i), Request.QueryString.Get(i));
            }

            // remove the erroneous ampersand
            queryStringList = queryStringList.TrimEnd(new char[] { '&' });

            // append the '?' to the beginning
            if (!string.IsNullOrEmpty(queryStringList))
            {
                url = "?" + queryStringList;
            }

            RedirectToPage(url);
        }
    }

    #endregion

    #region ViewState Methods

    /// <summary>
    /// Retrieves a value from ViewState
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    protected object GetViewStateValue(string key, object defaultValue)
    {
        return ((ViewState[key] == null) ? defaultValue : ViewState[key]);
    }

    /// <summary>
    /// Sets a value in ViewState
    /// </summary>
    /// <param name="key"></param>
    /// <param name="val"></param>
    protected void SetViewStateValue(string key, object val)
    {
        ViewState[key] = val;
    }

    /// <summary>
    /// Clears a value from ViewState
    /// </summary>
    /// <param name="key"></param>
    protected void ClearViewStateValue(string key)
    {
        ViewState[key] = null;
    }

    #endregion

    #region Cache Methods

    /// <summary>
    /// Returns an item from the application cache
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected object GetCachedItem(string key)
    {
        object returnValue = null;

        try
        {
            returnValue = Cache.Get(key);
        }
        catch { }

        return returnValue;
    }

    /// <summary>
    /// Adds in item to the application cache
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="minutes"></param>
    protected void SetCachedItem(string key, object value, int minutes)
    {
        try
        {
            Cache.Insert(key, value, null,
                DateTime.Now.AddMinutes(minutes), TimeSpan.Zero);
        }
        catch { }
    }

    /// <summary>
    /// Clears an item from the application cache
    /// </summary>
    /// <param name="key"></param>
    protected void ClearCachedItem(string key)
    {
        try
        {
            Cache.Remove(key);
        }
        catch { }
    }

    #endregion

    #region Error Logging
	//protected void LogError(Exception ex)
	//{
	//	ErrorSignal.FromCurrentContext().Raise(ex);
	//}
    #endregion

    protected void PageNotFound()
    {
        CustomErrorCollection errorPages = new CustomErrorCollection();
        Response.Redirect(errorPages["404"].Redirect, true);
    }

    protected void AccessDenied()
    {
        CustomErrorCollection errorPages = new CustomErrorCollection();
        Response.Redirect(errorPages["403"].Redirect, true);
    }


    // LLBL Methods
    //==============

    protected string GetLocalizedField(object collection, string fieldName)
    {
        IEntityCollection localizedCollection = (IEntityCollection)collection;
        string defaultLanguageValue = null;
        string selectedLanguageValue = null;

        for (int i = 0; i < localizedCollection.Count; i++)
        {
            if (Convert.ToInt32(localizedCollection[i].GetFieldByName("LanguageId").DbValue) == LanguageId)
            {
                selectedLanguageValue = localizedCollection[i].GetFieldByName(fieldName).CurrentValue.ToString();
            }
            else if (Convert.ToInt32(localizedCollection[i].GetFieldByName("LanguageId").DbValue) == DefaultLanguageId)
            {
                defaultLanguageValue = localizedCollection[i].GetFieldByName(fieldName).CurrentValue.ToString();
            }
        }
        return selectedLanguageValue ?? defaultLanguageValue;
    }

}