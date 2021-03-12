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
            string str_Command = $"INSERT INTO {DTB_Tabela.TCC} (ID_Projeto, Titulo, Autor, Situacao) VALUES (@id_projeto, @titulo, @autor, @situacao)";
            if (!(dto_tcc is null))
                Fpr_SQL_Seletivo(dto_tcc, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_tcc));
        }
        public void Fpu_Update(DTO_TCC dto_tcc)
        {
            string str_Command = $"UPDATE {DTB_Tabela.TCC} SET ID_Projeto = @id_projeto, Titulo = @titulo, Autor = @autor, Situacao = @situacao WHERE ID = @id";
            if (!(dto_tcc is null))
                Fpr_SQL_Seletivo(dto_tcc, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_tcc));
        }
        public void Fpu_Delete(DTO_TCC dto_tcc)
        {
            string str_Command = $"DELETE {DTB_Tabela.TCC} WHERE ID = @id";
            if (!(dto_tcc is null))
                Fpr_SQL_Seletivo(dto_tcc, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_tcc));
        }
        private void Fpr_SQL_Seletivo(DTO_TCC dto_tcc, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (dto_tcc.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_tcc.int_ID);
                    if (dto_tcc.int_ID_Projeto > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id_projeto", dto_tcc.int_ID_Projeto);
                    if (!string.IsNullOrWhiteSpace(dto_tcc.str_Titulo))
                        _ = sqlCommand.Parameters.AddWithValue("@titulo", dto_tcc.str_Titulo);
                    if (!string.IsNullOrWhiteSpace(dto_tcc.str_Situacao))
                        _ = sqlCommand.Parameters.AddWithValue("@situacao", dto_tcc.str_Situacao);
                    if (!string.IsNullOrWhiteSpace(dto_tcc.str_Autor))
                        _ = sqlCommand.Parameters.AddWithValue("@autor", dto_tcc.str_Autor);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
