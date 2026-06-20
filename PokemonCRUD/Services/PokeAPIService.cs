using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PokemonCRUD.Models;
using System.Net.Http;

namespace PokemonCRUD.Services
{
    public class PokeAPIService
    {
        // Cria um objeto para acessar páginas
        private static readonly HttpClient client = new HttpClient();

        // Método assíncrono - evita travamentos
        // Aguarda a finalização do método
        public async Task<Pokemon> BuscarPokemon(string NomeOuId)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{NomeOuId.ToLower()}";

            // Faz a requisição na internet e aguarda a resposta
            var response = await client.GetAsync(url);

            // Se não encontrou (ex. nome errado) retorna nulo
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                // Lê o conteúdo da resposta como texto
                var json = await response.Content.ReadAsStringAsync();

                // Converte o texto Json para um objeto navegável
                var obj = JObject.Parse(json);

                var pokemon = new Pokemon
                {
                    Nome = obj["name"].ToString(),
                    Altura = (decimal)obj["height"],
                    Peso = (decimal)obj["weight"],
                    ImagemUrl = obj["sprites"]["front_default"].ToString()
                };

                // Pegar o tipo do pokemon (pode ter 1 ou 2 tipos)
                var tipos = obj["types"];
                pokemon.Tipo1 = tipos[0]["type"]["name"].ToString();
                pokemon.Tipo2 = tipos.Count() > 1
                    ? tipos[1]["type"]["name"].ToString()
                    : null; // if ternário

                foreach (var stat in obj["stats"])
                {
                    string statName = stat["stat"]["name"].ToString();
                    int valor = (int)stat["base_stat"];

                    switch (statName)
                    {
                        case "hp": pokemon.Hp = valor; break;
                        case "attack": pokemon.Ataque = valor; break;
                        case "defense": pokemon.Defesa = valor; break;
                        case "speed": pokemon.Velocidade = valor; break;
                    }
                }

                return pokemon;
            }
        }
    }
}
