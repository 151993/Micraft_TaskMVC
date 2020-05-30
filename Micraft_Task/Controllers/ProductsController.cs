using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Micraft_Task;

namespace Micraft_Task.Controllers
{
    public class ProductsController : Controller
    {
        private MicraftTaskDBEntities db = new MicraftTaskDBEntities();

        // GET: Products
        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }

       
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCode,ProductName,ProductImage,Unit,Rate,Description")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = FilePath(product.ProductCode, file);
                    product.ProductImage = path;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,ProductName,ProductImage,Unit,Rate,Description")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = FilePath(product.ProductCode, file);
                    product.ProductImage = path;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    //Product product1 = db.Products.Find(product.ProductId);
                    //        var pr = db.Products.Select(item => new Product
                    //        {
                    //            ProductCode = item.ProductCode,
                    //            ProductName = item.ProductName,
                    //            Unit = item.Unit,
                    //            Rate = item.Rate,
                    //            Description = item.Description
                    //        }
                    //).ToList();


                    //List<Product> p=  (from item in db.Products
                    //   where item.ProductId == product.ProductId
                    //   select new Product {

                    //       ProductCode = item.ProductCode,
                    //       ProductName = item.ProductName,
                    //       Unit = item.Unit,
                    //       Rate = item.Rate,
                    //       Description = item.Description
                    //   }).ToList();
                    Product prod = db.Products.Where(x => x.ProductId.Equals(product.ProductId)).FirstOrDefault();
                    prod.ProductCode = product.ProductCode;
                    prod.ProductName = product.ProductName;
                           prod.Unit = product.Unit;
                    prod.Rate = product.Rate;
                    prod.Description = product.Description;
                    //strinprod.g path = prId;
                    //product.ProductImage = prId;
                    //fileName = carousel.CarouselImage; 
                    //path = System.IO.Path.Combine(
                    //                      Server.MapPath("~/Images/Carousel"), fileName);
                    db.Entry(prod).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(product);
        }

       

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string FilePath(string productCode ,HttpPostedFileBase file)
        {
            string imagefile = "";
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
                };
            var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                imagefile = name + "_" + productCode + ext; //appending the name with id  
                                                                        // store the file inside ~/project folder(Img)  
                var path = Path.Combine(Server.MapPath("~/Images"), imagefile);
                file.SaveAs(path);
            }
            else
            {
                ViewBag.message = "Please choose only Image file";
            }
            return imagefile;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
