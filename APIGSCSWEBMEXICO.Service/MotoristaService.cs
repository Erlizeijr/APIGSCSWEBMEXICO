using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIGSCSWEBMEXICO.Models;
using APIGSCSWEBMEXICO.Service.Interfaces;
using APIGSCSWEBMEXICO.Service.DB;
using System.Data;

namespace APIGSCSWEBMEXICO.Service
{
    public class MotoristaService : IMotoristaService

    {
        private SqlCommand cmd = new SqlCommand();
        private Connection cn = new Connection();

        public async Task<Models.Motoristas> GetMotoristaById(int id, string nome)
        {
            try
            {
                string newId = id.ToString();
                if (id == 0)
                {
                    newId = "null";
                }
                string newName = nome;
                if (nome == null || nome == "")
                {
                    newName = "null";
                }

                string sqlQuery = "EXEC Stpprv_AplMOTORISTA_Selecionar " + newId + ","+newName+",null,null,null,null,null,null";

                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar();
                cmd.ExecuteReader();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaMotorista = new DataTable();
                da.Fill(TabelaMotorista);

                var listMotorista = new List<Models.Motorista>();

                foreach (DataRow dataRow in TabelaMotorista.Rows)

                {


                    var mot = new Models.MotoristaModel();
                    mot.IdMotorista = int.Parse(dataRow["CodMotorista"].ToString());
                    mot.Nome = dataRow["Nome"].ToString();
                    mot.Cpf = dataRow["CPF"].ToString();
                    mot.Ativo = Convert.ToBoolean(int.Parse(dataRow["Ativo"].ToString()));
                    mot.StatusMotorista = dataRow["CodStatus"].ToString();
                    mot.DataCadastro = dataRow["DataRegistro"].ToString();
                    var motoras = new Models.Motorista()
                    {
                        Driver = mot
                    };
                    listMotorista.Add(motoras);
                }
                var listMotoristas = new Models.Motoristas
                {
                    Drivers = listMotorista
                };




                return listMotoristas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

   
}
