//using Interfaces;
//using model;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Util;

//namespace DAL
//{
//    public class DALProduto : ICrud
//    {
//        private DBContexto db = new DBContexto();
//        public void Atualizar<T>(T t)
//        {
//            Produto produto = Converte.ConvertToProduto(t);
//            db.Entry(produto).State = EntityState.Modified;
//            db.SaveChanges();
//        }

//        public void Deletar<T>(T t)
//        {
//            Produto produto = Converte.ConvertToProduto(t);
//            db.Produtos.Remove(produto);
//            db.SaveChanges();
//        }

//        public int Inserir<T>(T t)
//        {
//            Produto produto = Converte.ConvertToProduto<T>(t);

//            db.Produtos.Add(produto);
//            db.SaveChanges();

//            return produto.Id;
//        }

//        public List<T> Listar<T>()
//        {
//            List<Produto> produtos = db.Produtos.ToList();

//            return Converte.ConvertToListTProdutos<List<T>>(produtos);
//        }

//        public T ObterPorId<T>(int id)
//        {
//            Produto produto = db.Produtos.Find(id);

//            return Converte.ConvertToT<T>(produto);
//        }

//    }
//}
