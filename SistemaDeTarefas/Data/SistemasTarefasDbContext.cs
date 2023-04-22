using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemasTarefasDbContext : DbContext
    {
        public SistemasTarefasDbContext(DbContextOptions<SistemasTarefasDbContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TarefaModel>()
                 .HasOne(tarefa => tarefa.Usuario);
        }



    }
}
