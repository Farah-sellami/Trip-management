using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Autobus
    {
        [Key]
        public int idAutobus { get; set; }
        [Required]
        public int matricule { get; set; }
        public int capacite { get; set; }
        public ICollection<Voyage> Voyages { get; set; }
    }
}
