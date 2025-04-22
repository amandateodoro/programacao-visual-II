using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace AppInventario.Models
{
    [Table("propriedade")]
    public class Propriedade
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("valor")]
        public double? valor { get; set; }

        [Column("id_pessoa")]
        public int? IdPessoa { get; set; }

        [ForeignKey("IdPessoa")] //informa qual o atributo da classe vai armazenar a FK
        public Pessoa? Pessoa { get; set; } // indica o dono da propriedade
    }
}
