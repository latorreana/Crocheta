using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Crocheta.Models
{
    public class ContatoRepository
    {
        private const string dadosConexao = "Database = Crocheta; Data Source = localhost; User Id = root";

        public void testeConexao()
        {
            MySqlConnection conexao = new MySqlConnection(connectionString: dadosConexao);

            conexao.Open();

            Console.WriteLine("Conectado com sucesso!");

            conexao.Close();
        }
        public void inserir(Contato contato)
        {
            MySqlConnection conexao = new MySqlConnection(connectionString: dadosConexao);
            conexao.Open();

            string query = "INSERT INTO Contato (nomeContato, telefone, email, mensagem) VALUES (@nomeContato, @telefone, @email, @mensagem)";

            MySqlCommand comando = new MySqlCommand(commandText: query, connection: conexao);

            comando.Parameters.AddWithValue(parameterName: "@nomeContato", value: contato.nomeContato);
            comando.Parameters.AddWithValue(parameterName: "@telefone", value: contato.telefone);
            comando.Parameters.AddWithValue(parameterName: "@email", value: contato.email);
            comando.Parameters.AddWithValue(parameterName: "@mensagem", value: contato.mensagem);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public List<Contato> listar()
        {
            List<Contato> lista = new List<Contato>();

            MySqlConnection conexao = new MySqlConnection(connectionString: dadosConexao);
            conexao.Open();

            string query = "SELECT * FROM Contato";
            MySqlCommand comando = new MySqlCommand(commandText: query, connection: conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contato novoContato = new Contato();

                novoContato.idContato = reader.GetInt32("idContato");

                if (!reader.IsDBNull(reader.GetOrdinal("nomeContato")))
                    novoContato.nomeContato = reader.GetString("nomeContato");

                if (!reader.IsDBNull(reader.GetOrdinal("telefone")))
                    novoContato.telefone = reader.GetString("telefone");

                if (!reader.IsDBNull(reader.GetOrdinal("email")))
                    novoContato.email = reader.GetString("email");

                if (!reader.IsDBNull(reader.GetOrdinal("mensagem")))
                    novoContato.mensagem = reader.GetString("mensagem");

                lista.Add(novoContato);
            }

            conexao.Close();

            return lista;
        }
    }
}
