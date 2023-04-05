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

        public List<string> GenerateSQLInsert(IXLWorksheet planilha, int line)
        {
            throw new NotImplementedException();
        }
    }
}
