using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.Models;

namespace Z_BandAPI.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {

            CreateMap<Entities.m_cls_Album, Models.Albums_Dto>().ReverseMap();
            CreateMap<AlbumForCreating_Dto, Entities.m_cls_Album>();
            CreateMap<Models.AlbumForUpdating_Dto, Entities.m_cls_Album>().ReverseMap();

        }
    }
}
