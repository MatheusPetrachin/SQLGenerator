using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

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
            columnNames.ForEach(name => {
                Console.WriteLine($"Column Name: {name}.");
            });
            return columnNames;
        }
    }
}
