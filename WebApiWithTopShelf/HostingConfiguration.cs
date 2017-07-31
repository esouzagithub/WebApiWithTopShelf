using System;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace WebApiWithTopShelf {
    public class HostingConfiguration : ServiceControl {

        private IDisposable _webApplication;
        public bool Start(HostControl hostControl) {
            Console.WriteLine("Iniciando o serviço");
            _webApplication = WebApp.Start<Startup>("http://localhost:8080");
            Console.WriteLine("Serviço Iniciado");
            return true;
        }
        public bool Stop(HostControl hostControl) {
            Console.WriteLine("Terminando o serviço");
            _webApplication.Dispose();
            Console.WriteLine("Serviço terminado");
            return true;
        }
    }
}
