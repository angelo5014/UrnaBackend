using System;

namespace Aula4Ado
{
    public class Voto
    {
        public int IdVoto { get; set; }
        public int IdCandidato { get; set; }
        CandidatoRepositorio candidatoRepositorio = new CandidatoRepositorio();

        public Voto(int numeroCandidato)
        {
            Candidato candidatoASerVotado = candidatoRepositorio.BuscarPorNumero(numeroCandidato);
            IdCandidato = candidatoASerVotado.IdCandidato;
        }

        public override string ToString()
        {
            return string.Format("{3,-13}{1}{0}{4,-13}{2}",
                Environment.NewLine, IdVoto, IdCandidato, "IdVoto:", "IdCandidato:");
        }

        public override bool Equals(object obj)
        {
            Voto voto = (Voto)obj;
            return voto.IdCandidato == IdCandidato && voto.IdVoto == IdVoto;
        }
    }
}
