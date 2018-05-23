using Biblioteca.Application.Features.Livros;
using Biblioteca.Common.Tests.Livros;
using Biblioteca.Domain.Features.Livros;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Tests.Features.Livros
{
    [TestFixture]
    public class LivroServiceTests
    {
        Mock<ILivroRepository> _repository;
        LivroService _service;
        Livro _livro;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<ILivroRepository>();
            _service = new LivroService(_repository.Object);
        }

        [Test]
        public void Service_Livro_Deveria_Adicionar_Livro()
        {
            _livro = ObjectMother.GetLivro();
            _repository
                .Setup(l => l.Adicionar(It.IsAny<Livro>()))
                .Returns(new Livro
                {
                    Autor = _livro.Autor,
                    DataPublicacao = _livro.DataPublicacao,
                    Tema = _livro.Tema,
                    Titulo = _livro.Titulo,
                    Volume = _livro.Volume,
                    Id = 1
                });
            _service.Adicionar(_livro);
            _repository.Verify(l => l.Adicionar(_livro));
        }

        [Test]
        public void Service_Livro_Nao_Deveria_Adicionar_Livro_Com_Erros()
        {
            _livro = ObjectMother.GetLivroAutorMenos4Caracteres();
            Action action = () => _service.Adicionar(_livro);
            action.Should().Throw<InvalidCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Livro_Deveria_Editar_Livro()
        {
            _livro = ObjectMother.GetLivroComId();
            _repository
                .Setup(l => l.Editar(It.IsAny<Livro>()));
            _service.Editar(_livro);
            _repository.Verify(l => l.Editar(_livro));
        }

        [Test]
        public void Service_Livro_Deveria_Excluir_Livro()
        {
            _livro = ObjectMother.GetLivroComId();
            _repository
                .Setup(l => l.Excluir(It.IsAny<int>()));
            _service.Excluir(_livro);
            _repository.Verify(l => l.Excluir(_livro.Id));
        }

        [Test]
        public void Service_Livro_Deveria_BuscarPorId()
        {
            _livro = ObjectMother.GetLivroComId();
            _repository
                .Setup(l => l.GetById(It.IsAny<int>()));
            _service.Get(_livro.Id);
            _repository.Verify(l => l.GetById(_livro.Id));
        }

        [Test]
        public void Service_Livro_Deveria_BuscarTodos()
        {
            List<Livro> livros = ObjectMother.GetLivros();
            _repository
                .Setup(l => l.GetAll()).Returns(livros);
            List<Livro> recebidos = _service.PegarTodos();
            _repository.Verify(x => x.GetAll());
            recebidos.Should().BeEquivalentTo(livros);
        }
    }
}
