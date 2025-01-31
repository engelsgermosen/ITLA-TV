using ITLA_TV.Core.Application.Interfaces.Repositories;
using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Series;
using ITLA_TV.Core.Domain.Entities;
using ITLA_TV.Core.Domain.Enums;

namespace ITLA_TV.Core.Application.Services
{
    public class SerieService : ISerieService
    {
        public readonly ISerieRepository repository;

        public SerieService(ISerieRepository _repo)
        {
            repository = _repo;
        }

        public async Task Add(SaveSerieViewModel entity)
        {
            Serie serie = new Serie()
            {
                Name = entity.Name,
                ImagePath = entity.ImagePath,
                VideoPath = entity.VideoPath,
                ProducerId = entity.ProducerId,
                PrimaryGenderId = entity.PrimaryGender,
                SecondaryGenderId = entity?.SecondaryGender,
            };
            await repository.AddAsync(serie);
        }

        public async Task Delete(int id)
        {
            var response = await repository.GetById(id);
                await repository.DeleteAsync(response);
        }

        public async Task<List<SerieViewModel>> GetAll()
        {
            var response = await repository.GetAllWithIncludeAsync(new List<string> { "Producer", "PrimaryGender", "SecondaryGender" });

            return response
                .Select(serie => new SerieViewModel
                {
                    Id = serie.Id,
                    Name = serie.Name,
                    ImagePath = serie.ImagePath,
                    VideoPath = serie.VideoPath,
                    ProducerId = serie.ProducerId,
                    ProducerName = serie.Producer.Name,
                    PrimaryGender = serie.PrimaryGender.Name,
                    SecondaryGender = serie.SecondaryGender?.Name
                }).ToList();
        }

        public async Task<SerieViewModel> GetById(int id)
        {
            var response = await repository.GetById(id);
            SerieViewModel vm = new()
            {
                Id = id,
                Name = response.Name,
                VideoPath = response.VideoPath,
                ImagePath = response.ImagePath,
                ProducerId = response.ProducerId,
                PrimaryGender = response.PrimaryGender.Name,
                SecondaryGender = response.SecondaryGender?.Name,
                ProducerName = response.Producer.Name,
            };
            return vm;
        }

        public async Task<SaveSerieViewModel> GetByIdViewModel(int id)
        {
            var response = await repository.GetById(id);

            SaveSerieViewModel vm = new()
            {
                Id = id,
                Name = response.Name,
                VideoPath = response.VideoPath,
                ImagePath = response.ImagePath,
                ProducerId = response.ProducerId,
                PrimaryGender = response.PrimaryGenderId,
                SecondaryGender = response.SecondaryGenderId,
            };
            return vm;
        }

        public async Task<List<SerieViewModel>> GetSeriesWithFilter(FilterSerieViewModel filters)
        {
            var seriesList = await GetAll();

            if (!string.IsNullOrEmpty(filters.SerieName))
            {
                seriesList = seriesList.Where(s => s.Name.ToLower().StartsWith(filters.SerieName.ToLower())).ToList();
            }
            else if (!string.IsNullOrEmpty(filters.ProducerName))
            {
                seriesList = seriesList.Where(s => s.ProducerName == filters.ProducerName).ToList();

            }
            else if (!string.IsNullOrEmpty(filters.GeneroName))
            {
                seriesList = seriesList.Where(s => s.PrimaryGender == filters.GeneroName || (s.SecondaryGender != null && s.SecondaryGender == filters.GeneroName)).ToList();

            }
            return seriesList;
        }

        public async Task<List<SerieViewModel>> Order(int orden)
        {
            var seriList = await GetAll();

            switch (orden)
            {
                case (int)SeriesOrder.Productora:

                    return seriList.OrderBy(x => x.ProducerName).ToList();

                case (int)SeriesOrder.Genero:

                    return seriList.OrderBy(x => x.PrimaryGender).ToList();

                case (int)SeriesOrder.Nombre:

                    return seriList.OrderBy(x => x.Name).ToList();

                default:
                    return seriList;
            }
        }

        public async Task Update(SaveSerieViewModel entity)
        {
            Serie serie = new Serie()
            {
                Id = entity.Id,
                Name = entity.Name,
                ImagePath = entity.ImagePath,
                VideoPath = entity.VideoPath,
                ProducerId = entity.ProducerId,
                PrimaryGenderId = entity.PrimaryGender,
                SecondaryGenderId = entity.SecondaryGender,
            };
            await repository.UpdateAsync(serie);
        }
    }
}
