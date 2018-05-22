using Biblioteca.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Features.Emprestimos
{
    public class InvalidDateException : BusinessException
    {
        public InvalidDateException() : base("Data para devolução inválida!")
        {
        }
    }
}
