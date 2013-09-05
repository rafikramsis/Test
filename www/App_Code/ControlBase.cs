using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using SD.LLBLGen.Pro.ORMSupportClasses;

/// <summary>
/// Summary description for ControlBase
/// </summary>
public abstract class ControlBase : System.Web.UI.UserControl
{
    public ControlBase()
    {
        
    }

    public int LanguageId
    {
        get
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture.LCID;
        }
    }

    protected string GetLocalizedUrl(string path)
    {
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

    // LLBL Methods
    //==============

    protected string GetLocalizedField(object collection, string fieldName)
    {
        int DefaultLanguageId = 2057;
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