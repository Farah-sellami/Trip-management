using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
   public interface IAutobusRepository
    {
        IList<Autobus> GetAll();
        Autobus GetAutobusById(int id);
        void AddAutobus(Autobus a);
        void EditAutobus(Autobus a);
        void DeleteAutobus(Autobus a);
    

    }
}
