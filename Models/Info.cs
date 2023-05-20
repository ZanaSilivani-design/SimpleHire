using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SimpleHire.Models
{
    public class Info
    {
        public int InfoId { get; set; }
        [Required(ErrorMessage ="please enter the full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter the full name")]
        [Range(1,30, ErrorMessage ="Must put how many years of experience")]
        public int? YearExp { get; set; }

        [Required(ErrorMessage = "please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "please enter your major")]
        public string Major { get; set; }

        [Required(ErrorMessage ="Plese select the job you are looking for")]
        public string JobId { get; set; }
        [ValidateNever]
        public Job Job { get; set; }
    }
}
