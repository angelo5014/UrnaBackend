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
    public class PartidoRepositorioTests
    {
        [TestMethod()]
        public void AtualizarTest()
        {
            PartidoRepositorio repositorio = new PartidoRepositorio();
            Partido esperado = repositorio.BuscarPorId(1);
            string nome = esperado.Nome;
            esperado.Nome = "$$$Teste";
            repositorio.Atualizar(esperado);
            Partido atual = repositorio.BuscarPorId(1);

            Assert.AreEqual(esperado, atual);

            esperado.Nome = nome;
            repositorio.Atualizar(esperado);
        }

        [TestMethod()]
        public void NaoAtualizarTest()
        {
            PartidoRepositorio repositorio = new PartidoRepositorio();
            Partido partido = repositorio.BuscarPorId(1);
            string nome = partido.Nome;
            partido.Nome = "";

            int atual = repositorio.Atualizar(partido);

            Assert.AreEqual(0, atual);
        }

        [TestMethod()]
        public void BuscarPorIdTest()
        {
            Partido atual = new PartidoRepositorio().BuscarPorId(2);
            Assert.AreEqual("PAB", atual.Sigla);
        }

        [TestMethod()]
        public void BuscarPorSiglaENomeTest()
        {

            Partido atual = new PartidoRepositorio().BuscarPorSiglaENome(new Partido("Partido da Arte Brasileira", null, "PAB"));
            Assert.AreEqual("PAB", atual.Sigla);
        }

        [TestMethod()]
        public void DeletarPorIdTest()
        {
            PartidoRepositorio repositorio = new PartidoRepositorio();
            Partido partido = new Partido("Partido", "Slogan", "Sigla");
            repositorio.Inserir(partido);
            partido = repositorio.BuscarPorSiglaENome(partido);

            int atual = repositorio.DeletarPorId(partido.IdPartido);

            Assert.AreEqual(1, atual);
        }

        [TestMethod()]
        public void InserirTest()
        {
            PartidoRepositorio repositorio = new PartidoRepositorio();
            Partido partido = new Partido("Partido", "Slogan", "Sigla");
            int atual = repositorio.Inserir(partido);

            Assert.AreEqual(1, atual);

            partido = repositorio.BuscarPorSiglaENome(partido);
            repositorio.DeletarPorId(partido.IdPartido);
        }

        [TestMethod()]
        public void ValidarTest()
        {
            PartidoRepositorio repositorio = new PartidoRepositorio();
            Partido partido = new Partido("Partido", "Slogan", "Sigla");
            Assert.IsTrue(repositorio.Validar(partido));
            partido.Sigla = null;
            Assert.IsFalse(repositorio.Validar(partido));
        }
    }
}