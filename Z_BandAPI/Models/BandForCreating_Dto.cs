using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Z_BandAPI.Models
{
    public class BandForCreating_Dto
    {
        //
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string MainGenre { get; set; }
        public ICollection<AlbumForCreating_Dto> Albums { get; set; } = new List<AlbumForCreating_Dto>();
        //
    }
}
