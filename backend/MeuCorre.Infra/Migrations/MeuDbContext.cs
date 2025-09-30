using MeuCorre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuCorre.Infra.Data.Context
{
    public class MeuDbqContext : DbContext
    {
        // Removed duplicate constructor to fix CS0111 error
        public MeuDbqContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
    }
}
