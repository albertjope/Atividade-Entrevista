using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DAL
{
    internal class AcessoDados
    {
        private string stringDeConexao
        {
            get
            {
                ConnectionStringSettings conn = System.Configuration.ConfigurationManager.ConnectionStrings["BancoDeDados"];
                if (conn != null)
                    return conn.ConnectionString;
                else
                    return string.Empty;
            }
        }

        internal long Executar(string NomeProcedure, object Obj, bool IgnorarID)
        {
            long ret = 0;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(stringDeConexao);
            comando.Connection = conexao;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = NomeProcedure;

            DefineParametrosPorObjeto(comando, Obj, IgnorarID);

            conexao.Open();
            try
            {
                ret = comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
            return ret;
        }

        internal long Executar(string NomeProcedure, List<SqlParameter> parametros)
        {
            long ret = 0;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(stringDeConexao);
            comando.Connection = conexao;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = NomeProcedure;

            foreach (var item in parametros)
                comando.Parameters.Add(item);

            conexao.Open();
            try
            {
                ret = comando.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
            return ret;
        }

        private void DefineParametrosPorObjeto(SqlCommand comando, object obj, bool IgnorarID)
        {
            SqlParameter item;

            foreach (var prop in obj.GetType().GetProperties())
            {
                if ((!IgnorarID && prop.Name.ToUpper() == "ID") || prop.Name.ToUpper() != "ID")
                {
                    item = new System.Data.SqlClient.SqlParameter(prop.Name, prop.GetValue(obj));
                    comando.Parameters.Add(item);
                }
            }
        }

        internal DataSet Consultar(string NomeProcedure, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(stringDeConexao);

            comando.Connection = conexao;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = NomeProcedure;
            foreach (var item in parametros)
                comando.Parameters.Add(item);

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            conexao.Open();

            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                conexao.Close();
            }
            finally
            {
                conexao.Close();
            }

            return ds;
        }

    }
}
