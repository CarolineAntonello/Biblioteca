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

namespace Biblioteca.Infra.Data.Tests.Feature.Biblioteca
{
    [TestFixture]
    public class EmprestimoSqlRepositoryTests
    {
        private IEmprestimoRepository _repository;
        private Emprestimo _emprestimo;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new EmprestimoSQLRepository();
        }

        [Test]
        public void Repository_Emprestimo_Sql_Adicionar_ShouldBeOk()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _emprestimo = _repository.Adicionar(_emprestimo);
            _emprestimo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Emprestimo_Sql_Adicionar_ShouldBeFail()
        {
            _emprestimo = ObjectMother.GetEmprestimoClienteMenor4Caracteres();
            Action action = () => _repository.Adicionar(_emprestimo);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Emprestimo_Sql_Editar_ShouldBeOk()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _repository.Editar(_emprestimo);
            Emprestimo recebe = _repository.GetById(_emprestimo.Id);
            recebe.Id.Should().Be(_emprestimo.Id);
        }

        [Test]
        public void Repository_Emprestimo_Sql_Editar_ShouldBeFail()
        {
            _emprestimo = ObjectMother.GetEmprestimoClienteMenor4Caracteres();
            Action action = () => _repository.Editar(_emprestimo);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Emprestimo_Sql_Excluir_ShouldBeOk()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _repository.Excluir(_emprestimo.Id);
            Emprestimo recebe = _repository.GetById(_emprestimo.Id);
            recebe.Should().BeNull();
        }

        [Test]
        public void Repository_Emprestimo_Sql_GetById_ShouldBeOk()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _repository.GetById(_emprestimo.Id);
            _emprestimo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Emprestimo_Sql_GetAll_ShouldBeOk()
        {
            List<Emprestimo> emprestimos = ObjectMother.GetEmprestimos();
            foreach (var item in emprestimos)
            {
                _repository.Adicionar(item);
            }
            var emprestimos_add = _repository.GetAll();
            emprestimos_add.Count().Should().Be(3);
        }

    }
}
