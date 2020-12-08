using Apiautomotora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Apiautomotora.Azure
{
    public class ContratoAzure
    {
        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso;Trusted_Connection=true";
        private static List<Contrato> contratos;
        public static List<Contrato> ObtenerContratos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableContrato = retornoDeContratosSQL(connection);
                return LlenadoContratos(dataTableContrato);
            }
        }

        public static Contrato ObtenerContratosPorId(int idcontrato)
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = $"SELECT * FROM contrato WHERE idcontrato = {idcontrato}";

                connection.Open();
                var dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    Contrato contrato = new Contrato();
                    contrato.idcontrato = int.Parse(dataTable.Rows[0]["idcontrato"].ToString());
                    contrato.rutcliente = dataTable.Rows[0]["rutcliente"].ToString();
                    contrato.tipocontrato = dataTable.Rows[0]["tipocontrato"].ToString();
                    contrato.datoauto = dataTable.Rows[0]["idSede"].ToString();
                    contrato.fecontrato = dataTable.Rows[0]["fecontrato"].ToString();
                    contratos.Add(contrato);

                    return contrato;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int AgregarContrato(Contrato contrato)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO contrato (idcontrato, rutcliente, datoauto, fecontrato, tipocontrato) VALUES (@idcontrato, @rutcliente, @datoauto, @fecontrato, @tipocontrato)";
                sqlCommand.Parameters.AddWithValue("@idcontrato", contrato.idcontrato);
                sqlCommand.Parameters.AddWithValue("@rutcliente", contrato.rutcliente);
                sqlCommand.Parameters.AddWithValue("@datoauto", contrato.datoauto);
                sqlCommand.Parameters.AddWithValue("@fecontrato", contrato.fecontrato);
                sqlCommand.Parameters.AddWithValue("@tipocontrato", contrato.tipocontrato);
                

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

        public static int EliminarContratoPorId(int idcontrato)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "DELETE FROM contrato WHERE idcontrato = @idcontrato";
                sqlCommand.Parameters.AddWithValue("@idcontrato", idcontrato);

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

        private static List<Contrato> LlenadoContratos(DataTable dataTable)
        {
            contratos = new List<Contrato>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Contrato contrato = new Contrato();
                contrato.idcontrato = int.Parse(dataTable.Rows[0]["idcontrato"].ToString());
                contrato.rutcliente = dataTable.Rows[0]["rutcliente"].ToString();
                contrato.tipocontrato = dataTable.Rows[0]["tipocontrato"].ToString();
                contrato.datoauto = dataTable.Rows[0]["idSede"].ToString();
                contrato.fecontrato = dataTable.Rows[0]["fecontrato"].ToString();
                contratos.Add(contrato);
            }
            return contratos;
        }

        private static DataTable retornoDeContratosSQL(SqlConnection connection)
        {
            var dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "SELECT * FROM contrato";
            connection.Open();
            var DataAdapter = new SqlDataAdapter(sqlCommand);
            DataAdapter.Fill(dataTable);

            return dataTable;

        }
    }
}
    

