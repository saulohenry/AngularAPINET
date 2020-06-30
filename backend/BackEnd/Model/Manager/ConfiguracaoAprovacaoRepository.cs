using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Tables;

namespace Model.Manager
{
    public class ConfiguracaoAprovacaoRepository : IDataRepository<ConfiguracaoAprovacao>
    {
        readonly Contexto _Context;

        public ConfiguracaoAprovacaoRepository(Contexto context)
        {
            _Context = context;
        }

        public IEnumerable<ConfiguracaoAprovacao> GetAll()
        {
            return _Context.ConfiguracaoAprovacao.ToList();
        }

        public ConfiguracaoAprovacao Get(int id)
        {
            return _Context.ConfiguracaoAprovacao
                  .FirstOrDefault(e => e.id == id);
        }
       
        public void Add(ConfiguracaoAprovacao entity)
        {
            _Context.ConfiguracaoAprovacao.Add(entity);
            _Context.SaveChanges();
        }

        public void Update(ConfiguracaoAprovacao n, ConfiguracaoAprovacao n1)
        {

        }

        public void Delete(ConfiguracaoAprovacao configuracao)
        {
            _Context.ConfiguracaoAprovacao.Remove(configuracao);
            _Context.SaveChanges();
        }
    }
}
