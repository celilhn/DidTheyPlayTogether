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
        public string Subject { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Producer { get; set; }

    }
}
