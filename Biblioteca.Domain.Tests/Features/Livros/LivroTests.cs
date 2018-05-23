using Biblioteca.Common.Tests.Livros;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.Features.Livros;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biblioteca.Domain.Tests.Features.Livros
{
    [TestFixture]
    public class LivroTests
    {
        Livro _livro;

        [Test]
        public void Domain_Livro_Deveria_Adicionar_Corretamente()
        {
            _livro = ObjectMother.GetLivroComId();
            _livro.Validar();
            _livro.Should().NotBeNull();
        }

        [Test]
        public void Domain_Livro_Nao_Deveria_Aceitar_Autor_Menor_Que_4_Caracteres()
        {
            _livro = ObjectMother.GetLivroAutorMenos4Caracteres();
            Action action = () => _livro.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Livro_Nao_Deveria_Aceitar_Tema_Menor_Que_4_Caracteres()
        {
            _livro = ObjectMother.GetLivroTemaMenos4Caracteres();
            Action action = () => _livro.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Livro_Nao_Deveria_Aceitar_Titulo_Menor_Que_4_Caracteres()
        {
            _livro = ObjectMother.GetLivroTituloMenos4Caracteres();
            Action action = () => _livro.Validar();
            action.Should().Throw<InvalidCaractersException>();
        }

        [Test]
        public void Domain_Livro_Nao_Deveria_Aceitar_Volume_Menor_Que_0()
        {
            _livro = ObjectMother.GetLivroVolumeoMenor0();
            Action action = () => _livro.Validar();
            action.Should().Throw<InvalidVolumeException>();
        }

        //[Test]
        //public void Domain_Livro_Nao_Deveria_Aceitar_Id_Menor_Que_0()
        //{
        //    _livro = ObjectMother.GetLivro();
        //    Action action = () => _livro.Validar();
        //    action.Should().Throw<IdentifierUndefinedException>();
        //}

    }
}
