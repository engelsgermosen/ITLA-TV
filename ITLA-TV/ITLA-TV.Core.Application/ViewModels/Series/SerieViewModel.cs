using ITLA_TV.Core.Domain.Entities;

namespace ITLA_TV.Core.Application.ViewModels.Series
{
    public class SerieViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string VideoPath { get; set; }

        public string ProducerName { get; set; }

        public int ProducerId { get; set; }

        public string PrimaryGender { get; set; }

        public string? SecondaryGender { get; set; }
    }
}
