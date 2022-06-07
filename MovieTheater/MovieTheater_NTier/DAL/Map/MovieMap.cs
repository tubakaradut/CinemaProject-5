using Core.CoreMap;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Map
{
  public  class MovieMap:CoreMap<Movie>
    {
        public MovieMap()
        {
            ToTable("dbo.Movies");
            Property(x => x.MovieName).IsRequired().HasMaxLength(255);
            Property(x => x.Description).IsOptional().HasMaxLength(255);
            Property(x => x.Duraction).IsRequired();
          
        }
    }
}
