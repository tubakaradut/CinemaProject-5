using Core.CoreEntity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Session:EntityRepository
    {
        public string Duration { get; set; }


        //Relation Property
        public virtual List<Theater> Theaters { get; set; }

    }
}
