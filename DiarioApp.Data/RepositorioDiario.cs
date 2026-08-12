using MySql.Data.MySqlClient;

namespace DiarioSenac
{
    public class RepositorioDiario
    {
        public void Inserir(Registro registro)
        {
            using var conexao = MeuDiarioSenacContext.ObterConexao();
            conexao.Open();

            string sql = "INSERT INTO registros (titulo, conteudo, data_registro) VALUES (@titulo, @conteudo, @data)";

            using var comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@titulo", registro.Titulo);
            comando.Parameters.AddWithValue("@conteudo", registro.Conteudo);
            comando.Parameters.AddWithValue("@data", registro.DataRegistro);

            comando.ExecuteNonQuery();
        }

        public void ListarTodos()
        {
            using var conexao = MeuDiarioSenacContext.ObterConexao();
            conexao.Open();

            string sql = "SELECT id, titulo, conteudo, data_registro FROM registros ORDER BY data_registro DESC";

            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();

            Console.WriteLine("\n--- Registros ---");
            while (leitor.Read())
            {
                Console.WriteLine($"ID: {leitor.GetInt32("id")}");
                Console.WriteLine($"Título: {leitor.GetString("titulo")}");
                Console.WriteLine($"Conteúdo: {leitor.GetString("conteudo")}");
                Console.WriteLine($"Data: {leitor.GetDateTime("data_registro")}");
              
            }
        }

        public void BuscarPorId(int id)
        {
            using var conexao = MeuDiarioSenacContext.ObterConexao();
            conexao.Open();

            string sql = "SELECT id, titulo, conteudo, data_registro FROM registros WHERE id = @id";

            using var comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@id", id);

            using var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                Console.WriteLine("\n--- Registro Encontrado ---");
                Console.WriteLine($"ID: {leitor.GetInt32("id")}");
                Console.WriteLine($"Título: {leitor.GetString("titulo")}");
                Console.WriteLine($"Conteúdo: {leitor.GetString("conteudo")}");
                Console.WriteLine($"Data: {leitor.GetDateTime("data_registro")}");
            }
            else
            {
                Console.WriteLine("\nNenhum registro encontrado com esse ID.");
            }
        }
    }
}