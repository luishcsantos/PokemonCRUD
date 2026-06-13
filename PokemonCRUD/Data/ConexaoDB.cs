using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PokemonCRUD.Data
{
    public class ConexaoDB
    {
        private static string connectionString = "server=localhost;database=pokemondb;uid=root;pwd=123456;";

        public static MySqlConnection ObterConexao()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
