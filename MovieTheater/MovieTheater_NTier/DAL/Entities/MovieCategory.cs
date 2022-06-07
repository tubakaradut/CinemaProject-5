using Core.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MovieCategory : EntityRepository
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

