using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Common
{
    /// <summary>
    /// Generates SQL Server stored procedures for a database.
    /// </summary>
    internal static class SPGenerator
    {
        /// <summary>
        /// Creates the "use [database]" statement in a specified file.
        /// </summary>
        /// <param name="databaseName">The name of the database that the login will be created for.</param>
        /// <param name="path">Path where the "use [database]" statement should be created.</param>
        public static void CreateUseDatabaseStatement(string databaseName, string path)
        {
            string fileName = Path.Combine(path, "StoredProcedures.sql");
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.WriteLine("use [{0}]", databaseName);
                streamWriter.WriteLine("go");
            }
        }

        /// <summary>
        /// Writes the "use [database]" statement to the specified stream.
        /// </summary>
        /// <param name="databaseName">The name of the database that the login will be created for.</param>
        /// <param name="streamWriter">StreamWriter to write the script to.</param>
        public static void CreateUseDatabaseStatement(string databaseName, StreamWriter streamWriter)
        {
            streamWriter.WriteLine("use [{0}]", databaseName);
            streamWriter.WriteLine("go");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="table"></param>
        /// <param name="path"></param>
        public static void CreateSetStoredProcedure(string databaseName, Table table, string path)
        {
            // Create the stored procedure name
            string procedureName = "SP_Set" + table.Name;
            string fileName = Path.Combine(path, "StoredProcedures.sql");
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.WriteLine("go");
                streamWriter.WriteLine();
                streamWriter.WriteLine("/******************************************************************************");
                streamWriter.WriteLine("******************************************************************************/");

                // Create the drop statment
                streamWriter.WriteLine(" if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[" + procedureName + "]') and ObjectProperty(id, N'IsProcedure') = 1)");
                streamWriter.WriteLine("\tdrop procedure [dbo].[" + procedureName + "]");
                streamWriter.WriteLine("go");
                streamWriter.WriteLine();

                // Create the SQL for the stored procedure
                streamWriter.WriteLine(" create procedure [dbo].[" + procedureName + "]");
                streamWriter.WriteLine("(");
                var primaryKey = string.Empty;
                
                for (int i = 0; i < table.PrimaryKeys.Count; i++)
                {
                    var column = table.PrimaryKeys[i];
                    if (i == (table.PrimaryKeys.Count - 1))
                    {
                        primaryKey = column.Name;
                    }
                    
                }

                // operate the query
                //streamWriter.WriteLine("@action char,");
                // Create the parameter list
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    var column = table.Columns[i];
                    streamWriter.Write("\t" + Utility.CreateParameterString(column, true));
                    if (i < (table.Columns.Count - 1))
                    {
                        streamWriter.Write(",");
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.WriteLine(")");
                streamWriter.WriteLine(" AS");
                streamWriter.WriteLine(" BEGIN");
                streamWriter.WriteLine();

                // for insert commend.
                streamWriter.WriteLine("if(@" + primaryKey + " = 0)");
                
                #region insertpart
                streamWriter.WriteLine("BEGIN");
                streamWriter.WriteLine("insert into [" + table.Name + "]");
                streamWriter.WriteLine("(");
                // Create the parameter list
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    Column column = table.Columns[i];

                    // Ignore any identity columns
                    if (column.IsIdentity == false)
                    {
                        // Append the column name as a parameter of the insert statement
                        if (i < (table.Columns.Count - 1))
                        {
                            streamWriter.WriteLine("\t[" + column.Name + "],");
                        }
                        else
                        {
                            streamWriter.WriteLine("\t[" + column.Name + "]");
                        }
                    }
                }

                streamWriter.WriteLine(")");
                streamWriter.WriteLine("values");
                streamWriter.WriteLine("(");

                // Create the values list
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    Column column = table.Columns[i];

                    // Is the current column an identity column?
                    if (column.IsIdentity == false)
                    {
                        // Append the necessary line breaks and commas
                        if (i < (table.Columns.Count - 1))
                        {
                            streamWriter.WriteLine("\t@" + column.Name + ",");
                        }
                        else
                        {
                            streamWriter.WriteLine("\t@" + column.Name);
                        }
                    }
                }

                streamWriter.WriteLine(")");

                // Should we include a line for returning the identity?
                foreach (Column column in table.Columns)
                {
                    // Is the current column an identity column?
                    if (column.IsIdentity)
                    {
                        streamWriter.WriteLine();
                        streamWriter.WriteLine("select scope_identity()");
                        break;
                    }
                    else if (column.IsRowGuidCol)
                    {
                        streamWriter.WriteLine();
                        streamWriter.WriteLine("Select @" + column.Name);
                        break;
                    }
                }

                streamWriter.WriteLine("END");
                #endregion
                // for insert commend.
                streamWriter.WriteLine(" ELSE");
                streamWriter.WriteLine("  BEGIN");
                #region update command
                streamWriter.WriteLine();
                streamWriter.WriteLine("UPDATE [" + table.Name + "]");
                streamWriter.Write("SET");

                bool firstLine = true;
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    var column = (Column)table.Columns[i];

                    // Ignore Identity and RowGuidCol columns
                    if (table.PrimaryKeys.Contains(column) == false)
                    {
                        if (firstLine)
                        {
                            streamWriter.Write(" ");
                            firstLine = false;
                        }
                        else
                        {
                            streamWriter.Write("\t");
                        }

                        streamWriter.Write("[" + column.Name + "] = @" + column.Name);

                        if (i < (table.Columns.Count - 1))
                        {
                            streamWriter.Write(",");
                        }

                        streamWriter.WriteLine();
                    }
                }

                streamWriter.Write(" where");

                // Create the where clause
                for (int i = 0; i < table.PrimaryKeys.Count; i++)
                {
                    var column = table.PrimaryKeys[i];

                    if (i == 0)
                    {
                        streamWriter.Write(" [" + column.Name + "] = @" + column.Name);
                    }
                    else
                    {
                        streamWriter.Write("\tand [" + column.Name + "] = @" + column.Name);
                    }
                }

                #endregion
                streamWriter.WriteLine(" end");
                streamWriter.WriteLine(" end");

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="table"></param>
        /// <param name="path"></param>
        public static void CreateGetStoredProcedure(string databaseName, Table table, string path)
        {
            // Create the stored procedure name
            string procedureName = "SP_Get" + table.Name;
            string fileName = Path.Combine(path, "StoredProcedures.sql");
            using (var streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.WriteLine("go");
                streamWriter.WriteLine();
                streamWriter.WriteLine("/******************************************************************************");
                streamWriter.WriteLine("******************************************************************************/");

                // Create the drop statment
                streamWriter.WriteLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[" + procedureName + "]') and ObjectProperty(id, N'IsProcedure') = 1)");
                streamWriter.WriteLine("\tdrop procedure [dbo].[" + procedureName + "]");
                streamWriter.WriteLine("go");
                streamWriter.WriteLine();

                // Create the SQL for the stored procedure
                streamWriter.WriteLine("create procedure [dbo].[" + procedureName + "]");
                streamWriter.WriteLine("(");
                var primaryKey = string.Empty;
                // operate the query
                // Create the parameter list
                for (int i = 0; i < table.PrimaryKeys.Count; i++)
                {
                    var column = table.PrimaryKeys[i];
                    if (i == (table.PrimaryKeys.Count - 1))
                    {
                        streamWriter.WriteLine("\t" + Utility.CreateParameterString(column, false));
                        primaryKey = column.Name;
                    }
                    else
                    {
                        streamWriter.WriteLine("\t" + Utility.CreateParameterString(column, false) + ",");
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.WriteLine(")");
                streamWriter.WriteLine(" AS");
                streamWriter.WriteLine(" BEGIN");
                streamWriter.WriteLine();

                // for insert commend.
                streamWriter.WriteLine("if(@" + primaryKey + " > 0)");
                #region insertpart
                streamWriter.WriteLine("BEGIN");
                streamWriter.WriteLine("SELECT * FROM " + table.Name);
                streamWriter.WriteLine(" WHERE ");
                for (int i = 0; i < table.PrimaryKeys.Count; i++)
                {
                    Column column = table.PrimaryKeys[i];

                    if (i == 0)
                    {
                        streamWriter.WriteLine(" [" + column.Name + "] = @" + column.Name);
                    }
                    else
                    {
                        streamWriter.WriteLine("\tand [" + column.Name + "] = @" + column.Name);
                    }
                }
                streamWriter.WriteLine(" END");
                #endregion
                // for insert commend.
                streamWriter.WriteLine(" ELSE");
                streamWriter.WriteLine(" BEGIN");
                #region update command
                streamWriter.WriteLine(" SELECT * FROM " + table.Name);
                #endregion
                streamWriter.WriteLine(" END");
                streamWriter.WriteLine(" END");

            }

        }

        public static void CreateDeleteStoredProcedure(string databaseName, Table table, string path)
        {
            if (table.PrimaryKeys.Count > 0)
            {
                // Create the stored procedure name
                string procedureName = "SP_Delete" + table.Name;
                string fileName = Path.Combine(path, "StoredProcedures.sql");

                // Determine the file name to be used
                using (StreamWriter streamWriter = new StreamWriter(fileName, true))
                {
                    // Create the "use" statement or the seperator
                    streamWriter.WriteLine("go");
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("/******************************************************************************");
                    streamWriter.WriteLine("******************************************************************************/");

                    // Create the drop statment
                    streamWriter.WriteLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[" + procedureName + "]') and ObjectProperty(id, N'IsProcedure') = 1)");
                    streamWriter.WriteLine("\tdrop procedure [dbo].[" + procedureName + "]");
                    streamWriter.WriteLine("go");
                    streamWriter.WriteLine();

                    // Create the SQL for the stored procedure
                    streamWriter.WriteLine("create procedure [dbo].[" + procedureName + "]");
                    streamWriter.WriteLine("(");

                    // Create the parameter list
                    for (int i = 0; i < table.PrimaryKeys.Count; i++)
                    {
                        Column column = table.PrimaryKeys[i];

                        if (i < (table.PrimaryKeys.Count - 1))
                        {
                            streamWriter.WriteLine("\t" + Utility.CreateParameterString(column, false) + ",");
                        }
                        else
                        {
                            streamWriter.WriteLine("\t" + Utility.CreateParameterString(column, false));
                        }
                    }
                    streamWriter.WriteLine(")");

                    streamWriter.WriteLine();
                    streamWriter.WriteLine("as");
                    streamWriter.WriteLine("begin");
                    streamWriter.WriteLine("set nocount on");
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("delete from [" + table.Name + "]");
                    streamWriter.Write("where");

                    // Create the where clause
                    for (int i = 0; i < table.PrimaryKeys.Count; i++)
                    {
                        Column column = table.PrimaryKeys[i];

                        if (i == 0)
                        {
                            streamWriter.WriteLine(" [" + column.Name + "] = @" + column.Name);
                        }
                        else
                        {
                            streamWriter.WriteLine("\tand [" + column.Name + "] = @" + column.Name);
                        }
                    }

                    streamWriter.WriteLine("end");

                }
            }
        }
    }
}

