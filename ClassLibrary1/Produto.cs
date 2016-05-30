using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Estoque { get; set; }
        [Range(0.01, 99999.99,
             ErrorMessage = "O Preço de Venda deve estar entre " +
                            "0,00 e 99999,99.")]
        public decimal Preco { get; set; }


    }
}
