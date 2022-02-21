using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Service.Interfaces
{
    public interface IUnidadeService
    {
        public Task<Models.Unidades> GetUnidadeId(int id);
    }
}
