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
            Property(x => x.MovieName).IsRequired();
            Property(x => x.Description).IsOptional();
            Property(x => x.Duration).IsRequired();
          
        }
    }
}
