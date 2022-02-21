using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Models
{
    public class TransportadoraModel
    {
        public int IdTransportadora { get; set; }
        public string DscTransportadora { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        public string StatusTransportadora { get; set; }
        public string DataCadastro { get; set; }

    }

    public class Transportadora
    {
        public TransportadoraModel Shipping { get; set; }
    }

    public class Transportadoras
    {
        public List<Transportadora> Shippings { get; set; }
    }
   
}
