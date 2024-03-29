﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("PlayedFilms")]
    public class PlayedFilm : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int FilmID { get; set; }
        [Column(TypeName = "int")]
        public int FamousID { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Character { get; set; }
        [Column(TypeName = "int")]
        public int ContributionID { get; set; }
    }
}
