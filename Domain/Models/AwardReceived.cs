using Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("AwardReceiveds")]
    internal class AwardReceived : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int FamousID { get; set; }
        [Column(TypeName = "int")]
        public int AwardID { get; set; }
        [Column(TypeName = "int")]
        public int AwardCategoryID { get; set; }
        [Column(TypeName = "varchar(80)")]
        public string CandidacyWork { get; set; }
        [Column(TypeName = "tinyint"), DefaultValue(1)]
        public short Result { get; set; }
    }
}
