using Biblioteca.Domain.Features.Emprestimos;
using Biblioteca.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Common.Tests.Emprestimos
{
    public partial class ObjectMother
    {
        public static Emprestimo GetEmprestimo()
        {
            return new Emprestimo
            {
                Cliente = "João",
                DataDevolucao = DateTime.Now.AddDays(10),
                livro = Biblioteca.Common.Tests.Livros.ObjectMother.GetLivroComId(),
            };
        }

        public static Emprestimo GetEmprestimoComId()
        {
            return new Emprestimo
            {
                Id = 1,
                Cliente = "João",
                DataDevolucao = DateTime.Now.AddDays(10),
                livro = Biblioteca.Common.Tests.Livros.ObjectMother.GetLivroComId(),
            };
        }

        public static Emprestimo GetEmprestimoClienteMenor4Caracteres()
        {
            return new Emprestimo
            {
                Cliente = "Jó",
                DataDevolucao = DateTime.Now.AddDays(10),
                livro = Biblioteca.Common.Tests.Livros.ObjectMother.GetLivroComId(),
            };
        }

        public static Emprestimo GetEmprestimoDataMenorQueAtual()
        {
            return new Emprestimo
            {
                Cliente = "Jaquim",
                DataDevolucao = DateTime.Now.AddDays(-2),
                livro = Biblioteca.Common.Tests.Livros.ObjectMother.GetLivroComId(),
            };
        }

        public static List<Emprestimo> GetEmprestimos()
        {
            return new List<Emprestimo>
            {
                new Emprestimo
                {
                    Id = 1,
                   Cliente = "Carol",
                   DataDevolucao = DateTime.Now.AddDays(7),
                   livro = Biblioteca.Common.Tests.Livros.ObjectMother.GetLivroComId(),
                },

                new Emprestimo
                {
                    Id = 2,
                    Cliente = "Xivits",
                   DataDevolucao = DateTime.Now.AddDays(7),
                   livro = Biblioteca.Common.Tests.Livros.ObjectMother.GetLivroComId(),
                },

            };
        }
    }
}
