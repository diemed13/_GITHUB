using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class LocacaoView
    {
        public int Id { get; set; }

        public int IdLivro { get; set; }

        public DateTime DataLocacao { get; set; }

    }
}