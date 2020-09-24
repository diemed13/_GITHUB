namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Livro")]
    public partial class Livro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livro()
        {
            Locacao = new HashSet<Locacao>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(30)]
        public string Genero { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Locacao> Locacao { get; set; }
    }
}
