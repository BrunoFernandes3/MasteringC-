using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    [Table("Cidade")]
    public class CidadeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CidadeId { get; set; }
        [MaxLength(100)]
        [MinLength(2)]
        public string CidadeNome { get; set; }

        public int QuantidadeHabitantes { get; set; }
        [NotMapped]
        public string PrefeitoNome { get; set; }
    }
}
