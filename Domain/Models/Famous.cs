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
    [Table("Famouses")]
    public class Famous : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Age { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Size { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Weight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateBirh { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Education { get; set; }
    }
}
