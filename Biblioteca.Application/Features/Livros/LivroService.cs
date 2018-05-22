using Biblioteca.Application.Abstract;
using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Livros
{
    public class LivroService : Service<Livro>
    {
        public LivroService(IRepository<Livro> repository) : base(repository)
        {
        }
    }
}
