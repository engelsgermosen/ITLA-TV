using ITLA_TV.Core.Application.ViewModels.Genres;
using ITLA_TV.Core.Application.ViewModels.Series;

namespace ITLA_TV.Core.Application.Interfaces.Services
{
    public interface ISerieService : IGenericService<SaveSerieViewModel, SerieViewModel>
    {
        Task<List<SerieViewModel>> GetSeriesWithFilter(FilterSerieViewModel filters);

        Task<List<SerieViewModel>> Order(int orden);

        
    }
}
