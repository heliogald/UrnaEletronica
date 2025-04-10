using System.Collections.Generic;
using UrnaEletronica.Models;

namespace UrnaEletronica.Repositories
{
    public class CandidatoRepository
    {
        private readonly List<Candidato> _candidatos = new List<Candidato>
        {
            new Candidato { Numero = "13", Nome = "Lula", Partido = "PT" },
            new Candidato { Numero = "45", Nome = "Enéias", Partido = "XYZ" },
            //new Candidato { Numero = "77", Nome = "Carlos Lima", Partido = "QWE" }
        };

        public Candidato BuscarPorNumero(string numero)
        {
            return _candidatos.Find(c => c.Numero == numero);
        }
    }
}
