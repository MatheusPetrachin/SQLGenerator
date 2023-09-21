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

            string[] files = Directory.GetFiles(Path.Combine(basePath, @$"Temp\Excel\"));
            var fileNamesWithPrefix = files.Where(arquivo => Path.GetFileNameWithoutExtension(arquivo.ToLower()).StartsWith(tableName.ToLower())).Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();

            foreach (string fileName in fileNamesWithPrefix)
            {
                List<string> values = new List<string> { $"INSERT INTO {tableName} ({string.Join(", ", columnNames.Select(x => x))}) VALUES" };

                var xls = new XLWorkbook(Path.Combine(basePath, @$"Temp/Excel/{fileName}.xlsx"));
                var spreadsheet = xls.Worksheets.First(w => w.Name == "Planilha1");
                var totalOfLines = spreadsheet.Rows().Count();

                var instance = (T)Activator.CreateInstance(typeof(T));

                values.AddRange(instance.GenerateSQLInsert(spreadsheet, totalOfLines));

                CreateSQLArchive(values, fileName);
            }
        }

        public static void CreateSQLArchive(List<string> values, string table)
        {
            try
            {
                foreach (string f in Directory.GetFiles(Path.Combine(basePath, @$"Temp\SQL"), $"INSERT_{table}.sql"))
                    File.Delete(f);

                using (var fs = new FileStream(Path.Combine(basePath, @$"Temp\SQL\INSERT_{table}.sql"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var fw = new StreamWriter(fs))
                    {
                        values.ForEach(x =>
                        {
                            fw.WriteLine(x);
                        });
                        fw.WriteLine("ON CONFLICT DO NOTHING;");
                        fw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRRO] - {ex.Message}");
            }
        }
    }
}
