using Biblioteca.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Common.Tests.Livros
{
    public partial class ObjectMother
    {
        public static Livro GetLivro()
        {
            return new Livro
            {
                Autor = "Alberto",
                Tema = "Biografia",
                Titulo = "Minha História",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-200),
                Disponibilidade = true,
            };
        }

        public static Livro GetLivroComId()
        {
            return new Livro
            {
                Id = 1,
                Autor = "Alberto",
                Tema = "Biografia",
                Titulo = "Minha História",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-200),
                Disponibilidade = true,
            };
        }

        public static Livro GetLivroAutorMenos4Caracteres()
        {
            return new Livro
            {
                Autor = "tes",
                Tema = "tema",
                Titulo = "umteste",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-200),
                Disponibilidade = true,
            };
        }

        public static Livro GetLivroTemaMenos4Caracteres()
        {
            return new Livro
            {
                Autor = "teste",
                Tema = "tem",
                Titulo = "umteste",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-200),
                Disponibilidade = true,
            };
        }

        public static Livro GetLivroTituloMenos4Caracteres()
        {
            return new Livro
            {
                Autor = "teste",
                Tema = "teste",
                Titulo = "um",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-200),
                Disponibilidade = true,
            };
        }

        public static Livro GetLivroVolumeoMenor0()
        {
            return new Livro
            {
                Autor = "teste",
                Tema = "teste",
                Titulo = "teste",
                Volume = 0,
                DataPublicacao = DateTime.Now.AddDays(-200),
                Disponibilidade = true,
            };
        }
    }
}
