using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public interface IChauffeurRepository
    {
        IList<Chauffeur> GetAll();
        Chauffeur GetById(int id);
        void AddChauffeur(Chauffeur ch);
        void EditChauffeur(Chauffeur ch);
        void DeleteChauffeur(Chauffeur ch);
        IList<Chauffeur> FindChauffeurByName(string name);
    }
}
