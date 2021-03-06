using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace BLL
{
    public class TCC : DTO_TCC
    {
        public void Fpu_Insert(DTO_TCC dto_tcc)
        {
            string str_Command = $"INSERT INTO {DTB_Tabela.TCC} (ID_Projeto, Titulo, Nome, Situacao) VALUES (@id_projeto, @titulo, @nome, @situacao)";
            if (!(dto_tcc is null))
                Fpr_SQL_Metodo(dto_tcc, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_tcc));
        }
        private void Fpr_SQL_Metodo(DTO_TCC dto_tcc, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    _ = sqlCommand.Parameters.AddWithValue("@id_projeto", dto_tcc.int_ID_Projeto);
                    _ = sqlCommand.Parameters.AddWithValue("@titulo", dto_tcc.str_Titulo);
                    _ = sqlCommand.Parameters.AddWithValue("@situacao", dto_tcc.str_Situacao);
                    _ = sqlCommand.Parameters.AddWithValue("@nome", dto_tcc.str_Nome);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
