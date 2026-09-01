namespace DiarioSenac;

public class RepositorioDiario
{
    private readonly MeuDiarioSenacContext _context = new MeuDiarioSenacContext();

    public void Inserir(Registro registro)
    {
        _context.Registros.Add(registro);
        _context.SaveChanges();
    }

    public void ListarTodos()
    {
        var registros = _context.Registros.ToList();
        if (registros.Count == 0)
        {
            Console.WriteLine("\nNenhum registro encontrado.");
            return;
        }

        Console.WriteLine("\n--- Lista de Registros ---");
        foreach (var registro in registros)
        {
            Console.WriteLine($"ID: {registro.Id} | Título: {registro.Titulo} | Data: {registro.DataRegistro:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Conteúdo: {registro.Conteudo}");
            Console.WriteLine(new string('-', 30));
        }
    }

    public void BuscarPorId(int id)
    {
        var registro = _context.Registros.Find(id);
        if (registro != null)
        {
            Console.WriteLine("\n--- Registro Encontrado ---");
            Console.WriteLine($"ID: {registro.Id}");
            Console.WriteLine($"Título: {registro.Titulo}");
            Console.WriteLine($"Data: {registro.DataRegistro:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Conteúdo: {registro.Conteudo}");
            Console.WriteLine($"Usuário ID: {registro.UsuarioId}");
        }
        else
        {
            Console.WriteLine($"\nRegistro com ID {id} não encontrado.");
        }
    }
}