using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ClosedXML.Excel;

namespace SQLGenerator.Models
{
    [Table("UserProfile")]
    public class UserProfile : IGenerateSQL
    {
        public string UserId { get; set; }
        public string ProfileId { get; set; }

        public List<string> GenerateSQLInsert(IXLWorksheet planilha, int line)
        {
            throw new NotImplementedException();
        }
    }
}
