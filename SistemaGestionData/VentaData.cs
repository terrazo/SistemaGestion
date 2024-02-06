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
    public static class VentaData
    {

        public static List<Venta> ObtenerVenta(int id)
        {
            List<Venta> list = new List<Venta>();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "SELECT * FROM Venta where id = @id ";

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
                                var v = new Venta();

                                v.Id = Convert.ToInt32(reader["id"]);

                                v.Comentarios = reader["Comentarios"].ToString();
                                v.IdUsuario = Convert.ToInt32(reader["idUsuario"]);

                                list.Add(v);

                            }
                        }
                    }
                }
            }
            return list;
        }


        public static List<Venta> ListarVentas()
        {
            List<Venta> list = new List<Venta>();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "SELECT * FROM Venta";

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
                                var v = new Venta();
                                v.Id = Convert.ToInt32(reader["id"]);

                                v.Comentarios = reader["Comentarios"].ToString();
                                v.IdUsuario = Convert.ToInt32(reader["idUsuario"]);

                                list.Add(v);

                            }
                        }
                    }


                }
            }
            return list;
        }

        public static void CrearVenta(Venta v)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "INSERT INTO Venta (Comentarios,IdUsuario) VALUES(@Comentarios,@IdUsuario)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = v.Comentarios });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = v.IdUsuario });
                }
                connection.Close();
            }
        }




        public static void ModificarVenta(Venta v)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = v.Id });

                    command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = v.Comentarios });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = v.IdUsuario });
                }
                connection.Close();
            }
        }

        public static void EliminarVenta(Venta v)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=SistemaGestion;Trusted_Connection=True;";
            string query = "DELETE from Venta WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = v.Id });
                }
                connection.Close();
            }

        }



















    }
}
