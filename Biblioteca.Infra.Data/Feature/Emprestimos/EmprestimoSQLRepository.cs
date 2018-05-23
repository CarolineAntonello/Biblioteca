using Biblioteca.Application.Features.Emprestimos;
using Biblioteca.Domain.Features.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Feature.Emprestimos
{
    public class EmprestimoSQLRepository : IEmprestimoRepository
    {
        public Emprestimo Adicionar(Emprestimo entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(Emprestimo entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Emprestimo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Emprestimo GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
