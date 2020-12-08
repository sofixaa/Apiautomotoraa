using Apiautomotora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Apiautomotora.Azure
{
    public class AdministradorAzure
    {
        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso;Trusted_Connection=true";

        private static List<Administrador> administradores;

        public static List<Administrador> ObtenerAdministradores()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTablesAdministradores = retornoDeAdministradoresSQL(connection);
                return LlenadoAdministradores (dataTablesAdministradores);
            }
        }

        public static Administrador ObtenerAdministradoresPorId(int idadmi)
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = $"SELECT * FROM administrador WHERE idadmi = {idadmi}";

                connection.Open();
                var dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    Administrador administrador = new Administrador();
                    administrador.idadmi= int.Parse(dataTable.Rows[0]["idadmi"].ToString());
                    administrador.nombreadmi= dataTable.Rows[0]["nombreadmi"].ToString();
                    administrador.rutadmi = dataTable.Rows[0]["rutadmi"].ToString();
                    return administrador;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int AgregarAdministrador(Administrador administrador)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO cargo (idadmi, nombreadmi, rutadmi) VALUES (@idadmi, @nombreadmi, @rutadmi)";
                sqlCommand.Parameters.AddWithValue("@idadmi", administrador.idadmi);
                sqlCommand.Parameters.AddWithValue("@nombreadmi", administrador.nombreadmi);
                sqlCommand.Parameters.AddWithValue("@rutadmi", administrador.nombreadmi);


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

        public static int EliminarAdministradorPorNombre(string nombreadmi)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "DELETE FROM administrador WHERE nombreadmi = @nombreadmi";
                sqlCommand.Parameters.AddWithValue("@nombreadmi", nombreadmi);

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
                return resultado;
            }
        }

        private static List<Administrador> LlenadoAdministradores(DataTable dataTable)
        {
            administradores = new List<Administrador>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Administradores administrador = new Administrador();
                administrador.idadmi = int.Parse(dataTable.Rows[0]["idadmi"].ToString());
                administrador.nombreadmi = dataTable.Rows[0]["nombreadmi"].ToString();
                administrador.rutadmi = dataTable.Rows[0]["rutadmi"].ToString();
                administradores.Add(administrador);
            }
            return administradores;
        }

        private static DataTable retornoDeAdministradoresSQL(SqlConnection connection)
        {
            var dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "SELECT * FROM administrador";
            connection.Open();
            var DataAdapter = new SqlDataAdapter(sqlCommand);
            DataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
    

