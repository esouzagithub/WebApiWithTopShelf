using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace WebApiWithTopShelf {
    public class Startup {

        /// <summary>
        /// Método de configuração
        /// </summary>
        /// <param name="appBuilder">Componente de contrução da aplicação</param>
        public static void Configuration(IAppBuilder appBuilder) {
            // Configure Web API for self-host.
            var config = new HttpConfiguration();

            //Limpa formatação
            config.Formatters.Clear();
            //Define o tipo de mídia
            config.Formatters.Add(new JsonMediaTypeFormatter());
            //Define o formatador
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings {
                //Tipo de formação
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                //Ignora valores nulos
                NullValueHandling = NullValueHandling.Ignore
            };

            //Com identação
            config.Formatters.JsonFormatter.Indent = true;

            //Define atributos
            config.MapHttpAttributeRoutes();

            //Mapeia as rotas padrão
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
