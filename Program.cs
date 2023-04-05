﻿using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace CarDataBase
{
    class Program
    {
        static void Main()
        {


          start(true);
         


            string? input = Console.ReadLine();


        





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
                   // Main();

                    break;

                case "addcar":
                    System.Console.WriteLine("Type the car's brand: ");
                    string? brand = Console.ReadLine();

                    System.Console.WriteLine("Type the car's model: ");
                    string? model = Console.ReadLine();

                    System.Console.WriteLine("Type the car's potence");
                    int potence = int.Parse(Console.ReadLine());

                    System.Console.WriteLine("Type the car's weight");
                    int weight = int.Parse(Console.ReadLine());

                    System.Console.WriteLine("Type the car's tork");
                    int tork = int.Parse(Console.ReadLine());

                    System.Console.WriteLine("Type the car's plate");
                    string? plate = Console.ReadLine();


                    DatabaseHelper.addCar(brand, model, potence, weight, tork, plate);
                      //Main();


                    break;


                case "collums":
                    DatabaseHelper.seeCollums();
                     // Main();

                    break;

                case "lines":
                    DatabaseHelper.seeLines();
                     // Main();

                    break;

                case "sID":

                    DatabaseHelper.findID();
                     // Main();

                    break;

                case "delcar":
                    DatabaseHelper.deleteCarById();
                     // Main();

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

            // Console.WriteLine("   _  ___      __   __    ___  __   ");
            //   Thread.Sleep(400);
            // Console.WriteLine("  / |/ (_)__ _/ /  / /_ / _ )/ /_ ___");
            //   Thread.Sleep(400);
            // Console.WriteLine(" /    / / _ `/ _ \\/ __// _  / / // / -_)");
            //   Thread.Sleep(400);
            // Console.WriteLine("/_/|_/_/\\_, /_//_/\\__//____/_/\\_,_/\\__/ ");
            //   Thread.Sleep(400);
            // Console.WriteLine("       /___/                          ");
            //   Thread.Sleep(400);


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
                    "To see all the logs, type 'logs', to see only the last, type 'log'"

                };

                foreach (string opt in options)
                {
                    System.Console.WriteLine(opt);
                }

            }





        }


        static void getCar()
        {

            //Car carro1 = new Car();




        }


        static void saveJson()
        {
            Car carro1 = new Car();
        }

    }

}