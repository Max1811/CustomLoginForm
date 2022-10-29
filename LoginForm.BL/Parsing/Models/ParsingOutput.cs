using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Parsing.Models
{
    public class ParsingOutput
    {
        public ParsingOutput(
            string goal,
            IEnumerable<Alternative> alternatives,
            IEnumerable<Criterion> criterias,
            IEnumerable<double> relativeImportanceList)
        {
            Goal = goal;
            Alternatives = alternatives;
            Criterias = criterias;
            RelativeImportanceList = relativeImportanceList;
        }

        public string Goal { get; }
        public IEnumerable<Alternative> Alternatives { get; }
        public IEnumerable<Criterion> Criterias { get; }
        public IEnumerable<double> RelativeImportanceList { get; }
    }
}
