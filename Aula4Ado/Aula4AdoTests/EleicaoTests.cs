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
    public class EleicaoTests
    {
        [TestMethod()]
        public void NaoVotarTest()
        {
            EleitorRepositorio eleitorRepositorio = new EleitorRepositorio();
            Eleicao eleicao = new Eleicao();
            Eleitor eleitor = eleitorRepositorio.BuscarPorId(4004);

            Assert.IsFalse(eleicao.Votar(eleitor.CPF, 20102));
        }

        [TestMethod()]
        public void VotarTest()
        {
            EleitorRepositorio eleitorRepositorio = new EleitorRepositorio();
            Eleicao eleicao = new Eleicao();
            Eleitor eleitor = eleitorRepositorio.BuscarPorId(4004);

            eleicao.IniciarEleicoes();

            Assert.IsTrue(eleicao.Votar(eleitor.CPF, 20102));

            eleicao.FinalizarEleicoes();
            eleitor = eleitorRepositorio.BuscarPorId(4004);
            Assert.AreEqual('S', eleitor.Votou);

            eleitor.Votou = 'N';
            eleitorRepositorio.Atualizar(eleitor);

        }

        [TestMethod()]
        public void IniciarEleicoesTest()
        {
            new Eleicao().IniciarEleicoes();
            Assert.IsTrue(Eleicao.EleicoesIniciadas);
        }

        [TestMethod()]
        public void FinalizarEleicoesTest()
        {
            new Eleicao().FinalizarEleicoes();
            Assert.IsFalse(Eleicao.EleicoesIniciadas);
        }
    }
}