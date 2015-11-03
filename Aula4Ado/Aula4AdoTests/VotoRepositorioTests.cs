using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula4Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado.Tests
{
    [TestClass()]
    public class VotoRepositorioTests
    {
        [TestMethod()]
        public void AtualizarTest()
        {
            int atual = new VotoRepositorio().Atualizar(new Voto(3412));
            Assert.AreEqual(0, atual);
        }

        [TestMethod()]
        public void BuscarPorIdTest()
        {
            Voto voto = new VotoRepositorio().BuscarPorId(1);
            int atual = new CandidatoRepositorio().BuscarPorNumero(voto.Numero).IdCandidato;
            Assert.AreEqual(2, atual);
        }

        [TestMethod()]
        public void ValidarTest()
        {
            Voto voto = new Voto(3412)
            {
                IdVoto = 432
            };
            Assert.IsTrue(new VotoRepositorio().Validar(voto));
        }
    }
}