using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Z_BandAPI.Entities
{
    public class m_cls_Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        // relationship between band
        [ForeignKey("BandId")]
        public m_cls_Band Band { get; set; }
        public Guid BandId { get; set; }
    }
}
