using System.ComponentModel.DataAnnotations;

namespace ITLA_TV.Core.Application.ViewModels.Genres
{
    public class SaveGenresViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del genero")]
        public string Name { get; set; }
    }
}
