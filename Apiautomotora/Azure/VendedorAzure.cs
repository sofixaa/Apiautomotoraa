using Apiautomotora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Apiautomotora.Azure
{
    public class VendedorAzure
    {
        static string connectionString = @"Server=LAPTOP-RSP5ST3A\SQLEXPRESS;Database=apicaso;Trusted_Connection=true";
        private static List<Vendedor> vendedores;
        private static DataTable retornoDeVendedorSQL(SqlConnection connection)
        {
            var dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "SELECT * FROM vendedor";
            connection.Open();
            var DataAdapter = new SqlDataAdapter(sqlCommand);
            DataAdapter.Fill(dataTable);

            return dataTable;
        }
        private static List<Vendedor> LlenadoVendedores(DataTable dataTable)
        {
            vendedores = new List<Vendedor>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Vendedor vendedor = new Vendedor();
                vendedor.idvendedor = int.Parse(dataTable.Rows[i]["idvendedor"].ToString());
                vendedor.nomvendedorven = dataTable.Rows[i]["nomvendedorven"].ToString();
                vendedor.rutvendedor = dataTable.Rows[i]["rutvendedor"].ToString();
                vendedor.direccionven = dataTable.Rows[i]["direccionven"].ToString();
                vendedor.numvendedor = int.Parse(dataTable.Rows[i]["numvendedor"].ToString());
                vendedor.direccionauto = dataTable.Rows[i]["direccionauto"].ToString();
                vendedores.Add(vendedor);
            }
            return vendedores;
        }
        public static int AgregarVendedor(Vendedor vendedor)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "INSERT INTO vendedor (idvendedor, nomvendedorven, rutvendedor, direccionven, numvendedor, direccionauto ) VALUES (@idvendedor, @nomvendedorven, @rutvendedor, @direccionven, @numvendedor, @direccionauto )";
                sqlCommand.Parameters.AddWithValue("@idvendedor", vendedor.idvendedor);
                sqlCommand.Parameters.AddWithValue("@nomvendedorven", vendedor.nomvendedorven);
                sqlCommand.Parameters.AddWithValue("@rutvendedor", vendedor.rutvendedor);
                sqlCommand.Parameters.AddWithValue("@direccionven", vendedor.direccionven);
                sqlCommand.Parameters.AddWithValue("@numvendedor", vendedor.numvendedor);
                sqlCommand.Parameters.AddWithValue("@direccionauto", vendedor.direccionauto);

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
    }
}
