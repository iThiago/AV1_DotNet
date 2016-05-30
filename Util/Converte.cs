using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Converte
    {
       

        public static T ConvertToT<T>(Produto t)
        {
            return (T)Convert.ChangeType(t, typeof(T));
        }

        public static T ConvertToT<T>(T t)
        {
            return (T)Convert.ChangeType(t, typeof(T));
        }

        public static Cliente ConvertToCliente<T>(T t)
        {
            return (Cliente)Convert.ChangeType(t, typeof(Cliente));
        }

        public static T ConvertToT<T>(Cliente t)
        {
            return (T)Convert.ChangeType(t, typeof(T));
        }

        public static T ConvertToListTClientes<T>(List<Cliente> t)
        {
            return (T)Convert.ChangeType(t, typeof(T));
        }


        public static Produto ConvertToProduto<T>(T t)
        {
            return (Produto)Convert.ChangeType(t, typeof(Produto));
        }
        

        public static T ConvertToListTProdutos<T>(List<Produto> t)
        {
            return (T)Convert.ChangeType(t, typeof(T));
        }


    }
}
