using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult Index()
        {
            IEnumerable<LivroView> livros;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Livro").Result;
            livros = response.Content.ReadAsAsync<IEnumerable<LivroView>>().Result;

            return View(livros);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new LivroView());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Livro/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<LivroView>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(LivroView livro)
        {
            if (livro.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Livro", livro).Result;
                TempData["Mensagem"] = "Registro adicionado com sucesso";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Livro/" + livro.Id, livro).Result;
                TempData["Mensagem"] = "Registro alterado com sucesso";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Livro/" + id).Result;
            TempData["Mensagem"] = "Registro removido com sucesso";

            return RedirectToAction("Index");
        }

        public ActionResult Pesquisar(string pesquisa)
        {
            IEnumerable<LivroView> livros;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Livro").Result;

            livros = response.Content.ReadAsAsync<IEnumerable<LivroView>>().Result
                        .Where(x => (x.Titulo != null && x.Titulo.ToLower().Contains(pesquisa.ToLower())) ||
                                    (x.Descricao != null && x.Descricao.ToLower().Contains(pesquisa.ToLower())) ||
                                    (x.Genero != null && x.Genero.ToLower().Contains(pesquisa.ToLower())));

            return View("Index", livros);
        }


    }
}