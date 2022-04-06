using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("FilmCategories")]
    internal class FilmCategory : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(100)")]
        public string CategoryName { get; set; }
    }
}
