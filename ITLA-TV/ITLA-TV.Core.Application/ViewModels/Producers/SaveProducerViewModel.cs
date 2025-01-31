using System.ComponentModel.DataAnnotations;

namespace ITLA_TV.Core.Application.ViewModels.Producers
{
    public class SaveProducerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la productora")]
        public string Name { get; set; }
    }
}
