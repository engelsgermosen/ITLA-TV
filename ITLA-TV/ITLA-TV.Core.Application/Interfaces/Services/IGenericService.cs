using ITLA_TV.Core.Application.ViewModels.Series;

namespace ITLA_TV.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task Update(SaveViewModel entity);

        Task Add(SaveViewModel entity);

        Task Delete(int id);

        Task<ViewModel> GetById(int id);

        Task<List<ViewModel>> GetAll();

        Task<SaveViewModel> GetByIdViewModel(int id);
    }
}
