using Mvc.Models;
using System;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.UI;

namespace Mvc.Controllers
{
    public class LocacaoController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            return View(new LocacaoView());
        }

        public ActionResult Locacao(int id = 0)
        {
            TempData["Retorno"] = null;

            if (id == 0)
            {
                TempData["Retorno"] = "id-error";
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Locacao/" + id.ToString()).Result;
                var obj = response.Content.ReadAsAsync<LocacaoView>().Result;

                if (obj == null)
                {
                    response = GlobalVariables.WebApiClient
                                .PostAsJsonAsync("Locacao", new LocacaoView
                                {
                                    DataLocacao = DateTime.Now,
                                    IdLivro = id
                                }).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        TempData["Retorno"] = "success";
                        return RedirectToAction("Index");
                    }
                }


                TempData["Retorno"] = "error";
                return RedirectToAction("Index");
            }
        }
    }
}
