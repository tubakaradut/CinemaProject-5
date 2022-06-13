using Core.CoreEntity;

namespace DAL.Entities
{
    public class MovieCategory: EntityRepository
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

