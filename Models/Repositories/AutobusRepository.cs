using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public class AutobusRepository : IAutobusRepository
    {
        readonly AppDbContext context;
        public AutobusRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddAutobus(Autobus a)
        {
            context.Autobus.Add(a);
            context.SaveChanges();
        }

        public void DeleteAutobus(Autobus a)
        {
            Autobus a1 = context.Autobus.Find(a.idAutobus);
            if (a1 != null)
            {
                context.Autobus.Remove(a1);
                context.SaveChanges();
            }
        }

        public void EditAutobus(Autobus a)
        {
            Autobus a1 = context.Autobus.Find(a.idAutobus);
            if (a1 != null)
            {
                a1.matricule = a.matricule;
                a1.capacite = a.capacite ;
                context.SaveChanges();
            }

        }

        public IList<Autobus> GetAll()
        {
            return context.Autobus.OrderBy(a => a.matricule).ToList();
        }

        public Autobus GetAutobusById(int id)
        {
            return context.Autobus.Find(id);
        }
    }
}
