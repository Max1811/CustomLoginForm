using LoginForm.BL.Algorithms;
using LoginForm.BL.Parsing;
using LoginForm.BL.Parsing.Models;
using LoginForm.BL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Services
{
    public class AnaliticHierarchyService : IAlgorithmService
    {
        private readonly ISourceParser _parser;
        private readonly IAlgorithmProcessor _processor;

        public AnaliticHierarchyService(ISourceParser parser, IAlgorithmProcessor processor)
        {
            _parser = parser;
            _processor = processor;
        }

        public List<AlgorithmExecutionResult> GetResults(string path)
        {
            using var stream = File.Open("C:/Users/vakyl/Desktop/Book2.xlsx", FileMode.Open, FileAccess.Read);
            var parceResult = _parser.Parse(stream);

            var result = _processor.Handle((List<Alternative>)parceResult.Alternatives, (List<Criterion>)parceResult.Criterias, (List<double>)parceResult.RelativeImportanceList);

            return result;
        }
    }
}
