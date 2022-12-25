using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataAccess.Entities
{
    public class Voting : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; } = new List<Alternative>();
    }
}
