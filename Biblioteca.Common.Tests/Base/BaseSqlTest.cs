using Biblioteca.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_LIVRO_TABLE = "DELETE FROM [dbo].[TBLivro]" +
                                                    "DBCC CHECKIDENT ('TBLivro', RESEED, 0)";

        private const string RECREATE_EMPRESTIMO_TABLE = "DELETE FROM [dbo].[TBEmprestimo]" +
                                                       "DBCC CHECKIDENT ('TBEmprestimo', RESEED, 0)";

        private const string INSERT = @"
                        DECLARE @dateNowMoreDays DateTime;
                        DECLARE @LivroId INT

                        SELECT  @dateNowMoreDays = DATEADD(day, 30, GETDATE())

                        INSERT INTO TBLivro(Titulo, 
                                            Tema, 
                                            Autor, 
                                            Volume, 
                                            DataPublicacao, 
                                            Disponibilidade)

                        VALUES('Teste', 'Livro de testes', 'Joaquim José', 1, GETDATE(), 1)

                        SET @LivroId = @@IDENTITY

                        INSERT INTO TBEmprestimo (Cliente, DataDevolucao, LivroId)         
			            VALUES ('Caroline', GETDATE(), @LivroId);";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_EMPRESTIMO_TABLE);
            Db.Update(RECREATE_LIVRO_TABLE);
            Db.Update(INSERT);
        }
    }
}
