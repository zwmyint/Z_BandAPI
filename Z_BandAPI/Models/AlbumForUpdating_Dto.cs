using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.ValidationAttributes;

namespace Z_BandAPI.Models
{
    //[TitleAndDescriptionAttribute] // custom error message
    public class AlbumForUpdating_Dto : AlbumManipulation_Dto
    {
        //[Required]
        //[MaxLength(200)]
        //public string Title { get; set; }

        //[Required]
        //[MaxLength(400)]
        //public string Description { get; set; }

        [Required(ErrorMessage = "You need to fill description")]
        public override string Description { get => base.Description; set => base.Description = value; }
        //
    }
}
