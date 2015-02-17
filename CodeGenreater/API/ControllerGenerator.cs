using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Common;

namespace CodeGenerator.API
{
   public class ControllerGenerator
    {
       public static string entityNameSpace = string.Empty;
        public static void GenerateController(string ControllersPath, List<Common.Table> tables, string nameSpaceName)
        {
            entityNameSpace = nameSpaceName + ".Models.Entity";
            foreach (var table in tables)
            {
                var className = Utility.FormatPascalCase(table.Name);
                
                var variableName = Utility.FormatCamelCase(table.Name);
                using (var streamWriter = new StreamWriter(Path.Combine(ControllersPath, className + "Controller.cs")))
                {
                    
                    streamWriter.WriteLine("using System;");
                    streamWriter.WriteLine("using System.Collections.Generic;");
                    streamWriter.WriteLine("using System.Linq;");
                    streamWriter.WriteLine("using System.Net;");
                    streamWriter.WriteLine("using System.Net.Http;");
                    streamWriter.WriteLine("using System.Web.Http;");
                    streamWriter.WriteLine("using " + nameSpaceName + ".Models;");
                    //streamWriter.WriteLine("using " + nameSpaceName + ".Models.Entity;");
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("namespace "+nameSpaceName+".Controllers");
                    streamWriter.WriteLine("{");

                    streamWriter.WriteLine("\t/// <summary>");
                    streamWriter.WriteLine("\t/// Gets or sets the " + className + " controller.");
                    streamWriter.WriteLine("\t/// </summary>");

                    streamWriter.WriteLine("\tpublic class " + className + "Controller : ApiController");
                    streamWriter.WriteLine("\t{");
                    streamWriter.WriteLine("\t\t"+className + " " + variableName + " = new " + className + "();");
                    streamWriter.WriteLine();
                    genreateGetAllMethod(table, streamWriter, className, variableName);
                    genreateGetMethod(table, streamWriter, className, variableName);
                    genreatePostMethod(table, streamWriter, className, variableName);
                    //genreatePutMethod(table, streamWriter, className, variableName);
                    genreateDeleteMethod(table, streamWriter, className, variableName);
                    streamWriter.WriteLine("\t}");
                    streamWriter.WriteLine("}");
                }
            }
        }

        private static void genreateDeleteMethod(Table table, StreamWriter streamWriter, string className, string variableName)
        {
            streamWriter.WriteLine("\t\tpublic void Delete(");
            for (int i = 0; i < table.PrimaryKeys.Count; i++)
            {
                Column column = table.PrimaryKeys[i];
                streamWriter.Write(Utility.CreateMethodParameter(column));
                if (i < (table.PrimaryKeys.Count - 1))
                {
                    streamWriter.Write(", ");
                }
            }
            streamWriter.Write(")");

            streamWriter.WriteLine("\t\t{");
            streamWriter.Write("\t\t\t " + variableName + ".Delete(");
            for (int i = 0; i < table.PrimaryKeys.Count; i++)
            {
                Column column = table.PrimaryKeys[i];
                streamWriter.Write(Utility.FormatCamelCase(column.Name));
                if (i < (table.PrimaryKeys.Count - 1))
                {
                    streamWriter.Write(", ");
                }
            }
            streamWriter.WriteLine(");");
            streamWriter.WriteLine("\t\t}");
            streamWriter.WriteLine();
        }

        private static void genreatePostMethod(Table table, StreamWriter streamWriter, string className, string variableName)
        {
            streamWriter.WriteLine("\t\tpublic void Post([FromBody] " + entityNameSpace + "." + className + " Entity" + variableName + ")");
            streamWriter.WriteLine("\t\t{");
            streamWriter.WriteLine("\t\t\t" + variableName + ".Save(Entity" + variableName + ");");
            streamWriter.WriteLine("\t\t}");
            streamWriter.WriteLine();
        }

        private static void genreateGetAllMethod(Table table, StreamWriter streamWriter, string className, string variableName)
        {
            streamWriter.WriteLine("\t\tpublic IEnumerable<" + entityNameSpace + "." + className + "> Get()");
            streamWriter.WriteLine("\t\t{");
            streamWriter.WriteLine("\t\t\treturn " + variableName + ".GetAll();");
            streamWriter.WriteLine("\t\t}");
            streamWriter.WriteLine();
        }

        private static void genreateGetMethod(Table table, StreamWriter streamWriter, string className, string variableName)
        {
            streamWriter.WriteLine("\t\tpublic " + entityNameSpace + "." + className + " Get(");
            for (int i = 0; i < table.PrimaryKeys.Count; i++)
            {
                Column column = table.PrimaryKeys[i];
                streamWriter.Write(Utility.CreateMethodParameter(column));
                if (i < (table.PrimaryKeys.Count - 1))
                {
                    streamWriter.Write(", ");
                }
            }
            streamWriter.Write(")");

            streamWriter.WriteLine("\t\t{");
            streamWriter.Write("\t\t\treturn " + variableName + ".Get(");
            for (int i = 0; i < table.PrimaryKeys.Count; i++)
            {
                Column column = table.PrimaryKeys[i];
                streamWriter.Write(Utility.FormatCamelCase(column.Name));
                if (i < (table.PrimaryKeys.Count - 1))
                {
                    streamWriter.Write(", ");
                }
            }
            streamWriter.WriteLine(");");
            streamWriter.WriteLine("\t\t}");
            streamWriter.WriteLine();
        }

    }
}
