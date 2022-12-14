using Core.CoreMap;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.AppUsers");
            Property(x => x.Firstname).HasMaxLength(255);
            Property(x => x.Lastname).HasMaxLength(255);
            Property(x => x.Email).IsRequired();
            Property(x => x.Password).IsRequired().HasMaxLength(255);

        }
    }
    
}
