using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Common;

namespace CodeGenerator.API
{
   public static class ModelGenerator
    {
       private static string entityPath;
        public static void GenreateEntity(string ModelsPath, List<Common.Table> tables, string nameSpaceName)
        {
            entityPath = Path.Combine(ModelsPath, "Entity");
            Utility.CreateSubDirectory(entityPath, true);

            foreach (var table in tables)
            {
                CSGenerator.generateEntity(table, entityPath, nameSpaceName + ".Models.Entity");
            }

        }

        public static void GenreateModelLogic(string ModelsPath, List<Table> tables, string namespaceName)
        {
            foreach (var table in tables)
            {
                CSGenerator.generateDataAccess(table, ModelsPath, namespaceName + ".Models", "API");
            }
        }
    }
}
