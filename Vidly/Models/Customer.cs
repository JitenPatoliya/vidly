using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Helpers;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; } //NOTE: automatically tagged as required, because emptry string from view cannot translate to byte value, which make its valid state false
    }
}