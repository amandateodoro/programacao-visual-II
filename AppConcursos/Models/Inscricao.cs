using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcursos.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("numero_insc")]
        public int NumeroInscricao { get; set; }

        [Column("data_inscricao")]
        public DateTime? DataInscricao { get; set; }

        [Column("nota_conh_gerais")]
        public decimal NotaConhecimentosGerais {  get; set; }

        [Column("nota_conh_especificos")]
        public decimal NotaConhecimentosEspecificos { get; set; }

        [ForeignKey("candidato_id")]
        public Candidato? Candidato { get; set; }

        [ForeignKey("cargo_id")]
        public Cargo? Cargo { get; set; }
    }
}
