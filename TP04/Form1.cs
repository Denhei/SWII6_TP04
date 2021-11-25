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
using TP04.models;
using TP04.Services;

namespace TP04
{
    public partial class Form1 : Form
    {
        private readonly LivroService _service;

        public Form1()
        {
            InitializeComponent();

            _service = new LivroService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string autor = txt_autor.Text;
            string titulo = txt_titulo.Text;
            int id = 1;

            if(lst_livros.Items.Count > 0)
            {
                id = int.Parse(lst_livros.Items[lst_livros.Items.Count - 1].ImageKey) + 1;
            }

            bool success = _service.CadastrarLivro(new Livro(titulo, autor, id));

            AtualizarListaLivros();
            LimparCampos();

            if (success)
            {
                MessageBox.Show("Cadastrado com sucesso");
            }
            else
            {
                MessageBox.Show("Falha ao cadastrar");
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarListaLivros();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            string selecionado = lst_livros.SelectedItems[0].ImageKey;

            _service.RemoverLivros(selecionado);

            AtualizarListaLivros();
            LimparCampos();

            MessageBox.Show("Removido com sucesso");
        }

        private void AtualizarListaLivros()
        {
            lst_livros.Items.Clear();
            
            List<Livro> livros = _service.BuscarLivros();

            lst_livros.View = View.List;

            if (livros.Count > 0)
            {
                foreach (Livro livro in livros)
                {
                    lst_livros.Items.Add(new ListViewItem($"Id: {livro.Id} | Autor: {livro.Autor} | Titulo: {livro.Titulo}", $"{livro.Id}"));
                }
            }
        }

        private void LimparCampos()
        {
            txt_autor.Text = String.Empty;
            txt_titulo.Text = String.Empty;
        }
    }
}
