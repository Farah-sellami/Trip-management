using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public class ExcursionRepository : IExcursionRepository
    {
        readonly AppDbContext context;
        public ExcursionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddExcursion(Excursion e)
        {
            context.Excursions.Add(e);
            context.SaveChanges();
        }

        public void DeleteExcursion(Excursion e)
        {
            Excursion e1 = context.Excursions.Find(e.idExcur);
            if (e1 != null)
            {
                context.Excursions.Remove(e1);
                context.SaveChanges();
            }
        }

        public void EditExcursion(Excursion e)
        {
            Excursion e1 = context.Excursions.Find(e.idExcur);
            if (e1 != null)
            {
                e1.description = e.description;
                e1.imageExcur = e.imageExcur;
                e1.lieuExcur = e.lieuExcur;
                e1.prixExcur = e.prixExcur;
                context.SaveChanges();
            }
        }

        public IList<Excursion> FindExcursionByLieu(string lieuE)
        {
            return context.Excursions.Where(e =>e.lieuExcur.Contains(lieuE)).ToList();

        }

        public IList<Excursion> GetAllExcursion()
        {
            return context.Excursions.ToList();
        }

        public Excursion GetExcursionById(int id)
        {
            return context.Excursions.Find(id);
        }

        public Excursion Update(Excursion excursionChanges)
        {
            var excursion = context.Excursions.Attach(excursionChanges);
            excursion.State = EntityState.Modified;
            context.SaveChanges();
            return excursionChanges;
        }
    }
}
