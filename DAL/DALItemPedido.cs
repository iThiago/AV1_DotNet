using Interfaces;
using model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DAL
{
    public class DALItemPedido<T> : ICrud<ItemPedido>
    {
        private DBContexto db = new DBContexto();

        public DALItemPedido()
        {
            db = new DBContexto();
        }

        public int Inserir(ItemPedido cliente)
        {
            db.ItemPedidos.Add(cliente);
            db.SaveChanges();

            return cliente.Id;
        }

        public void Atualizar(ItemPedido t)
        {
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Deletar(ItemPedido cliente)
        {
            db.ItemPedidos.Remove(cliente);
            db.SaveChanges();
        }

        public List<ItemPedido> Listar()
        {
            List<ItemPedido> clientes = db.ItemPedidos.ToList();

            return clientes;
        }

        public ItemPedido ObterPorId(int id)
        {
            ItemPedido cliente = db.ItemPedidos.Find(id);

            return cliente;
        }


    }
}
