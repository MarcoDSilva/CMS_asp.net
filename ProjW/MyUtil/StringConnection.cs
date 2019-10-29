using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjW.MyUtil
{
    public class StringConnection
    {
        /// <summary>
        /// Recebe como input uma String Connection, e uma instrução sql
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// 
        private string sConnection = "";

        public DataTable ContaRegistos(string connection, string query)
        {
            //conexao À bd
            SqlConnection sql = new SqlConnection(connection);
            sql.Open();

            //query sql
            SqlCommand sqlCommand = sql.CreateCommand();
            sqlCommand.CommandText = query;

            //dados da bd para uma tabela em memória
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();

            adapter.Fill(table);
            sql.Close();
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getSConnection()
        {
            return this.sConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sconnection"></param>
        public void setSConnection(string sconnection)
        {
            this.sConnection = sconnection;
        }
    }
}