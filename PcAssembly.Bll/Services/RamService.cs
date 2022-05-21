using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.RAM;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;
using AutoMapper;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain.Components;
using PcAssembly.Bll.Exeptions;

namespace PcAssembly.Bll.Services
{
    public class RamService : IRamService
    {
        private readonly IMapper _mapper;
        private readonly IRamRepository _repository;

        public RamService(IMapper mapper, IRamRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ServiceResponse<GetRamDto>> AddRam(AddRamDto newRam)
        {
            var serviceResponse = new ServiceResponse<GetRamDto>();
            if (!await _repository.ExistComponentWithTheModel(newRam.Model))
            {
                Ram ram = _mapper.Map<Ram>(newRam);
                serviceResponse.Data = _mapper.Map<GetRamDto>(await _repository.Insert(ram));
                serviceResponse.Message = "RAM added to db";
            }
            else
            {
                serviceResponse.Message = "RAM with the same model already in DataBase";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRamDto>> DeleteRam(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetRamDto>();
            try
            {
                var ram = await _repository.GetById(id);
                if (ram != null)
                {
                    var deleteComponent = await _repository.GetById(id);
                    await _repository.Delete(deleteComponent);
                    serviceResponse.Data = _mapper.Map<GetRamDto>(ram);
                    serviceResponse.Message = $"Ram {id} Deleted";
                }
                else
                {
                    serviceResponse.Message = $"Ram not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<PaginatedResult<GetRamDto>> GetPagedRams(PagedRequest pagedRequest)
        {
            return await _repository.GetPagedData<Ram, GetRamDto>(pagedRequest);
        }

        public async Task<GetRamDto> GetRamById(Guid id)
        {
            return _mapper.Map<GetRamDto>(await _repository.GetById(id));
        }

        public async Task<ServiceResponse<List<GetRamDto>>> GetRams()
        {
            var serviceResponse = new ServiceResponse<List<GetRamDto>>();
            try
            {
                var dbRam = await _repository.GetAll();
                serviceResponse.Data = dbRam.Select(c => _mapper.Map<GetRamDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRamDto>> UpdateRam(Guid id, UpdateRamDto updatedRam)
        {
            var serviceResponse = new ServiceResponse<GetRamDto>();
            try
            {

                var dbRam = await _repository.GetById(id);
                if (dbRam != null)
                {
                    if (!string.IsNullOrWhiteSpace(updatedRam.Model)
                        && dbRam.Model != updatedRam.Model)
                    {
                        if (await _repository.ExistComponentWithTheModel(updatedRam.Model))
                        {
                            throw new ComponentAlreadyExistsException("Component With The Same Model AlreadyExists");
                        }

                        dbRam.Model = updatedRam.Model;
                    }

                    if (!string.IsNullOrWhiteSpace(updatedRam.ImageUrl.ToString()))
                        dbRam.ImageUrl = updatedRam.ImageUrl;
                    if (!string.IsNullOrWhiteSpace(updatedRam.Company.ToString()))
                        dbRam.Company = updatedRam.Company;
                    if (!string.IsNullOrWhiteSpace(updatedRam.InfoAbout.ToString()))
                        dbRam.InfoAbout = updatedRam.InfoAbout;
                    if (!string.IsNullOrWhiteSpace(updatedRam.PowerConsumption.ToString()))
                        dbRam.PowerConsumption = updatedRam.PowerConsumption;
                    if (!string.IsNullOrWhiteSpace(updatedRam.Type.ToString()))
                        dbRam.Type = updatedRam.Type;
                    if (!string.IsNullOrWhiteSpace(updatedRam.Price.ToString()))
                        dbRam.Price = updatedRam.Price;
                    if (!string.IsNullOrWhiteSpace(updatedRam.RamType.ToString()))
                        dbRam.RamType = updatedRam.RamType;
                    if (!string.IsNullOrWhiteSpace(updatedRam.RamSize.ToString()))
                        dbRam.RamSize = updatedRam.RamSize;

                    await _repository.Update(dbRam);
                    await _repository.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetRamDto>(dbRam);
                    serviceResponse.Message = "Ram updated";
                }
                else
                {
                    serviceResponse.Message = "Ram to Update Not Found";
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
