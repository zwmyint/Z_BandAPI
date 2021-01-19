using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Z_BandAPI.Helpers;
using Z_BandAPI.Models;
using Z_BandAPI.Services.IRepository;

namespace Z_BandAPI.Controllers
{
    //
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase // this is for API Controller = ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }


        // http://localhost:5000/api/bands
        // http://localhost:5000/api/bands?mainGenre=Rock&searchQuery=s
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Band_Dto>> GetBands([FromQuery]BandsResourceParameters bandsResourceParameters)
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands(bandsResourceParameters);

            //var bandsDto = new List<Band_Dto>();

            //foreach (var b in bandsFromRepo)
            //{
            //    bandsDto.Add(new Band_Dto()
            //    {
            //        Id = b.Id,
            //        Name = b.Name,
            //        MainGenre = b.MainGenre,
            //        FoundedYearsAgo = $"{b.Founded.ToString("yyyy")} ({b.Founded.GetYearsAgo()} years ago)"

            //    });
            //}

            //return new JsonResult(bandsFromRepo);
            //return new JsonResult(bandsDto);

            return Ok(_mapper.Map< IEnumerable<Band_Dto>>(bandsFromRepo));
        }

        // http://localhost:5000/api/bands/cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074
        [HttpGet("{bandId}", Name = "GetBand")]
        public IActionResult GetBand(Guid bandId)
        {
            var bandFromRepo = _bandAlbumRepository.GetBand(bandId);

            if (bandFromRepo == null)
                return NotFound();

            //return new JsonResult(bandFromRepo);
            return Ok(bandFromRepo);

        }

        // http://localhost:5000/api/bands
        /*
        {
            "name": "testing band createion",
            "founded": "2021-01-12",
            "mainGenre": "Rock",
            "albums" : [
                {
                    "title" : "tiele1",
                    "description": "album description 1"
                },
                {
                    "title" : "tiele2",
                    "description": "album description 2"
                }
            ]
        } 
        */
        [HttpPost]
        public ActionResult<Band_Dto> CreateBand([FromBody] BandForCreating_Dto newband)
        {
            var bandEntity = _mapper.Map<Entities.m_cls_Band>(newband); // Profiles
            _bandAlbumRepository.AddBand(bandEntity);
            _bandAlbumRepository.Save();

            var bandToReturn = _mapper.Map<Band_Dto>(bandEntity);

            // redirect to GetBand route (Name = GetBand)
            return CreatedAtRoute("GetBand", new { bandId = bandToReturn.Id }, bandToReturn);
        }

        // info for user which v are allow for this controller
        // this is option v
        [HttpOptions]
        public IActionResult GetBandsOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,DELETE,HEAD,OPTIONS");
            return Ok();
        }


        //
    }
}