using ITLA_TV.Core.Domain.Common;

namespace ITLA_TV.Core.Domain.Entities
{
    public class Producer : BasicEntities
    {
        public ICollection<Serie>? series {  get; set; }
    }
}
