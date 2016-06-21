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
    public class DALProduto<T> : ICrud<Produto>
    {
        private DBContexto db = new DBContexto();
        
        public int Inserir(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();

            return produto.Id;
        }

        public void Atualizar(Produto produto)
        {
            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Deletar(Produto t)
        {
            db.Produtos.Remove(t);
            db.SaveChanges();
        }

        public List<Produto> Listar()
        {
            List<Produto> produtos = db.Produtos.ToList();

            return produtos;
        }

        public Produto ObterPorId(int id)
        {
            Produto produto = db.Produtos.Find(id);

            return produto;
        }
    }
}
