using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using model;

namespace AV1_ThiagoNeto.Controllers
{
    public class ItemPedidoController : Controller
    {
        private BLL.BLLItemPedido<ItemPedido> bllItemPedido = new BLL.BLLItemPedido<ItemPedido>();

        // GET: ItemPedido
        public ActionResult Index()
        {
            return View(bllItemPedido.Listar());
        }

        // GET: ItemPedido/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = bllItemPedido.ObterPorId(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // GET: ItemPedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantidade")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                bllItemPedido.Inserir(itemPedido);
                return RedirectToAction("Index");
            }

            return View(itemPedido);
        }

        // GET: ItemPedido/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = bllItemPedido.ObterPorId(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // POST: ItemPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantidade")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                var teste = new BLLItemPedido<ItemPedido>().ObterPorId(itemPedido.Id);
                itemPedido.PedidoId = teste.PedidoId;
                itemPedido.ProdutoId = teste.ProdutoId;
                new BLLItemPedido<ItemPedido>().Atualizar(itemPedido);
                return RedirectToAction("Index");
            }
            return View(itemPedido);
        }

        // GET: ItemPedido/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = bllItemPedido.ObterPorId(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // POST: ItemPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPedido itemPedido = bllItemPedido.ObterPorId(id);
            bllItemPedido.Deletar(itemPedido);
            return RedirectToAction("Index");
        }
        
    }
}
