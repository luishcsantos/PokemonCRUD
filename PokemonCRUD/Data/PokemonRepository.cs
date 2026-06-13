using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonCRUD.Models;
using MySql.Data.MySqlClient;

namespace PokemonCRUD.Data
{
    public class PokemonRepository
    {
        //CRUD
        #region Salvar

        public void Salvar(Pokemon p)
        {
            // Garante que a conexão seja fechada após o uso
            using (var conn = ConexaoDB.ObterConexao())
            {
                conn.Open(); // Abre a conexão com o banco de dados

                string sql = @"INSERT INTO pokemons 
                             (nome, tipo1, tipo2, altura, peso, hp, ataque, defesa, velocidade, imagem_url) 
                             VALUES (@nome, @tipo1, @tipo2, @altura, @peso, @hp, @ataque, @defesa, @velocidade, @imagem_url)";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@tipo1", p.Tipo1);
                cmd.Parameters.AddWithValue("@tipo2", p.Tipo2 ?? "");
                cmd.Parameters.AddWithValue("@altura", p.Altura);
                cmd.Parameters.AddWithValue("@peso", p.Peso);
                cmd.Parameters.AddWithValue("@hp", p.Hp);
                cmd.Parameters.AddWithValue("@ataque", p.Ataque);
                cmd.Parameters.AddWithValue("@defesa", p.Defesa);
                cmd.Parameters.AddWithValue("@velocidade", p.Velocidade);
                cmd.Parameters.AddWithValue("@imagem_url", p.ImagemUrl);

                cmd.ExecuteNonQuery(); // Não retorna resultados, apenas executa ação INSERET e SELECT
            }
        }

        #endregion

        #region Listar

        public List<Pokemon> ListarTodos() // Método que retorna uma lista de pokémons
        {
            var lista = new List<Pokemon>();
            using(var conn = ConexaoDB.ObterConexao())
            {
                var cmd = new MySqlCommand("SELECT * FROM pokemons", conn);
                var reader = cmd.ExecuteReader(); // Percorre os resultados linha por linha

                while (reader.Read())
                {
                    lista.Add(new Pokemon
                    {
                        Id = reader.GetInt32("id"),
                        Nome = reader.GetString("nome"),
                        Tipo1 = reader.GetString("tipo1"),
                        Tipo2 = reader.GetString("tipo2"),
                        Altura = reader.GetDecimal("altura"),
                        Peso = reader.GetDecimal("peso"),
                        Hp = reader.GetInt32("hp"),
                        Ataque = reader.GetInt32("ataque"),
                        Defesa = reader.GetInt32("defesa"),
                        Velocidade = reader.GetInt32("velocidade"),
                        ImagemUrl = reader.GetString("imagem_url")
                    });
                }
            }

            return lista; //Devolve a lista preenchida
        }

        #endregion

        #region Atualizar

        public void Atualizar(Pokemon p)
        {
            using(var conn = ConexaoDB.ObterConexao())
            {
                conn.Open();
                string sql = @"UPDATE pokemons SET 
                             tipo1 = @tipo1, tipo2 = @tipo2, altura = @altura, peso = @peso, 
                             hp = @hp, ataque = @ataque, defesa = @defesa, velocidade = @velocidade, imagem_url = @imagem_url 
                             WHERE id = @id";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tipo1", p.Tipo1);
                cmd.Parameters.AddWithValue("@tipo2", p.Tipo2 ?? "");
                cmd.Parameters.AddWithValue("@altura", p.Altura);
                cmd.Parameters.AddWithValue("@peso", p.Peso);
                cmd.Parameters.AddWithValue("@hp", p.Hp);
                cmd.Parameters.AddWithValue("@ataque", p.Ataque);
                cmd.Parameters.AddWithValue("@defesa", p.Defesa);
                cmd.Parameters.AddWithValue("@velocidade", p.Velocidade);
                cmd.Parameters.AddWithValue("@imagem_url", p.ImagemUrl);
                cmd.Parameters.AddWithValue("@id", p.Id);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Excluir



        #endregion
    }
}
