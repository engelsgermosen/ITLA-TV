using ITLA_TV.Core.Domain.Common;

namespace ITLA_TV.Core.Domain.Entities
{
    public class Gender : BasicEntities
    {
        public ICollection<Serie> seriesPrimary { get; set; }
        public ICollection<Serie> seriesSecondary { get; set; }
    }
}
