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

namespace Biblioteca.Infra.Data.Tests.Feature.Livros
{
    [TestFixture]
    public class LivroSqlRepositoryTests
    {
        private ILivroRepository _repository;
        private Livro _livro;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new LivroSQLRepository();
        }

        [Test]
        public void Repository_Livro_Sql_Adicionar_ShouldBeOk()
        {
            _livro = ObjectMother.GetLivro();
            _livro = _repository.Adicionar(_livro);
            _livro.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Livro_Sql_Adicionar_ShouldBeFail()
        {
            _livro = ObjectMother.GetLivroAutorMenos4Caracteres();
            Action action = () => _repository.Adicionar(_livro);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Livro_Sql_Editar_ShouldBeOk()
        {
            _livro = ObjectMother.GetLivroComId();
            _repository.Editar(_livro);
            Livro liv = _repository.GetById(_livro.Id);
            liv.Id.Should().Be(_livro.Id);
        }

        [Test]
        public void Repository_Livro_Sql_Editar_ShouldBeFail()
        {
            _livro = ObjectMother.GetLivroAutorMenos4Caracteres();
            Action action = () => _repository.Editar(_livro);
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Repository_Livro_Sql_Excluir_ShouldBeOk()
        {
            _livro = ObjectMother.GetLivroComId();
            _repository.Excluir(_livro.Id);
            Livro liv = _repository.GetById(_livro.Id);
            liv.Should().BeNull();
        }

        [Test]
        public void Repository_Livro_Sql_GetById_ShouldBeOk()
        {
            _livro = ObjectMother.GetLivroComId();
            _repository.GetById(_livro.Id);
            _livro.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Livro_Sql_GetAll_ShouldBeOk()
        {
            List<Livro> livro = ObjectMother.GetLivros();
            foreach (var item in livro)
            {
                _repository.Adicionar(item);
            }
            var livros_add = _repository.GetAll();
            livros_add.Count().Should().Be(3);
        }
    }
}
