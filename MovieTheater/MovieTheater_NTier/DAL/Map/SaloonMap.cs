using Core.CoreMap;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
 public   class SaloonMap:CoreMap<Saloon>
    {
        public SaloonMap()
        {
            ToTable("dbo.Saloons");
            Property(x => x.SaloonName).IsRequired().HasMaxLength(255);
            Property(x => x.Capacity).IsRequired();
           
        }

    }
}
