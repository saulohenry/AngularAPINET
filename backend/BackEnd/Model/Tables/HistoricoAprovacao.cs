using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Tables
{
    public class HistoricoAprovacao
    {
        public int Id;
        public int IdNota;
        public DateTime DataOcorrencia;
        public string Usuario;
        public string Operacao;

        public NotaCompra NotaCompra;
    }
}
