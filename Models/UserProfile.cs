using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NextGenLife.Models
{
    public class UserProfile
    {
        [Key]

        public string UserProfilePk { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }
        public string gender { get; set; }
        public string UserProfileIdNumber { get; set; }
        public string UserProfileEmail { get; set; }

        public string UserProfileCellNumber { get; set; }
        public string UserProfileAlternativeNumber { get; set; }

        public string UserProfileAddress { get; set; }
    
    }
}