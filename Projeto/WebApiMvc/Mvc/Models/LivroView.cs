using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class LivroView
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "O título precisa ter entre 2 e 50 caracteres")]
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }


        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O Gênero precisa ter entre 3 e 30 caracteres")]
        public string Genero { get; set; }
        

         
    }
}