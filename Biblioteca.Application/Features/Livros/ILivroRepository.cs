using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Livros
{
    public interface ILivroRepository : IRepository<Livro>
    {
    }
}
