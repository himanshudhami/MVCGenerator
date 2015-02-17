using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.Common
{
    /// <summary>
    /// 
    /// </summary>
   internal static class Utility
    {
       public static string rootFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="checkForOutputParameter"></param>
        /// <returns></returns>
       public static string CreateParameterString(Column column, bool checkForOutputParameter)
        {
            var parameter = string.Empty;
            switch (column.Type.ToLower())
            {
                case "binary":
                    parameter = "@" + column.Name + " " + column.Type + "(" + GetParameterLength(column) + ")";
                    break;
                case "bigint" :
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "bit":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "char":
                    parameter = "@" + column.Name + " " + column.Type + "(" + GetParameterLength(column) + ")";
                    break;
                case "datetime":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "decimal":
                    if (column.Scale.Length == 0)
                        parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ")";
                    else
                        parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ", " + column.Scale + ")";
                    break;
                case "float":
                    parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ")";
                    break;
                case "image":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "int":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "money":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "nchar":
                    parameter = "@" + column.Name + " " + column.Type + "(" + GetParameterLength(column) + ")";
                    break;
                case "ntext":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "nvarchar":
                    parameter = "@" + column.Name + " " + column.Type + "(" + GetParameterLength(column) + ")";
                    break;
                case "numeric":
                    if (column.Scale.Length == 0)
                        parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ")";
                    else
                        parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ", " + column.Scale + ")";
                    break;
                case "real":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "smalldatetime":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "smallint":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "smallmoney":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "sql_variant":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "sysname":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "text":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "timestamp":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "tinyint":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "varbinary":
                    parameter = "@" + column.Name + " " + column.Type + "(" + GetParameterLength(column) + ")";
                    break;
                case "varchar":
                    parameter = "@" + column.Name + " " + column.Type + "(" + GetParameterLength(column) + ")";
                    break;
                case "uniqueidentifier":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                case "xml":
                    parameter = "@" + column.Name + " " + column.Type;
                    break;
                default:  // Unknow data type
                    throw (new Exception("Invalid SQL Server data type specified: " + column.Type));

            }
            return parameter;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="column"></param>
       /// <returns></returns>
       public static string GetParameterLength(Column column)
       {
           if (column.Length == "-1")
           {
               return "max";
           }
           return column.Length;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="orignalText"></param>
       /// <returns></returns>
       public static string FormatPascalCase(string orignalText)
       {
           return char.ToUpper(orignalText[0]) + orignalText.Substring(1);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="orignalText"></param>
       /// <returns></returns>
       public static string FormatCamelCase(string orignalText)
       {
           return char.ToLower(orignalText[0]) + orignalText.Substring(1);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="DirectoryPath"></param>
       /// <param name="deleteIfExists"></param>
       public static void CreateSubDirectory(string DirectoryPath, bool deleteIfExists)
       {
           if (deleteIfExists)
           {
               if (Directory.Exists(DirectoryPath))
               {
                   Directory.Delete(DirectoryPath, true);
               }
           }
           Directory.CreateDirectory(DirectoryPath);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="databaseName"></param>
       /// <returns></returns>
       public static string CreateTableQuery(string databaseName)
       {
           
           return GetResourceAsString(rootFolderPath+ "\\Resource\\TableQuery.sql", "#DatabaseName#", databaseName);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="tableName"></param>
       /// <returns></returns>
       public static string CreateColumnQuery(string tableName)
       {
           return GetResourceAsString(rootFolderPath + "\\Resource\\ColumnQuery.sql", "#TableName#", tableName);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="path"></param>
       /// <param name="oldName"></param>
       /// <param name="newName"></param>
       /// <returns></returns>
       public static string GetResourceAsString(string path, string oldName, string newName)
       {
           using (var stream = new StreamReader(path))
           {
               return stream.ReadToEnd().Replace(oldName, newName);
           }
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="path"></param>
       /// <returns></returns>
       public static string GetResourceAsString(string path)
       {
           using (var stream = new StreamReader(path))
           {
               return stream.ReadToEnd();
           }
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="connection"></param>
       /// <param name="tableName"></param>
       /// <returns></returns>
       public static DataTable GetPrimaryKeyList(SqlConnection connection, string tableName)
       {
           SqlParameter parameter;

           using (var command = new SqlCommand("sp_pkeys", connection))
           {
               command.CommandType = CommandType.StoredProcedure;

               parameter = new SqlParameter("@table_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "table_name", DataRowVersion.Current, tableName);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@table_owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "table_owner", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "table_qualifier", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);

               var dataAdapter = new SqlDataAdapter(command);
               DataTable dataTable = new DataTable();
               dataAdapter.Fill(dataTable);

               return dataTable;
           }
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="connection"></param>
       /// <param name="tableName"></param>
       /// <returns></returns>
       public static DataTable GetForeignKeyList(SqlConnection connection, string tableName)
       {
           SqlParameter parameter;

           using (SqlCommand command = new SqlCommand("sp_fkeys", connection))
           {
               command.CommandType = CommandType.StoredProcedure;

               parameter = new SqlParameter("@pktable_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "pktable_name", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@pktable_owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "pktable_owner", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@pktable_qualifier", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "pktable_qualifier", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@fktable_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "fktable_name", DataRowVersion.Current, tableName);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@fktable_owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "fktable_owner", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);
               parameter = new SqlParameter("@fktable_qualifier", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "fktable_qualifier", DataRowVersion.Current, DBNull.Value);
               command.Parameters.Add(parameter);

               SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
               DataTable dataTable = new DataTable();
               dataAdapter.Fill(dataTable);

               return dataTable;
           }
       }

       public static string CreateMethodParameter(Column column)
       {
           return GetCsType(column) + " " + FormatCamelCase(column.Name);
       }

       /// <summary>
       /// Creates the name of the method to call on a SqlDataReader for the specified column.
       /// </summary>
       /// <param name="column">The column to retrieve data for.</param>
       /// <returns>The name of the method to call on a SqlDataReader for the specified column.</returns>
       public static string GetCsType(Column column)
       {
           switch (column.Type.ToLower())
           {
               case "binary":
                   return "byte[]";
               case "bigint":
                   return "long";
               case "bit":
                   return "bool";
               case "char":
                   return "string";
               case "datetime":
                   return "DateTime";
               case "decimal":
                   return "decimal";
               case "float":
                   return "float";
               case "image":
                   return "byte[]";
               case "int":
                   return "int";
               case "money":
                   return "decimal";
               case "nchar":
                   return "string";
               case "ntext":
                   return "string";
               case "nvarchar":
                   return "string";
               case "numeric":
                   return "decimal";
               case "real":
                   return "decimal";
               case "smalldatetime":
                   return "DateTime";
               case "smallint":
                   return "short";
               case "smallmoney":
                   return "float";
               case "sql_variant":
                   return "byte[]";
               case "sysname":
                   return "string";
               case "text":
                   return "string";
               case "timestamp":
                   return "DateTime";
               case "tinyint":
                   return "byte";
               case "varbinary":
                   return "byte[]";
               case "varchar":
                   return "string";
               case "uniqueidentifier":
                   return "Guid";
               case "xml":
                   return "string";
               default:  // Unknow data type
                   throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
           }
       }

       public static string GetGetMethod(Column column)
       {
           switch (column.Type.ToLower())
           {
               case "binary":
                   return "GetBytes";
               case "bigint":
                   return "GetInt64";
               case "bit":
                   return "GetBoolean";
               case "char":
                   return "GetString";
               case "datetime":
                   return "GetDateTime";
               case "decimal":
                   return "GetDecimal";
               case "float":
                   return "GetFloat";
               case "image":
                   return "GetBytes";
               case "int":
                   return "GetInt32";
               case "money":
                   return "GetDecimal";
               case "nchar":
                   return "GetString";
               case "ntext":
                   return "GetString";
               case "nvarchar":
                   return "GetString";
               case "numeric":
                   return "GetDecimal";
               case "real":
                   return "GetDecimal";
               case "smalldatetime":
                   return "GetDateTime";
               case "smallint":
                   return "GetIn16";
               case "smallmoney":
                   return "GetFloat";
               case "sql_variant":
                   return "GetBytes";
               case "sysname":
                   return "GetString";
               case "text":
                   return "GetString";
               case "timestamp":
                   return "GetDateTime";
               case "tinyint":
                   return "GetByte";
               case "varbinary":
                   return "GetBytes";
               case "varchar":
                   return "GetString";
               case "uniqueidentifier":
                   return "GetGuid";
               case "xml":
                   return "GetString";
               default:  // Unknow data type
                   throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
           }
       }

       /// <summary>
       /// Creates a string for the default value of a column's data type.
       /// </summary>
       /// <param name="column">The column to get a default value for.</param>
       /// <returns>The default value for the column.</returns>
       public static string GetDefaultValue(Column column)
       {
           switch (column.Type.ToLower())
           {
               case "binary":
                   return "new byte[0]";
               case "bigint":
                   return "0";
               case "bit":
                   return "false";
               case "char":
                   return "String.Empty";
               case "datetime":
                   return "new DateTime(0)";
               case "decimal":
                   return "Decimal.Zero";
               case "float":
                   return "0.0F";
               case "image":
                   return "new byte[0]";
               case "int":
                   return "0";
               case "money":
                   return "Decimal.Zero";
               case "nchar":
                   return "String.Empty";
               case "ntext":
                   return "String.Empty";
               case "nvarchar":
                   return "null";
               case "numeric":
                   return "Decimal.Zero";
               case "real":
                   return "Decimal.Zero";
               case "smalldatetime":
                   return "DateTime.Now";
               case "smallint":
                   return "0";
               case "smallmoney":
                   return "0.0F";
               case "sql_variant":
                   return "new byte[0]";
               case "sysname":
                   return "null";
               case "text":
                   return "null";
               case "timestamp":
                   return "DateTime.Now";
               case "tinyint":
                   return "0x00";
               case "varbinary":
                   return "new byte[0]";
               case "varchar":
                   return "null";
               case "uniqueidentifier":
                   return "Guid.Empty";
               case "xml":
                   return "null";
               default:  // Unknow data type
                   throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
           }
       }

       public static string CreateSqlParameter(Table table, Column column)
       {
           string className = Utility.FormatPascalCase(table.Name);
           string variableName = Utility.FormatCamelCase(className);

           if (column.Type == "xml")
           {
               return "new SqlParameter(\"@" + column.Name + "\", SqlDbType.Xml) { Value = " + variableName + "." + FormatPascalCase(column.Name) + " }";
           }
           else
           {
               return "new SqlParameter(\"@" + column.Name + "\", " + variableName + "." + FormatPascalCase(column.Name) + ")";
           }
       }
    }
}
