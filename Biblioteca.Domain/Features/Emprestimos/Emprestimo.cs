using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Features.Emprestimos
{
    public class Emprestimo : Entidade
    {
        public string Cliente;
        public Livro livro;
        public DateTime DataDevolucao;

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
