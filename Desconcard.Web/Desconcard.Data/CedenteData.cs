using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconcard.Data
{
   public class CedenteData
    {
        string conex = Configuration.DBConection;


        public DataSet recContaCentente()
        {
            var connString = conex;
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            MySqlDataAdapter boletos = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Sel_Cedente";

                boletos.SelectCommand = command;
                boletos.Fill(ds);

                return ds;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public string DigitoAgencia = "";
        public string OperacaoConta = "";
        public string Conta = "";
        public string DigitoConta = "";
        public string CarteiraPadrao;
        public string Codigo;
        public string CodigoDV;
        public EnderecoData endereco;
        public int Cd_Banco = 104;
    }
}
