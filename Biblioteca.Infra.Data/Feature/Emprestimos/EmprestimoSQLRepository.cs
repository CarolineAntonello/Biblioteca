using Biblioteca.Application.Features.Emprestimos;
using Biblioteca.Domain.Features.Emprestimos;
using Biblioteca.Domain.Features.Livros;
using Biblioteca.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Feature.Emprestimos
{
    public class EmprestimoSQLRepository : IEmprestimoRepository
    {
        #region Querys
        private string _sqlAdd = @"INSERT INTO 
                                    TBEmprestimo
                                    (Cliente,
                                    DataDevolucao,
                                    LivroId) 
                                    VALUES 
                                    (@Cliente, 
                                    @DataDevolucao,
                                    @LivroId)";

        private string _sqlUpdate = @"UPDATE 
                                    TBEmprestimo 
                                    SET 
                                    Cliente = @Cliente, 
                                    DataDevolucao = @DataDevolucao, 
                                    LivroId = @LivroId
                                    where Id = @Id";

        private string _sqlGetById = @"SELECT e.Id,
                                              e.Cliente,
                                              e.DataDevolucao,
                                              e.LivroId,
                                              l.Titulo,
                                              l.Tema,
                                              l.Autor,
                                              l.Volume
                                              FROM TBEmprestimo as e
                                              INNER JOIN TBLivro as l ON l.Id = e.LivroId                                                
                                              WHERE e.Id = @Id";

        private string _sqlDelete = @"DELETE FROM TBEmprestimo
                                    WHERE Id = @Id";

        private string _sqlGetAll = @"SELECT e.Id,
                                            e.Cliente,
                                            e.DataDevolucao,
                                            e.LivroId,
                                            l.Titulo,
                                            l.Tema,
                                            l.Autor,
                                            l.Volume
                                            FROM TBEmprestimo as e
                                            INNER JOIN TBLivro as l ON l.Id = e.LivroId";
        #endregion

        public Emprestimo Adicionar(Emprestimo entidade)
        {
            entidade.Validar();
            entidade.Id = Db.Insert(_sqlAdd, Take(entidade));
            return entidade;
        }

        public void Editar(Emprestimo entidade)
        {
            entidade.Validar();
            Db.Update(_sqlUpdate, Take(entidade));
        }

        public void Excluir(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Db.Delete(_sqlDelete, parms);
        }

        public List<Emprestimo> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Emprestimo GetById(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Emprestimo emprestimo = Db.Get(_sqlGetById, Make, parms);
            return emprestimo;
        }
        
        private Emprestimo Make(IDataReader reader)
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.livro = new Livro();

            emprestimo.Id = Convert.ToInt32(reader["Id"]);
            emprestimo.Cliente = reader["Cliente"].ToString();
            emprestimo.DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]);
            emprestimo.livro.Id = Convert.ToInt32(reader["LivroId"]);
            return emprestimo;
        }

        private Dictionary<string, object> Take(Emprestimo emprestimo)
        {

            return new Dictionary<string, object>
            {
                { "Id", emprestimo.Id },
                { "Cliente", emprestimo.Cliente },
                { "DataDevolucao", emprestimo.DataDevolucao },
                { "LivroId", emprestimo.livro.Id }
            };
        }
    }
}
