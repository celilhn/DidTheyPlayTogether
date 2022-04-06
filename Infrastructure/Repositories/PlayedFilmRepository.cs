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
    public class PlayedFilmRepository : IPlayedFilmRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public PlayedFilmRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public PlayedFilm AddPlayedFilm(PlayedFilm playedFilm)
        {
            playedFilm.InsertionDate = DateTime.Now;
            playedFilm.UpdateDate = DateTime.Now;
            playedFilm.Status = 1;
            context.PlayedFilms.Add(playedFilm);
            context.SaveChanges();
            return playedFilm;
        }

        public PlayedFilm GetPlayedFilm(int id)
        {
            return context.PlayedFilms.Where(x => x.ID == id).SingleOrDefault();
        }

        public List<PlayedFilm> GetPlayedFilmByFilmID(int filmId)
        {
            return context.PlayedFilms.Where(x => x.FilmID == filmId).ToList();
        }

        public List<PlayedFilm> GetPlayedFilmsByFamousID(int famousId)
        {
            return context.PlayedFilms.Where(x => x.FamousID == famousId).ToList();
        }

        public PlayedFilm UpdatePlayedFilm(PlayedFilm playedFilm)
        {
            context.Entry(playedFilm).State = EntityState.Modified;
            context.SaveChanges();
            return playedFilm;
        }
    }
}
