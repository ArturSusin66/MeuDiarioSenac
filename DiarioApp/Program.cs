using DiarioSenac;
using DiarioApp.Model.Models;
using MeudiarioSenac.Business;

RegistroBusiness business = new RegistroBusiness();


RepositorioDiario repositorio = new RepositorioDiario();


try
{
    repositorio.GarantirUsuarioPadrao();
}
catch
{
}

while (true)
{
    Console.Clear();


    Console.WriteLine("        DIÁRIO SENAC APP           ");

    Console.WriteLine("1 - Novo Registro ");
    Console.WriteLine("2 - Listar Registros ");
    Console.WriteLine("3 - Buscar Registro por ID ");
    Console.WriteLine("4 - Atualizar Registro ");
    Console.WriteLine("5 - Excluir Registro");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Registro novoRegistro = new Registro();

            Console.Write("\nTítulo: ");
            novoRegistro.Titulo = Console.ReadLine();

            Console.Write("Conteúdo: ");
            novoRegistro.Conteudo = Console.ReadLine();

            Console.Write("ID do Usuário (padrão 1): ");
            string? entradaUsuarioId = Console.ReadLine();
            novoRegistro.UsuarioId = int.TryParse(entradaUsuarioId, out int usuarioId) ? usuarioId : 1;

            novoRegistro.DataRegistro = DateTime.Now;

            try
            {
                business.ValidarTituloObrigatorio(novoRegistro.Titulo);
                business.ValidarTituloMaximo(novoRegistro.Titulo);
                business.ValidarData(novoRegistro.DataRegistro);
                business.ValidarConteudo(novoRegistro.Conteudo);

                repositorio.Inserir(novoRegistro);
                Console.WriteLine("\nRegistro salvo com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nValidação: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao persistir: {ex.Message}");
            }
            break;

        case "2":
            try
            {
                repositorio.ListarTodos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao listar registros: {ex.Message}");
            }
            break;

        case "3":
            Console.Write("\nDigite o ID: ");
            if (int.TryParse(Console.ReadLine(), out int idBusca))
            {
                try
                {
                    repositorio.BuscarPorId(idBusca);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro na busca: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Digite um número inteiro.");
            }
            break;

        case "4":
            Console.Write("\nDigite o ID do registro a ser atualizado: ");
            if (int.TryParse(Console.ReadLine(), out int idAtualizar))
            {
                Console.Write("Novo Título: ");
                string? novoTitulo = Console.ReadLine();

                Console.Write("Novo Conteúdo: ");
                string? novoConteudo = Console.ReadLine();

                try
                {
                    business.ValidarTituloObrigatorio(novoTitulo);
                    business.ValidarTituloMaximo(novoTitulo);
                    business.ValidarConteudo(novoConteudo);

                    repositorio.Atualizar(idAtualizar, novoTitulo ?? string.Empty, novoConteudo ?? string.Empty);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\nValidação: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro ao atualizar: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "5":
            Console.Write("\nDigite o ID do registro a ser excluído: ");
            if (int.TryParse(Console.ReadLine(), out int idExcluir))
            {
                Console.Write($"Confirma a exclusão do registro #{idExcluir}? (s/n): ");
                string? confirmacao = Console.ReadLine();

                if (confirmacao?.ToLower() == "s")
                {
                    try
                    {
                        repositorio.Remover(idExcluir);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nErro ao excluir: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Exclusão cancelada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "0":
            Console.WriteLine("\nEncerrando a aplicação...");
            return;

        default:
            Console.WriteLine("\nOpção inválida.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}