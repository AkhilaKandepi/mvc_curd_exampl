using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{
    public class PersonAddRequest
    {

        [Required]
        public string? PersonName { get; set; }

        [Required]
        [EmailAddress]
        public string? PersonEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [RegularExpression("Male|Female|Other",
        ErrorMessage = "Gender must be Male, Female, or Other")]
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; }
        //public string? Country { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string? Address { get; set; }

        [Required]
        [RegularExpression("A\\+|A-|B\\+|B-|AB\\+|AB-|O\\+|O-",
        ErrorMessage = "Enter a valid blood group")]
        public string? BloodGroup { get; set; }
        public bool ReceiveNewsLetters { get; set; }

    }



    public partial class PersonResponce
    { 
        public void Rani()
        { 
        
        }
    
    }
}
