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
        public List<string> Alternatives { get; set; }
        public int Rank { get; set; }
    }
}
