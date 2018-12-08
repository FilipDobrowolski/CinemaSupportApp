using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Owin;
using System.Web.Http;

namespace CinemaSupportWeb
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {


    }
    public static void Register(HttpConfiguration config)
    {
      // Web API routes
      config.MapHttpAttributeRoutes();

    }
  }
}
