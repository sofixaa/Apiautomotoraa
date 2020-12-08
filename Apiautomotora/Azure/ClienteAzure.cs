using Apiautomotora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Apiautomotora.Azure
{
    public class ClienteAzure
    {

        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso;Trusted_Connection=true";
        private static List<Cliente> clientes;

        public static List<Cliente> ObtenerCliente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableCliente = retornoDeClientesSQL(connection);
                return LlenadoClientes(dataTableCliente);
            }
        }

        public static Cliente ObtenerClientePorRut(string rutcliente)
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = $"SELECT * FROM cliente WHERE rutcliente = '{rutcliente}' ";

                connection.Open();
                var dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    Cliente cliente = new Cliente();
                    cliente.rutcliente = dataTable.Rows[0]["rutcliente"].ToString();
                    cliente.nombrecli = dataTable.Rows[0]["nombrecli"].ToString();
                    cliente.direccioncli = dataTable.Rows[0]["direccioncli"].ToString();
                    cliente.fechanaci = dataTable.Rows[0]["fechanaci"].ToString();
                    cliente.numcel = int.Parse(dataTable.Rows[0]["numcel"].ToString());
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int AgregarCliente(Cliente cliente)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO persona (rutcleinte, nombrecli, direccioncli, fechanaci, numcel) VALUES (@rutcleinte, @nombrecli, @direccioncli, @fechanaci, @numcel)";
                sqlCommand.Parameters.AddWithValue("@rutcliente", cliente.rutcliente);
                sqlCommand.Parameters.AddWithValue("@nombrecli", cliente.nombrecli);
                sqlCommand.Parameters.AddWithValue("@direccioncli", cliente.direccioncli);
                sqlCommand.Parameters.AddWithValue("@fechanaci", cliente.fechanaci);
                sqlCommand.Parameters.AddWithValue("@numcel", cliente.numcel);

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

        public static int EliminarClientePorRut(string rutcliente)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "DELETE FROM cliente WHERE rutcliente = @rutcliente";
                sqlCommand.Parameters.AddWithValue("@rutcliente", rutcliente);

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

        private static List<Cliente> LlenadoClientes(DataTable dataTable)
        {
            clientes = new List<Cliente>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Cliente cliente = new Cliente();
                cliente.rutcliente = dataTable.Rows[i]["rutcliente"].ToString();
                cliente.nombrecli = dataTable.Rows[i]["nombrecli"].ToString();
                cliente.direccioncli = dataTable.Rows[i]["direccioncli"].ToString();
                cliente.fechanaci = dataTable.Rows[i]["fechanaci"].ToString();
                cliente.numcel = int.Parse(dataTable.Rows[0]["numcel"].ToString());
                clientes.Add(cliente);
            }
            return clientes;
        }

        private static DataTable retornoDeClientesSQL(SqlConnection connection)
        {
            var dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "SELECT * FROM cliente";
            connection.Open();
            var DataAdapter = new SqlDataAdapter(sqlCommand);
            DataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
    

