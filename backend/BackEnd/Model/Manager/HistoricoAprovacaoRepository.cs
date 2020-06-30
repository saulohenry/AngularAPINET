using Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Manager
{
    public class HistoricoAprovacaoRepository : IDataRepository<HistoricoAprovacao>
    {
        readonly Contexto _Context;

        public HistoricoAprovacaoRepository(Contexto context)
        {
            _Context = context;
        }

        public IEnumerable<HistoricoAprovacao> GetAll()
        {
            return _Context.HistoricoAprovacao.ToList();
        }

        public HistoricoAprovacao Get(int idNota)
        {
            return _Context.HistoricoAprovacao
                  .FirstOrDefault(e => e.IdNota == idNota);
        }
        public HistoricoAprovacao Get(int idNota, string Usuario)
        {
            return _Context.HistoricoAprovacao
                  .FirstOrDefault(e => e.Usuario == Usuario && e.IdNota == idNota);
        }

        public void Add(HistoricoAprovacao entity)
        {
            _Context.HistoricoAprovacao.Add(entity);
            _Context.SaveChanges();

            ConfiguracaoAprovacao conf = _Context.ConfiguracaoAprovacao.Where(e => e.Faixa >= entity.NotaCompra.ValorTotal
                                                                                && e.Faixa <= entity.NotaCompra.ValorTotal).FirstOrDefault();

            List<HistoricoAprovacao> listAprovacao = _Context.HistoricoAprovacao.Where(e => e.IdNota == entity.NotaCompra.Id).ToList();

            if (listAprovacao.Count(e => e.Operacao == "Visto") == conf.Vistos
                && listAprovacao.Count(e => e.Operacao == "Operacao") == conf.Aprovacao)
            {
                entity.NotaCompra.Status = "Aprovada";
                _Context.SaveChanges();
            }
        }

        public void Update(HistoricoAprovacao n, HistoricoAprovacao n1)
        {
            
        }

        public void Delete(HistoricoAprovacao HistoricoNota)
        {
            _Context.HistoricoAprovacao.Remove(HistoricoNota);
            _Context.SaveChanges();
        }
    }
}
