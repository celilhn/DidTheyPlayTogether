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
    [Table("Contributions")]
    public class Contribution : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }
    }
}
