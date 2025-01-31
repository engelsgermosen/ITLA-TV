using ITLA_TV.Core.Application.Interfaces.Repositories;
using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Producers;
using ITLA_TV.Core.Application.ViewModels.Series;
using ITLA_TV.Core.Domain.Entities;

namespace ITLA_TV.Core.Application.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            this.producerRepository = producerRepository;
        }

        public async Task Add(SaveProducerViewModel entity)
        {
            Producer producer = new()
            {
                Name = entity.Name,
            };
            await producerRepository.AddAsync(producer);
        }

        public async Task Delete(int id)
        {
            var response = await producerRepository.GetById(id);
            await producerRepository.DeleteAsync(response);
        }

        public async Task<List<ProducerViewModel>> GetAll()
        {
            var response = await producerRepository.GetAll();

            return response
                .Select(prod => new ProducerViewModel
                {
                    Id = prod.Id,
                    Name = prod.Name,
                }).ToList();
        }

        public async Task<ProducerViewModel> GetById(int id)
        {
            var response = await producerRepository.GetById(id);

            ProducerViewModel vm = new()
            {
                Id = id,
                Name = response.Name,
            };
            return vm;
        }

        public async Task<SaveProducerViewModel> GetByIdViewModel(int id)
        {
            var response = await producerRepository.GetById(id);

            SaveProducerViewModel producer = new()
            {
                Id = id,
                Name = response.Name,
            };
            return producer;
        }

        public async Task Update(SaveProducerViewModel entity)
        {
            Producer vm = new()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            await producerRepository.UpdateAsync(vm);
        }
    }
}
