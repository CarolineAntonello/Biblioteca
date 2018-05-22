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
    }
}
