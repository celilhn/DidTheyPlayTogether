using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("AwardCategories")]
    public class AwardCategory : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(100)")]
        public string CategoryName { get; set; }
    }
}
