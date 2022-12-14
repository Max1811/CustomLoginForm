using DecisionSupport.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSupport.BL.Algorithms
{
    public interface IAnalyticHierarchyProcessorProcessor
    {
        List<AlgorithmExecutionResult> Handle(List<Alternative> alternatives, List<Criterion> criterias, List<double> relativeImportanceList);
    }
}
