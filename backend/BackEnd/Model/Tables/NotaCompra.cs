using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Tables
{
    public class NotaCompra
    {
        public int Id;
        public DateTime DataEmissao;
        public double ValorMercadorias;
        public double ValorDesconto;
        public double ValorFrete;
        public double ValorTotal;
        public string Status;

        public List<HistoricoAprovacao> historicoAprovacao;
    }
}
