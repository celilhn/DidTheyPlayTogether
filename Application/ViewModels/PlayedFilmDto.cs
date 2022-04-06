using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PlayedFilmDto
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public int FamousID { get; set; }
        public string Character { get; set; }
        public int ContributionID { get; set; }
        public string Year { get; set; }
    }
}
