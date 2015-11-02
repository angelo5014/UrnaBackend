using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado
{
    class Estatistica
    {
        string Nome { get; set; }
        string Cargo { get; set; }
        string Partido { get; set; }
        int Votos { get; set; }

        public Estatistica(string nome, string cargo, string partido, int votos)
        {
            Nome = nome;
            Cargo = cargo;
            Partido = partido;
            Votos = votos;
        }
    }
}
