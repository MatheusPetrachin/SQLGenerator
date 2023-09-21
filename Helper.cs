using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

namespace SQLGenerator
{
    public static class SQLGeneratorHelper
    {
        public static string GetTableName(Type type)
        {
            var tableName = type.Name.ToLower();
            Console.WriteLine($"Table Name: {tableName}.");
            return tableName;
        }

        public static List<string> GetColumnNames(Type type)
        {
            List<string> columnNames = type.GetProperties().Select(x => x.Name).ToList();
            columnNames.ForEach(name =>
            {
                Console.WriteLine($"Column Name: {name}.");
            });
            return columnNames;
        }

        public static string FormatDate(IXLWorksheet planilha, char column, int line)
        {
            var auxD = planilha.Cell($"{column}{line}").Value.ToString();
            return auxD == null || auxD == "" ? null : auxD.Substring(4, 4) + "-" + auxD.Substring(2, 2) + "-" + auxD.Substring(0, 2);
        }

        public static string ReturnPropValue(string prop)
        {
            return prop == null || prop == "" ? "NULL" : $"'{prop.Replace('\'', '\"')}'";
        }
    }
}
