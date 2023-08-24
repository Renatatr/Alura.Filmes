using System.ComponentModel.DataAnnotations.Schema;

namespace Alura.Filmes.App.Negocio
{
    [Table("actor")]
    internal class Ator
    {
        [Column("actor_id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string PrimeiroNome { get; set; }
        [Column("last_name")]
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $"Ator ({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
