using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public int? ProdutoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int? PedidoId { get; set; }

    }
}
