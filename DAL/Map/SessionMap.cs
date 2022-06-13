using Core.CoreMap;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
   public  class SessionMap:CoreMap<Session>
    {
        public SessionMap()
        {
            ToTable("dbo.Sessions");
            Property(x => x.Duration).IsRequired();  
        }
    }
}
