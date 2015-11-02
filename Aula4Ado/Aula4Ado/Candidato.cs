using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado
{
    public class Candidato
    {
        public int IdCandidato { get; set; }
        public string NomeCompleto { get; private set; }
        public string NomePopular { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public String RegistroTRE { get; private set; }
        public int IdPartido { get; private set; }
        public string Foto { get; private set; }
        public int Numero { get; private set; }
        public int IdCargo { get; private set; }
        public bool Exibe { get; set; }
        

        public Candidato(string nomeCompleto, string nomePopular, DateTime dataNascimento, string registroTRE,
            int idPartido, int numero, int idCargo, bool exibe)
        {
            NomeCompleto = nomeCompleto;
            NomePopular = nomePopular;
            DataNascimento = dataNascimento;
            RegistroTRE = registroTRE;
            IdPartido = idPartido;
            Foto = null;
            Numero = numero;
            IdCargo = idCargo;
            Exibe = exibe;
        }

        public Candidato(string nomeCompleto, string nomePopular, DateTime dataNascimento, string registroTRE,
            int idPartido, string foto, int numero, int idCargo, bool exibe) : this(nomeCompleto, nomePopular,
            dataNascimento, registroTRE, idPartido, numero, idCargo, exibe)
        {
            Foto = foto;
        }

        public override string ToString()
        {
            return string.Format("{1} {2}, {3} {4}, {5} {6},{0}{7} {8:dd/MM/yyyy}, {9} {10}, {11} {12},{0}{13} {14}, {15} {16}, {17} {18}", "\r\n",
                "Id do candidato:", IdCandidato, "Nome completo:", NomeCompleto, "Nome popular:", NomePopular,
                "Data de nascimento:", DataNascimento, "Registro TRE:", RegistroTRE, "Id do partido:", IdPartido,
                "Numero:", Numero, "Id do cargo:", IdCargo, "Exibe:", Exibe);
        }

        public override bool Equals(object obj)
        {
            Candidato candidato = (Candidato)obj;
            return this.IdCandidato == candidato.IdCandidato && this.NomeCompleto == candidato.NomeCompleto && this.NomePopular == candidato.NomePopular
                && this.DataNascimento == candidato.DataNascimento && this.RegistroTRE == candidato.RegistroTRE && this.IdPartido == candidato.IdPartido
                && this.Numero == candidato.Numero && this.IdCargo == candidato.IdCargo && Exibe == candidato.Exibe;
        }
    }
}
