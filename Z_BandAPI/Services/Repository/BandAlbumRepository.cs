using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.DbContexts;
using Z_BandAPI.Entities;
using Z_BandAPI.Helpers;
using Z_BandAPI.Services.IRepository;

namespace Z_BandAPI.Services.Repository
{
    public class BandAlbumRepository : IBandAlbumRepository
    {
        //
        private readonly BandAlbumDbContext _context;

        public BandAlbumRepository(BandAlbumDbContext context)
        {
            // ?? null check
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        //

        //
        public void AddAlbum(Guid bandId, m_cls_Album album)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            if (album == null)
                throw new ArgumentNullException(nameof(album));

            album.BandId = bandId;
            _context.Albums.Add(album);

            //throw new NotImplementedException();
        }

        public void AddBand(m_cls_Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Add(band);

            //throw new NotImplementedException();
        }

        public bool AlbumExists(Guid albumId)
        {
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));

            return _context.Albums.Any(a => a.Id == albumId);

            //throw new NotImplementedException();
        }

        public bool BandExists(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.Any(b => b.Id == bandId);

            //throw new NotImplementedException();
        }

        public void DeleteAlbum(m_cls_Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _context.Albums.Remove(album);

            //throw new NotImplementedException();
        }

        public void DeleteBand(m_cls_Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Remove(band);

            //throw new NotImplementedException();
        }

        public m_cls_Album GetAlbum(Guid bandId, Guid albumId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));

            return _context.Albums.Where(a => a.BandId == bandId && a.Id == albumId).FirstOrDefault();

            //throw new NotImplementedException();
        }

        public IEnumerable<m_cls_Album> GetAlbums(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Albums.Where(a => a.BandId == bandId)
                                  .OrderBy(a => a.Title).ToList();

            //throw new NotImplementedException();
        }

        public m_cls_Band GetBand(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.FirstOrDefault(b => b.Id == bandId);

            //throw new NotImplementedException();
        }

        public IEnumerable<m_cls_Band> GetBands()
        {
            return _context.Bands.ToList();

            //throw new NotImplementedException();
        }

        public IEnumerable<m_cls_Band> GetBands(IEnumerable<Guid> bandIds)
        {
            if (bandIds == null)
                throw new ArgumentNullException(nameof(bandIds));

            return _context.Bands.Where(b => bandIds.Contains(b.Id))
                            .OrderBy(b => b.Name).ToList();

            //throw new NotImplementedException();
        }

        //
        
        //
        //PagedList
        public IEnumerable<m_cls_Band> GetBands(BandsResourceParameters bandsResourceParameters)
        {
            if (bandsResourceParameters == null)
                throw new ArgumentNullException(nameof(bandsResourceParameters));

            var collection = _context.Bands as IQueryable<m_cls_Band>;

            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.MainGenre))
            {
                var mainGenre = bandsResourceParameters.MainGenre.Trim();
                collection = collection.Where(b => b.MainGenre == mainGenre);
            }

            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.SearchQuery))
            {
                var searchQuery = bandsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(b => b.Name.Contains(searchQuery));
            }

            return collection.ToList();
            //
        }
        //

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
            //throw new NotImplementedException();
        }

        public void UpdateAlbum(m_cls_Album album)
        {
            //not implemented
            throw new NotImplementedException();
        }

        public void UpdateBand(m_cls_Band band)
        {
            //not implemented
            throw new NotImplementedException();
        }


        //
    }
}
