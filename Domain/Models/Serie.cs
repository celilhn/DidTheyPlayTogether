using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Series")]
    public class Serie : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "int")]
        public int FirstEpisodeAirDate { get; set; }
        [Column(TypeName = "int")]
        public int LastEpisodeAirDate { get; set; }
        [Column(TypeName = "int")]
        public int NumberofSeasons { get; set; }
        [Column(TypeName = "int")]
        public int NumberofEpisodes { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Channel { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Producer { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Siciation { get; set; }
        [Column(TypeName = "int")]
        public int SourceID { get; set; }
    }
}
