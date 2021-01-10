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
    public class ProductController : ApiController
    {
        private db_testEntities db = new db_testEntities();
       public  List<tbl_product> _products = new List<tbl_product>();

        public ProductController() { }

        public ProductController(List<tbl_product> products)
        {
            this._products = products;
        }


        // GET: api/tbl_product
        public IQueryable<tbl_product> Gettbl_product()
        {
            return db.tbl_product;
        }

        // GET: api/tbl_product/5
        [ResponseType(typeof(tbl_product))]
        public IHttpActionResult Gettbl_product(int id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return NotFound();
            }

            return Ok(tbl_product);
        }

        // PUT: api/tbl_product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_product(int id, tbl_product tbl_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_product.product_id)
            {
                return BadRequest();
            }

            db.Entry(tbl_product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_productExists(id))
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

        // POST: api/tbl_product
        [ResponseType(typeof(tbl_product))]
        public IHttpActionResult Posttbl_product(tbl_product tbl_product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_product.Add(tbl_product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_product.product_id }, tbl_product);
        }

        // DELETE: api/tbl_product/5
        [ResponseType(typeof(tbl_product))]
        public IHttpActionResult Deletetbl_product(int id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return NotFound();
            }

            db.tbl_product.Remove(tbl_product);
            db.SaveChanges();

            return Ok(tbl_product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_productExists(int id)
        {
            return db.tbl_product.Count(e => e.product_id == id) > 0;
        }
    }
}