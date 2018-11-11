using System.Web.Http;
using ERA.Externals.DI;
using ERA.PermanentContractSalaryCalculation.WebApi.App_Start;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.ContentTypes;
using Autofac.Integration.WebApi;
using Owin;

namespace ERA.PermanentContractSalaryCalculation.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);

            appBuilder.UseWebApi(httpConfiguration);

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(AutofacContainer.Container);

            //SetStaticFilesHosting(appBuilder);
        }

        // to nie dziala ..:(
        private void SetStaticFilesHosting(IAppBuilder appBuilder)
        {
            var staticFilesPath = @".\Website\UI";

            var contentTypeProvider = new FileExtensionContentTypeProvider();
            contentTypeProvider.Mappings[".json"] = "application/json";

            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                StaticFileOptions = { ContentTypeProvider = contentTypeProvider },
                DefaultFilesOptions = { DefaultFileNames = { @"index.html" } }
            };

            options.FileSystem = new PhysicalFileSystem(staticFilesPath);
            appBuilder.UseFileServer(options);
        }
    }
}