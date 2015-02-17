using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Common;

namespace CodeGenerator.API
{
   public class ApiGenerator
    {
       private string path { get; set; }
       private List<Table> tables { get; set; }
       private string connectionString { get; set; }
       private string projectName { get; set; }
       private string namespceName { get; set; }

       private string App_StartPath;
       private string binPath;
       private string ControllersPath;
       private string ModelsPath;
       private string PropertiesPath;
       private string apiPath;

       public ApiGenerator(string path, List<Table> tables, string connectionString, string projectName, string namespceName)
       {
           this.path = path;
           this.tables = tables;
           this.connectionString = connectionString;
           this.projectName = projectName+".API";
           this.namespceName = namespceName+".API";
       }

       public void Generate()
       {
           apiPath = Path.Combine(path, "API");
           Utility.CreateSubDirectory(apiPath, true);
           App_StartPath = Path.Combine(apiPath, "App_Start");
            Utility.CreateSubDirectory(App_StartPath, true);
            generatorApp_StartFiles(App_StartPath);

            //generatorPackagesConfig();

            binPath = Path.Combine(apiPath, "bin");
            Utility.CreateSubDirectory(binPath, true);

            

            ModelsPath = Path.Combine(apiPath, "Models");
            Utility.CreateSubDirectory(ModelsPath, true);
            ModelGenerator.GenreateEntity(ModelsPath,tables,namespceName);
            CSGenerator.GenerateUtilFile(ModelsPath,namespceName);
            ModelGenerator.GenreateModelLogic(ModelsPath, tables, namespceName);

            ControllersPath = Path.Combine(apiPath, "Controllers");
            Utility.CreateSubDirectory(ControllersPath, true);
            ControllerGenerator.GenerateController(ControllersPath, tables, namespceName);

            PropertiesPath = Path.Combine(apiPath, "Properties");
            //CsGenerator.CreateAssemblyInfo(PropertiesPath, projectName, "");
            CSGenerator.GenerateConfigFile(apiPath, "API", connectionString);
       }

       private void generatorPackagesConfig()
       {//D:\AV\DataTierGenerator-4.4\AmitGenerator\Resources\api\packages.txt
           using (var streem = new StreamReader(""))
           {

           }
           //string packagesInfo = Utility.GetResource("DataTierGenerator.Resources.packages.txt");
           //File.WriteAllText(Path.Combine(apiPath, "pacakages.config"), packagesInfo);
       }

       private void generatorApp_StartCsCode(string App_StartPath, string className)
       {

           switch (className)
           {
               case "FilterConfig":
                   using (var streamWriter = new StreamWriter(Path.Combine(App_StartPath, className + ".cs")))
                   {
                       streamWriter.WriteLine("using System.Web;");
                       streamWriter.WriteLine("using System.Web.Mvc;");
                       streamWriter.WriteLine();
                       streamWriter.WriteLine("namespace " + namespceName);
                       streamWriter.WriteLine("{");

                       streamWriter.WriteLine("\tpublic class " + className);
                       streamWriter.WriteLine("\t{");
                       streamWriter.WriteLine("\t\tpublic static void RegisterGlobalFilters(GlobalFilterCollection filters)");
                       streamWriter.WriteLine("\t\t{");
                       streamWriter.WriteLine("\t\t\tfilters.Add(new HandleErrorAttribute());");
                       streamWriter.WriteLine("\t\t}");
                       streamWriter.WriteLine("\t}");
                       streamWriter.WriteLine("}");
                   }
                   break;
               case "RouteConfig":
                   using (var streamWriter = new StreamWriter(Path.Combine(App_StartPath, className + ".cs")))
                   {
                       streamWriter.WriteLine("using System;");
                       streamWriter.WriteLine("System.Collections.Generic;");
                       streamWriter.WriteLine("System.Linq;");
                       streamWriter.WriteLine("using System.Web;");
                       streamWriter.WriteLine("using System.Web.Mvc;");
                       streamWriter.WriteLine("System.Web.Routing;");

                       streamWriter.WriteLine();
                       streamWriter.WriteLine("namespace " + namespceName);
                       streamWriter.WriteLine("{");

                       streamWriter.WriteLine("\tpublic class " + className);
                       streamWriter.WriteLine("\t{");

                       streamWriter.WriteLine("\t\tpublic static void RegisterRoutes(RouteCollection routes)");
                       streamWriter.WriteLine("\t\t{");
                       streamWriter.WriteLine("\t\t\t routes.IgnoreRoute(\"{resource}.axd/{*pathInfo}\");");
                       streamWriter.WriteLine("\t\t\t routes.MapRoute(");
                       streamWriter.WriteLine("\t\t\t\t name: \"Default\",");
                       streamWriter.WriteLine("\t\t\t\t url: \"{controller}/{action}/{id}\",");
                       streamWriter.WriteLine("\t\t\t\t defaults: new { controller = \"Home\", action = \"Index\", id = UrlParameter.Optional }");
                       streamWriter.WriteLine("\t\t\t);");

                       streamWriter.WriteLine("\t\t}");
                       streamWriter.WriteLine("\t}");
                       streamWriter.WriteLine("}");
                   }
                   break;
               case "WebApiConfig":
                   using (var streamWriter = new StreamWriter(Path.Combine(App_StartPath, className + ".cs")))
                   {
                       streamWriter.WriteLine("using System;");
                       streamWriter.WriteLine("System.Collections.Generic;");
                       streamWriter.WriteLine("System.Linq;");
                       streamWriter.WriteLine("using System.Web;");
                       streamWriter.WriteLine("using System.Web.Mvc;");
                       streamWriter.WriteLine("System.Web.Routing;");

                       streamWriter.WriteLine();
                       streamWriter.WriteLine("namespace " + namespceName);
                       streamWriter.WriteLine("{");

                       streamWriter.WriteLine("\tpublic class " + className);
                       streamWriter.WriteLine("\t{");

                       streamWriter.WriteLine("\t\t public static void Register(HttpConfiguration config)");
                       streamWriter.WriteLine("\t\t{");

                       streamWriter.WriteLine("\t\t\t config.Routes.MapHttpRoute(");
                       streamWriter.WriteLine("\t\t\t\t name: \"Default\",");
                       streamWriter.WriteLine("\t\t\t\t routeTemplate: \"api/{controller}/{id}\",");
                       streamWriter.WriteLine("\t\t\t\t defaults: new { id = RouteParameter.Optional }");
                       streamWriter.WriteLine("\t\t\t);");

                       streamWriter.WriteLine("\t\t}");
                       streamWriter.WriteLine("\t}");
                       streamWriter.WriteLine("}");
                   }
                   break;
           }
       }
       

        private void generatorApp_StartFiles(string App_StartPath)
        {
            generatorApp_StartCsCode(App_StartPath, "FilterConfig");
            generatorApp_StartCsCode(App_StartPath, "RouteConfig");
            generatorApp_StartCsCode(App_StartPath, "WebApiConfig");
        }
    }
}
