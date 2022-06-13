using Core.Enum;
using System;

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
