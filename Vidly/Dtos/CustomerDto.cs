using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Helpers;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //[Min18YearsIfAMember] //NOTE: To support ActionResult response from API
        public DateTime? BirthDate { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
} 