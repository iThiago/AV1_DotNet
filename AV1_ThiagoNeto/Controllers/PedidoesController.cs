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
    public class PedidoesController : Controller
    {
        private BLLPedido<Pedido> bllPedido = new BLLPedido<Pedido>();
        private static List<ItemPedido> listPedidoItem = new List<ItemPedido>();
        // GET: Pedidoes
        public ActionResult Index()
        {
            return View(bllPedido.Listar());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = bllPedido.ObterPorId(id);
            ViewBag.Itens = pedido.ItensPedido;
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {

            ViewBag.Produtos =
                new BLLProduto<Produto>().Listar();

            ViewBag.Clientes = new SelectList(
                new BLLCliente<Cliente>().Listar(),
                "Id", "Nome"
                );

            ViewBag.ItensPedido = listPedidoItem;

            return View();
        }

        public ActionResult AddToCart(int idProduto)
        {

            ViewBag.Produtos =
                new BLLProduto<Produto>().Listar();

            ViewBag.Clientes = new SelectList(
                new BLLCliente<Cliente>().Listar(),
                "Id", "Nome"
                );

            if (listPedidoItem == null)
            {
                listPedidoItem = new List<ItemPedido>();
            }

            ItemPedido item = new ItemPedido();

            var produto = new BLLProduto<Produto>().ObterPorId(idProduto);
            item.ProdutoId = produto.Id;

            item.Produto = produto;

            var achou = false;

            foreach (ItemPedido itemPedido in listPedidoItem)
            {
                if (itemPedido.ProdutoId == item.ProdutoId)
                {
                    itemPedido.Quantidade += 1;
                    achou = true;
                }
            }

            if (!achou)
            {
                item.Quantidade = 1;
                listPedidoItem.Add(item);
            }

            ViewBag.ItensPedido = listPedidoItem;

            return RedirectToAction("Create");

        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,DataPedido,ClienteId")] Pedido pedido)
        {
            try
            {

                pedido.DataPedido = DateTime.Now;
                //pedido.ItensPedido = listPedidoItem;
                pedido.Status = "L";

                int idPedido = bllPedido.Inserir(pedido);
                
                foreach (var itemPedido in listPedidoItem)
                {
                    BLLItemPedido<ItemPedido> bllItemPedido = new BLLItemPedido<ItemPedido>();
                    itemPedido.PedidoId = idPedido;
                    var produto = itemPedido.Produto;
                    itemPedido.Produto = null;
                    bllItemPedido.Inserir(itemPedido);
                    itemPedido.Produto = produto;
                }

                ViewBag.Produtos = new BLLProduto<Produto>().Listar();
                listPedidoItem = null;
                ViewBag.ItensPedido = listPedidoItem;

                ViewBag.Clientes = new SelectList(
                    new BLLCliente<Cliente>().Listar(),
                    "Id", "Nome"
                    );

                ViewBag.Message = "Pedido Efetuado com Sucesso!";

                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pedido);
            }
        }
        [HttpGet]
        public String AddItem(int produtoId, int qtd)
        {
            if (ModelState.IsValid)
            {
                List<ItemPedido> itens = (List<ItemPedido>)Session["ITENS"];

                ItemPedido item = new ItemPedido();

                item.Produto = new BLLProduto<Produto>().ObterPorId(produtoId);

                item.Quantidade = qtd;

                itens.Add(item);

            }

            return "sucess";
        }


        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = bllPedido.ObterPorId(id);
            ViewBag.Itens = pedido.ItensPedido;
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,DataPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                bllPedido.Atualizar(pedido);

                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = bllPedido.ObterPorId(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = bllPedido.ObterPorId(id);
            bllPedido.Deletar(pedido);

            return RedirectToAction("Index");
        }

    }
}
