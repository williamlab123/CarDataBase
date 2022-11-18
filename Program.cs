using System.Text.Json;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
//using Newtonsoft.Json;


Console.WriteLine("Hello, World!");
Console.WriteLine("digite a marca do veiculo");
string ma = Console.ReadLine();

Console.WriteLine("digite o modelo do veiculo");
string m = Console.ReadLine();

Console.WriteLine("digite o ano do veiculo");
int a = int.Parse(Console.ReadLine());

Console.WriteLine("digite a cor do veiculo");
string c = Console.ReadLine();

Console.WriteLine("digite a placa");
string p = Console.ReadLine();

Console.WriteLine("digite se é completo ou nao");
string com = Console.ReadLine();

Console.WriteLine("digite a potencia do carro(cv)");
int pot = int.Parse(Console.ReadLine());



 void Main()
        {
             var estoque = new Estoque
            {
              

                modelo = m,
                 ano = a,
                  cor = c,
                   marca = ma,
                    placa = p,
                     completo = com,
                      potencia = pot

            
    
            };


            

            string jsonString = JsonSerializer.Serialize(estoque);

            Console.WriteLine(jsonString);

            string filePath = @"C:\Users\willi\Desktop\programas\CarDataBase\data.json";

       

            
            //     List<string> lines = new List<string>();
            //     lines = File.ReadAllLines(filePath).ToList();
 
            //     foreach (string line in lines)
            //     {
            //         Console.WriteLine(line);
            //     }
 
            //     lines.Add(jsonString);
            //    // lines.Add();
            //     lines.Add("");
            //     File.WriteAllLines(filePath, lines);

            string data = File.ReadAllText("YourFilePath"); // using System.IO

        var array = await JsonSerializer.DeserializeAsync<Estoque[]>(data); // using System.Text.Json

        if (array == null) {
        // Error. Do something
        return;
        }

        var list = new List<Estoque>(array); // using System.Collections.Generic

        list.Add(estoque); // Add your new object

        var newArray = list.ToArray();

        string json = await JsonSerializer.SerializeAsync<Estoque[]>(newArray);

        File.WriteAllText("YourFilePath", json);


                         

                            

              

        } 
 

 Main();
        

public class Estoque
    {
        public string modelo { get; set; }
        public int ano { get; set; }
        public string cor { get; set; }
        public string marca { get; set; }
        public string  placa {get; set;} 
        public string  completo {get; set;}
        public int  potencia {get; set;}
    }