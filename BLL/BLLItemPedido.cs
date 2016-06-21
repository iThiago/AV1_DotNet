using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAL;
using model;
using BLL;

namespace BLL
{
    public class BLLItemPedido<T> : ICrud<ItemPedido>
    {

        DALItemPedido<ItemPedido> dalItemPedido = new DALItemPedido<ItemPedido>();
        public void Atualizar(ItemPedido t)
        {
            dalItemPedido.Atualizar(t);
        }

        public void Deletar(ItemPedido t)
        {
            dalItemPedido.Deletar(t);
        }

        public int Inserir(ItemPedido t)
        {
            return dalItemPedido.Inserir(t);
        }

        public List<ItemPedido> Listar()
        {
            return dalItemPedido.Listar();
        }

        public ItemPedido ObterPorId(int id)
        {
            return dalItemPedido.ObterPorId(id);
        }
    }
}
