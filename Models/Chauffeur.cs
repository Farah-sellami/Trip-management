using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Chauffeur
    {
        [Key]
        public int idChauffeur { get; set; }
        [Required]
        public int cinChauffeur { get; set; }
        public string nomChauffeur { get; set; }
        public string typePermis { get; set; }
        public ICollection<Voyage> Voyages { get; set; }
    }
}
