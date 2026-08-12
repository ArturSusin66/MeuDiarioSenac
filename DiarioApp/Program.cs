using DiarioSenac;

RepositorioDiario repositorio = new RepositorioDiario();

while (true)
{
    Console.Clear();

    Console.WriteLine("DIÁRIO SENAC");
    Console.WriteLine("1 - Novo Registro");
    Console.WriteLine("2 - Listar Registros");
    Console.WriteLine("3 - Buscar Registro por ID");
    Console.WriteLine("0 - Sair");
    Console.Write("\nEscolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            Registro novoRegistro = new Registro();

            Console.Write("Título: ");
            novoRegistro.Titulo = Console.ReadLine();

            Console.Write("Conteúdo: ");
            novoRegistro.Conteudo = Console.ReadLine();

            novoRegistro.DataRegistro = DateTime.Now;

            repositorio.Inserir(novoRegistro);

            Console.WriteLine("\nRegistro salvo com sucesso!");
            break;

        case "2":

            repositorio.ListarTodos();
            break;

        case "3":

            Console.Write("Digite o ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            repositorio.BuscarPorId(id);
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}