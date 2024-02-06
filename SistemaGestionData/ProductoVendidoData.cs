using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using SistemaGestionEntities;


namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {

        public static List<ProductoVendido> ObtenerProductoVendido(int id)
        {
            List<ProductoVendido> list = new List<ProductoVendido>();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "SELECT * FROM ProductoVendido where id = @id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = id;

                    command.Parameters.Add(parametro);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var producto = new ProductoVendido();

                                producto.Id = Convert.ToInt32(reader["id"]);
                                producto.Stock = (double)Convert.ToDecimal(reader["Stock"]);
                                producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                                producto.IdVenta = Convert.ToInt32(reader["IdVenta"]);

                                list.Add(producto);

                            }
                        }
                    }


                }
            }
            return list;
        }


        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> list = new List<ProductoVendido>();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "SELECT * FROM ProductoVendido";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var producto = new ProductoVendido();
                                producto.Id = Convert.ToInt32(reader["id"]);
                                producto.Stock = (double)Convert.ToDecimal(reader["Stock"]);
                                producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                                producto.IdVenta = Convert.ToInt32(reader["IdVenta"]);

                                list.Add(producto);

                            }
                        }
                    }
                }
            }
            return list;
        }

        public static void CrearProductoVendido(ProductoVendido producto)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "INSERT INTO PRODUCTOVENDIDO (Stock,IdProducto, IdVenta) VALUES(@Stock,@IdProducto,@IdVenta)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int) { Value = producto.IdProducto });
                    command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.Int) { Value = producto.IdVenta });
                }
                connection.Close();
            }
        }




        public static void ModificarProductoVendido(ProductoVendido producto)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "UPDATE PRODUCTOVENDIDO SET Stock = @Stock, IdProducto = @IdProducto, IdVenta = @IdVenta WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int) { Value = producto.IdProducto });
                    command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.Int) { Value = producto.IdVenta });
                }
                connection.Close();
            }
        }

        public static void EliminarProductoVendido(ProductoVendido producto)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "DELETE from PRODUCTOVENDIDO WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
                }
                connection.Close();
            }

        }



















    }
}
