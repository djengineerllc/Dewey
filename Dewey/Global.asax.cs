using Dewey.HelloWorld;
using System;

namespace Dewey
{
    public class Global : System.Web.HttpApplication
    {

        //Initialize your application
        protected void Application_Start(object sender, EventArgs e) => new HelloWorldAppHost().Init();
        protected void Session_Start(object sender, EventArgs e) { }
        protected void Application_BeginRequest(object sender, EventArgs e) { }
        protected void Application_AuthenticateRequest(object sender, EventArgs e) { }
        protected void Application_Error(object sender, EventArgs e) { }
        protected void Session_End(object sender, EventArgs e) { }
        protected void Application_End(object sender, EventArgs e) { }
    }
}