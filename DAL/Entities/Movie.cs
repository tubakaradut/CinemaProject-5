using Core.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie : EntityRepository
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        //Relation Property
        public virtual List<Theater>Theaters  { get; set; }
        public virtual List<MovieCategory> MovieCategories { get; set;}
    }
}
