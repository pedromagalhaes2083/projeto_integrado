using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace BLL
{
    public class Usuario : DTO_Usuario
    {
        public void Fpu_Insert(DTO_Usuario dto_usuario)
        {
            string str_Command = $"INSERT INTO {DTB_Tabela.Usuario} (Nome, User_Login, Senha) VALUES (@nome, @login, @senha)";
            if (!(dto_usuario is null))
                Fpr_SQL_Metodo(dto_usuario, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_usuario));
        }
        public void Fpu_Udpate(DTO_Usuario dto_usuario)
        {
            string str_Command = $"UPDATE {DTB_Tabela.Usuario} SET Nome = @nome, User_Login = @login, Senha = @senha WHERE ID = @id";
            if (!(dto_usuario is null))
                Fpr_SQL_Metodo(dto_usuario, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_usuario));
        }
        public void Fpu_Delete(DTO_Usuario dto_usuario)
        {
            string str_Command = $"DELETE {DTB_Tabela.Usuario} WHERE ID = @id";
            if (!(dto_usuario is null))
                Fpr_SQL_Identificador(dto_usuario, str_Command);
            else
                throw new ArgumentNullException(nameof(dto_usuario));
        }
        private void Fpr_SQL_Metodo(DTO_Usuario dto_usuario, string str_Command)
        {
            using (SqlConnection sqlConnection = new Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (dto_usuario.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_usuario.int_ID);
                    _ = sqlCommand.Parameters.AddWithValue("@nome", dto_usuario.str_Nome);
                    _ = sqlCommand.Parameters.AddWithValue("@login", dto_usuario.str_Login);
                    _ = sqlCommand.Parameters.AddWithValue("@senha", dto_usuario.str_Senha);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        private void Fpr_SQL_Identificador(DTO_Usuario dto_usuario, string str_Command)
        {
            using (SqlConnection sqlConnection = new Conexao_SQL().Conectar)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlConnection Connection = sqlCommand.Connection = sqlConnection;
                    Connection.Open();

                    if (dto_usuario.int_ID > 0)
                        _ = sqlCommand.Parameters.AddWithValue("@id", dto_usuario.int_ID);

                    _ = sqlCommand.CommandText = str_Command;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
