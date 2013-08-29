using ServiceStack.Logging;
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
            //LogManager.LogFactory = new EventLogFactory("ServiceStack.Logging.Tests", "Application"); // Logs to the Event Log
            ILog log = LogManager.GetLogger(GetType());
            //Looks strange when the name is null so we replace with a generic name.
            string name = request.Name ?? "World!";
            string HelloWorldResult = "Hello " + name;
            log.InfoFormat("HelloWorldService - Name: {0}", name);
            log.InfoFormat("Response: {0}", HelloWorldResult);
            return new HelloWorldResponse { Result = HelloWorldResult };
        }
    }
}