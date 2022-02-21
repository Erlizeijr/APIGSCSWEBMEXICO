using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Service.Interfaces
{
    public interface IMotoristaService
    {
        public Task<Models.Motoristas> GetMotoristaById(int id, string nome);
    }

    public interface IInsertMotoristaService
    {
        public string PostMotorista(string nome, string cpf, string telefone, bool ativo, string CodPais, string Fingerprint, string Signature, string Driver, string DriverDate);
    }
}
