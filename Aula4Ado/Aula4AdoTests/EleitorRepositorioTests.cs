using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula4Ado;

namespace Aula4AdoTests
{
    [TestClass]
    public class EleitorRepositorioTests
    {
        [TestMethod]
        public void BuscarEleitorPorID()
        {
            var eleitores = new EleitorRepositorio();
            Eleitor eleitorEncontrado = eleitores.BuscarPorId(4001);
            Assert.AreEqual("Baraquizio Lurdes Panichi", eleitorEncontrado.Nome);
            Assert.AreEqual("10219998", eleitorEncontrado.TituloEleitoral);
            Assert.AreEqual("7896RS1", eleitorEncontrado.RG);
            Assert.AreEqual("00000000326", eleitorEncontrado.CPF);
            Assert.AreEqual(new DateTime(2015, 10, 27), eleitorEncontrado.DataNascimento);
            Assert.AreEqual("51", eleitorEncontrado.ZonaEleitoral);
            Assert.AreEqual("N444", eleitorEncontrado.Secao);
            Assert.AreEqual('A', eleitorEncontrado.Situacao);
            Assert.AreEqual('N', eleitorEncontrado.Votou);
        }

        [TestMethod]
        public void BuscarPorCPF()
        {
            var eleitores = new EleitorRepositorio();
            Eleitor eleitorEncontrado = eleitores.BuscarPorCpf("00000000326");
            Assert.AreEqual("Baraquizio Lurdes Panichi", eleitorEncontrado.Nome);
            Assert.AreEqual("10219998", eleitorEncontrado.TituloEleitoral);
            Assert.AreEqual("7896RS1", eleitorEncontrado.RG);
            Assert.AreEqual("00000000326", eleitorEncontrado.CPF);
            Assert.AreEqual(new DateTime(2015, 10, 27), eleitorEncontrado.DataNascimento);
            Assert.AreEqual("51", eleitorEncontrado.ZonaEleitoral);
            Assert.AreEqual("N444", eleitorEncontrado.Secao);
            Assert.AreEqual('A', eleitorEncontrado.Situacao);
            Assert.AreEqual('N', eleitorEncontrado.Votou);
        }
                
        [TestMethod]
        public void InsertUpdateAndDeleteEleitor()
        {
            var eleitores = new EleitorRepositorio();
            Eleitor eleitorInserido = new Eleitor("Júlio", "99219998", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            eleitores.Inserir(eleitorInserido);
            Eleitor eleitorAEditar = eleitores.BuscarPorCpf("99000000326");
            Assert.AreEqual("Júlio", eleitorAEditar.Nome);
            Assert.AreEqual("99219998", eleitorAEditar.TituloEleitoral);
            Assert.AreEqual("9996RS1", eleitorAEditar.RG);
            Assert.AreEqual("99000000326", eleitorAEditar.CPF);
            Assert.AreEqual(new DateTime(1992, 12, 31), eleitorAEditar.DataNascimento);
            Assert.AreEqual("51", eleitorAEditar.ZonaEleitoral);
            Assert.AreEqual("N444", eleitorAEditar.Secao);
            Assert.AreEqual('A', eleitorAEditar.Situacao);
            Assert.AreEqual('N', eleitorAEditar.Votou);
            eleitorAEditar.Nome = "César";
            eleitores.Atualizar(eleitorAEditar);
            eleitorAEditar = eleitores.BuscarPorCpf("99000000326");
            Assert.AreEqual("César", eleitorAEditar.Nome);
            eleitores.DeletarPorId(eleitorAEditar.IdEleitor);
            Assert.AreEqual(null, eleitores.BuscarPorCpf("99000000326"));
        }

        [TestMethod]
        public void NaoInserirComMesmoCPF()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "99219998", "9996RS1", "00000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);
            
            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComMesmoRG()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "99219998", "7896RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComNomeNull()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor(null, "99219998", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComTituloEleitoralNull()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", null, "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComRGNull()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "9996RS1", null, "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComCPFNull()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "9996RS1", "9996RS1", null, new DateTime(1992, 12, 31), "51", "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComZonaEleitoralNull()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "9996RS1", "9996RS1", "99000000326", new DateTime(1992, 12, 31), null, "N444", 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComSecaoNull()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "9996RS1", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", null, 'A', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComSituacaoInvalida()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "9996RS1", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'W', 'N');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void NaoInserirComVotouInvalido()
        {
            var eleitores = new EleitorRepositorio();
            int inserido;
            Eleitor eleitorInserido = new Eleitor("Júlio", "9996RS1", "9996RS1", "99000000326", new DateTime(1992, 12, 31), "51", "N444", 'A', 'W');
            inserido = eleitores.Inserir(eleitorInserido);

            Assert.AreEqual(0, inserido);
        }

        [TestMethod]
        public void InvalidarEleitorEtestarPodeVotarPorCPF()
        {
            var eleitores = new EleitorRepositorio();
            Eleitor eleitorOriginal = eleitores.BuscarPorId(5000);
            eleitores.InativarPorId(5000);
            Eleitor eleitorAlterado = eleitores.BuscarPorId(5000);

            Assert.AreEqual('I', eleitorAlterado.Situacao);
            Assert.AreEqual(false, eleitores.PodeVotarPorCpf(eleitorAlterado.CPF));

            eleitores.Atualizar(eleitorOriginal);
            eleitorAlterado = eleitores.BuscarPorId(5000);

            Assert.AreEqual('A', eleitorAlterado.Situacao);
            Assert.AreEqual(true, eleitores.PodeVotarPorCpf(eleitorAlterado.CPF));
        }

        [TestMethod]
        public void EleitorNaoPodeVotar2Vezes()
        {
            var eleitores = new EleitorRepositorio();
            Eleitor eleitorEncontrado = eleitores.BuscarPorId(5000);
            Eleitor eleitorOriginal = eleitores.BuscarPorId(5000);

            Assert.AreEqual(true, eleitores.PodeVotarPorCpf(eleitorEncontrado.CPF));

            eleitorEncontrado.Votou = 'S';
            eleitores.Atualizar(eleitorEncontrado);
            eleitorEncontrado = eleitores.BuscarPorId(5000);

            Assert.AreEqual(false, eleitores.PodeVotarPorCpf(eleitorEncontrado.CPF));

            eleitores.Atualizar(eleitorOriginal);
            eleitorEncontrado = eleitores.BuscarPorId(5000);

            Assert.AreEqual(true, eleitores.PodeVotarPorCpf(eleitorEncontrado.CPF));
        }
    }
}
