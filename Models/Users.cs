using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ClosedXML.Excel;

namespace SQLGenerator.Models
{
    [Table("users")]
    public class Users : IGenerateSQL
    {        
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int YearsOld { get; set; }

        public List<string> GenerateSQLInsert(IXLWorksheet planilha, int totalOfLines)
        {
            List<string> values = new List<string>();
            for (int line = 1; line <= totalOfLines; line++)
            {  
                var A = planilha.Cell($"A{line}").Value?.ToString();
                var B = planilha.Cell($"B{line}").Value?.ToString();             
                var C = planilha.Cell($"C{line}").Value?.ToString();
                var D = planilha.Cell($"D{line}").Value?.ToString();
                var E = planilha.Cell($"E{line}").Value?.ToString();               

                string value = @$"('{Guid.NewGuid()}',{SQLGeneratorHelper.ReturnPropValue(A)},{SQLGeneratorHelper.ReturnPropValue(B)},{SQLGeneratorHelper.ReturnPropValue(C)},{SQLGeneratorHelper.ReturnPropValue(D)},{SQLGeneratorHelper.ReturnPropValue(E)}){(line == totalOfLines ? ";" : ",")}";
                values.Add(value);
            }
            return values;
        }
    }
}
