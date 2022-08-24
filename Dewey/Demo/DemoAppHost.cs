using Funq;
using ServiceStack;

namespace Dewey.Demo
{
    public class DemoAppHost : AppHostBase
    {
        /// <summary>
        /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
        /// </summary>
        public DemoAppHost() : base("Dewey Demo Services", typeof(DemoService).Assembly) { }
        public override void Configure(Container container) { }
    }
}