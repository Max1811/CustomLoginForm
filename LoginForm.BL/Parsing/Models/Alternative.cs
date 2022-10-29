using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Parsing.Models
{
    public class Alternative
    {
        public string? Name { get; set; }
        public List<Criterion> Criterias { get; set; }
    }
}
