namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Locacao)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Livro>()
                .HasMany(e => e.Locacao)
                .WithRequired(e => e.Livro)
                .HasForeignKey(e => e.IdLivro)
                .WillCascadeOnDelete(false);
        }
    }
}
