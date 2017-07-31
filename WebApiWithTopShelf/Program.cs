using Topshelf;

namespace WebApiWithTopShelf {
    class Program {
        static void Main(string[] args) {

            HostFactory.Run(x => {
                x.Service<HostingConfiguration>();
                x.RunAsLocalSystem();
                x.SetDescription("Owin with Webapi as Windows service");
                x.SetDisplayName("selfhost.owin.webapi");
                x.SetServiceName("selfhost.owin.webapi");
            });
        }
    }
}
