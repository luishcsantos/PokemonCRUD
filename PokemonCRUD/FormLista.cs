using PokemonCRUD.Data;
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
    public partial class FormLista : Form
    {
        private PokemonRepository repo = new PokemonRepository();
        public FormLista()
        {
            InitializeComponent();
            CarregarDados();

            // Configurações visuais do DataGridView
            // expandir as colunas para a largura disponível
            dgvPokemons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // seleciona a linha toda ao clicar
            dgvPokemons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // impedir a edição direto na grid
            dgvPokemons.ReadOnly = true;
        }

        // buscar dados no banco e exibir na tabela
        private void CarregarDados()
        {
            var lista = repo.ListarTodos();
            dgvPokemons.DataSource = null; // limpa antes de carregar
            dgvPokemons.DataSource = lista;
        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(dgvPokemons.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um Pokémon para deletar!");
                return;
            }

            // pegar os dados da linha selecionada
            var row = dgvPokemons.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;
            string nome = row.Cells["Nome"].Value.ToString();

            // pede uma confirmação antes de deletar
            var confirm = MessageBox.Show(
                $"Deseja deletar {nome} ?",
                "Confirmar deleção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if(confirm == DialogResult.Yes)
            {
                repo.Deletar(id);
                MessageBox.Show("Pokémon deletado!");
                CarregarDados();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
