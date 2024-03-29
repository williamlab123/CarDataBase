using System;
using MySql.Data.MySqlClient;
using System.Data;
//using Newtonsoft.Json;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

// using Newtonsoft.Json;



namespace CarDataBase
{

    public static class DatabaseHelper
    {

        public static void ConnectToDatabase()
        {

            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados MySQL estabelecida com sucesso.");
                System.Console.WriteLine("Database: " + connection.Database);
                Console.ResetColor();

                System.Console.WriteLine("You're connected!");



                // string sql = "INSERT INTO carros (marca, modelo, potencia) VALUES (@marca, @modelo, @potencia)";
                // MySqlCommand cmd = new MySqlCommand(sql, connection);
                // cmd.Parameters.AddWithValue("@marca", "Tesla");
                // cmd.Parameters.AddWithValue("@modelo", "Model s");
                // cmd.Parameters.AddWithValue("@potencia", "150");

                // int affectedRows = cmd.ExecuteNonQuery();
                // if (affectedRows > 0)
                // {
                //     Console.WriteLine("Informações adicionadas com sucesso.");
                // }
                // else
                // {
                //     Console.WriteLine("Falha ao adicionar informações.");
                // }
                connection.Close();

                connection.Open();


                using (MySqlConnection connect = new MySqlConnection(connectionString))
                {
                    //connection.Open();

                    string tableName = "carros";
                    string query = $"DESCRIBE {tableName}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Colunas da tabela '{0}':", tableName);
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetString(0));
                            }
                        }
                    }
                }

            }



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM carros";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("marca: " + reader["marca"].ToString());
                    Console.WriteLine("modelo: " + reader["modelo"].ToString());
                    Console.WriteLine("potencia: " + reader["potencia"].ToString());
                    Console.WriteLine("peso: " + reader["peso"].ToString());
                    Console.WriteLine("torque: " + reader["torque"].ToString());
                    Console.WriteLine("placa: " + reader["placa"].ToString());
                    Console.WriteLine();
                }
            }
        }

        // class Carro
        // {

        //     public string Modelo { get; set; }
        //     public string Marca { get; set; }
        //     public string Potencia { get; set; }

        //     public Carro(string modelo, string marca, string potencia)
        //     {
        //         Modelo = modelo;
        //         Marca = marca;
        //         Potencia = potencia;
        //     }

        // }

        public static void addCar(string marca, string modelo, int potencia, int peso, int torque, string placa)
        {


            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados MySQL estabelecida com sucesso.");
                System.Console.WriteLine(connection.Database);

                string sql = "INSERT INTO carros (marca, modelo, potencia, peso, torque, placa) VALUES (@marca, @modelo, @potencia," +
                "@peso, @torque, @placa)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@marca", marca);
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@potencia", potencia);
                cmd.Parameters.AddWithValue("@peso", peso);
                cmd.Parameters.AddWithValue("@torque", torque);
                cmd.Parameters.AddWithValue("@placa", placa);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.WriteLine("Informações adicionadas com sucesso.");
                }
                else
                {
                    Console.WriteLine("Falha ao adicionar informações.");
                }
                connection.Close();

                connection.Open();


                // using (MySqlConnection connect = new MySqlConnection(connectionString))
                // {
                //     //connection.Open();

                //     string tableName = "carros";
                //     string query = $"DESCRIBE {tableName}";

                //     using (MySqlCommand command = new MySqlCommand(query, connection))
                //     {
                //         using (MySqlDataReader reader = command.ExecuteReader())
                //         {
                //             Console.WriteLine("Colunas da tabela '{0}':", tableName);
                //             while (reader.Read())
                //             {
                //                 Console.WriteLine(reader.GetString(0));
                //             }
                //         }
                //     }
                // }

            }
        }


        public static void seeCollums()
        {
            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))

            {
                connection.Open();

                string tableName = "carros";
                string query = $"DESCRIBE {tableName}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Colunas da tabela '{0}':", tableName);
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0));
                        }
                    }
                }
                connection.Close();
            }
        }


        public static void seeLines()
        {
            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string tableName = "carros";
                string query = $"SELECT * FROM {tableName}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                       
                        Console.WriteLine("Linhas da tabela '{0}':", tableName);
                         System.Console.WriteLine("MARCA  MODELO  POTENCIA  PESO  TORQUE  COR  ANO  MOTOR  PLACA  ID");
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i] + " | " + "");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                connection.Close();
            }

        }


        public static void findID()
        {

            System.Console.WriteLine("Type the car's ID: ");
            int id = int.Parse(Console.ReadLine());


            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                //string tableName = "carros";
                string query = $"SELECT * FROM carros WHERE id = {id}";
                connection.Open();


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Console.WriteLine("ID: " + reader["id"].ToString());
                            Console.WriteLine("Marca: " + reader["marca"].ToString());
                            Console.WriteLine("Modelo: " + reader["modelo"].ToString());
                            Console.WriteLine("Potencia: " + reader["potencia"].ToString());
                            Console.WriteLine("Peso: " + reader["peso"].ToString());
                            Console.WriteLine("Torque: " + reader["torque"].ToString());
                            Console.WriteLine("Placa: " + reader["placa"].ToString());

                        }
                    }
                }





            }
        }


        public static void deleteCarById()
        { 
              string filePath = @"F:\programas\CarDataBase\db.json";
              string is_deleted;
              string allText = File.ReadAllText(filePath);
         


            System.Console.WriteLine("Type the car's ID you want to DELETE: ");
            int id = int.Parse(Console.ReadLine());

            string query = $"DELETE FROM carros WHERE id = {id}";

            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

            
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                  
                    int rowsAffected = command.ExecuteNonQuery();

                   
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Registro com ID {id} excluído com sucesso.");
                        is_deleted = $" O carro {id} foi deletado excluido sucesso";

                       is_deleted = JsonSerializer.Serialize(is_deleted, new JsonSerializerOptions { WriteIndented = true });
                       allText += is_deleted + Environment.NewLine;
                      
                         File.WriteAllText(filePath, allText);

                          
                    }
                    else
                    {
                        Console.WriteLine($"Nenhum registro encontrado com o ID {id}.");
                         is_deleted = $"Tentativa de excluir o carro {id} falha. Id nao encontrado";
                          is_deleted = JsonSerializer.Serialize(is_deleted, new JsonSerializerOptions { WriteIndented = true });
                          allText += is_deleted + Environment.NewLine;
                         
                          File.WriteAllText(filePath, allText);

                    }
                }
            }

            



        }


    }
}





