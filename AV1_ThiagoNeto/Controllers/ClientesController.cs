using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model;
using System.Data.Entity.Validation;
using BLL;

namespace AV1_ThiagoNeto.Controllers
{
    public class ClientesController : Controller
    {
        private BLLCliente<Cliente> bllCliente = new BLLCliente<Cliente>();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(bllCliente.Listar());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = bllCliente.ObterPorId(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Endereco,Telefone")] Cliente cliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    int id = bllCliente.Inserir(cliente);

                    return RedirectToAction("Details/" + id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Propriedade: " + validationError.PropertyName + " Erro: " +
                                       validationError.ErrorMessage);
                    }
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

                return View(cliente);
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = bllCliente.ObterPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Endereco,Telefone")] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bllCliente.Atualizar(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Propriedade: " + validationError.PropertyName + " Erro: " + validationError.ErrorMessage);
                    }
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

                return View(cliente);
            }

        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = bllCliente.ObterPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = bllCliente.ObterPorId(id);
            bllCliente.Deletar(cliente);

            return RedirectToAction("Index");
        }

    }
}
