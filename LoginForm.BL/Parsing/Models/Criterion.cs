using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Parsing.Models
{
    public class Criterion
    {
        public string? Name { get; set; }
        public double Value { get; set; }
        public double Rank { get; set; }
        public double Weight { get; set; }
        public SortingDirection Sort {  get; set; }
    }

    public enum SortingDirection
    {
        Ascending = 0,
        Descending = 1,
    }
}
