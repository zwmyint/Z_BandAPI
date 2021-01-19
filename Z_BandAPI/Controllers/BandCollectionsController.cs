using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Z_BandAPI.Models;
using Z_BandAPI.Services.IRepository;

namespace Z_BandAPI.Controllers
{
    //
    [ApiController]
    [Route("api/bandcollections")]
    public class BandCollectionsController : ControllerBase // this is for API Controller = ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandCollectionsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ??
                throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        // http://localhost:5000/api/bandcollections
        /*
         [
            {
                "name": "testing band createion 1",
                "founded": "2021-01-12",
                "mainGenre": "Rock"
            },
            {
                "name": "testing band createion 2",
                "founded": "2021-01-12",
                "mainGenre": "Heay Metal"
            }
        ] 
        */
        [HttpPost]
        public ActionResult<IEnumerable<Band_Dto>> CreateBandCollection([FromBody] IEnumerable<BandForCreating_Dto> newbandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<Entities.m_cls_Band>>(newbandCollection);

            foreach (var band in bandEntities)
            {
                _bandAlbumRepository.AddBand(band);
            }

            _bandAlbumRepository.Save();

            //var bandCollectionToReturn = _mapper.Map<IEnumerable<Band_Dto>>(bandEntities);
            //var IdsString = string.Join(",", bandCollectionToReturn.Select(a => a.Id));

            //return CreatedAtRoute("GetBandCollection", new { ids = IdsString }, bandCollectionToReturn);

            return Ok();
        }

        //
    }
}