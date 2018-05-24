using Biblioteca.Application.Features.Emprestimos;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Common.Tests.Emprestimos;
using Biblioteca.Domain.Features.Emprestimos;
using Biblioteca.Domain.Features.Livros;
using Biblioteca.Infra.Data.Feature.Emprestimos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Integration.Tests.Feature.Emprestimos
{
    [TestFixture]
    public class EmprestimoIntegrationTests
    {
        private IEmprestimoRepository _repository;
        private EmprestimoService _service;
        private Emprestimo _emprestimo;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new EmprestimoSQLRepository();
            _service = new EmprestimoService(_repository);
        }

        [Test]
        public void Integration_AddEmprestimo_ShouldBeOK()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _service.Adicionar(_emprestimo);
            var livroVerify = _service.Get(_emprestimo.Id);
            livroVerify.Should().NotBeNull();
            livroVerify.Id.Should().Be(_emprestimo.Id);
        }

        [Test]
        public void Integration_AddEmprestimo_ShouldBeFail()
        {
            _emprestimo = ObjectMother.GetEmprestimoClienteMenor4Caracteres();
            Action action = () => _service.Adicionar(_emprestimo);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_UpdateEmprestimo_ShouldBeOK()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _service.Editar(_emprestimo);
            var livroVerify = _service.Get(_emprestimo.Id);
            livroVerify.Should().NotBeNull();
            livroVerify.Id.Should().Be(_emprestimo.Id);
        }

        [Test]
        public void Integration_UpdateEmprestimo_ShouldBeFail()
        {
            _emprestimo = ObjectMother.GetEmprestimoClienteMenor4Caracteres();
            Action action = () => _service.Editar(_emprestimo);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Integration_DeleteEmprestimo_ShouldBeOK()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _service.Excluir(_emprestimo);
            Emprestimo received = _service.Get(_emprestimo.Id);
            received.Should().BeNull();
        }

        [Test]
        public void Integration_GetEmprestimo_ShouldBeOK()
        {
            _emprestimo = _service.Get(1);
            _emprestimo.Should().NotBeNull();
            _emprestimo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Integration_GetEmprestimo_ShouldBeFail()
        {
            _emprestimo = _service.Get(200);
            _emprestimo.Should().BeNull();
        }

        [Test]
        public void Integration_GetAllLivros_ShouldBeOkay()
        {
            List<Emprestimo> emprestimos = _service.PegarTodos();
            emprestimos.Count().Should().BeGreaterThan(0);
        }
    }
}
