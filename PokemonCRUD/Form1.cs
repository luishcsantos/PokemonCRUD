using PokemonCRUD.Data;
using PokemonCRUD.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonCRUD
{
    public partial class Form1 : Form
    {
        // Criando os objetos que vamos usar
        private PokeAPIService apiService = new PokeAPIService();
        private PokemonRepository repo = new PokemonRepository();

        // Variável que guarda o pokemon atual
        private Pokemon pokemonAtual = null;

        public Form1()
        {
            InitializeComponent();
            btnSalvar.Enabled = false; // Botão desabilitado até buscar algo
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string busca = txtBusca.Text.Trim();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
