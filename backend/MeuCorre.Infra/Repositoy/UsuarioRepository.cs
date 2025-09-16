using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interface.Repository;
using MeuCorre.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Infra.REpositoy
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly MeuDbContext _meuDbContext;

        public UsuarioRepository(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }

        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            await _meuDbContext.Usuarios.AddAsync(usuario);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            _meuDbContext.Usuarios.Update(usuario);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task RemoverUsuarioAsync(Usuario usuario)
        {
            _meuDbContext.Usuarios.Remove(usuario);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            return _meuDbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
