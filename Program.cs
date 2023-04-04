using MySql.Data.MySqlClient;

namespace CarDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            name();
            msg(false);


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


                case "?":
                    msg(true);

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
                     
                   break; 


                   case "collums":
                   DatabaseHelper.seeCollums();
                   break;

                   case "lines":
                   DatabaseHelper.seeLines();
                   break;



            }





        }


        static void name()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   _  ___      __   __    ___  __   ");
            Console.WriteLine("  / |/ (_)__ _/ /  / /_ / _ )/ /_ ___");
            Console.WriteLine(" /    / / _ `/ _ \\/ __// _  / / // / -_)");
            Console.WriteLine("/_/|_/_/\\_, /_//_/\\__//____/_/\\_,_/\\__/ ");
            Console.WriteLine("       /___/                          ");
            Console.ResetColor();


        }

        static void msg(bool ask)
        {
            System.Console.WriteLine("Type '?' to see all the options");
            System.Console.WriteLine("Type 'connect' to connect to your DATABASE");


            if(ask)
            {
                string[] options =
                 {
                    "To see all the specs of a car, type sID(Car's id)",
                    "To add add car, type 'addcar",
                    "To remove a car, type 'remcar",
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

          Car carro1 = new Car();

           


        }

    }

}