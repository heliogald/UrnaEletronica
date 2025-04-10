using UrnaEletronica.Models;
using UrnaEletronica.Repositories;
using UrnaEletronica.Services;

namespace UrnaEletronica
{
    public partial class Form1 : Form
    {
        private readonly CandidatoRepository _repository = new CandidatoRepository();
        private readonly VotacaoService _votacaoService = new VotacaoService();
        private Candidato _candidatoAtual;
        private string numeroDigitado = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumero(object sender, EventArgs e)
        {
            if (numeroDigitado.Length >= 2)
                return;

            Button botao = sender as Button;
            numeroDigitado += botao.Text;
            txtDireita.Text = numeroDigitado;

            if (numeroDigitado.Length == 2)
            {
                _candidatoAtual = _repository.BuscarPorNumero(numeroDigitado);
                MostrarCandidato(_candidatoAtual);
            }
        }

        private void MostrarCandidato(Candidato candidato)
        {
            if (candidato != null)
            {
                lblNomeCandidato.Text = $"Nome: {candidato.Nome} - Partido: {candidato.Partido}";

                string caminhoImagem = Path.Combine(Application.StartupPath, @"..\..\..\Imagens", $"{candidato.Numero}.jpg");

                if (File.Exists(caminhoImagem))
                {
                    pictureBox1.Image = Image.FromFile(caminhoImagem);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                lblNomeCandidato.Text = "Número inválido";
                pictureBox1.Image = null;
            }
        }

        private void button14_Click(object sender, EventArgs e) // CORRIGE
        {
            numeroDigitado = "";
            txtDireita.Clear();
            lblNomeCandidato.Text = "";
            pictureBox1.Image = null;
            _candidatoAtual = null;
        }

        private void button15_Click(object sender, EventArgs e) // BRANCO
        {
            numeroDigitado = "--";
            txtDireita.Text = "--";
            lblNomeCandidato.Text = "VOTO EM BRANCO";
            pictureBox1.Image = null;
            _candidatoAtual = null;
        }

        private void button13_Click(object sender, EventArgs e) // CONFIRMA
        {
            if (numeroDigitado == "--")
            {
                _votacaoService.ConfirmarVotoBranco();
                MessageBox.Show("Voto em branco registrado.");
            }
            else if (_candidatoAtual != null)
            {
                _votacaoService.ConfirmarVoto(_candidatoAtual);
                MessageBox.Show("Voto registrado com sucesso!");
            }
            else
            {
                _votacaoService.ConfirmarVotoNulo(numeroDigitado);
                MessageBox.Show("Voto nulo registrado.");
            }

            numeroDigitado = "";
            txtDireita.Clear();
            lblNomeCandidato.Text = "";
            pictureBox1.Image = null;
            _candidatoAtual = null;
        }

        private void button10_Click(object sender, EventArgs e) // Finalizar
        {
            MessageBox.Show("Votação finalizada!");
            Application.Exit();
        }

        private void txtDireita_TextChanged(object sender, EventArgs e)
        {
            // Caixa de texto é atualizada automaticamente pelos botões
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Não necessário
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Não utilizado
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
