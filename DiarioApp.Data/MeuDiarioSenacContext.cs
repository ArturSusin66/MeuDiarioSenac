using MySql.Data.MySqlClient;

namespace DiarioSenac
{
    public class MeuDiarioSenacContext
    {
        private const string Servidor = "localhost";
        private const string Porta = "3306";
        private const string Banco = "diario_senac";
        private const string Usuario = "root";
        private const string Senha = "1234";

        private static string ConnectionString =>
            $"Server={Servidor};Port={Porta};Database={Banco};Uid={Usuario};Pwd={Senha};";

        public static MySqlConnection ObterConexao()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}