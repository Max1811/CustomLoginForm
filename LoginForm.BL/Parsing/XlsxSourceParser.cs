using ExcelDataReader;
using LoginForm.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Parsing
{
    public class XlsxSourceParser : ISourceParser
    {
        public ParsingOutput Parse(Stream input)
        {
            using var reader = ExcelReaderFactory.CreateReader(input);
            var conf = new ExcelDataSetConfiguration
            {
                UseColumnDataType = true,
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    FilterRow = rowReader => rowReader[0] != null
                }
            };

            DataSet excelDataSet = reader.AsDataSet(conf);

            var rows = GetDataRows(excelDataSet, "Sheet1");

            var goal = rows[0].ItemArray[0].ToString();

            var relativeImportanceRowItem = rows[1].ItemArray[0].ToString();
            var relativeImportanceList = ParseRelativeImportanceListRowItem(relativeImportanceRowItem);

            var criteriasListRow = rows[2];
            var criteriasList = ParseCriterionsListRow(criteriasListRow);

            rows.RemoveAt(0);
            rows.RemoveAt(0);
            rows.RemoveAt(0);

            var alternatives = ParseAlternativeRows(rows, criteriasList);

            return new ParsingOutput(goal, alternatives, criteriasList, relativeImportanceList);
        }

        private List<double> ParseRelativeImportanceListRowItem(string relativeImportanceRowItem)
        {
            var split = relativeImportanceRowItem.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var scale = split[1].Split(',').Select(x => double.Parse(x)).ToList();

            return scale;
        }

        private List<Criterion> ParseCriterionsListRow(DataRow row)
        {
            var result = new List<Criterion>();

            for (int i = 1; i < row.ItemArray.Length; i++)
            {
                var split = row.ItemArray[i].ToString().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                result.Add(new Criterion { 
                    Name = split[0],
                    Rank = i,
                    Sort = split[1] == "asc" ? SortingDirection.Ascending : SortingDirection.Descending 
                });;    
            }

            return result;
        }

        private List<Alternative> ParseAlternativeRows(DataRowCollection rows, List<Criterion> criterias)
        {
            var listAlternatives = new List<Alternative>();

            foreach (DataRow row in rows)
            {
                var result = new List<Criterion>();
                var fullName = row.ItemArray[0].ToString();

                for (int i = 1; i < row.ItemArray.Length; i++)
                {
                    var criterion = new Criterion
                    {
                        Name = criterias[i - 1].Name,
                        Rank = criterias[i - 1].Rank,
                        Sort = criterias[i - 1].Sort
                    };
                    criterion.Value = double.Parse(row[i].ToString());
                    result.Add(criterion);
                }

                listAlternatives.Add(new Alternative()
                {
                    Name = fullName,
                    Criterias = result
                });
            }
            
            return listAlternatives;
        }

        private DataRowCollection GetDataRows(DataSet excelDataSet, string sheetName)
        {
            return excelDataSet.Tables.Contains(sheetName) ? excelDataSet.Tables[sheetName].Rows : new DataTable(sheetName).Rows;
        }
    }
}
