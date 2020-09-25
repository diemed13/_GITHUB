namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Locacao")]
    public partial class Locacao
    {
        public int Id { get; set; }

        public int IdLivro { get; set; }

        public DateTime DataLocacao { get; set; }

        //public virtual Livro Livro { get; set; }
    }
}
