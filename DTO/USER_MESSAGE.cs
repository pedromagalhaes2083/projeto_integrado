using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class USER_MESSAGE
    {
        public static string Sucesso => "Sucesso.";
        public static string Modelo_Invalido => "Modelo Inválido.";
        public static string Artigo_Existente => "Esse artigo já esta cadastrado.";
        public static string Coautor_Existente => "Este coautor já esta cadastrado.";
        public static string Projeto_Apagar => "Esse projeto não pode ser apagado.";
        public static string Exclusao_Responsavel => "Esse responsável não pode ser excluído no momento.";
        public static string Exclusao_Artigo => "Esse artigo não pode ser excluído, pois o mesmo possui coautores.";
    }
}
