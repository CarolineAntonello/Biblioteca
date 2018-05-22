using Biblioteca.Domain.Abstract;
using Biblioteca.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Features.Emprestimos
{
    public class Emprestimo : Entidade
    {
        public string Cliente;
        public Livro livro;
        public DateTime DataDevolucao;
        public double valorMulta;

        public override void Validar()
        {
            if (Cliente.Length < 4)
                throw new InvalidCaractersException();

            if (livro.Disponibilidade == false)
                throw new InvalidAvailabilityException();

            if (DataDevolucao < DateTime.Now)
                throw new InvalidDateException();
        }

        public void CalcularValorMulta(DateTime DataDeHoje)
        {
            //var DataDeDevolucao = DateTime.Parse(Convert.ToString(DataDevolucao));
            if (DataDeHoje > DataDevolucao)
            {
                valorMulta = (DataDeHoje.Date - DataDevolucao.Date).Days * 2.50;
            }
        }
    }
}
