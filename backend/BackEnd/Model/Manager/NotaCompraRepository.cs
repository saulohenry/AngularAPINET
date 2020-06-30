using Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Manager
{
    public class NotaCompraRepository : IDataRepository<NotaCompra>
    {
        readonly Contexto _Context;

        public NotaCompraRepository(Contexto context)
        {
            _Context = context;
        }

        public IEnumerable<NotaCompra> GetAll()
        {
            return _Context.NotaCompra.ToList();
        }

        public NotaCompra Get(int id)
        {
            return _Context.NotaCompra
                  .FirstOrDefault(e => e.Id == id);
        }

        public NotaCompra Get(string usuario)
        {
            return _Context.NotaCompra
                  .FirstOrDefault(e => e.Status == "Pendente"
                                && e.historicoAprovacao.Any(i => i.Usuario != usuario));
        }

        public List<NotaCompra> Get(DateTime data, string usuario)
        {
            return _Context.NotaCompra
                  .Where(e => e.Status == "Pendente"
                                    && e.DataEmissao == data 
                                    && e.historicoAprovacao.Any(i => i.Usuario != usuario) ).ToList();
        }

        public void Add(NotaCompra entity)
        {
            _Context.NotaCompra.Add(entity);
            _Context.SaveChanges();
        }

        public void Update(NotaCompra n, NotaCompra n1)
        {
            n.Id = n1.Id;
            n.Status = n1.Status;
            n.ValorDesconto = n1.ValorDesconto;
            n.ValorFrete = n1.ValorFrete;
            n.ValorMercadorias = n1.ValorMercadorias;
            n.ValorTotal = n1.ValorTotal;
            n.DataEmissao = n1.DataEmissao;

            _Context.SaveChanges();
        }

        public void Delete(NotaCompra nota)
        {
            _Context.NotaCompra.Remove(nota);
            _Context.SaveChanges();
        }
    }
}
