using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.ValidationAttributes;

namespace Z_BandAPI.Models
{
    [TitleAndDescriptionAttribute] // class level (overrided)
    public class AlbumForCreating_Dto // : IValidatableObject
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(Title == Description)
        //    {
        //        yield return new ValidationResult("The title and description need to be different.", new[] { "AlbumForCreation_Dto" });
        //    }
        //}


    }
}
