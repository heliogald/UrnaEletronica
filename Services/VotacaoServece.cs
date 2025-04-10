using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UrnaEletronica.Models;

namespace UrnaEletronica.Services
{
    public class VotacaoService
    {
        private readonly string _arquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "votos.txt");
        private string _ultimoHash = "";

        public VotacaoService()
        {
            if (File.Exists(_arquivo))
            {
                string ultimaLinha = File.ReadAllLines(_arquivo)[^1];
                if (ultimaLinha.Contains("HASH:"))
                    _ultimoHash = ultimaLinha.Split(new[] { "HASH:" }, StringSplitOptions.None)[1].Trim();
            }
        }

        public void ConfirmarVoto(Candidato candidato)
        {
            string dados = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{candidato.Numero}|{candidato.Nome}|{candidato.Partido}";
            SalvarComHash(dados);
        }

        public void ConfirmarVotoBranco()
        {
            string dados = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|BRANCO";
            SalvarComHash(dados);
        }

        public void ConfirmarVotoNulo(string numero)
        {
            string dados = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|NULO|{numero}";
            SalvarComHash(dados);
        }

        private void SalvarComHash(string dados)
        {
            string hashAtual = GerarHash(dados + _ultimoHash);
            _ultimoHash = hashAtual;
            File.AppendAllText(_arquivo, $"{dados}|HASH:{hashAtual}{Environment.NewLine}");
        }

        private string GerarHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
