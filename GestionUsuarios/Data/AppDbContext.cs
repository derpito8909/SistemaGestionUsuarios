using GestionUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUsuarios.Data;

public class AppDbContext : DbContext

{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options){}

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Usuario>()
        .HasKey(x => x.IdUser);
    }
}
