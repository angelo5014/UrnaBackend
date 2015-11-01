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
        public string NomeCompleto { get; set; }
        public string NomePopular { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public String RegistroTRE { get; set; }
        public int IdPartido { get; set; }
        public int Numero { get; set; }
        public int IdCargo { get; set; }
        public short Exibe { get; set; }
        public string Foto { get; set; }

        public Candidato(int idCandidato, string nomeCompleto, string nomePopular, DateTime dataNascimento, string registroTRE, 
            int idPartido, int numero, int idCargo, short exibe)
        {
            IdCandidato = idCandidato;
            NomeCompleto = nomeCompleto;
            NomePopular = nomePopular;
            DataDeNascimento = dataNascimento;
            RegistroTRE = registroTRE;
            IdPartido = idPartido;
            Numero = numero;
            IdCargo = idCargo;
            if (exibe == 1) { Exibe = 1; }
            else { Exibe = 0; }
        }

        public Candidato(int idCandidato, string nomeCompleto, string nomePopular, DateTime dataNascimento, string registroTRE,
            int idPartido, int numero, int idCargo, short exibe, string foto) : this(idCandidato, nomeCompleto, nomePopular, 
            dataNascimento, registroTRE, idPartido, numero, idCargo, exibe)
        {
            Foto = foto;
        }

        public override string ToString()
        {
            return string.Format("{1} {2}, {3} {4}, {5} {6},{0}{7} {8:dd/MM/yyyy}, {9} {10}, {11} {12},{0}{13} {14}, {15} {16}, {17} {18}", "\r\n", 
                "Id do candidato:", IdCandidato, "Nome completo:", NomeCompleto, "Nome popular:", NomePopular,
                "Data de nascimento:", DataDeNascimento, "Registro TRE:", RegistroTRE, "Id do partido:", IdPartido,
                "Numero:", Numero, "Id do cargo:", IdCargo, "Exibe:", Exibe);
        }

        public override bool Equals(object obj)
        {
            Candidato candidato = (Candidato)obj;
            return this.IdCandidato == candidato.IdCandidato && this.NomeCompleto == candidato.NomeCompleto && this.NomePopular == candidato.NomePopular
                && this.DataDeNascimento == candidato.DataDeNascimento && this.RegistroTRE == candidato.RegistroTRE && this.IdPartido == candidato.IdPartido
                && this.Numero == candidato.Numero && this.IdCargo == candidato.IdCargo && Exibe == candidato.Exibe;
        }
    }
}
