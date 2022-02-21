using APIGSCSWEBMEXICO.Models;
using APIGSCSWEBMEXICO.Service.DB;
using APIGSCSWEBMEXICO.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGSCSWEBMEXICO.Service
{
    public class TransportadoraService : ITransportadoraService  
    {
        private SqlCommand cmd = new SqlCommand();
        private Connection cn = new Connection();
        public async Task<Transportadoras> GetTransportadoraById(int id)
        {
            try
            {

                string sqlQuery = "SELECT TOP 10 * FROM Transportadora  ";

                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar();
                cmd.ExecuteReader();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaTransportadora = new DataTable();
                da.Fill(TabelaTransportadora);

                var listTransportadora = new List<Models.Transportadora>();

                foreach (DataRow dataRow in TabelaTransportadora.Rows)
                {
                    var transp = new Models.TransportadoraModel();
                    transp.IdTransportadora = int.Parse(dataRow["CodTransportadora"].ToString());
                    transp.CNPJ = dataRow["CNPJ"].ToString();
                    transp.DscTransportadora = dataRow["DscTransportadora"].ToString();
                    transp.Ativo = Convert.ToBoolean(int.Parse(dataRow["Ativo"].ToString()));
                    transp.StatusTransportadora = dataRow["StatusTransportadora"].ToString();
                    transp.DataCadastro = dataRow["DataRegistro"].ToString();
                    var transports = new Models.Transportadora
                    {
                        Shipping = transp
                    };
                    listTransportadora.Add(transports);
                }
                var listTransportadoras = new Models.Transportadoras
                {
                    Shippings = listTransportadora
                };
                return listTransportadoras;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

    

