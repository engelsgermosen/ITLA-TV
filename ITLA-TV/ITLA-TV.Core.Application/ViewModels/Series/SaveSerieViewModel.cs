using System.ComponentModel.DataAnnotations;

namespace ITLA_TV.Core.Application.ViewModels.Series
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocal el nombre de la serie")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar la url de la imagen")]

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Debe colocar la url del video")]

        public string VideoPath { get; set; }
        [Required(ErrorMessage = "Debe colocar la productora de la serie")]

        public int ProducerId { get; set; }

        [Range (1,int.MaxValue,ErrorMessage = "Debe colocar el genero primario")]

        public int PrimaryGender { get; set; }

        public int? SecondaryGender { get; set; }

    }
}
