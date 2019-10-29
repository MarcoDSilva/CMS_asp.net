using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjW.Models;
using ProjW.DAL;
using System.Data.SqlClient;

namespace ProjW.MyUtil
{
    public class TarefasFuncs 
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas(); //db pointer

        /// <summary>
        /// retorna o id do cliente, se este existe
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public int GetCliente(string nome){
            return 0;
        }

        /// <summary>
        /// retorna uma string com a saudação para o utilizador, consoante a hora do servidor 
        /// </summary>
        /// <returns></returns>
        public string Saudacao() {

            if (DateTime.Now.Hour < 12) {
                return "bom dia";
            }
            else if (DateTime.Now.Hour < 20) {
                return "boa tarde";
            } else {
                return "boa noite";
            }
        }

    }
}