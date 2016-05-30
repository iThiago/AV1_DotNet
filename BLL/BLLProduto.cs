//using DAL;
//using Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL
//{
//    public class BLLProduto : ICrud
//    {
//        DALProduto dalProduto = new DALProduto();
//        public void Atualizar<T>(T t)
//        {
//            dalProduto.Atualizar<T>(t);
//        }

//        public void Deletar<T>(T t)
//        {
//            dalProduto.Deletar<T>(t);
//        }

//        public int Inserir<T>(T t)
//        {
//            return dalProduto.Inserir<T>(t);
//        }

//        public List<T> Listar<T>()
//        {
//            return dalProduto.Listar<T>();
//        }

//        public T ObterPorId<T>(int id)
//        {
//            return dalProduto.ObterPorId<T>(id);
//        }
//    }
//}
