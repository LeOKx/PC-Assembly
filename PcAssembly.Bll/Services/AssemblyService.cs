﻿using AutoMapper;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Common.Models.PagedRequest;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Services
{
    public class AssemblyService : IAssemblyService
    {
        private readonly IMapper _mapper;
        private readonly IAssemblyRepository _repository;

        public AssemblyService(IMapper mapper, IAssemblyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ServiceResponse<GetAssemblyDto>> CreateAssembly(AddAssemblyDto assemblyDto)
        {
            var serviceResponse = new ServiceResponse<GetAssemblyDto>();
            Assembly assembly = _mapper.Map<Assembly>(assemblyDto);
            if(! await _repository.ExistAssemblyWithName(assembly.Name))
            {
                assembly.CreateDate = DateTime.Now;
                serviceResponse.Data = _mapper.Map<GetAssemblyDto>(await _repository.Insert(assembly));
                serviceResponse.Message = "Assembly created and added to db";
            }
            else
            {
                serviceResponse.Message = "Assembly with the same name already in DataBase";
                serviceResponse.Success = false;
            }


            return serviceResponse;
        }

        public async Task<PaginatedResult<GetAssemblyDto>> GetPagedAssemblies(PagedRequest pagedRequest)
        {
            return await _repository.GetPagedAssembliesWithDetails(pagedRequest);
        }

        public async Task<ServiceResponse<GetAssemblyDto>> DeleteAssembly(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetAssemblyDto>();
            try
            {
                var assembly = await _repository.GetById(id);
                if (assembly != null)
                {
                    var deleteComponent = await _repository.GetById(id);
                    await _repository.Delete(deleteComponent);
                    serviceResponse.Data = _mapper.Map<GetAssemblyDto>(assembly);
                    serviceResponse.Message = $"Assembly {id} Deleted";
                }
                else
                {
                    serviceResponse.Message = $"Assembly not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAssemblyDto>>> GetAssemblies()
        {
            var serviceResponse = new ServiceResponse<List<GetAssemblyDto>>();
            try
            {
                var dbAssembly = await _repository.GetAll();
                serviceResponse.Data = dbAssembly.Select(c => _mapper.Map<GetAssemblyDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<GetAssemblyDto> GetAssemblyById(Guid id)
        {
            return _mapper.Map<GetAssemblyDto>(await _repository.GetById(id));
        }

        public async Task<ServiceResponse<GetAssemblyDto>> UpdateAssembly(Guid id, UpdateAssemblyDto updatedAssembly)
        {

            var serviceResponse = new ServiceResponse<GetAssemblyDto>();
            try
            {

                var dbAssembly = await _repository.GetById(id);
                if (dbAssembly != null)
                {
                    if (!string.IsNullOrWhiteSpace(updatedAssembly.Name)
                        && dbAssembly.Name != updatedAssembly.Name)
                    {
                        if (await _repository.ExistAssemblyWithName(updatedAssembly.Name))
                        {
                            throw new ComponentAlreadyExistsException("Assembly With The Same Name AlreadyExists");
                        }

                        dbAssembly.Name = updatedAssembly.Name;
                    }

                    //if (!string.IsNullOrWhiteSpace(updatedAssembly.Company.ToString()))
                    if (!string.IsNullOrWhiteSpace(updatedAssembly.Name.ToString()))
                        dbAssembly.Name = updatedAssembly.Name;
                    if (!string.IsNullOrWhiteSpace(updatedAssembly.ImageUrl.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.Rating.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.CoolersCount.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.Cpu.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.Motherboard.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.GraphicCard.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.Ram.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.PowerSupply.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;

                    if (!string.IsNullOrWhiteSpace(updatedAssembly.TotalPrice.ToString()))
                        dbAssembly.ImageUrl = updatedAssembly.ImageUrl;


                    await _repository.Update(dbAssembly);
                    await _repository.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetAssemblyDto>(dbAssembly);
                    serviceResponse.Message = "Assembly updated";
                }
                else
                {
                    serviceResponse.Message = "Assembly to Update Not Found";
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
