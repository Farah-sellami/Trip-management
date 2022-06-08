using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public interface IExcursionRepository
    {
        IList<Excursion> GetAllExcursion();
        Excursion GetExcursionById(int id);
        void AddExcursion(Excursion e);
        void EditExcursion(Excursion e);
        void DeleteExcursion(Excursion e);
        Excursion Update(Excursion excursionChanges);

        IList<Excursion> FindExcursionByLieu(string lieuExcur);


    }
}
