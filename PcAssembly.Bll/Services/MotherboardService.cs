using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.Motherboard;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain.Components;
using PcAssembly.Bll.Exeptions;

namespace PcAssembly.Bll.Services
{
    
    public class MotherboardService : IMotherboardService
    {
        private readonly IMapper _mapper;
        private readonly IMotherboardRepository _repository;

        public MotherboardService(IMapper mapper, IMotherboardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ServiceResponse<GetMotherboardDto>> AddMotherboard(AddMotherboardDto newMotherboard)
        {
            var serviceResponse = new ServiceResponse<GetMotherboardDto>();
            if (!await _repository.ExistComponentWithTheModel(newMotherboard.Model))
            {
                Motherboard motherboard = _mapper.Map<Motherboard>(newMotherboard);
                serviceResponse.Data = _mapper.Map<GetMotherboardDto>(await _repository.Insert(motherboard));
                serviceResponse.Message = "Motherboard added to db";
            }
            else
            {
                serviceResponse.Message = "Motherboard with the same model already in DataBase";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMotherboardDto>> DeleteMotherboard(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetMotherboardDto>();
            try
            {
                var motherboard = await _repository.GetById(id);
                if (motherboard != null)
                {
                    var deleteComponent = await _repository.GetById(id);
                    await _repository.Delete(deleteComponent);
                    serviceResponse.Data = _mapper.Map<GetMotherboardDto>(motherboard);
                    serviceResponse.Message = $"Motherboard {id} Deleted";
                }
                else
                {
                    serviceResponse.Message = $"Motherboard not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<GetMotherboardDto> GetMotherboardById(Guid id)
        {
            return _mapper.Map<GetMotherboardDto>(await _repository.GetById(id));
        }

        public async Task<ServiceResponse<List<GetMotherboardDto>>> GetMotherboards()
        {
            var serviceResponse = new ServiceResponse<List<GetMotherboardDto>>();
            try
            {
                var dbMotherboard = await _repository.GetAll();
                serviceResponse.Data = dbMotherboard.Select(c => _mapper.Map<GetMotherboardDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<PaginatedResult<GetMotherboardDto>> GetPagedMotherboards(PagedRequest pagedRequest)
        {
            return await _repository.GetPagedData<Motherboard, GetMotherboardDto>(pagedRequest);
        }

        public async Task<ServiceResponse<GetMotherboardDto>> UpdateMotherboard(Guid id, UpdateMotherboardDto updatedMotherboard)
        {
            var serviceResponse = new ServiceResponse<GetMotherboardDto>();
            try
            {

                var dbMotherboard = await _repository.GetById(id);
                if (dbMotherboard != null)
                {
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.Model)
                        && dbMotherboard.Model != updatedMotherboard.Model)
                    {
                        if (await _repository.ExistComponentWithTheModel(updatedMotherboard.Model))
                        {
                            throw new ComponentAlreadyExistsException("Component With The Same Model AlreadyExists");
                        }

                        dbMotherboard.Model = updatedMotherboard.Model;
                    }

                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.ImageUrl.ToString()))
                        dbMotherboard.ImageUrl = updatedMotherboard.ImageUrl;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.Company.ToString()))
                        dbMotherboard.Company = updatedMotherboard.Company;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.InfoAbout.ToString()))
                        dbMotherboard.InfoAbout = updatedMotherboard.InfoAbout;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.Socket.ToString()))
                        dbMotherboard.Socket = updatedMotherboard.Socket;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.PowerConsumption.ToString()))
                        dbMotherboard.PowerConsumption = updatedMotherboard.PowerConsumption;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.Type.ToString()))
                        dbMotherboard.Type = updatedMotherboard.Type;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.Price.ToString()))
                        dbMotherboard.Price = updatedMotherboard.Price;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.Chipset.ToString()))
                        dbMotherboard.Chipset = updatedMotherboard.Chipset;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.FormFactor.ToString()))
                        dbMotherboard.FormFactor = updatedMotherboard.FormFactor;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.RamSlots.ToString()))
                        dbMotherboard.RamSlots = updatedMotherboard.RamSlots;
                    if (!string.IsNullOrWhiteSpace(updatedMotherboard.RamType.ToString()))
                        dbMotherboard.RamType = updatedMotherboard.RamType;


                    await _repository.Update(dbMotherboard);
                    await _repository.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetMotherboardDto>(dbMotherboard);
                    serviceResponse.Message = "Motherboard updated";
                }
                else
                {
                    serviceResponse.Message = "Motherboard to Update Not Found";
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
