using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconcard.Data
{
    public class UsuarioData
    {

        string conex = Configuration.DBConection;
        bool login = false;

        public bool beLogin(string desc_email_usuario, string desc_Senha)
        {

            var connString = conex;
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            MySqlDataAdapter boletos = new MySqlDataAdapter();


            try
            {
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Login_Usuario";
                command.Parameters.AddWithValue("Ds_Email", desc_email_usuario.ToString());
                command.Parameters.AddWithValue("Ds_Senha", desc_Senha.ToString());

                boletos.SelectCommand = command;

                MySqlDataReader dr;

                dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    login = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar boleto " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return login;
        }
    }
}
