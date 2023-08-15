using MySql.Data.MySqlClient;
//using Newtonsoft.Json;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace CarDataBase
{
    class Program
    {

        public static int abc = 0;

        static void Main()
        {

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Environment.SetEnvironmentVariable("PROMPT", "$NightBlue$ ");
            }
            else
            {
                Environment.SetEnvironmentVariable("PS1", "\\u@\\h:\\w\\$ ");
            }


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Environment.GetEnvironmentVariable("PROMPT") ?? Environment.GetEnvironmentVariable("PROMPT"));
                Console.ResetColor();
                //   string input = Console.ReadLine();
                // Console.WriteLine($"You entered: {input}");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.L && key.Modifiers == ConsoleModifiers.Control)
                    {
                        Console.Clear();
                        Main();
                    }




                    if (abc == 0)
                    {
                        start(true);
                    }

                    abc++;


















                    string input = Console.ReadLine();





                    Levenshtein Levenshtein = new Levenshtein();
                    Levenshtein.LevenshteinDistance(input, 2);

                    string corrigida1 = Levenshtein.LevenshteinDistance(input, 2);

                    input = corrigida1;



                    switch (input)
                    {

                        case "connect":

                            DatabaseHelper.ConnectToDatabase();
                            //Console.ReadKey();
                            //DatabaseHelper.addCar();
                            System.Console.WriteLine("");
                            System.Console.WriteLine("");
                            break;


                        case "exit":

                            System.Console.WriteLine("Shutting Down");
                            Environment.Exit(0);
                            break;


                        case "?":
                            msg(true);
                            Main();

                            break;

                        case "addcar":





                            System.Console.WriteLine("Type the car's brand: ");
                            string brand = Console.ReadLine();




                            string corrigida = Levenshtein.LevenshteinDistance(brand, 1);


                            brand = corrigida;


                            Levenshtein.LevenshteinDistance(brand, 1);

                            brand = corrigida;







                            System.Console.WriteLine("Type the car's model: ");
                            string model = Console.ReadLine();

                            System.Console.WriteLine("Type the car's potence");
                            int potence = int.Parse(Console.ReadLine());

                            System.Console.WriteLine("Type the car's weight");
                            int weight = int.Parse(Console.ReadLine());

                            System.Console.WriteLine("Type the car's tork");
                            int tork = int.Parse(Console.ReadLine());

                            System.Console.WriteLine("Type the car's plate");
                            string plate = Console.ReadLine();


                            DatabaseHelper.addCar(brand, model, potence, weight, tork, plate);
                            CreateCar(brand, model, potence, weight, tork, plate);
                            Main();





                            break;


                        case "collums":
                            DatabaseHelper.seeCollums();
                            Main();

                            break;

                        case "lines":
                            DatabaseHelper.seeLines();
                            Main();

                            break;

                        case "sID":

                            DatabaseHelper.findID();
                            Main();

                            break;

                        case "delcar":
                            DatabaseHelper.deleteCarById();
                            Main();

                            break;


                        case "logs":
                            string filePath = @"F:\programas\CarDataBase\db.json";


                            string allText = File.ReadAllText(filePath);
                            System.Console.WriteLine(allText);
                            Main();

                            break;


                        case "dellogs":

                            filePath = @"F:\programas\CarDataBase\db.json";

                            System.Console.WriteLine("Are you sure you want do DELETE all your LOGS?[y][n]");
                            string yn = Console.ReadLine();
                            if (yn.ToLower() == "y")
                            {
                                File.WriteAllText(filePath, string.Empty);
                                System.Console.WriteLine("All your LOGS have been deleted");
                            }

                            else
                            {
                                System.Console.WriteLine("Canceling");
                            }

                            Main();
                            break;




                    }





                }


                static void start(bool start)
                {

                    name();
                    msg(false);




                }


                static void name()
                {




                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int screenWidth = Console.WindowWidth;
                    string line1 = "   _  ___      __   __    ___  __   ";
                    string line2 = "  / |/ (_)__ _/ /  / /_ / _ )/ /_ ___";
                    string line3 = " /    / / _ `/ _ \\/ __// _  / / // / -_)";
                    string line4 = "/_/|_/_/\\_, /_//_/\\__//____/_/\\_,_/\\__/ ";
                    string line5 = "       /___/                          ";

                    int left1 = (screenWidth - line1.Length) / 2;
                    int left2 = (screenWidth - line2.Length) / 2;
                    int left3 = (screenWidth - line3.Length) / 2;
                    int left4 = (screenWidth - line4.Length) / 2;
                    int left5 = (screenWidth - line5.Length) / 2;




                    Console.SetCursorPosition(left1, Console.CursorTop);
                    Console.WriteLine(line1);
                    Thread.Sleep(300);

                    Console.SetCursorPosition(left2, Console.CursorTop);
                    Console.WriteLine(line2);
                    Thread.Sleep(300);

                    Console.SetCursorPosition(left3, Console.CursorTop);
                    Console.WriteLine(line3);
                    Thread.Sleep(300);

                    Console.SetCursorPosition(left4, Console.CursorTop);
                    Console.WriteLine(line4);
                    Thread.Sleep(300);

                    Console.SetCursorPosition(left5, Console.CursorTop);
                    Console.WriteLine(line5);
                    Thread.Sleep(300);

                    Console.ResetColor();


                }

                static void msg(bool ask)
                {

                    System.Console.WriteLine("Type '?' to see all the options");
                    System.Console.WriteLine("Type 'connect' to connect to your DATABASE");


                    if (ask)
                    {
                        Console.Clear();
                        string[] options =
                         {
                    "To see all the specs of a car, type sID(Car's id)",
                    "To add add car, type 'addcar",
                    "To remove a car by its ID, type 'delcar",
                    "To change the info about a car, type 'cinfocar",
                    "To logout from your DataBase, type 'logout'",
                    "To connect into a new DataBase, type 'new', then 'database'",
                    "To show all the colluns from your DataBase, type 'collums'",
                    "To show all the lines of your DataBase, type 'lines",
                    "To show a specifit line or collum, type 'collum1,2,3' line1,2,3, etc",
                    "To use a speficit funcion, use the name of the funcion",
                    "To know the relaton Weight/HP, type 'WHP'",
                    "To change a car's owner, type 'ccowner'",
                    "To find a car by its ID, type 'fID'",
                    "To see all the logs, type 'logs'",
                    "To erase the logs, type dellogs",
                    "To clear the console, Type CTRL + L"

                };

                        foreach (string opt in options)
                        {
                            System.Console.WriteLine(opt);
                        }

                    }





                }


                static void CreateCar(string marca, string modelo, int potencia, int peso, int torque, string placa)
                {
                    Car carro1 = new Car();

                    carro1.Marca = marca;
                    carro1.Modelo = modelo;
                    carro1.Potencia = potencia;
                    carro1.Peso = peso;
                    carro1.Torque = torque;
                    carro1.Placa = placa;

                    var objetoCompleto = new
                    {
                        Carro_Adicionado = carro1

                    };

                    string jsonString = JsonSerializer.Serialize(objetoCompleto, new JsonSerializerOptions { WriteIndented = true });
                    string filePath = @"F:\programas\CarDataBase\db.json";


                    string allText = File.ReadAllText(filePath);




                    allText += jsonString;


                    File.WriteAllText(filePath, allText);




                }




            }

        }
    }
}