using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CoreEntity
{
   public class EntityRepository
    {
        public EntityRepository()
        {
            DataStatus = DataStatus.Active;
            CreatedDate = DateTime.Now;

        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
