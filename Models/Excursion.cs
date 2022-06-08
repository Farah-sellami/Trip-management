using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Excursion
    {
        [Key]
        public int idExcur { get; set; }
        public string imageExcur { get; set; }
        public string lieuExcur { get; set; }
        public string description { get; set; }
        public int prixExcur { get; set; }
        public ICollection< Voyage> Voyages { get; set; }
    }
}
