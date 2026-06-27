using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;

namespace PokemonCRUD.Data
{
    public class ConexaoDB
    {
        private static string connectionString =
            "Server=localhost;Database=pokemondb;Uid=root;Pwd=123456;";

        public static MySqlConnection ObterConexao()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
