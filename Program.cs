using System;
using System.Linq;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SQLGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = new List<string>();
            var xls = new XLWorkbook(@"C:\Users\Matheus.Petrachin\source\repos\SQLGenerator\SQLGenerator\Temp\Excel.xlsx");

            var registerType = 2;
            var planilha = xls.Worksheets.First(w => w.Name == "Planilha1");

            var totalLinhas = planilha.Rows().Count();

            values.Add("INSERT INTO table VALUES");
            for (int line = 2; line <= totalLinhas; line++)
            {
                var A = planilha.Cell($"A{line}").Value?.ToString();
                var B = planilha.Cell($"B{line}").Value?.ToString();

                var auxC = planilha.Cell($"C{line}").Value.ToString();
                var C = auxC.Substring(4,4) + "-" + auxC.Substring(2, 2) + "-" + auxC.Substring(0, 2);

                var auxD = planilha.Cell($"D{line}").Value.ToString();                
                var D = auxD == null || auxD == "" ? null : auxD.Substring(4, 4) + "-" + auxD.Substring(2, 2) + "-" + auxD.Substring(0, 2);

                var E = planilha.Cell($"E{line}").Value?.ToString();
                var F = planilha.Cell($"F{line}").Value?.ToString();
                var G = planilha.Cell($"G{line}").Value?.ToString();
                var H = planilha.Cell($"H{line}").Value?.ToString();

                var I = planilha.Cell($"I{line}").Value?.ToString().Replace("\'", "\"");

                string value = @$"('{Guid.NewGuid()}',{registerType},{ReturnPropValue(A)},{ReturnPropValue(B)},{ReturnPropValue(C)},{ReturnPropValue(D)},{ReturnPropValue(E)},{ReturnPropValue(F)},{ReturnPropValue(G)},{ReturnPropValue(H)},{ReturnPropValue(I)}){(line == totalLinhas ? ";" : ",")}";

                values.Add(value);
            }

            CreateSQLArchive(values);
        }

        public static void CreateSQLArchive(List<string> values)
        {
            try
            {
                using (var fs = new FileStream(@"C:\Users\Matheus.Petrachin\source\repos\SQLGenerator\SQLGenerator\Temp\SQL.sql", FileMode.OpenOrCreate, FileAccess.ReadWrite))
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

        public static string ReturnPropValue(string prop)
        {
            return prop == null || prop == "" ? "NULL" : $"'{prop.Replace('\'', '\"')}'";
        }
    }
}
