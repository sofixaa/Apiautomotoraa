using Apiautomotora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Apiautomotora.Azure
{
    public class AutomotoraAzure
    {

        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso1;Trusted_Connection=true";
        private static List<Automotora> automotoras;

        public static List<Automotora> ObtenerAutomotora()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableAutomotora = retornoDeAutomotoraSQL(connection);
                return LlenadoAutomotora(dataTableAutomotora);
            }
        }

        public static int ObtenerAutomotoraPorId(int idAutomotora)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "SELECT * FROM automotora WHERE idAutomotora = @idAutomotora";
                sqlCommand.Parameters.AddWithValue("@idAutomotora", idAutomotora);

                connection.Open();
                var dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                try 
                    
                {
                    foreach(DataRow row in dt.Rows)
                       
                    {
                        Automotora automotora = new Automotora();
                        automotora.idAutomotora = int.Parse(row["idAutomotora"].ToString());
                        automotora.nomautomotora = row["nomautomotora"].ToString();
                        automotora.direccionauto = row["direccionauto"].ToString();
                        //return automotora 1;
                        

                    }
                    return 1;
                }
                catch
                {
                    return 0; 
                }
            }

        }

        public static int AgregarAutomotora(Automotora automotora)
        {
            int resultado;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO automotora (idAutomotora, nomautomotora, direccionauto) VALUES (@idAutomotora, @nomautomotora, @direccionauto)";
                sqlCommand.Parameters.AddWithValue("@idAutomotora", automotora.idAutomotora);
                sqlCommand.Parameters.AddWithValue("@nomautomotora", automotora.nomautomotora);
                sqlCommand.Parameters.AddWithValue("@direccionauto", automotora.direccionauto);
                
                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
            
        }

        public static int EliminarAutomotoraPorNombre(string nomautomotora)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "DELETE FROM automotora WHERE nomautomotora = @nomautomotora";
                sqlCommand.Parameters.AddWithValue("@nomautomotora", nomautomotora);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        private static List<Automotora> LlenadoAutomotora(DataTable dataTable)
        {
            automotoras = new List<Automotora>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Automotora automotora = new Automotora();
                automotora.idAutomotora = int.Parse(dataTable.Rows[0]["idAutomotora"].ToString());
                automotora.nomautomotora = dataTable.Rows[0]["nomautomotora"].ToString();
                automotora.direccionauto = dataTable.Rows[0]["direccionauto"].ToString();
                automotoras.Add(automotora);
            }
            return automotoras;
        }

        public static int modificarAutomotora(Automotora automotora)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "UPDATE AUTOMOTORA SET nomautomotora = @nomautomotora WHERE idAutomotora = @idAutomotora";
                command.Parameters.AddWithValue("@idAutomotora", automotora.idAutomotora );
                command.Parameters.AddWithValue("@nomautomotora", automotora.nomautomotora);

                try
                {
                    connection.Open();
                    var resultado = command.ExecuteNonQuery();
                    connection.Close();
                    return 1;
                }
                catch
                {
                    return 0;

                }
            }
          

            
        }

        private static DataTable retornoDeAutomotoraSQL(SqlConnection connection)
        {
            var dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "SELECT * FROM automotora";
            connection.Open();
            var dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
    

