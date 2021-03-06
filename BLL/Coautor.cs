using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace BLL
{
    public class Coautor : DTO_Coautor
    {
        public void Fpu_Insert(DTO_Coautor dto_coautor)
        {
            string str_Command = $"INSERT INTO {DTB_Tabela.Coautor} (ID_Artigo, Nome, Email) VALUES (@id_artigo, @nome, @email)";
            if (!(dto_coautor is null))
                Fpr_SQL_Metodo(dto_coautor, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_coautor));
        }
        private void Fpr_SQL_Metodo(DTO_Coautor dto_coautor, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    _ = sqlCommand.Parameters.AddWithValue("@id_artigo", dto_coautor.int_ID_Artigo);
                    _ = sqlCommand.Parameters.AddWithValue("@nome", dto_coautor.str_Nome);
                    _ = sqlCommand.Parameters.AddWithValue("@email", dto_coautor.str_Email);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
