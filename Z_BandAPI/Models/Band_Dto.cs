using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Z_BandAPI.Models
{
    public class Band_Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FoundedYearsAgo { get; set; }
        public string MainGenre { get; set; }
    }
}
