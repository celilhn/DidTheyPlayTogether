using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FamousRepository : IFamousRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public FamousRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }
        public Famous AddFamous(Famous famous)
        {
            famous.DateBirh = DateTime.Now;
            famous.InsertionDate = DateTime.Now;
            famous.UpdateDate = DateTime.Now;
            famous.Status = 1;
            context.Famouses.Add(famous);
            context.SaveChanges();
            return famous;
        }

        public Famous GetFamous(int id)
        {
            return context.Famouses.Where(x => x.ID == id).SingleOrDefault();
        }

        public Famous GetFamous(string name)
        {
            return context.Famouses.Where(x => x.Name == name).SingleOrDefault();
        }

        public List<Famous> GetFamouses()
        {
            return context.Famouses.ToList();
        }

        public List<Famous> GetFamousFromMovieDb()
        {
            return context.Famouses.Where(x => x.SourceID == 1).ToList();
        }

        public List<Famous> GetFamousFromWikipedia()
        {
            return context.Famouses.Where(x => x.SourceID == 0).ToList();
        }

        public Famous UpdateFamous(Famous famous)
        {
            context.Entry(famous).State = EntityState.Modified;
            context.SaveChanges();
            return famous;
        }
    }
}
