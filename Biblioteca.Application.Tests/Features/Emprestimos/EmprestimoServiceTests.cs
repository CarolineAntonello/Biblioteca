using Biblioteca.Application.Features.Emprestimos;
using Biblioteca.Common.Tests.Emprestimos;
using Biblioteca.Domain.Features.Emprestimos;
using Biblioteca.Domain.Features.Livros;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Tests.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoServiceTests
    {
        Mock<IEmprestimoRepository> _repository;
        EmprestimoService _service;
        Emprestimo _emprestimo;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<IEmprestimoRepository>();
            _service = new EmprestimoService(_repository.Object);
        }

        [Test]
        public void Service_Emprestimo_Deveria_Adicionar_Emprestimo()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _repository
                .Setup(l => l.Adicionar(It.IsAny<Emprestimo>()))
                .Returns(new Emprestimo
                {
                    Cliente = _emprestimo.Cliente,
                    DataDevolucao = _emprestimo.DataDevolucao,
                    Id = 1
                });
            _service.Adicionar(_emprestimo);
            _repository.Verify(l => l.Adicionar(_emprestimo));
        }

        [Test]
        public void Service_Emprestimo_Nao_Deveria_Adicionar_Emprestimo_Com_Erros()
        {
            _emprestimo = ObjectMother.GetEmprestimoClienteMenor4Caracteres();
            Action action = () => _service.Adicionar(_emprestimo);
            action.Should().Throw<InvalidCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Emprestimo_Deveria_Editar_Emprestimo()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _repository
                .Setup(l => l.Editar(It.IsAny<Emprestimo>()));
            _service.Editar(_emprestimo);
            _repository.Verify(l => l.Editar(_emprestimo));
        }

        [Test]
        public void Service_Emprestimo_Deveria_Excluir_Emprestimo()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _repository
                .Setup(l => l.Excluir(It.IsAny<int>()));
            _service.Excluir(_emprestimo);
            _repository.Verify(l => l.Excluir(_emprestimo.Id));
        }

        [Test]
        public void Service_Emprestimo_Deveria_BuscarPorId()
        {
            _emprestimo = ObjectMother.GetEmprestimoComId();
            _repository
                .Setup(l => l.GetById(It.IsAny<int>()));
            _service.Get(_emprestimo.Id);
            _repository.Verify(l => l.GetById(_emprestimo.Id));
        }

        [Test]
        public void Service_Emprestimo_Deveria_BuscarTodos()
        {
            List<Emprestimo> emprestimos = ObjectMother.GetEmprestimos();
            _repository
                .Setup(l => l.GetAll()).Returns(emprestimos);
            List<Emprestimo> recebidos = _service.PegarTodos();
            _repository.Verify(x => x.GetAll());
            recebidos.Should().BeEquivalentTo(emprestimos);
        }
    }
}
