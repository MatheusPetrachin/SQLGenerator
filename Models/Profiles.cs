using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ClosedXML.Excel;

namespace SQLGenerator.Models
{
    [Table("users")]
    public class Profiles : IGenerateSQL
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public List<string> GenerateSQLInsert(IXLWorksheet planilha, int totalOfLines)
        {
            List<string> values = new List<string>();
            for (int line = 1; line <= totalOfLines; line++)
            {  
                var A = planilha.Cell($"A{line}").Value?.ToString();              

                string value = @$"('{Guid.NewGuid()}',{SQLGeneratorHelper.ReturnPropValue(A)}){(line == totalOfLines ? ";" : ",")}";
                values.Add(value);
            }
            return values;
        }
    }
}
