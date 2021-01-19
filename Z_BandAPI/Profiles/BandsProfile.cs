using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.Helpers;

namespace Z_BandAPI.Profiles
{
    public class BandsProfile : Profile
    {
        //
        public BandsProfile()
        {
            CreateMap<Entities.m_cls_Band, Models.Band_Dto>()
                .ForMember(
                    dest => dest.FoundedYearsAgo,
                    opt => opt.MapFrom(src => $"{src.Founded.ToString("yyyy")} ({src.Founded.GetYearsAgo()}) years ago"));

            CreateMap<Models.BandForCreating_Dto, Entities.m_cls_Band>();
        }
        //

    }
}
