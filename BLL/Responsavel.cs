using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace BLL
{
    public class Responsavel : DTO_Responsavel
    {
        public void Fpu_Insert(DTO_Responsavel dto_responsavel)
        {
            string str_Command = $"INSERT INTO {DTB_Tabela.Responsavel} (Nome, Email) VALUES (@nome, @email)";
            if (!(dto_responsavel is null))
                Fpr_SQL_Metodo(dto_responsavel, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_responsavel));
        }
        public void Fpu_Update(DTO_Responsavel dto_responsavel)
        {
            string str_Command = $"UPDATE {DTB_Tabela.Responsavel} SET Nome = @nome, Email = @email WHERE ID = {dto_responsavel.int_ID}";
            if (!(dto_responsavel is null))
                Fpr_SQL_Seletivo(dto_responsavel, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_responsavel));
        }
        public void Fpu_Delete(DTO_Responsavel dto_responsavel)
        {
            string str_Command = $"DELETE {DTB_Tabela.Responsavel} WHERE ID = {dto_responsavel.int_ID}";
            if (!(dto_responsavel is null))
                Fpr_SQL_Seletivo(dto_responsavel, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_responsavel));
        }
        private void Fpr_SQL_Metodo(DTO_Responsavel dto_responsavel, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    _ = sqlCommand.Parameters.AddWithValue("@nome", dto_responsavel.str_Nome);
                    _ = sqlCommand.Parameters.AddWithValue("@email", dto_responsavel.str_Email);


                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        private void Fpr_SQL_Seletivo(DTO_Responsavel dto_responsavel, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (!string.IsNullOrWhiteSpace(dto_responsavel.str_Nome))
                        _ = sqlCommand.Parameters.AddWithValue("@nome", dto_responsavel.str_Nome);
                    if (dto_responsavel.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_responsavel.int_ID);
                    if (!string.IsNullOrWhiteSpace(dto_responsavel.str_Email))
                        _ = sqlCommand.Parameters.AddWithValue("@email", dto_responsavel.str_Email);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
