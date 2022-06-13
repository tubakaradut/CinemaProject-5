using Core.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Theater : EntityRepository
    {
        public int MovieId { get; set; }
        public int SessionId { get; set; }
        public int SaloonId { get; set; }
        public int WeekId { get; set; }

        //Relation property

        public virtual Movie Movie { get; set; }
        public virtual Session Session { get; set; }
        public virtual Saloon Saloon { get; set; }
        public virtual Week Week { get; set; }


    }
}
