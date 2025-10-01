using Application.Interfaces;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
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

        public Task<List<Conta>> ObterPorUsuarioAsync(Guid usuarioId, bool apenasAtivas = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<Conta>> ObterPorTipoAsync(Guid usuarioId, TipoConta tipo)
        {
            throw new NotImplementedException();
        }

        public Task<Conta?> ObterPorIdEUsuarioAsync(Guid contaId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteContaComNomeAsync(Guid usuarioId, string nome, Guid? contaIdExcluir = null)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> CalcularSaldoTotalAsync(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        Task IContaRepository.ListarPorUsuarioAsync(Guid usuarioId)
        {
            return ListarPorUsuarioAsync(usuarioId);
        }
    }
}
