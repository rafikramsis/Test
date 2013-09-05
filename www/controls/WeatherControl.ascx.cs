using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeatherControl : System.Web.UI.UserControl
{
    public string City { get; set; }
    public string Country { get; set; }
    public string CityTitle { get; set; }
    public string CountryTitle { get; set; }
    public int ForcastingDays { get; set; }
    public string ApiKey { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
