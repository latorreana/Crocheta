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
            Usuario UsuarioLogado = null;

            MySqlConnection conexao = new MySqlConnection(connectionString: dadosConexao);
            conexao.Open();

            string query = "SELECT * FROM Usuario WHERE login = @login AND senha = @senha";
            MySqlCommand comando = new MySqlCommand(commandText: query, connection: conexao);
            
            comando.Parameters.AddWithValue(parameterName: "@login", value: u.login);
            comando.Parameters.AddWithValue(parameterName: "@senha", value: u.senha);

            using MySqlDataReader reader = comando.ExecuteReader();

            if(reader.Read())
            {
                UsuarioLogado = new Usuario();
                
                UsuarioLogado.idUsuario = reader.GetInt32(name: "idUsuario");

                if(!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "nome")))
                UsuarioLogado.nome = reader.GetString(name: "nome");

                if(!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "login")))
                UsuarioLogado.login = reader.GetString(name: "login");

                if(!reader.IsDBNull(ordinal: reader.GetOrdinal(name: "senha")))
                UsuarioLogado.senha = reader.GetString(name: "senha");
            }
            conexao.Close();
            return UsuarioLogado;
        }
    }
}