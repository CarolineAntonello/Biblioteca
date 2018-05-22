using Biblioteca.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Features.Livros
{
    public class InvalidVolumeException : BusinessException
    {
        public InvalidVolumeException() : base("Volume inválido! É preciso ser acima de 0")
        {
        }
    }
}
