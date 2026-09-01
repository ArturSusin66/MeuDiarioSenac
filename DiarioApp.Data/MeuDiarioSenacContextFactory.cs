using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DiarioApp.Data;

public class MeuDiarioSenacContextFactory : IDesignTimeDbContextFactory<MeuDiarioSenacContext>
{
    public MeuDiarioSenacContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MeuDiarioSenacContext>();
        var connectionString = "Server=localhost;Database=diario_senac;User=root;Password=1234;";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

        optionsBuilder.UseMySql(connectionString, serverVersion);

        return new MeuDiarioSenacContext(optionsBuilder.Options);
    }
}
