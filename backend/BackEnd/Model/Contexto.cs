using System;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Contexto : DbContext
    {
        public Contexto()
        { }

        public Contexto(DbContextOptions<Contexto> opcoes)
           :base(opcoes)
        { }

        public DbSet<Tables.HistoricoAprovacao> HistoricoAprovacao { get; set; }
        public DbSet<Tables.NotaCompra> NotaCompra { get; set; }
        public DbSet<Tables.Usuario> Usuario { get; set; }
        public DbSet<Tables.ConfiguracaoAprovacao> ConfiguracaoAprovacao { get; set; }
    }
}
