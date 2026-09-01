using DiarioSenac;
using Microsoft.EntityFrameworkCore;

public class MeuDiarioSenacContext : DbContext
{
    public MeuDiarioSenacContext()
    {
    }

    public MeuDiarioSenacContext(
        DbContextOptions<MeuDiarioSenacContext> options)
        : base(options)
    {
    }

    public DbSet<Registro> Registros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    private readonly string connectionString = "Server=localhost;Database=diario_senac;User=root;Password=1234;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Registros)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.UsuarioId);
    }
}