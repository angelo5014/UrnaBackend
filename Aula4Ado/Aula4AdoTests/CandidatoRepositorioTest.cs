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
        public void CandidatoPrefeitoNaoEhInseridoPartidosIguais()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("Francisco Everardo Oliveira Silva", "Tiririca", new DateTime(2015 - 11 - 2), "666", 2, 666, 1, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            Assert.AreEqual(0, linhasAfetadasInsert);
        }

        [TestMethod]
        public void CandidatoPresidenteEhInseridoEDeletado()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("Francisco Everardo Oliveira Silva", "Tiririca", new DateTime(2015 - 11 - 2), "666", 2, 666, 2, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            int linhasAfetadasDelete = repo.DeletarPorNomeCompleto(candidato.NomeCompleto);
            Assert.AreEqual(1, linhasAfetadasInsert);
            Assert.AreEqual(1, linhasAfetadasDelete);
        }

        [TestMethod]
        public void CandidatoComNomeEmBrancoNaoEhInserido()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("", "Tiririca", new DateTime(2015 - 11 - 2), "666", 2, 666, 2, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            Assert.AreEqual(0, linhasAfetadasInsert);
        }

        [TestMethod]
        public void CandidatoComNomePopularIgualNaoEhInserido()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("Francisco Everardo Oliveira Silva", "JK da Brasilia", new DateTime(2015 - 11 - 2), "666", 2, 666, 2, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            Assert.AreEqual(0, linhasAfetadasInsert);
        }
        [TestMethod]
        public void CandidatoComNumeroIgualNaoEhInserido()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("Francisco Everardo Oliveira Silva", "Tiririca", new DateTime(2015 - 11 - 2), "666", 2, 30300, 2, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            Assert.AreEqual(0, linhasAfetadasInsert);
        }

        [TestMethod]
        public void CandidatoComRegistroTREIgualNaoEhInserido()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("Francisco Everardo Oliveira Silva", "Tiririca", new DateTime(2015 - 11 - 2), "1976", 2, 666, 2, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            Assert.AreEqual(0, linhasAfetadasInsert);
        }

        [TestMethod]
        public void CandidatoEhAdicionadoAtualizadoEExcluido()
        {
            var repo = new CandidatoRepositorio();
            var candidato = new Candidato("Francisco Everardo Oliveira Silva", "Tiririca", new DateTime(2015, 11, 2), "666", 2, 666, 2, true);
            int linhasAfetadasInsert = repo.Inserir(candidato);
            var candidato2 = repo.BuscarPorNomeCompleto("Francisco Everardo Oliveira Silva");
            candidato2.Numero = 777;
            int linhasAfetadasUpdate = repo.Atualizar(candidato2);
            int linhasAfetadasDelete = repo.DeletarPorNomeCompleto("Francisco Everardo Oliveira Silva");
            Assert.AreEqual(1, linhasAfetadasInsert);
            Assert.AreEqual(1, linhasAfetadasUpdate);
            Assert.AreEqual(1, linhasAfetadasDelete);
        }
    }
}
