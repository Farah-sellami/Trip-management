using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models
{
    public class Voyage
    {
        [Key]
        public int idVoyage { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDep { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRetour { get; set; }

        public int idAutobus { get; set; }
        public Autobus Autobus { get; set; }
        public int idChauffeur { get; set; }
        public Chauffeur Chauffeur { get; set; }
        public int idExcur { get; set; }
        public Excursion Excursion { get; set; }


    }
}
