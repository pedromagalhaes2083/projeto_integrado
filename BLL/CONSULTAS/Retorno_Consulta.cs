using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class Retorno_Consulta
    {
        private static DataTable Fpr_Retornar_DataTable(string sql)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();
                    sqlCommand.CommandText = sql;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                    return dataTable;
                }
            }
        }
        protected static DataTable Fpt_Retornar_DataTable(string sql)
        {
            return Fpr_Retornar_DataTable(sql);
        }
    }
}
