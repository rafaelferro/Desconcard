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
        DataSet ds = new DataSet();


        public DataSet recuperarValorBoletoPorusuario(int cod)
        {
            var connString = conex;
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            MySqlDataAdapter boletos = new MySqlDataAdapter();
  
            try
            {
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Sp_Sel_Valor_Boleto_Socio";
                command.Parameters.AddWithValue("ID_Socio", cod);

                boletos.SelectCommand = command;
                boletos.Fill(ds);


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

        public int NumeroBoletoControleData(int Cliente, decimal valor, int Mes, int Ano)
        {
            var connString = conex;
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            MySqlDataAdapter boletos = new MySqlDataAdapter();
           

            try
            {
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Sp_Insert_Boleto";
                command.Parameters.AddWithValue("ID_Socio", Cliente);
                command.Parameters.AddWithValue("Valor", valor);
                command.Parameters.AddWithValue("Mes", Mes);
                command.Parameters.AddWithValue("Ano", Ano);

                boletos.SelectCommand = command;
                boletos.Fill(ds);


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
