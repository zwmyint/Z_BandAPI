using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Z_BandAPI.Models;

namespace Z_BandAPI.ValidationAttributes
{
    public class TitleAndDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var album = (AlbumForCreating_Dto)validationContext.ObjectInstance;

            if (album.Title == album.Description)
            {
                return new ValidationResult("The title and the description need to be different", new[] { "AlbumForCreating_Dto" });
            }

            return ValidationResult.Success;
        }
    }
}
