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
    [Table("Films")]
    public class Film : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string OriginalName { get; set; }
        [Column(TypeName = "varchar(1500)")]
        public string Subject { get; set; }
        [Column(TypeName = "varchar(400)")]
        public string Producer { get; set; }
        [Column(TypeName = "varchar(75)")]
        public string Director { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Note { get; set; }
        [Column(TypeName = "int")]
        public int FilmCategoryID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PosterPath { get; set; }
        [Column(TypeName = "int")]
        public int ReleaseDate { get; set; }
        [Column(TypeName = "int")]
        public int SourceID { get; set; }

    }
}
