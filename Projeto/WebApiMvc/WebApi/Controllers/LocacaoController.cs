using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LocacaoController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Locacao
        public IQueryable<Locacao> GetLocacao()
        {
            return db.Locacao;
        }

        // GET: api/Locacao/5
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult GetLocacao(int id)
        {
            Locacao locacao = db.Locacao.Find(id);
            if (locacao == null)
            {
                return NotFound();
            }

            return Ok(locacao);
        }

        // PUT: api/Locacao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locacao.Id)
            {
                return BadRequest();
            }

            db.Entry(locacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Locacao
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult PostLocacao(Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Locacao.Add(locacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacao/5
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult DeleteLocacao(int id)
        {
            Locacao locacao = db.Locacao.Find(id);
            if (locacao == null)
            {
                return NotFound();
            }

            db.Locacao.Remove(locacao);
            db.SaveChanges();

            return Ok(locacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocacaoExists(int id)
        {
            return db.Locacao.Count(e => e.Id == id) > 0;
        }
    }
}