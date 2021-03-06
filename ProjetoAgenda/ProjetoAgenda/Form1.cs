﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgenda
{
    public partial class Form1 : Form
    {
        Contatos objuso = new Contatos();
        private Button novo;
        private Button gravar;
        private Button excluir;
        private Button Pesquisar;
        private Button Alterar;
        private Button listar;
        private Label email;
        private Label nome;
        private Label telefone;
        private TextBox Email;
        private TextBox Nome;
        private TextBox Telefone;
        private Label display;

        public void iniciarComponentes()
        {
            #region botões
            listar = new Button();
            listar.Parent = this;
            listar.Width = 80;
            listar.Top = 250;
            listar.Left = 350;
            listar.Text = "Listar";
            listar.Click += new EventHandler(clicouListar);

            novo = new Button();
            novo.Parent = this;
            novo.Width =80;
            novo.Top = 250;
            novo.Left = 5;
            novo.Text = "Novo";
            novo.Click += new EventHandler(clicouNovo);

            gravar = new Button();
            gravar.Parent = this;
            gravar.Width = 80;
            gravar.Top = 250;
            gravar.Left = 90;
            gravar.Text = "Gravar";
            gravar.Click += new EventHandler(clicouGravar);

            excluir = new Button();
            excluir.Parent = this;
            excluir.Width = 80;
            excluir.Top = 250;
            excluir.Left = 175;
            excluir.Text = "Excluir";
            excluir.Click += new EventHandler(clicouExcluir);

            Pesquisar = new Button();
            Pesquisar.Parent = this;
            Pesquisar.Width = 80;
            Pesquisar.Top = 250;
            Pesquisar.Left = 260;
            Pesquisar.Text = "Pesquisar";
            Pesquisar.Click += new EventHandler(clicouPesquisar);

            Alterar = new Button();
            Alterar.Parent = this;
            Alterar.Width = 80;
            Alterar.Top = 280;
            Alterar.Left = 90;
            Alterar.Text = "Alterar";
            Alterar.Click += new EventHandler(clicouAlterar);
            #endregion

            #region Label
            email = new Label();
            email.Parent = this;
            email.Width = 70;
            email.Top = 20;
            email.Left = 10;
            email.Text = "Email :";

            nome = new Label();
            nome.Parent = this;
            nome.Width = 70;
            nome.Top = 60;
            nome.Left = 10;
            nome.Text = "Nome :";

            telefone = new Label();
            telefone.Parent = this;
            telefone.Width = 70;
            telefone.Top = 100;
            telefone.Left = 10;
            telefone.Text = "Telefone :";

            display = new Label();
            display.Parent = this;
            display.Height = 200;
            display.Width = 250;
            display. Top = 10;
            display.Left = 210;
            display.Text = "";
            display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            #endregion

            #region Textbox
            Email = new TextBox();
            Email.Parent = this;
            Email.Width = 90;
            Email.Top = 20;
            Email.Left = 100;

            Nome = new TextBox();
            Nome.Parent = this;
            Nome.Width = 70;
            Nome.Top = 60;
            Nome.Left = 100;


            Telefone = new TextBox();
            Telefone.Parent = this;
            Telefone.Width = 70;
            Telefone.Top = 100;
            Telefone.Left = 100;

            #endregion

        }

        private void clicouAlterar(object sender, EventArgs e)
        {
            try
            {
                var c = new Contato(Email.Text, Nome.Text, Telefone.Text);
                if (objuso.alterar(c))
                    MessageBox.Show("Alterado com sucesso");
                else
                    MessageBox.Show("Contato não encontrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            iniciarComponentes();
            
        }

        public void clicouNovo (object sender, EventArgs e)
        {
            Nome.Text = "";
            Telefone.Text = "";
            Email.Text = "";
            MessageBox.Show("Limpeza de campos executada");

        }
        public void clicouGravar (object sender, EventArgs e)
        {
            try
            {
                var c = new Contato(Email.Text, Nome.Text, Telefone.Text);
                if (objuso.adicionar(c))
                    MessageBox.Show("Cadastro com sucesso");
                else
                    MessageBox.Show("Contato já inserido");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clicouExcluir (object sender, EventArgs e)
        {
            try
            {
                var c = new Contato(Email.Text, Nome.Text, Telefone.Text);
                if (objuso.remover(c))
                    MessageBox.Show("Excluido com sucesso");
                else
                    MessageBox.Show("Contato não encontrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void clicouPesquisar(object sender, EventArgs e)
        {
            var c = new Contato(Email.Text, Nome.Text, Telefone.Text);
            var pesquisado = objuso.Pesquisa(c);
            if (pesquisado != null)
            {
                Email.Text = pesquisado.Email;
                Nome.Text = pesquisado.Nome;
                Telefone.Text = pesquisado.Telefone;
            }
            else
                MessageBox.Show("Contato não encontrado");
        }
        public void clicouListar(object sender, EventArgs e)
        {
            display.Text = string.Join("\n", objuso.Lista.Select(x => x.dados()));
        }
    }
}
