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
    public class InserirMotoristaService : IInsertMotoristaService
    {
        private SqlCommand cmd = new SqlCommand();
        private Connection cn = new Connection();

        public string PostMotorista(string nome, string cpf, string telefone, bool ativo, string CodPais, string Fingerprint, string Signature, string Driver, string DriverDate)
        {
            string newAtivo = "0";
            if (ativo)  newAtivo = "1"; 
            string sqlQuery = "Exec Stpprv_AplMOTORISTA_Gravar null,'" + nome + "'," + cpf + ",'" + telefone + "'," + newAtivo + ",'" + CodPais + "'," + Fingerprint + "," + Signature + "," + Driver + "," +
                "'" + DriverDate + "',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null," +
                "null,null,null,null,null,null,null,null,null,null,null";
            cmd.CommandText = sqlQuery;
            cmd.Connection = cn.Conectar();
            cmd.ExecuteReader();
            cn.Desconectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable TabelaMotorista = new DataTable();
            da.Fill(TabelaMotorista);

            return "Dados inseridos com sucesso";
        }
    }
}
