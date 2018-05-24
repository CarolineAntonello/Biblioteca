using Biblioteca.Application.Features.Livros;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Common.Tests.Livros;
using Biblioteca.Domain.Features.Livros;
using Biblioteca.Infra.Data.Feature.Livros;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Integration.Tests.Feature.Livros
{
    [TestFixture]
    public class LivroIntegrationTests
    {
        private ILivroRepository _repository;
        private LivroService _service;
        private Livro _livro;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new LivroSQLRepository();
            _service = new LivroService(_repository);
        }

        [Test]
        public void Integration_AddLivro_ShouldBeOK()
        {
            _livro = ObjectMother.GetLivro();
            _service.Adicionar(_livro);
            var livroVerify = _service.Get(_livro.Id);
            livroVerify.Should().NotBeNull();
            livroVerify.Id.Should().Be(_livro.Id);
        }

        [Test]
        public void Integration_AddLivro_ShouldBeFail()
        {
            _livro = ObjectMother.GetLivroTemaMenos4Caracteres();
            Action action = () =>_service.Adicionar(_livro);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_UpdateLivro_ShouldBeOK()
        {
            _livro = ObjectMother.GetLivroComId();
            _service.Editar(_livro);
            var livroVerify = _service.Get(_livro.Id);
            livroVerify.Should().NotBeNull();
            livroVerify.Id.Should().Be(_livro.Id);
        }

        [Test]
        public void Integration_UpdateLivro_ShouldBeFail()
        {
            _livro = ObjectMother.GetLivroTituloMenos4Caracteres();
            Action action = () => _service.Editar(_livro);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_DeleteLivro_ShouldBeOK()
        {
            _livro = ObjectMother.GetLivroComId();
            _service.Excluir(_livro);
            Livro received = _service.Get(_livro.Id);
            received.Should().BeNull();
        }

        [Test]
        public void Integration_GetLivro_ShouldBeOK()
        {
            _livro = _service.Get(1);
            _livro.Should().NotBeNull();
            _livro.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Integration_GetProduct_ShouldBeFail()
        {
            _livro = _service.Get(200);
            _livro.Should().BeNull();
        }

        [Test]
        public void Integration_GetAllLivros_ShouldBeOkay()
        {
            List<Livro> livros = _service.PegarTodos();
            livros.Count().Should().BeGreaterThan(0);
        }
    }
}
