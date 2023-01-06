using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Parsing.Models
{
    public class VotingExecutionResult
    {
        public string MethodName { get; set; }
        public List<VotingExecution> Result { get; set; } = new List<VotingExecution>();
    }

    public class VotingExecution
    {
        public List<string> Alternatives { get; set; } = new List<string>();
        public int Rank { get; set; }
    }
}
