﻿using Core.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Session:EntityRepository
    {
        public DateTime Duraction { get; set; }
       

        //Relation Property
        public virtual List<Theater> Theaters { get; set; }

    }
}
