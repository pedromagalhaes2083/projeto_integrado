using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace BLL
{
    public class Projeto : DTO_Projeto
    {
        public void Fpu_Insert(DTO_Projeto dto_projeto)
        {
            string str_Command = $"INSERT INTO {DTB_Tabela.Projeto} (ID_Responsavel, Titulo, Data_Inicio, Data_Final, Situacao) VALUES (@id_responsavel, @titulo, @data_inicio, @data_final, @situacao)";
            if (!(dto_projeto is null))
                Fpr_SQL_Metodo(dto_projeto, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_projeto));
        }
        public void Fpu_Update(DTO_Projeto dto_projeto)
        {
            string str_Command = $"UPDATE {DTB_Tabela.Projeto} SET Titulo = @titulo, Data_Final = @data_Final,  ID_Responsavel = @id_responsavel, Situacao = @situacao WHERE ID = {dto_projeto.int_ID}";
            if (!(dto_projeto is null))
                Fpr_SQL_Seletivo(dto_projeto, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_projeto));
        }
        public void Fpu_Delete(DTO_Projeto dto_projeto)
        {
            string str_Command = $"DELETE {DTB_Tabela.Projeto} WHERE ID = {dto_projeto.int_ID}";
            if (!(dto_projeto is null))
                Fpr_SQL_Seletivo(dto_projeto, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_projeto));
        }
        private void Fpr_SQL_Metodo(DTO_Projeto dto_projeto, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    _ = sqlCommand.Parameters.AddWithValue("@id_responsavel", dto_projeto.int_ID_Responsavel);
                    _ = sqlCommand.Parameters.AddWithValue("@titulo", dto_projeto.str_Titulo);
                    _ = sqlCommand.Parameters.AddWithValue("@data_inicio", dto_projeto.dte_Data_Inicio);
                    _ = sqlCommand.Parameters.AddWithValue("@data_final", dto_projeto.dte_Data_Final);
                    _ = sqlCommand.Parameters.AddWithValue("@situacao", dto_projeto.str_Situacao);


                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        private void Fpr_SQL_Seletivo(DTO_Projeto dto_projeto, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (!string.IsNullOrWhiteSpace(dto_projeto.str_Situacao))
                        _ = sqlCommand.Parameters.AddWithValue("@situacao", dto_projeto.str_Situacao);
                    if (dto_projeto.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_projeto.int_ID);
                    if (dto_projeto.dte_Data_Inicio != null)
                        _ = sqlCommand.Parameters.AddWithValue("@data_inicio", dto_projeto.dte_Data_Inicio);
                    if (dto_projeto.dte_Data_Final != null)
                        _ = sqlCommand.Parameters.AddWithValue("@data_final", dto_projeto.dte_Data_Final);
                    if (!string.IsNullOrWhiteSpace(dto_projeto.str_Titulo))
                        _ = sqlCommand.Parameters.AddWithValue("@titulo", dto_projeto.str_Titulo);
                    if (dto_projeto.int_ID_Responsavel > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id_responsavel", dto_projeto.int_ID_Responsavel);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
