using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Models
{
    public class UnidadeModel
    {
        public int CodUnidade { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        public string StatusUnidade { get; set; }
        public string DataCadastro { get; set; }

    }

    public class Unidade
    {
        public UnidadeModel Unit { get; set; }
    }

    public class Unidades
    {
        public List<Unidade> Units { get; set; }
    }
}
