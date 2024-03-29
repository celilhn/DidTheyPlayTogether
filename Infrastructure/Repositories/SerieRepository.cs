﻿using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public SerieRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public Serie AddSerie(Serie serie)
        {
            serie.InsertionDate = DateTime.Now;
            serie.UpdateDate = DateTime.Now;
            context.Series.Add(serie);
            context.SaveChanges();
            return serie;
        }

        public Serie GetSerie(int id)
        {
            return context.Series.Where(x => x.ID == id).SingleOrDefault();
        }

        public Serie GetSerie(string name)
        {
            return context.Series.Where(x => x.Name == name).FirstOrDefault();
        }

        public Serie GetSerieByOriginalName(string originalName)
        {
            return context.Series.Where(x => x.OriginalName == originalName).FirstOrDefault();
        }

        public Serie UpdateSerie(Serie serie)
        {
            context.Entry(serie).State = EntityState.Modified;
            context.SaveChanges();
            return serie;
        }
    }
}
