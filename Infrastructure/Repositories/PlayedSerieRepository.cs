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
    public class PlayedSerieRepository : IPlayedSerieRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public PlayedSerieRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public PlayedSerie AddPlayedSerie(PlayedSerie playedSerie)
        {
            playedSerie.InsertionDate = DateTime.Now;
            playedSerie.UpdateDate = DateTime.Now;
            playedSerie.Status = 1;
            context.PlayedSeries.Add(playedSerie);
            context.SaveChanges();
            return playedSerie;
        }

        public PlayedSerie GetPlayedSerie(int id)
        {
            return context.PlayedSeries.Where(x => x.ID == id).SingleOrDefault();
        }

        public List<PlayedSerie> GetPlayedSeriesByFamousID(int famousId)
        {
            return context.PlayedSeries.Where(x => x.FamousID == famousId).ToList();
        }

        public List<PlayedSerie> GetPlayedSeriesByFilmID(int filmId)
        {
            return context.PlayedSeries.Where(x => x.FilmID == filmId).ToList();
        }

        public PlayedSerie UpdatePlayedSerie(PlayedSerie playedSerie)
        {
            context.Entry(playedSerie).State = EntityState.Modified;
            context.SaveChanges();
            return playedSerie;
        }
    }
}
