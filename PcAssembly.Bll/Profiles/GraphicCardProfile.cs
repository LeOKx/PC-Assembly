using AutoMapper;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.GraphicCard;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Bll.Profiles
{
    public class GraphicCardProfile : Profile
    {
        public GraphicCardProfile()
        {
            CreateMap<GraphicCard, GetGraphicCardDto>();
            CreateMap<AddGraphicCardDto, GraphicCard>();
            CreateMap<UpdateGraphicCardDto, GraphicCard>();
        }

    }
}
