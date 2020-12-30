using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using NLog;
using sql_demo.Context;

namespace sql_demo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IEnumerable<tbl_product> productList;
        db_testEntities9 db = new db_testEntities9();

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ActionResult Product(tbl_product obj)
        {
            if (obj != null)
                return View(obj);
            else
                return View();

        }
        [HttpPost]
        public ActionResult AddProduct(tbl_product model)
        {
            try {

                if (ModelState.IsValid)
                {

                    tbl_product obj = new tbl_product();
                    obj.product_id = model.product_id;
                    obj.product_name = model.product_name;
                    obj.product_category = model.product_category;
                    obj.price = model.price;
                    obj.quantity = model.quantity;
                    obj.short_desc = model.short_desc;
                    obj.long_desc = model.long_desc;

                    String fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    String extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    model.small_image = "~/Image/" + fileName;
                    model.large_image = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    model.ImageFile.SaveAs(fileName);


                    obj.small_image = model.small_image;
                    obj.large_image = model.large_image;


                    if (model.product_id == 0)
                    {
                        //db.tbl_product.Add(obj);
                        //db.SaveChanges();
                        HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", obj).Result;
                        logger.Info("Product added successfully");
                        TempData["successMesg"] = "Saved Successfully";
                    }
                    else
                    {
                        //db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        //db.SaveChanges();
                        HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product/" + model.product_id, obj).Result;
                        TempData["successMesg"] = "Updated Successfully";
                    }
                }
                // ModelState.Clear();
                //return View("Product");
                HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Product").Result;
                productList = responses.Content.ReadAsAsync<IEnumerable<tbl_product>>().Result;
                return View("ProductList", productList);
            }
            catch(Exception e)
            {
                logger.Error("Exception !" + e.Message);
                //throw e;
                return Content("Exception in adding products" + e.Message);
            }
            }
     
        public ActionResult ProductList()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<tbl_product>>().Result;
            return View(productList);
            /*
            var res = db.tbl_product.ToList();
            return View(res);
            */
        }
        public ActionResult Delete(int product_id)
        {
           /* var res = db.tbl_product.Where(x => x.product_id == product_id).First();
            db.tbl_product.Remove(res);
            db.SaveChanges();

            var list = db.tbl_product.ToList();*/

            HttpResponseMessage delresponse = GlobalVariables.WebApiClient.DeleteAsync("Product/" + product_id.ToString()).Result;
            
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<tbl_product>>().Result;
            TempData["successMesg"] = "Deleted Successfully";
            return View("ProductList", productList);
        }

    }
}