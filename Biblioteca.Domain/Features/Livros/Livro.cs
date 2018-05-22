using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Features.Livros
{
    public class Livro : Entidade
    {
        public string Titulo;
        public string Tema;
        public string Autor;
        public int Volume;
        public DateTime DataPublicacao;
        public bool Disponibilidade;

        public override void Validar()
        {
            if (Titulo.Length < 4)
                throw new InvalidCaractersException();

            if (Tema.Length < 4)
                throw new InvalidCaractersException();

            if (Autor.Length < 4)
                throw new InvalidCaractersException();

            if (Volume <= 0)
                throw new InvalidVolumeException();

            if (Id <= 0)
                throw new IdentifierUndefinedException();

        }
    }
}
