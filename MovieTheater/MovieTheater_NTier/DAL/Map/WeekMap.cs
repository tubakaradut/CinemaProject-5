using Core.CoreMap;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
   public class WeekMap:CoreMap<Week>
    {
        public WeekMap()
        {
            Property(x => x.WeekName).IsRequired().HasMaxLength(255);
            Property(x => x.FirstDay).IsOptional();
            Property(x => x.LastDay).IsOptional();
        }

    }
}
