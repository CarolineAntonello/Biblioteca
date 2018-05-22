using Biblioteca.Common.Tests.Emprestimos;
using Biblioteca.Domain.Features.Emprestimos;
using Biblioteca.Domain.Features.Livros;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Tests.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoTests
    {
        Emprestimo _emprestimo;


        [Test]
        public void Domain_Emprestimo_Deveria_Adicionar_Corretamente()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _emprestimo.Validar();
            _emprestimo.Should().NotBeNull();
        }

        [Test]
        public void Domain_Emprestimo_Nao_Deveria_Aceitar_Cliente_Com_Menos_4_Caracteres()
        {
            _emprestimo = ObjectMother.GetEmprestimoClienteMenor4Caracteres();
            Action action = () => _emprestimo.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Emprestimo_Nao_Deveria_Aceitar_Disponiblidade_Indisponivel()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _emprestimo.livro.Disponibilidade = false;
            Action action = () => _emprestimo.Validar();
            action.Should().Throw<InvalidAvailabilityException>();
        }

        [Test]
        public void Domain_Emprestimo_Nao_Deveria_Aceitar_Data_Menor_Que_Atual()
        {
            _emprestimo = ObjectMother.GetEmprestimoDataMenorQueAtual();
            Action action = () => _emprestimo.Validar();
            action.Should().Throw<InvalidDateException>();
        }

        [Test]
        public void Domain_Emprestimo_Deveria_Calcular_Multa()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _emprestimo.DataDevolucao = DateTime.Now;
            _emprestimo.CalcularValorMulta(DateTime.Now.AddDays(5));
            _emprestimo.valorMulta.Should().Be(12.5);
        }

        [Test]
        public void Domain_Emprestimo_Deveria_Calcular_Multa_Sem_Multa()
        {
            _emprestimo = ObjectMother.GetEmprestimo();
            _emprestimo.DataDevolucao = DateTime.Now;
            _emprestimo.CalcularValorMulta(DateTime.Now);
            _emprestimo.valorMulta.Should().Be(0);
        }
    }
}
