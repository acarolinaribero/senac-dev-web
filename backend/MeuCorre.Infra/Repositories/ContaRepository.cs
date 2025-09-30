using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MeuCorre.Infra.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly MeuDbContext _context;

        public ContaRepository(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<Conta?> ObterPorIdAsync(Guid id)
        {
            return await _context.Contas
                .Include(c => c.Usuario) 
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Conta>> ListarPorUsuarioAsync(Guid usuarioId)
        {
            return await _context.Contas
                .Where(c => c.UsuarioId == usuarioId)
                .OrderBy(c => c.Nome) 
                .ToListAsync();
        }

        public async Task AdicionarAsync(Conta conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Conta conta)
        {
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Conta conta)
        {
            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();
        }
    }
}
