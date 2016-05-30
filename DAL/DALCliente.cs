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
    public class DALCliente<T> : ICrud<Cliente>
    {
        private DBContexto db = new DBContexto();
      
        public int Inserir(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();

            return cliente.Id;
        }

        public void Atualizar(Cliente t)
        {
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Deletar(Cliente cliente)
        {
            db.Clientes.Remove(cliente);
            db.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = db.Clientes.ToList();

            return clientes;
        }

        public Cliente ObterPorId(int id)
        {
            Cliente cliente = db.Clientes.Find(id);

            return cliente;
        }

        
    }
}
