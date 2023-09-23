using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Crocheta.Models
{
    public class UsuarioRepository
    {
        private const string dadosConexao = "Database = Crocheta; Data Source = localhost; User Id = root";

        public void testeConexao()
        {
            MySqlConnection conexao = new MySqlConnection(connectionString: dadosConexao);

            conexao.Open();

            Console.WriteLine(value: "Conectado com sucesso!");

            conexao.Close();
        }

        public Usuario validarLogin(Usuario u)
        {
            Usuario usuarioLogado = null;

            using MySqlConnection conexao = new MySqlConnection(connectionString: dadosConexao);
            {
                conexao.Open();

                string query = "SELECT * FROM Usuario WHERE login = @login AND senha = @senha";
                MySqlCommand comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue(parameterName: "@login", value: u.login);
                comando.Parameters.AddWithValue(parameterName: "@senha", value: u.senha);

                using MySqlDataReader reader = comando.ExecuteReader();

                usuarioLogado = new Usuario();
                if (reader.Read())
                {

                    usuarioLogado.idUsuario = reader.GetInt32(name: "idUsuario");

                    if (!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "nome")))
                        usuarioLogado.nome = reader.GetString(name: "nome");

                    if (!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "login")))
                        usuarioLogado.login = reader.GetString(name: "login");

                    if (!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "senha")))
                        usuarioLogado.senha = reader.GetString(name: "senha");
                    
                    if (!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "dataNascimento")))
                        usuarioLogado.dataNascimento = reader.GetDateTime(name: "dataNascimento");
                }
                conexao.Close();
                return usuarioLogado;
            }
        }
    }
}