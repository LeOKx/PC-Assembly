using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.PowerSupply;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;
using AutoMapper;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain.Components;
using PcAssembly.Bll.Exeptions;

namespace PcAssembly.Bll.Services
{
    public class PowerSupplyService : IPowerSupplyService
    {
        private readonly IMapper _mapper;
        private readonly IPowerSupplyRepository _repository;

        public PowerSupplyService(IMapper mapper, IPowerSupplyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ServiceResponse<GetPowerSupplyDto>> AddPowerSupply(AddPowerSupplyDto newPowerSupply)
        {
            var serviceResponse = new ServiceResponse<GetPowerSupplyDto>();
            if (!await _repository.ExistComponentWithTheModel(newPowerSupply.Model))
            {
                PowerSupply powerSupply = _mapper.Map<PowerSupply>(newPowerSupply);
                serviceResponse.Data = _mapper.Map<GetPowerSupplyDto>(await _repository.Insert(powerSupply));
                serviceResponse.Message = "PowerSupply added to db";
            }
            else
            {
                serviceResponse.Message = "PowerSupply with the same model already in DataBase";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPowerSupplyDto>> DeletePowerSupply(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetPowerSupplyDto>();
            try
            {
                var powerSupply = await _repository.GetById(id);
                if (powerSupply != null)
                {
                    var deleteComponent = await _repository.GetById(id);
                    await _repository.Delete(deleteComponent);
                    serviceResponse.Data = _mapper.Map<GetPowerSupplyDto>(powerSupply);
                    serviceResponse.Message = $"PowerSupply {id} Deleted";
                }
                else
                {
                    serviceResponse.Message = $"PowerSupply not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<PaginatedResult<GetPowerSupplyDto>> GetPagedPowerSupplies(PagedRequest pagedRequest)
        {
            return await _repository.GetPagedData<PowerSupply, GetPowerSupplyDto>(pagedRequest);
        }

        public async Task<ServiceResponse<List<GetPowerSupplyDto>>> GetPowerSupplies()
        {
            var serviceResponse = new ServiceResponse<List<GetPowerSupplyDto>>();
            try
            {
                var dbPowerSupply = await _repository.GetAll();
                serviceResponse.Data = dbPowerSupply.Select(c => _mapper.Map<GetPowerSupplyDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<GetPowerSupplyDto> GetPowerSupplyById(Guid id)
        {
            return _mapper.Map<GetPowerSupplyDto>(await _repository.GetById(id));
        }

        public async Task<ServiceResponse<GetPowerSupplyDto>> UpdatePowerSupply(Guid id, UpdatePowerSupplyDto updatedPowerSupply)
        {
            var serviceResponse = new ServiceResponse<GetPowerSupplyDto>();
            try
            {

                var dbPowerSupply = await _repository.GetById(id);
                if (dbPowerSupply != null)
                {
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.Model)
                        && dbPowerSupply.Model != updatedPowerSupply.Model)
                    {
                        if (await _repository.ExistComponentWithTheModel(updatedPowerSupply.Model))
                        {
                            throw new ComponentAlreadyExistsException("Component With The Same Model AlreadyExists");
                        }

                        dbPowerSupply.Model = updatedPowerSupply.Model;
                    }

                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.ImageUrl.ToString()))
                        dbPowerSupply.ImageUrl = updatedPowerSupply.ImageUrl;
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.Company.ToString()))
                        dbPowerSupply.Company = updatedPowerSupply.Company;
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.InfoAbout.ToString()))
                        dbPowerSupply.InfoAbout = updatedPowerSupply.InfoAbout;
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.PowerConsumption.ToString()))
                        dbPowerSupply.PowerConsumption = updatedPowerSupply.PowerConsumption;
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.Type.ToString()))
                        dbPowerSupply.Type = updatedPowerSupply.Type;
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.Price.ToString()))
                        dbPowerSupply.Price = updatedPowerSupply.Price;
                    if (!string.IsNullOrWhiteSpace(updatedPowerSupply.Power.ToString()))
                        dbPowerSupply.Power = updatedPowerSupply.Power;

                    await _repository.Update(dbPowerSupply);
                    await _repository.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetPowerSupplyDto>(dbPowerSupply);
                    serviceResponse.Message = "PowerSupply updated";
                }
                else
                {
                    serviceResponse.Message = "PowerSupply to Update Not Found";
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
