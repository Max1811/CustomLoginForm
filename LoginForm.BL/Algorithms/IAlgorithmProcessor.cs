using LoginForm.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Algorithms
{
    public interface IAlgorithmProcessor
    {
        List<AlgorithmExecutionResult> Handle(List<Alternative> alternatives, List<Criterion> criterias, List<double> relativeImportanceList);
    }
}
