using System.Collections.Generic;
using UrnaEletronica.Models;

namespace UrnaEletronica.Repositories
{
    public class CandidatoRepository
    {
        private readonly List<Candidato> _candidatos = new List<Candidato>
        {
            new Candidato { Numero = "10", Nome = "Homer Simpson", Partido = "ABC" },
            new Candidato { Numero = "20", Nome = "Sr Barnes", Partido = "DEF" },
            new Candidato { Numero = "30", Nome = "Picapau", Partido = "GHI" },
            new Candidato { Numero = "40", Nome = "Leoncio", Partido = "JLM" }

        };

        public Candidato BuscarPorNumero(string numero)
        {
            return _candidatos.Find(c => c.Numero == numero);
        }
    }
}
