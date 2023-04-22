using SistemaDeTarefas.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
        [MaxLength(1000)]
        public string? Descricao { get; set; }
        [Required]
        public StatusTarefas Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; } 
    }
}
