using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Awards")]
    public class Award : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "int")]
        public int Year { get; set; }
    }
}
