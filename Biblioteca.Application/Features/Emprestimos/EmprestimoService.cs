using Biblioteca.Application.Abstract;
using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Features.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Emprestimos
{
    public class EmprestimoService : Service<Emprestimo>
    {
        IEmprestimoRepository _repository;
        public EmprestimoService(IEmprestimoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
