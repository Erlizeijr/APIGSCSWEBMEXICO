using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Service.Interfaces
{
    public interface ITransportadoraService
    {
        public Task<Models.Transportadoras> GetTransportadoraById(int id);

    }
}
