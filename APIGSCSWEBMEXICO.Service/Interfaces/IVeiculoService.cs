using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Service.Interfaces
{
    public interface IVeiculoService
    {
        public Task<Models.Veiculos> GetByPlate(int id);
    }
}

