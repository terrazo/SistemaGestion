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

        public static  ProductoVendido  ObtenerProductoVendido(int id)
        {
             ProductoVendido pv = new  ProductoVendido();

            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
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
 
                                pv.Id = Convert.ToInt32(reader["id"]);
                                pv.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                pv.IdProducto = Convert.ToInt32(reader["idProducto"]);
                                pv.IdVenta = Convert.ToInt32(reader["IdVenta"]);
 
                            }
                        }
                    }


                }
            }
            return pv;
        }


        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> list = new List<ProductoVendido>();

            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
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
                                producto.Stock = (int)Convert.ToDecimal(reader["Stock"]);
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
            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "INSERT INTO PRODUCTOVENDIDO (Stock,IdProducto, IdVenta) VALUES(@Stock,@IdProducto,@IdVenta)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int) { Value = producto.IdProducto });
                    command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.Int) { Value = producto.IdVenta });

                    command.ExecuteNonQuery();

                }
                //connection.Close(); Al usar "using" en los metodos hace que se cierre solo la conexion, por lo que el connection.Close() No seria necesario
            }
        }




        public static void ModificarProductoVendido(ProductoVendido producto)
        {
            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
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

                    command.ExecuteNonQuery();

                }
                //connection.Close(); Al usar "using" en los metodos hace que se cierre solo la conexion, por lo que el connection.Close() No seria necesario
            }
        }

        public static void EliminarProductoVendido(ProductoVendido producto)
        {
            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "DELETE from PRODUCTOVENDIDO WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });

                    command.ExecuteNonQuery();

                }
                //connection.Close(); Al usar "using" en los metodos hace que se cierre solo la conexion, por lo que el connection.Close() No seria necesario
            }

        }



















    }
}
