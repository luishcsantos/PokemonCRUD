namespace PokemonCRUD.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public int Hp { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public int Velocidade { get; set; }
        public string ImagemUrl { get; set; }
    }
}
