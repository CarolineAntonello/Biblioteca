using Biblioteca.Application.Features.Livros;
using Biblioteca.Domain.Features.Livros;
using Biblioteca.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Feature.Livros
{
    public class LivroSQLRepository : ILivroRepository
    {
        private string _sqlAdd = @"INSERT INTO 
                                    TBLivro
                                    (Titulo,
                                    Tema,
                                    Autor,
                                    Volume,
                                    DataPublicacao,
                                    Disponibilidade) 
                                    VALUES 
                                    (@Titulo, 
                                    @Tema,
                                    @Autor, 
                                    @Volume, 
                                    @DataPublicacao, 
                                    @Disponibilidade)";

        private string _sqlUpdate = @"UPDATE 
                                    TBLivro 
                                    SET 
                                    Titulo = @Titulo, 
                                    Tema = @Tema, 
                                    Autor = @Autor, 
                                    Volume = @Volume, 
                                    DataPublicacao = @DataPublicacao, 
                                    Disponibilidade = @Disponibilidade 
                                    where Id = @Id";

        private string _sqlGetById = @"select *from TBLivro where Id = @Id";

        private string _sqlDelete = @"DELETE FROM TBLivro
                                    WHERE Id = @Id";

        private string _sqlGetAll = @"SELECT 
                                    Id,
                                    Titulo,
                                    Tema,
                                    Autor,
                                    Volume,
                                    DataPublicacao,
                                    Disponibilidade
                                    FROM
                                    TBLivro";

        public Livro Adicionar(Livro entidade)
        {
            entidade.Validar();
            entidade.Id = Db.Insert(_sqlAdd, Take(entidade));
            return entidade;
        }

        public void Editar(Livro entidade)
        {
            entidade.Validar();
            Db.Update(_sqlUpdate, Take(entidade));
        }

        public void Excluir(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Db.Delete(_sqlDelete, parms);
        }

        public List<Livro> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Livro GetById(int Id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", Id } };
            Livro livro = Db.Get(_sqlGetById, Make, parms);
            return livro;
        }

        
        private static Func<IDataReader, Livro> Make = reader =>
           new Livro
           {
               Id = Convert.ToInt32(reader["Id"]),
               Titulo = reader["Titulo"].ToString(),
               Tema = reader["Tema"].ToString(),
               Autor = reader["Autor"].ToString(),
               Volume = Convert.ToInt32(reader["Volume"]),
               Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
               DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"])

           };

        private Dictionary<string, object> Take(Livro livro)
        {

            return new Dictionary<string, object>
            {
                { "Id", livro.Id },
                { "Titulo", livro.Titulo },
                { "Tema", livro.Tema },
                { "Autor", livro.Autor },
                { "Volume", livro.Volume },
                { "Disponibilidade", livro.Disponibilidade },
                { "DataPublicacao", livro.DataPublicacao }
            };
        }
    }
}
