using RedCloud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class NumberVM
    {


        public int NumberId { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter Valid Details")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits and it should be in Numeric Format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Select Type Name")]
        public int TypesId { get; set; }
        //public Types Types { get; set; }

        [Required(ErrorMessage = "Please Select State ")]
        public int StateId { get; set; }
        //  public State State { get; set; }
        public int? AssignmentTypeId { get; set; }
        // public AssignmentType? AssignmentType { get; set; }

        [Required(ErrorMessage = "Please Select Carrier ")]
        public int? CarrierId { get; set; }
        //  public Carrier? Carrier { get; set; }

        //public Country Country { get; set; }
        [Required(ErrorMessage = "Please Select Country Name")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please Select Country Name")]
        public int CityId { get; set; }

        [RegularExpression(@"^\d{3}$", ErrorMessage = "LATA must be a 3-digit number.")]
        public string LATA { get; set; }

        [RegularExpression(@"^\d{4}$", ErrorMessage = "RateCenter must be a 4-digit number.")]
        public string RateCenter { get; set; }

        [Required(ErrorMessage = "Please Select StartDate")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please Select EndDate ")]
        public DateTime EndDate { get; set; }


    }
}
