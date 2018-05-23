using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Features.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Emprestimos
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
    }
}
