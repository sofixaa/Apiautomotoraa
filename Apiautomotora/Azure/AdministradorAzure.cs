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
        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso1;Trusted_Connection=true";

        private static List<Administrador> administradores;

        public static int ObtenerAdministradores()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT * FROM administrador";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                try
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Administrador administrador = new Administrador();
                        administrador.idadmi = int.Parse(row["idadmi"].ToString());
                        administrador.nombreadmi = row["nombreadmi"].ToString();
                        administrador.rutadmi = row["rutadmi"].ToString();

                    }
                    
                    return 1;
                } 
                catch
                {
                    return 0;
                }

            }
        }

        public static int ObtenerAdministradoresPorId(int idadmi)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "SELECT * FROM administrador WHERE idadmi = @idadmi";
                sqlCommand.Parameters.AddWithValue("@idadmi", idadmi);

                connection.Open();
                var dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                try
                   
                { 
                    foreach (DataRow row in dt.Rows)
                    {
                        Administrador administrador = new Administrador();
                        administrador.idadmi = int.Parse(row["idadmi"].ToString());
                        administrador.nombreadmi = row["nombreadmi"].ToString();
                        administrador.rutadmi = row["rutadmi"].ToString();
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

        public static int modificarAdministrador(Administrador administrador)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "UPDATE ADMINISTRADOR SET nombreadmi = @nombreadmi WHERE idadmi = @idadmi";
                command.Parameters.AddWithValue("@idadmi", administrador.idadmi);
                command.Parameters.AddWithValue("@nombreadmi", administrador.nombreadmi);


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
        public static int AgregarAdministrador(Administrador administrador)
        {
            int resultado;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO administrador (idadmi, nombreadmi, rutadmi) VALUES (@idadmi, @nombreadmi, @rutadmi)";
                sqlCommand.Parameters.AddWithValue("@idadmi", administrador.idadmi);
                sqlCommand.Parameters.AddWithValue("@nombreadmi", administrador.nombreadmi);
                sqlCommand.Parameters.AddWithValue("@rutadmi", administrador.nombreadmi);


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

        public static int EliminarAdministradorPorNombre(string nombreadmi)
        {
            int resultado;

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
                    return 1; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
               
            }
        }

        private static List<Administrador> LlenadoAdministradores(DataTable dataTable)
        {
            administradores = new List<Administrador>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Administrador administrador = new Administrador();
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
    

