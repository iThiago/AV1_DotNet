using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAL;
using model;

namespace BLL
{
    public class BLLCliente<T> : ICrud<Cliente>
    {

        DALCliente<Cliente> dalCliente = new DALCliente<Cliente>();
        public void Atualizar(Cliente t)
        {
            dalCliente.Atualizar(t);
        }

        public void Deletar(Cliente t)
        {
            dalCliente.Deletar(t);
        }

        public int Inserir(Cliente t)
        {
           return dalCliente.Inserir(t);
        }

        public List<Cliente> Listar()
        {
            return dalCliente.Listar();
        }

        public Cliente ObterPorId(int id)
        {
            return dalCliente.ObterPorId(id);
        }
    }
}
