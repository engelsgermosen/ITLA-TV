using ITLA_TV.Core.Domain.Common;

namespace ITLA_TV.Core.Domain.Entities
{
    public class Serie : BasicEntities
    {
        public string ImagePath { get; set; }

        public string VideoPath { get; set; }

        public Producer Producer { get; set; }

        public int ProducerId { get; set; }


        public Gender PrimaryGender { get; set; }
        public int PrimaryGenderId { get; set; }


        public Gender? SecondaryGender { get; set; }

        public int? SecondaryGenderId {  get; set; }
    }
}
