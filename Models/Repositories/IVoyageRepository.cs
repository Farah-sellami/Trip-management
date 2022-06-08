using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public interface IVoyageRepository
    {
        IList<Voyage> GetAll();
        Voyage GetById(int id);
        void AddVoyage(Voyage v);
        void EditVoyage(Voyage v);
        void DeleteVoyage(Voyage v);
        IList<Voyage> GetVoyagesByExcursionID(int? idExcur);
    }
}
