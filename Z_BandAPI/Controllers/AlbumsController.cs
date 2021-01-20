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
    [Route("api/bands/{bandId}/albums")] // albums are the child of band
    public class AlbumsController : ControllerBase // this is for API Controller = ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public AlbumsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        // http://localhost:5000/api/bands/cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074/albums
        // return multiple albums from this band
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Albums_Dto>> GetAlbumsForBand(Guid bandId)
        {
            if (!_bandAlbumRepository.BandExists(bandId))
                return NotFound();

            var albumsFromRepo = _bandAlbumRepository.GetAlbums(bandId);
            return Ok(_mapper.Map<IEnumerable<Albums_Dto>>(albumsFromRepo));
        }

        // http://localhost:5000/api/bands/cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074/albums/380c545c-9665-4043-baf2-34a3edefd373
        // return one single album based on albumId
        [HttpGet("{albumId}", Name = "GetAlbumForBand")]
        public ActionResult<Albums_Dto> GetAlbumForBand(Guid bandId, Guid albumId)
        {
            if (!_bandAlbumRepository.BandExists(bandId))
                return NotFound();

            var albumFromRepo = _bandAlbumRepository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<Albums_Dto>(albumFromRepo));
        }

        // http://localhost:5000/api/bands/8e2f0a16-4c09-44c7-ba56-8dc62dfd792d/albums
        [HttpPost]
        public ActionResult<Albums_Dto> CreateAlbumForBand(Guid bandId, [FromBody] AlbumForCreating_Dto newalbum)
        {
            if (!_bandAlbumRepository.BandExists(bandId))
                return NotFound();

            var albumEntity = _mapper.Map<Entities.m_cls_Album>(newalbum);
            _bandAlbumRepository.AddAlbum(bandId, albumEntity);
            _bandAlbumRepository.Save();

            var albumToReturn = _mapper.Map<Albums_Dto>(albumEntity);
            return CreatedAtRoute("GetAlbumForBand", new { bandId = bandId, albumId = albumToReturn.Id }, albumToReturn);
        }

        // http://localhost:5000/api/bands/a052a63d-fa53-44d5-a197-83089818a676/albums/218a7203-77a7-44b5-3982-08d8bd41f19d
        [HttpPut("{albumId}")]
        public ActionResult UpdateAlbumForBand(Guid bandId, Guid albumId, [FromBody] AlbumForUpdating_Dto updatealbum)
        {
            if (!_bandAlbumRepository.BandExists(bandId))
                return NotFound();

            var albumFromRepo = _bandAlbumRepository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
            {
                //    var albumToAdd = _mapper.Map<Entities.m_cls_Album>(updatealbum);
                //    albumToAdd.Id = albumId;
                //    _bandAlbumRepository.AddAlbum(bandId, albumToAdd);
                //    _bandAlbumRepository.Save();

                //    var albumToReturn = _mapper.Map<Albums_Dto>(albumToAdd);

                //    return CreatedAtRoute("GetAlbumForBand", new { bandId = bandId, albumId = albumToReturn.Id }, albumToReturn);

                return NotFound();
            }

            _mapper.Map(updatealbum, albumFromRepo); // Profiles

            _bandAlbumRepository.UpdateAlbum(albumFromRepo);
            _bandAlbumRepository.Save();

            return NoContent();
            //
        }

        //
    }
}