using System;

namespace Aula4Ado
{
    class Voto
    {
        public int IdVoto { get; set; }
        public int IdCandidato { get; set; }

        public Voto(int idCandidato)
        {
            IdCandidato = idCandidato;
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
