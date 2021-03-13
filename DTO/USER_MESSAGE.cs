using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class USER_MESSAGE
    {
        public static string Login_Efetuado => "Login efetuado com sucesso.";
        public static string Coautor_Vinculado => "Esse coautor já está vinculado a esse artigo";
        public static string Sucesso => "Sucesso.";
        public static string Modelo_Invalido => "Modelo Inválido.";
        public static string Artigo_Existente => "Esse artigo já esta cadastrado.";
        public static string Coautor_Existente => "Este coautor já esta cadastrado.";
        public static string Projeto_Apagar => "Esse projeto não pode ser apagado.";
        public static string Exclusao_Responsavel => "Esse responsável não pode ser excluído no momento.";
        public static string Exclusao_Artigo => "Esse artigo não pode ser excluído, pois o mesmo possui coautores.";
        public static string Senha_Nao_Coincedem => "As senhas não coincidem";
        public static string Login_Indisponivel => "Esse login se encontra em uso.";
        public static string Credenciais_Invalidas => "Erro, confira suas credenciais.";
        public static string Efetue_Login => "Primeiramente efetue login nesse sistema!";
    }
}
