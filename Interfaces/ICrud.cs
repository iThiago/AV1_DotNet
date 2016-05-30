using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICrud<T>
    {
        int Inserir(T t);
        void Atualizar(T t);
        void Deletar(T t);
        List<T> Listar();
        T ObterPorId(int id);

    }
}
