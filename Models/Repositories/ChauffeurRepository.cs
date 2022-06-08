using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Models.Repositories
{
    public class ChauffeurRepository : IChauffeurRepository
    {
        readonly AppDbContext context;
        public ChauffeurRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void AddChauffeur(Chauffeur ch)
        {
            context.Chauffeurs.Add(ch);
            context.SaveChanges();
        }

        public void DeleteChauffeur(Chauffeur ch)
        {
            Chauffeur ch1 = context.Chauffeurs.Find(ch.idChauffeur);
            if (ch1 != null)
            {
                context.Chauffeurs.Remove(ch1);
                context.SaveChanges();
            }
        }

        public void EditChauffeur(Chauffeur ch)
        {
            Chauffeur ch1 = context.Chauffeurs.Find(ch.idChauffeur);
            if (ch1 != null)
            {
                ch1.nomChauffeur = ch.nomChauffeur;
                ch1.cinChauffeur = ch.cinChauffeur;
                ch1.typePermis = ch.typePermis;
                context.SaveChanges();
            }
        }

        public IList<Chauffeur> FindChauffeurByName(string name)
        {
            return context.Chauffeurs.Where(ch =>ch.nomChauffeur.Contains(name)).ToList();

        }

        public IList<Chauffeur> GetAll()
        {
            return context.Chauffeurs.OrderBy(ch => ch.nomChauffeur).ToList();
        }

        public Chauffeur GetById(int id)
        {
            return context.Chauffeurs.Find(id);
        }
    }
}
