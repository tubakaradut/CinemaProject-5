using Core.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category: EntityRepository
    {
        public string CategoryName { get; set; }

        public virtual List<MovieCategory> MovieCategories { get; set; }


        //Relation Property

    }
}
