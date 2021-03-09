using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace BLL
{
    public class Artigo : DTO_Artigo
    {
        public void Fpu_Insert(DTO_Artigo dto_artigo)
        {
            string str_Command = $"INSERT INTO {DTB_Tabela.Artigo} ( ID_Projeto, Titulo, Natureza, Autor_Principal, Email) VALUES (@id_projeto, @titulo, @natureza, @autor, @email_autor)";
            if (!(dto_artigo is null))
                Fpr_SQL_Metodo(dto_artigo, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_artigo));
        }
        public void Fpu_Update(DTO_Artigo dto_artigo)
        {
            string str_Command = $"UPDATE {DTB_Tabela.Artigo} SET Titulo = @titulo, Natureza = @natureza, Autor_Principal = @autor, Email = @email_autor WHERE ID = @id";
            if (!(dto_artigo is null))
                Fpr_SQL_Metodo(dto_artigo, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_artigo));
        }
        public void Fpu_Delete(DTO_Artigo dto_artigo)
        {
            string str_Command = $"DELETE {DTB_Tabela.Artigo} WHERE ID = @id";
            if (!(dto_artigo is null))
                Fpr_SQL_Seletivo(dto_artigo, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_artigo));
        }
        private void Fpr_SQL_Metodo(DTO_Artigo dto_artigo, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (dto_artigo.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_artigo.int_ID);
                    _ = sqlCommand.Parameters.AddWithValue("@id_projeto", dto_artigo.int_ID_Projeto);
                    _ = sqlCommand.Parameters.AddWithValue("@titulo", dto_artigo.str_Titulo);
                    _ = sqlCommand.Parameters.AddWithValue("@natureza", dto_artigo.str_Natureza);
                    _ = sqlCommand.Parameters.AddWithValue("@autor", dto_artigo.str_Autor);
                    _ = sqlCommand.Parameters.AddWithValue("@email_autor", dto_artigo.str_Email_Autor);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        private void Fpr_SQL_Seletivo(DTO_Artigo dto_artigo, string str_Command)
        {
            using (SqlConnection sqlConnection = new DTO.Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (dto_artigo.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_artigo.int_ID);
                    if (dto_artigo.int_ID_Projeto > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id_projeto", dto_artigo.int_ID_Projeto);
                    if (!string.IsNullOrWhiteSpace(dto_artigo.str_Titulo))
                        _ = sqlCommand.Parameters.AddWithValue("@titulo", dto_artigo.str_Titulo);
                    if (!string.IsNullOrWhiteSpace(dto_artigo.str_Natureza))
                        _ = sqlCommand.Parameters.AddWithValue("@natureza", dto_artigo.str_Natureza);
                    if (!string.IsNullOrWhiteSpace(dto_artigo.str_Autor))
                        _ = sqlCommand.Parameters.AddWithValue("@autor", dto_artigo.str_Autor);
                    if (!string.IsNullOrWhiteSpace(dto_artigo.str_Email_Autor))
                        _ = sqlCommand.Parameters.AddWithValue("@email_autor", dto_artigo.str_Email_Autor);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

    }
}
