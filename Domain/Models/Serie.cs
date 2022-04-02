﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Series")]
    public class Serie
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FirstEpisodeAirDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastEpisodeAirDate { get; set; }
        [Column(TypeName = "int")]
        public int NumberofSeasons { get; set; }
        [Column(TypeName = "int")]
        public int NumberofEpisodes { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Channel { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Producer { get; set; }
    }
}