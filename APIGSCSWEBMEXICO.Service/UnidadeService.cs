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
    public class UnidadeService : IUnidadeService
    {
        private SqlCommand cmd = new SqlCommand();
        private Connection cn = new Connection();

        public async Task<Unidades> GetUnidadeId(int id)
        {
            try
            {
                string sqlQuery = "SELECT TOP 10 * FROM Unidade  ";

                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar();
                cmd.ExecuteReader();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaUnidade = new DataTable();
                da.Fill(TabelaUnidade);

                var listUnidade = new List<Models.Unidade>();

                foreach (DataRow dataRow in TabelaUnidade.Rows)
                {
                    var unid = new Models.UnidadeModel();
                    unid.CodUnidade = int.Parse(dataRow["CodUnidade"].ToString());
                    unid.Endereco = dataRow["Endereco"].ToString();
                    unid.CNPJ = dataRow["CNPJ"].ToString();
                    unid.Ativo = Convert.ToBoolean(int.Parse(dataRow["Ativo"].ToString()));
                    unid.StatusUnidade = dataRow["StatusUnidade"].ToString();
                    unid.DataCadastro = dataRow["DataRegistro"].ToString();
                    var unidades = new Models.Unidade
                    {
                        Unit = unid
                    };
                    listUnidade.Add(unidades);
                }
                var listUnidades = new Models.Unidades
                {
                    Units = listUnidade
                };
                return listUnidades;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}

