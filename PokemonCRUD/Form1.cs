using PokemonCRUD.Data;
using PokemonCRUD.Models;
using PokemonCRUD.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonCRUD
{
    public partial class Form1 : Form
    {
        //criando os objetos que iremos usar
        private PokeAPIService apiService = new PokeAPIService();
        private PokemonRepository repo = new PokemonRepository();

        //variável que guarda o pokemon atual
        private Pokemon pokemonAtual = null;

        public Form1()
        {
            InitializeComponent();
            btnSalvar.Enabled = false; //botão desabilitado até buscar algo
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string busca = txtBusca.Text.Trim();

            // Validação caso a pessoa não digite nada no campo
            if (string.IsNullOrEmpty(busca))
            {
                MessageBox.Show("Digite o nome ou número do Pokémon!");
                return;
            }

            //Desativa o botão para evitar cliques duplos
            btnBuscar.Enabled = false;
            btnBuscar.Text = "Buscando...";

            pokemonAtual = await apiService.BuscarPokemon(busca);

            if(pokemonAtual == null)
            {
                MessageBox.Show("Pokémon não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBuscar.Enabled = true;
                btnBuscar.Text = "Buscar";
            }
            else
            {
                ExibirPokemon(pokemonAtual);
                btnBuscar.Enabled = true;
                btnBuscar.Text = "Buscar";
                btnSalvar.Enabled = true;
            }
        }

        //Criação de método para preencher os campos da tela
        private void ExibirPokemon(Pokemon p)
        {
            lblNome.Text = $"Nome: {p.Nome.ToUpper()}";
            lblTipos.Text = $"Tipo(s): {p.Tipo1}" + (p.Tipo2 != null ? $" / {p.Tipo2}" : "");
            lblAltura.Text = $"Altura: {p.Altura} m";
            lblPeso.Text = $"Peso: {p.Peso} kg";
            lblStats.Text = $"HP: {p.HP} ATK: {p.Ataque} DEF: {p.Defesa} VEL: {p.Velocidade}";

            //Carrega a imagem
            if(!string.IsNullOrEmpty(p.ImagemUrl))
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] imgBytes = wc.DownloadData(p.ImagemUrl);
                    using (var ms = new System.IO.MemoryStream(imgBytes))
                    {
                        picPokemon.Image = Image.FromStream(ms);
                        picPokemon.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(pokemonAtual == null) { return; }
            //Verificar se o pokemon existe no banco
            if (repo.Existe(pokemonAtual.Nome))
            {
                var resposta = MessageBox.Show(
                    $"{pokemonAtual.Nome} já está salvo! Deseja atualizar?",
                    "Já existe",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if(resposta == DialogResult.Yes)
                {
                    //atualizado por lista //TODO: REFATORAR
                    var lista = repo.ListarTodos();
                    var existente = lista.Find(x => x.Nome == pokemonAtual.Nome);
                    pokemonAtual.Id = existente.Id;
                    repo.Atualizar(pokemonAtual);
                    MessageBox.Show("Pokemon atualizado!");
                }
                return;
            }

            repo.Salvar(pokemonAtual);
            MessageBox.Show($"{pokemonAtual.Nome} salvo!");
        }

        private void btnVerSalvos_Click(object sender, EventArgs e)
        {
            new FormLista().ShowDialog();
        }

        private void lblStats_Click(object sender, EventArgs e)
        {

        }

        private void lblPeso_Click(object sender, EventArgs e)
        {

        }

        private void lblAltura_Click(object sender, EventArgs e)
        {

        }

        private void lblTipos_Click(object sender, EventArgs e)
        {

        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void picPokemon_Click(object sender, EventArgs e)
        {

        }
    }
}
