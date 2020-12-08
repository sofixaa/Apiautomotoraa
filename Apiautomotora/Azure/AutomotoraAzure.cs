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

        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso;Trusted_Connection=true";
        private static List<Automotora> automotoras;

        public static List<Automotora> ObtenerAutomotora()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableAutomotora = retornoDeAutomotoraSQL(connection);
                return LlenadoAutomotora(dataTableAutomotora);
            }
        }

        public static Automotora ObtenerAutomotoraPorId(int idAutomotora)
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = $"SELECT * FROM automotora WHERE idAutomotora = {idAutomotora}";

                connection.Open();
                var dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    Automotora automotora = new Automotora();
                    automotora.idAutomotora = int.Parse(dataTable.Rows[0]["idAutomotora"].ToString());
                    automotora.nomautomotora = dataTable.Rows[0]["nomautomotora"].ToString();
                    automotora.direccionauto = dataTable.Rows[0]["direccion"].ToString();
                    return automotora;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int AgregarAutomotora(Automotora automotora)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO automotora (idAutomotora, nomautomotora, direccionauto) VALUES (@idAutomotora, @nomautomotora, @direccionauto)";
                sqlCommand.Parameters.AddWithValue("@idAutomotora", automotora.idAutomotora);
                sqlCommand.Parameters.AddWithValue("@nomSede", automotora.nomautomotora);
                sqlCommand.Parameters.AddWithValue("@direccionauto", automotora.direccionauto);

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
                automotora.direccionauto = dataTable.Rows[0]["direccion"].ToString();
                automotoras.Add(automotora);
            }
            return automotoras;
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
    

