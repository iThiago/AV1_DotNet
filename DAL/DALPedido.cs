using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using model;

namespace DAL
{
    public class DALPedido<T> : ICrud<Pedido>
    {
        private DBContexto db = new DBContexto();
        public int Inserir(Pedido t)
        {
            db.Pedidos.Add(t);
            db.SaveChanges();

            return t.Id;
        }

        public void Atualizar(Pedido t)
        {
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Deletar(Pedido t)
        {
            var lista = db.ItemPedidos.Where(x => x.Pedido.Id == t.Id).ToList();

            foreach (ItemPedido itemPedido in lista)
            {
                db.ItemPedidos.Remove(itemPedido);
            }

            db.Pedidos.Remove(t);
            db.SaveChanges();
        }

        public List<Pedido> Listar()
        {
            List<Pedido> pedidos = db.Pedidos.ToList();
            foreach (Pedido pedido in pedidos)
            {
                pedido.ItensPedido = db.ItemPedidos.Where(x => x.Pedido.Id == pedido.Id).ToList();
            }
            return pedidos;
        }

        public Pedido ObterPorId(int id)
        {

            Pedido pedido = db.Pedidos.Find(id);
            pedido.ItensPedido = db.ItemPedidos.Where(x => x.Pedido.Id == id).ToList();

            return pedido;
        }
    }
}
