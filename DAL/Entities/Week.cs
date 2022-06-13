using Core.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Week : EntityRepository
    {
        public string WeekName { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }

        //Relation Property
        public virtual List<Theater> Theaters { get; set; }

    }
}
