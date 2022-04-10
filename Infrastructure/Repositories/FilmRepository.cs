using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly DidTheyPlayTogetherDbContext context;
        public FilmRepository(DidTheyPlayTogetherDbContext context)
        {
            this.context = context;
        }

        public Film AddFilm(Film film)
        {
            film.InsertionDate = DateTime.Now;
            film.UpdateDate = DateTime.Now;
            film.Status = 1;
            context.Films.Add(film);
            context.SaveChanges();
            return film;
        }

        public Film GetFilm(int id)
        {
            return context.Films.Where(x => x.ID == id).SingleOrDefault();
        }

        public Film GetFilm(string name)
        {
            return context.Films.Where(x => x.Name == name).SingleOrDefault();
        }

        public Film GetFilmByOriginalName(string originalName)
        {
            return context.Films.Where(x => x.OriginalName == originalName).FirstOrDefault();
        }

        public Film UpdateFilm(Film film)
        {
            context.Entry(film).State = EntityState.Modified;
            context.SaveChanges();
            return film;
        }
    }
}
