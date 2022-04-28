using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Filters;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Bll.Services
{
    public class CpuService : ICpuService
    {
        private readonly IMapper _mapper;
        //private readonly IComponentRepository<CPU, int> _componentRepository;
        private readonly ICpuRepository _repository;

        public CpuService(IMapper mapper, ICpuRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ServiceResponse<GetCpuDto>> AddCPU(AddCpuDto newCPU)
        {

            var serviceResponse = new ServiceResponse<GetCpuDto>();
            if(!await _repository.ExistComponentWithTheModel(newCPU.Model))
            {
                CPU cpu = _mapper.Map<CPU>(newCPU);
                serviceResponse.Data = _mapper.Map<GetCpuDto>(await _repository.Insert(cpu));
                serviceResponse.Message = "CPU added to db";
            }
            else
            {
                serviceResponse.Message = "CPU with the same model already in DataBase";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCpuDto>> DeleteCPU(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetCpuDto>();
            try
            {
                var cpu = await _repository.GetById(id);
                if(cpu != null)
                {
                    var deleteComponent = await _repository.GetById(id);
                    await _repository.Delete(deleteComponent);
                    serviceResponse.Data = _mapper.Map<GetCpuDto>(cpu);
                    serviceResponse.Message = $"CPU {id} Deleted";
                }
                else
                {
                    serviceResponse.Message = $"CPU not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCpuDto>>> GetCPUs(SearchOptions searchOption)
        {
            var serviceResponse = new ServiceResponse<List<GetCpuDto>>();
            try
            {
                //var dbCPU = await _repository.GetAll();
                //if (!string.IsNullOrWhiteSpace(searchOption.SearchType))
                //{
                //    dbCPU = dbCPU.FindAll(e => e.Generation.ToString().Contains(searchOption.SearchType));
                //}
                serviceResponse.Message = "All Cpu";
                if (!string.IsNullOrWhiteSpace(searchOption.SearchWord))
                {
                    serviceResponse.Message += $" with model {searchOption.SearchWord}";
                }
                if (searchOption.MinPrice.HasValue)
                {
                    serviceResponse.Message += $" with minimum price {searchOption.MinPrice}";
                }
                if (searchOption.MaxPrice.HasValue)
                {
                    serviceResponse.Message += $" with maximum price {searchOption.MaxPrice}";
                }
                var dbCPU = await _repository.GetAll(searchOption.SearchWord, searchOption.MinPrice, searchOption.MaxPrice);
                serviceResponse.Data = dbCPU.Select(c => _mapper.Map<GetCpuDto>(c)).ToList();
                if(serviceResponse.Data is null)
                {
                    serviceResponse.Message = "We haven't find components with youre requirements";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCpuDto>> GetCpuById(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetCpuDto>();
            try
            {
                var dbCPU = await _repository.GetById(id);
                    serviceResponse.Data = _mapper.Map<GetCpuDto>(dbCPU);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCpuDto>> UpdateCPU(Guid id,UpdateCpuDto updatedCPU)
        {

            var serviceResponse = new ServiceResponse<GetCpuDto>();
            try
            {
                
                var dbCPU = await _repository.GetById(id);
                if(dbCPU != null) 
                {
                    if(!string.IsNullOrWhiteSpace(updatedCPU.Model)
                        && dbCPU.Model != updatedCPU.Model)
                    {
                        if(await _repository.ExistComponentWithTheModel(updatedCPU.Model))
                        {
                            throw new ComponentAlreadyExistsException("Component With The Same Model AlreadyExists");
                        }

                        dbCPU.Model = updatedCPU.Model;
                    }
                        
                    //if (!string.IsNullOrWhiteSpace(updatedCPU.Company.ToString()))
                    if (updatedCPU.Company != null)
                        dbCPU.Company = updatedCPU.Company;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Frequency.ToString()))
                        dbCPU.Frequency = updatedCPU.Frequency;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Socket.ToString()))
                        dbCPU.Socket = updatedCPU.Socket;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Generation.ToString()))
                        dbCPU.Generation = updatedCPU.Generation;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.PowerConsumption.ToString()))
                        dbCPU.PowerConsumption = updatedCPU.PowerConsumption;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Family.ToString()))
                        dbCPU.Family = updatedCPU.Family;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Cores.ToString()))
                        dbCPU.Cores = updatedCPU.Cores;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Threads.ToString()))
                        dbCPU.Threads = updatedCPU.Threads;
                    if(!string.IsNullOrWhiteSpace(updatedCPU.Type.ToString()))
                        dbCPU.Type = updatedCPU.Type;
                    if (!string.IsNullOrWhiteSpace(updatedCPU.Price.ToString()))
                        dbCPU.Price = updatedCPU.Price;

                   /* _mapper.Map(updatedCPU, dbCPU);
                dbCPU.Id = id;*/
                await _repository.Update(dbCPU);
                await _repository.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCpuDto>(dbCPU);
                serviceResponse.Message = "CPU updated";
                }
                else
                {
                  serviceResponse.Message = "CPU to Update Not Found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }
    }
}
