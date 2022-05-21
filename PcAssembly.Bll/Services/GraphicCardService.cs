using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.GraphicCard;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;
using PcAssembly.Domain.Components;
using PcAssembly.Bll.Exeptions;

namespace PcAssembly.Bll.Services
{
    public class GraphicCardService : IGraphicCardService
    {
        private readonly IMapper _mapper;
        private readonly IGraphicCardRepository _repository;

        public GraphicCardService(IMapper mapper, IGraphicCardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ServiceResponse<GetGraphicCardDto>> AddGraphicCard(AddGraphicCardDto newGraphicCard)
        {
            var serviceResponse = new ServiceResponse<GetGraphicCardDto>();
            if (!await _repository.ExistComponentWithTheModel(newGraphicCard.Model))
            {
                GraphicCard graphicCard = _mapper.Map<GraphicCard>(newGraphicCard);
                serviceResponse.Data = _mapper.Map<GetGraphicCardDto>(await _repository.Insert(graphicCard));
                serviceResponse.Message = "GraphicCard added to db";
            }
            else
            {
                serviceResponse.Message = "GraphicCard with the same model already in DataBase";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGraphicCardDto>> DeleteGraphicCard(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetGraphicCardDto>();
            try
            {
                var graphicCard = await _repository.GetById(id);
                if (graphicCard != null)
                {
                    var deleteComponent = await _repository.GetById(id);
                    await _repository.Delete(deleteComponent);
                    serviceResponse.Data = _mapper.Map<GetGraphicCardDto>(graphicCard);
                    serviceResponse.Message = $"GraphicCard {id} Deleted";
                }
                else
                {
                    serviceResponse.Message = $"GraphicCard not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGraphicCardDto>>> GetGPUs()
        {
            var serviceResponse = new ServiceResponse<List<GetGraphicCardDto>>();
            try
            {
                var dbGraphicCard = await _repository.GetAll();
                serviceResponse.Data = dbGraphicCard.Select(c => _mapper.Map<GetGraphicCardDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<GetGraphicCardDto> GetGraphicCardById(Guid id)
        {
            return _mapper.Map<GetGraphicCardDto>(await _repository.GetById(id));
        }

        public async Task<PaginatedResult<GetGraphicCardDto>> GetPagedGraphicCards(PagedRequest pagedRequest)
        {
            return await _repository.GetPagedData<GraphicCard, GetGraphicCardDto>(pagedRequest);
        }

        public async Task<ServiceResponse<GetGraphicCardDto>> UpdateGraphicCard(Guid id, UpdateGraphicCardDto updatedGraphicCard)
        {
            var serviceResponse = new ServiceResponse<GetGraphicCardDto>();
            try
            {

                var dbGraphicCard = await _repository.GetById(id);
                if (dbGraphicCard != null)
                {
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.Model)
                        && dbGraphicCard.Model != updatedGraphicCard.Model)
                    {
                        if (await _repository.ExistComponentWithTheModel(updatedGraphicCard.Model))
                        {
                            throw new ComponentAlreadyExistsException("Component With The Same Model AlreadyExists");
                        }

                        dbGraphicCard.Model = updatedGraphicCard.Model;
                    }
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.ImageUrl.ToString()))
                        dbGraphicCard.ImageUrl = updatedGraphicCard.ImageUrl;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.Company.ToString()))
                        dbGraphicCard.Company = updatedGraphicCard.Company;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.InfoAbout.ToString()))
                        dbGraphicCard.InfoAbout = updatedGraphicCard.InfoAbout;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.PowerConsumption.ToString()))
                        dbGraphicCard.PowerConsumption = updatedGraphicCard.PowerConsumption;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.Type.ToString()))
                        dbGraphicCard.Type = updatedGraphicCard.Type;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.Price.ToString()))
                        dbGraphicCard.Price = updatedGraphicCard.Price;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.SgRamType.ToString()))
                        dbGraphicCard.SgRamType = updatedGraphicCard.SgRamType;
                    if (!string.IsNullOrWhiteSpace(updatedGraphicCard.SgRamSize.ToString()))
                        dbGraphicCard.SgRamSize = updatedGraphicCard.SgRamSize;

                    await _repository.Update(dbGraphicCard);
                    await _repository.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetGraphicCardDto>(dbGraphicCard);
                    serviceResponse.Message = "GraphicCard updated";
                }
                else
                {
                    serviceResponse.Message = "GraphicCard to Update Not Found";
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
