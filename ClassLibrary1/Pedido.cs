using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Pedido
    {
        public int Id { get; set; }
        public String Status { get; set; }
        public DateTime DataPedido { get; set; }
        public virtual List<ItemPedido> ItensPedido { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int? ClienteId { get; set; }

    }
}
