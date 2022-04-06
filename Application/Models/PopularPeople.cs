using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class KnownFor
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string media_type { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string first_air_date { get; set; }
        public string name { get; set; }
        public List<string> origin_country { get; set; }
        public string original_name { get; set; }
    }

    public class People
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public List<KnownFor> known_for { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public double popularity { get; set; }
        public string profile_path { get; set; }
    }

    public class PopularPeople
    {
        public int page { get; set; }
        public List<People> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
