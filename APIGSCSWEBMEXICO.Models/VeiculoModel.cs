using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Models
{
    public class VeiculoModel
    {
        public int IdVeiculo { get; set; }
        public string Tipo { get; set; }
        public string Placa { get; set; }
        public bool Ativo { get; set; }
        public string StatusVeiculo { get; set; }
        public string DataCadastro { get; set; }

    }

    public class Veiculo
    {
        public VeiculoModel Vehicle { get; set; }
    }

    public class Veiculos
    {
        public List<Veiculo> Vehicles { get; set; }
    }
}

