//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using model;
//using BLL;

//namespace AV1_ThiagoNeto.Controllers
//{
//    public class ProdutoesController : Controller
//    {
//        private BLLProduto bllProduto =BLLProduto(); new 

//        // GET: Produtoes
//        public ActionResult Index()
//        {
//            return View(bllProduto.Listar<Produto>());
//        }

//        // GET: Produtoes/Details/5
//        public ActionResult Details(int id)
//        {
//            if (id == 0)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            var produto = bllProduto.ObterPorId<Produto>(id);

//            if (produto == null)
//            {
//                return HttpNotFound();
//            }

//            return View(produto);
//        }

//        // GET: Produtoes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Produtoes/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Nome,Estoque,Preco")] Produto produto)
//        {
//            if (ModelState.IsValid)
//            {
//                int id = bllProduto.Inserir<Produto>(produto);

//                return RedirectToAction("Details/" + id);
//            }

//            return View(produto);
//        }

//        // GET: Produtoes/Edit/5
//        public ActionResult Edit(int id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

//            Produto produto;
//            produto = bllProduto.ObterPorId<Produto>(id);

//            return produto == null ? (ActionResult) HttpNotFound() : View(produto);
//        }

//        // POST: Produtoes/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Nome,Estoque,Preco")] Produto produto)
//        {
//            if (ModelState.IsValid)
//            {
//                bllProduto.Atualizar<Produto>(produto);
//                return RedirectToAction("Index");
//            }
//            return View(produto);
//        }

//        // GET: Produtoes/Delete/5
//        public ActionResult Delete(int id)
//        {
//            if (id == 0)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Produto produto = bllProduto.ObterPorId<Produto>(id);
//            if (produto == null)
//            {
//                return HttpNotFound();
//            }
//            return View(produto);
//        }

//        // POST: Produtoes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Produto produto = bllProduto.ObterPorId<Produto>(id);
//            bllProduto.Deletar<Produto>(produto);

//            return RedirectToAction("Index");
//        }

//    }
//}
