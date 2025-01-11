using CadastroUsuarioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarioApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
