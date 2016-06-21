using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Interfaces;
using model;

namespace BLL
{
    public class BLLPedido<T> : ICrud<Pedido> 
    {

        DALPedido<Pedido> dalPedido = new DALPedido<Pedido>();
        public void Atualizar(Pedido t)
        {
            dalPedido.Atualizar(t);
        }

        public void Deletar(Pedido t)
        {
            dalPedido.Deletar(t);
        }

        public int Inserir(Pedido t)
        {
            return dalPedido.Inserir(t);
        }

        public List<Pedido> Listar()
        {
            return dalPedido.Listar();
        }

        public Pedido ObterPorId(int id)
        {
            return dalPedido.ObterPorId(id);
        }
    }
}
