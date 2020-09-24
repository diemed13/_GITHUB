using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class ClienteView
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome precisa ter entre 3 e 50 caracteres")]
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}