using DecisionSupport.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSupport.BL.Parsing
{
    public interface ISourceParser
    {
        ParsingOutput Parse(Stream input);
    }
}
