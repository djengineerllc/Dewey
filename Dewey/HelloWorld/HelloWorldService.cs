using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.HelloWorld
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class HelloWorldService : IService
    {
        public object Any(HelloWorld request)
        {
            //Looks strange when the name is null so we replace with a generic name.
            var name = request.Name ?? "World!";
            return new HelloWorldResponse { Result = "Hello " + name };
        }
    }
}