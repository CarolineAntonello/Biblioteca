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
        ILivroRepository _repository;
        public LivroService(ILivroRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
