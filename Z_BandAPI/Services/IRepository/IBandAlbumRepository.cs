using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.Entities;
using Z_BandAPI.Helpers;

namespace Z_BandAPI.Services.IRepository
{
    public interface IBandAlbumRepository
    {
        // Album
        IEnumerable<m_cls_Album> GetAlbums(Guid bandId);
        m_cls_Album GetAlbum(Guid bandId, Guid albumId);
        void AddAlbum(Guid bandId, m_cls_Album album);
        void UpdateAlbum(m_cls_Album album);
        void DeleteAlbum(m_cls_Album album);

        // Band
        IEnumerable<m_cls_Band> GetBands();
        m_cls_Band GetBand(Guid bandId);
        IEnumerable<m_cls_Band> GetBands(IEnumerable<Guid> bandIds);
        IEnumerable<m_cls_Band> GetBands(BandsResourceParameters bandsResourceParameters);
        void AddBand(m_cls_Band band);
        void UpdateBand(m_cls_Band band);
        void DeleteBand(m_cls_Band band);
        
        //
        bool BandExists(Guid bandId);
        bool AlbumExists(Guid albumId);
        bool Save();
        //
    }
}
