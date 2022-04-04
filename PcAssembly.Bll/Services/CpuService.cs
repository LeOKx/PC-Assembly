using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponse<GetCpuDto>> DeleteCPU(int id)
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

        public async Task<ServiceResponse<List<GetCpuDto>>> GetAllCPUs()
        {
            var serviceResponse = new ServiceResponse<List<GetCpuDto>>();
            var dbCPU = await _repository.GetAll();
            serviceResponse.Data = dbCPU.Select(c => _mapper.Map<GetCpuDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCpuDto>> GetCpuById(int id)
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

        public async Task<ServiceResponse<GetCpuDto>> UpdateCPU(int id,UpdateCpuDto updatedCPU)
        {

            var serviceResponse = new ServiceResponse<GetCpuDto>();
            try
            {
                var dbCPU = await _repository.GetById(id);
                if(dbCPU != null) 
                {
                _mapper.Map(updatedCPU, dbCPU);
                dbCPU.Id = id;
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
