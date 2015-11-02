using Aula4Ado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aula4AdoTests
{
    [TestClass]
    public class CandidatoRepositorioTest
    {
        [TestMethod]
        public void BuscaPorNomeJuscelino()
        {
            var repo = new CandidatoRepositorio();
            var candidatoEncontrado = repo.BuscarPorNomeCompleto("Juscelino Kubitschek de Oliveira");
            Assert.AreEqual("JK da Brasilia", candidatoEncontrado.NomePopular);
            Assert.AreEqual(Convert.ToDateTime("1976-08-22"), candidatoEncontrado.DataNascimento);
            Assert.AreEqual("1976", candidatoEncontrado.RegistroTRE);
            Assert.AreEqual(30300, candidatoEncontrado.Numero);
        }
        [TestMethod]
        public void BuscarPorIdJuscelino()
        {
            var repo = new CandidatoRepositorio();
            var candidatoEncontrado = repo.BuscarPorId(10);
            Assert.AreEqual("Juscelino Kubitschek de Oliveira", candidatoEncontrado.NomeCompleto);
            Assert.AreEqual("JK da Brasilia", candidatoEncontrado.NomePopular);
        }
        [TestMethod]
        public void BuscaPorRegistroTRE()
        {
            var repo = new CandidatoRepositorio();
            var candidatoEncontrado = repo.BuscarPorRegistroTRE("1976");
            Assert.AreEqual("Juscelino Kubitschek de Oliveira", candidatoEncontrado.NomeCompleto);
            Assert.AreEqual("JK da Brasilia", candidatoEncontrado.NomePopular);
        }
        [TestMethod]
        public void BuscaPorNumero()
        {
            var repo = new CandidatoRepositorio();
            var candidatoEncontrado = repo.BuscarPorNumero(30300);
            Assert.AreEqual("Juscelino Kubitschek de Oliveira", candidatoEncontrado.NomeCompleto);
            Assert.AreEqual("JK da Brasilia", candidatoEncontrado.NomePopular);
        }
        [TestMethod]
        public void BuscaPorCargo()
        {
            var repo = new CandidatoRepositorio();
            var candidatoEncontrado = repo.BuscarPorNomePopular("JK da Brasilia");
            Assert.AreEqual("Juscelino Kubitschek de Oliveira", candidatoEncontrado.NomeCompleto);
            Assert.AreEqual(30300, candidatoEncontrado.Numero);
        }
    }
}
