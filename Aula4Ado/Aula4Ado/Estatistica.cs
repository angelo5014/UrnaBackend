using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado
{
    public class Estatistica
    {
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        public string Partido { get; private set; }
        public int Votos { get; private set; }

        public Estatistica(string nome, string cargo, string partido, int votos)
        {
            Nome = nome;
            Cargo = cargo;
            Partido = partido;
            Votos = votos;
        }

        public override string ToString()
        {
            return String.Format("{1,-9}{2}{0}{3,-9}{4}{0}{5,-9}{6}{0}{7,-9}{8}", Environment.NewLine, "Nome:", Nome, "Cargo:", Cargo, "Partido:", Partido, "Votos:", Votos);
        }

        public override bool Equals(object obj)
        {
            Estatistica estatistica = (Estatistica)obj;
            return Nome == estatistica.Nome && Cargo == estatistica.Cargo
                && Partido == estatistica.Partido && Votos == estatistica.Votos;
        }

        public static string PorcentagemEquivalente(IList<Estatistica> estatisticas)
        {
            string retorno = "";
            int total = estatisticas.Sum(estatistica => estatistica.Votos);
            foreach (Estatistica estatistica in estatisticas)
            {
                retorno += Environment.NewLine + String.Format("{0}: {1:0.00}%", estatistica.Nome, ((double)estatistica.Votos * 100 / (double)total));
            }
            return retorno + Environment.NewLine;
        }
    }
}
