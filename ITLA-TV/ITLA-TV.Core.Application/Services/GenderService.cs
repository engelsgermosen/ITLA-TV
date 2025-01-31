using ITLA_TV.Core.Application.Interfaces.Repositories;
using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Genres;
using ITLA_TV.Core.Application.ViewModels.Series;
using ITLA_TV.Core.Domain.Entities;

namespace ITLA_TV.Core.Application.Services
{
    public class GenderService : IGenderService
    {

        private readonly IGenderRepository repository;

        public GenderService(IGenderRepository repo)
        {
            repository = repo;
        }

        public async Task Add(SaveGenresViewModel entity)
        {
            Gender gender = new()
            {
                Name = entity.Name,
            };
            await repository.AddAsync(gender);
        }

        public async Task Delete(int id)
        {
            var response = await repository.GetById(id);
            await repository.DeleteAsync(response);
        }

        public async Task<List<GenresViewModel>> GetAll()
        {
            var response = await repository.GetAll();

            return response
                .Select(gender => new GenresViewModel
                {
                    Id = gender.Id,
                    Name = gender.Name,
                }).ToList();
        }

        public async Task<GenresViewModel> GetById(int id)
        {
            var response = await repository.GetById(id);

            GenresViewModel gender = new()
            {
                Id = id,
                Name = response.Name,
            };
            return gender;
        }

        public async Task<SaveGenresViewModel> GetByIdViewModel(int id)
        {
            var response = await repository.GetById(id);
            SaveGenresViewModel genres = new()
            {
                Id = response.Id,
                Name = response.Name,
            };
            return genres;
        }

        public async Task Update(SaveGenresViewModel entity)
        {
            Gender gender = new()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            await repository.UpdateAsync(gender);
        }
    }
}
