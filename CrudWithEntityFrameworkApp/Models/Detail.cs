using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithEntityFrameworkApp.Models
{
    class Detail
    {
        [Key]
        public int Id { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public DateTime Dob { get; set; }
    }
}
