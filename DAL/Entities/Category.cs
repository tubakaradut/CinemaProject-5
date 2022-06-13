using Core.CoreEntity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Category: EntityRepository
    {
        public string CategoryName { get; set; }

        public virtual List<MovieCategory> MovieCategories { get; set; }


        //Relation Property

    }
}
