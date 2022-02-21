using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Models
{
    public class MotoristaModel
    {
        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string StatusMotorista { get; set; }
        public string DataCadastro { get; set; }
        public string CodPais { get; set; }
        public int Fingerprint { get; set; }
        public int Signature { get; set; }
        public int driver { get; set; }
        public DateTime DriverDate { get; set; }
        public string DriverNumber { get; set; }
        public DateTime DataRegistro { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int IdRace { get; set; }
        public int IdSex { get; set; }
        public int IdEyeColor { get; set; }
        public int IdHairColor { get; set; }
        public int IdDriverLicense { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string comments { get; set; }
        public string cashierName { get; set; }
        public DateTime birthDate { get; set; }
        public int heightIn { get; set; }
        public DateTime yearmodel { get; set; }
        public string color { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string licenseState { get; set; }
        public string licensePlate { get; set; }
        public int IdStateNation { get; set; }
        public int IdStateCar { get; set; }
    }
    public class Motorista
    {
        public MotoristaModel Driver { get; set; }

    }

    public class Motoristas
    {
        public List<Motorista> Drivers { get; set; }
    }
}
