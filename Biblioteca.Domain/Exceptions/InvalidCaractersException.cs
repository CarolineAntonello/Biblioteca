using Biblioteca.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Features.Livros
{
    public class InvalidCaractersException : BusinessException
    {
        public InvalidCaractersException() : base("É preciso ter mais de 4 caracteres!")
        {
        }
    }
}
