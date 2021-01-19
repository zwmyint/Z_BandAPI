using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Z_BandAPI.Entities
{
    public class m_cls_Band
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public DateTime Founded { get; set; }

        [Required]
        [MaxLength(50)]
        public string MainGenre { get; set; }

        // each band have multiple albums
        public ICollection<m_cls_Album> Albums { get; set; } = new List<m_cls_Album>();

    }
}
