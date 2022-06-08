using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public class VoyageRepository : IVoyageRepository
    {
        readonly AppDbContext context;
        public VoyageRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddVoyage(Voyage v)
        {
            context.Voyages.Add(v);
            context.SaveChanges();
        }

        public void DeleteVoyage(Voyage v)
        {
            Voyage v1 = context.Voyages.Find(v.idVoyage);
            if (v1 != null)
            {
                context.Voyages.Remove(v1);
                context.SaveChanges();
            }
        }

        public void EditVoyage(Voyage v)
        {
            Voyage v1 = context.Voyages.Find(v.idVoyage);
            if (v1 != null)
            {
                v1.DateDep = v.DateDep;
                v1.DateRetour = v.DateRetour;
                v1.idAutobus = v.idAutobus;
                v1.idChauffeur = v.idChauffeur;
                v1.idExcur = v.idExcur;
                context.SaveChanges();
            }
        }

        public IList<Voyage> GetAll()
        {
            return context.Voyages.Include(x=> x.Excursion).ToList();
        }

        public Voyage GetById(int id)
        {
            return context.Voyages.Where(x => x.idVoyage ==id).Include(x => x.Excursion).SingleOrDefault();
        }

    public IList<Voyage> GetVoyagesByExcursionID(int? idEx)
        {
            return context.Voyages.Where(s => s.idExcur .Equals(idEx)).Include(std => std.Excursion).ToList();

        }
    }
}
