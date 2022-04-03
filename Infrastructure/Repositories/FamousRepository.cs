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

        public Famous UpdateFamous(Famous famous)
        {
            context.Entry(famous).State = EntityState.Modified;
            context.SaveChanges();
            return famous;
        }
    }
}
