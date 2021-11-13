using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab13.Models
{
    public class Persona
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}