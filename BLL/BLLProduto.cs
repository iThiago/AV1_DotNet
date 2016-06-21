using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace BLL
{
    public class BLLProduto<T> : ICrud<Produto>
    {
        DALProduto<T> dalProduto = new DALProduto<T>();
        
        public int Inserir(Produto t)
        {
            return dalProduto.Inserir(t);
        }

        public void Atualizar(Produto t)
        {
            dalProduto.Atualizar(t);
        }

        public void Deletar(Produto t)
        {
            dalProduto.Deletar(t);
        }

        public List<Produto> Listar()
        {
            return dalProduto.Listar();
        }

        public Produto ObterPorId(int id)
        {
            return dalProduto.ObterPorId(id);
        }
    }
}
