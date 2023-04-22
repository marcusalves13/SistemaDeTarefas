using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemasTarefasDbContext _context;
        public TarefaRepositorio(SistemasTarefasDbContext context)
        {
            _context = context;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _context.Tarefas
                .Include(tarefa => tarefa.Usuario)
                .FirstOrDefaultAsync(tarefa => tarefa.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _context.Tarefas
                .Include(tarefa => tarefa.Usuario)
                .ToListAsync();
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
           await _context.Tarefas.AddAsync(tarefa);
           await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Usuario para de id {id} não foi localizado.");
            }
            _context.Tarefas.Remove(tarefaPorId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null) 
            {
                throw new Exception($"Tarefa para de id {id} não foi localizado.");
            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _context.Tarefas.Update(tarefaPorId);
            await _context.SaveChangesAsync();
            return tarefaPorId;
        }

    }
}
