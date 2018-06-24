using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Desconcard.Data
{
   public class BoletosData
    {
        public int ControleBoleto;
        string conex = Configuration.DBConection;


        public DataSet recuperarValorBoletoPorusuario(int cod)
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
                command.CommandText = "Sp_Sel_Valor_Boleto_Socio";
                command.Parameters.AddWithValue("ID_Socio", cod);

                boletos.SelectCommand = command;
                boletos.Fill(ds);

                //MySqlDataReader boleto = command.ExecuteReader();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar boleto " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return ds;
        } 

        public int NumeroBoletoControleData(int Cliente)
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
                command.CommandText = "Sp_Sel_Valor_Boleto_Socio";

                boletos.SelectCommand = command;
                boletos.Fill(ds);

                //MySqlDataReader boleto = command.ExecuteReader();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar boleto " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return ControleBoleto;

        }

    }
}
