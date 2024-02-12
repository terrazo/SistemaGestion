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
    public static class ProductoData
    {
  
        public static Producto  ObtenerProducto(int id)
        {
             Producto  p = new Producto();

            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "SELECT * FROM Producto where id = @id ";

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
 
                                p.Id = Convert.ToInt32(reader["id"]);
                                p.Descripcion = reader["Descripciones"].ToString();
                                p.Costo = (double)Convert.ToDecimal(reader["Costo"]);
                                p.PrecioVenta = (double)Convert.ToDecimal(reader["PrecioVenta"]);
                                p.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                p.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
 
                            }
                        }
                    }


                }
            }
            return p;
        }


        public static List<Producto> ListarProductos()
        {
            List<Producto> list = new List<Producto>();

            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "SELECT * FROM Producto";

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
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(reader["id"]);
                                producto.Descripcion = reader["Descripciones"].ToString();
                                producto.Costo = (double)Convert.ToDecimal(reader["Costo"]);
                                producto.PrecioVenta = (double)Convert.ToDecimal(reader["PrecioVenta"]);
                                producto.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(reader["idUsuario"]);

                                list.Add(producto);

                            }
                        }
                    }


                }
            }
            return list;
        }

        public static void CrearProducto(Producto producto)
        {
            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "INSERT INTO PRODUCTO (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES(@Descripcion,@Costo,@PrecioVenta,@Stock,@IdUsuario)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value=producto.Descripcion});
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario });

                    command.ExecuteNonQuery();

                }
                //connection.Close(); Al usar "using" en los metodos hace que se cierre solo la conexion, por lo que el connection.Close() No seria necesario
            }
        }




        public static void ModificarProducto(Producto producto)
        {
            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "UPDATE PRODUCTO SET Descripciones = @Descripcion, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
                    command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario });

                    command.ExecuteNonQuery();

                }
                //connection.Close(); Al usar "using" en los metodos hace que se cierre solo la conexion, por lo que el connection.Close() No seria necesario
            }
        }

        public static void EliminarProducto(Producto producto)
        {
            string connectionString = @"Server=.;Database=coderhouse;Trusted_Connection=True;";
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;";
            string query = "DELETE from PRODUCTO WHERE Id =@Id";

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
