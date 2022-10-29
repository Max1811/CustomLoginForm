using LoginForm.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Parsing
{
    public interface ISourceParser
    {
        ParsingOutput Parse(Stream input);
    }
}
