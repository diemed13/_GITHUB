using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            IEnumerable<ClienteView> clientes;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cliente").Result;
            clientes = response.Content.ReadAsAsync<IEnumerable<ClienteView>>().Result;

            return View(clientes);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ClienteView());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cliente/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ClienteView>().Result);
            }            
        }

        [HttpPost]
        public ActionResult AddOrEdit(ClienteView cliente)
        {
            if (cliente.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cliente", cliente).Result;
                TempData["Mensagem"] = "Registro adicionado com sucesso";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Cliente/" + cliente.Id, cliente).Result;
                TempData["Mensagem"] = "Registro alterado com sucesso";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) 
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Cliente/" + id).Result;
            TempData["Mensagem"] = "Registro removido com sucesso";
            
            return RedirectToAction("Index");
        }


    }
}