using System.Text.Json;

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

       
           