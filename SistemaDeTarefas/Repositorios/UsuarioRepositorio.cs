using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTarefasDbContext _context;
        public UsuarioRepositorio(SistemasTarefasDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _context.Usuarios.AddAsync(usuario);
           await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para de id {id} não foi localizado.");
            }
            _context.Usuarios.Remove(usuarioPorId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null) 
            {
                throw new Exception($"Usuario para de id {id} não foi localizado.");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            _context.Usuarios.Update(usuarioPorId);
            await _context.SaveChangesAsync();
            return usuarioPorId;
        }

    }
}
