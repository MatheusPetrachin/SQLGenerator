using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using SQLGenerator.Models;

namespace SQLGenerator
{
    public class SQLGenerator<T> where T : IGenerateSQL  
    {        
        private static readonly string basePath = Directory.GetCurrentDirectory();
        public void SQLGeneratorHandler()
        {
            string tableName = SQLGeneratorHelper.GetTableName(typeof(T));
            List<string> columnNames = SQLGeneratorHelper.GetColumnNames(typeof(T));            
            List<string> values = new List<string> { $"INSERT INTO {tableName} VALUES ({string.Join(", ", columnNames.Select(x => x))})" };

            var xls = new XLWorkbook(Path.Combine(basePath, @"Temp/Excel.xlsx"));
            var spreadsheet = xls.Worksheets.First(w => w.Name == "Planilha1");
            var totalOfLines = spreadsheet.Rows().Count();

            var instance = (T)Activator.CreateInstance(typeof(T));

            values.AddRange(instance.GenerateSQLInsert(spreadsheet, totalOfLines));

            CreateSQLArchive(values);
        }

        public static void CreateSQLArchive(List<string> values)
        {
            try
            {
                using (var fs = new FileStream(Path.Combine(basePath, @"Temp\SQL.sql"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var fw = new StreamWriter(fs))
                    {
                        values.ForEach(x =>
                        {
                            fw.WriteLine(x);
                        });

                        fw.Flush();
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("ERROR THROWN");
            }
        }
    }
}
