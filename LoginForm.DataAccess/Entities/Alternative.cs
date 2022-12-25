using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataAccess.Entities
{
    public class Alternative : BaseEntity
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public virtual Voting Voting { get; set; }
    }
}
