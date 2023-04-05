using System.Collections.Generic;
using ClosedXML.Excel;

namespace SQLGenerator.Models
{
    public interface IGenerateSQL
    {
        public List<string> GenerateSQLInsert(IXLWorksheet planilha, int totalOfLines);
    }
}
