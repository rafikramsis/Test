<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);

    }

    void RegisterRoutes(RouteCollection routes)
    {
        //About Us
        RouteTable.Routes.MapPageRoute("about", "about", "~/about-us.aspx");

        //Contact Us
        RouteTable.Routes.MapPageRoute("contact", "contact", "~/contact-us.aspx");

        //Russian 
        //home page
        RouteTable.Routes.MapPageRoute("ru-homepage", "ru", "~/default.aspx");
        
        //Sample Route
        //RouteTable.Routes.MapPageRoute("products", "products/{productId}", "~/products.aspx");

    }
    
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

</script>
