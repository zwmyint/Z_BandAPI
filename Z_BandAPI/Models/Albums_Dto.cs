using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Z_BandAPI.Models
{
    public class Albums_Dto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BandId { get; set; }
    }
}
