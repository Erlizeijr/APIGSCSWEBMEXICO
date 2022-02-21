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
    public class VeiculoService : IVeiculoService
    {
        private SqlCommand cmd = new SqlCommand();
        private Connection cn = new Connection();
        public async Task<Veiculos> GetByPlate(int id)
        {
            try
            {
                string sqlQuery = "SELECT TOP 10 * FROM Veiculo  ";

                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar();
                cmd.ExecuteReader();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaVeiculo = new DataTable();
                da.Fill(TabelaVeiculo);

                var listVeiculo = new List<Models.Veiculo>();


                foreach (DataRow dataRow in TabelaVeiculo.Rows)
                {
                    var veic = new Models.VeiculoModel();
                    veic.IdVeiculo = int.Parse(dataRow["CodVeiculo"].ToString());
                    veic.Tipo = dataRow["Tipo"].ToString();
                    veic.Placa = dataRow["Placa "].ToString();
                    veic.Ativo = Convert.ToBoolean(int.Parse(dataRow["Ativo"].ToString()));
                    veic.DataCadastro = dataRow["DataRegistro"].ToString();
                    var veiculos = new Models.Veiculo
                    {
                        Vehicle = veic
                    };
                    listVeiculo.Add(veiculos);
                }
                var listVeiculos = new Models.Veiculos
                {
                    Vehicles = listVeiculo
                };

                return listVeiculos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
