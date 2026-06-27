using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PokemonCRUD.Models;

namespace PokemonCRUD.Data
{
    public class PokemonRepository
    {
        //CRUD
        #region SALVAR
        public void Salvar(Pokemon p)
        {
            //using garante que a conexao seja fechada após uso
            using (var conn = ConexaoDB.ObterConexao())
            {
                conn.Open(); //abre a conexão com o banco

                //comando
                string sql = @"INSERT INTO pokemons
                       (nome, tipo1, tipo2, altura, peso, hp,
                        ataque, defesa, velocidade, imagem_url)
                        VALUES(@nome,@tipo1,@tipo2,@altura, @peso, 
                        @hp, @ataque, @defesa, @velocidade, @img)";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@tipo1", p.Tipo1);
                cmd.Parameters.AddWithValue("@tipo2", p.Tipo2 ?? "");
                cmd.Parameters.AddWithValue("@altura", p.Altura);
                cmd.Parameters.AddWithValue("@peso", p.Peso);
                cmd.Parameters.AddWithValue("@hp", p.HP);
                cmd.Parameters.AddWithValue("@ataque", p.Ataque);
                cmd.Parameters.AddWithValue("@defesa", p.Defesa);
                cmd.Parameters.AddWithValue("@velocidade", p.Velocidade);
                cmd.Parameters.AddWithValue("@img", p.ImagemUrl);

                cmd.ExecuteNonQuery(); //não retorna linhas, 
                //apenas executa a ação INSERT, SELECT
            }
        }
        #endregion                                                   

        #region LISTAR
        //método q retorna uma lista de pokemon
        public List<Pokemon> ListarTodos() 
        {
            var lista = new List<Pokemon>(); //cria uma lista vazia
            using(var conn = ConexaoDB.ObterConexao())
            {
                var cmd = new MySqlCommand("SELECT * FROM pokemons", conn);
                //percorre os resultados linha por linha
                var reader = cmd.ExecuteReader();

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
                        HP = reader.GetInt32("hp"),
                        Ataque = reader.GetInt32("ataque"),
                        Defesa = reader.GetInt32("defesa"),
                        Velocidade = reader.GetInt32("velocidade"),
                        ImagemUrl = reader.GetString("imagem_url"),
                    });
                }
                
            }
            return lista; //devolve a lista preenchida
        }
        #endregion

        #region ATUALIZAR
        public void Atualizar(Pokemon p)
        {
            using (var conn = ConexaoDB.ObterConexao())
            {
                conn.Open();
                string sql = @"UPDATE pokemons SET
                        tipo1=@tipo1, tipo2=@tipo2, altura=@altura
                        peso=@peso, hp=@hp, ataque=@ataque, 
                        defesa=@defesa, velocidade=@velocidade
                        WHERE id=@id";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tipo1", p.Tipo1);
                cmd.Parameters.AddWithValue("@tipo2", p.Tipo2 ?? "");
                cmd.Parameters.AddWithValue("@altura", p.Altura);
                cmd.Parameters.AddWithValue("@peso", p.Peso);
                cmd.Parameters.AddWithValue("@hp", p.HP);
                cmd.Parameters.AddWithValue("@ataque", p.Ataque);
                cmd.Parameters.AddWithValue("@defesa", p.Defesa);
                cmd.Parameters.AddWithValue("@velocidade", p.Velocidade);
                cmd.Parameters.AddWithValue("@img", p.ImagemUrl);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region DELETAR
        public void Deletar(int id)
        {
            using(var conn = ConexaoDB.ObterConexao())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "DELETE FROM pokemons WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region EXISTE

        public bool Existe(string nome)
        {
            using(var conn = ConexaoDB.ObterConexao())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT COUNT(*) FROM pokemons WHERE nome=@nome", conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        #endregion

    }
}