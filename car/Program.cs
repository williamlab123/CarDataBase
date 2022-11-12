using System.Collections.Generic;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization; 


string version = "v1.0";
inicio();

void options()
{
    Console.WriteLine("Digite [1] para adicionar um carro ao estoque");
     Console.WriteLine("Digite [2] para ver o estoque de veiculos");
      Console.WriteLine("Digite [3] para ver informaçoes sobre os veiculos");
       Console.WriteLine("Digite [4] para alterar informaçoes sobre um veiculo");
        Console.WriteLine("Digite [5] para alterar o dono do estoque");
         Console.WriteLine("Digite [6] para remover um veiculo do estoque");
          Console.WriteLine("Digite 's' para sair");

}
void Msg()
{
      Console.WriteLine("Estoque de carros!");
     Console.WriteLine("Para ver as opçoes, digite b");
    Console.WriteLine("Digite a para iniciar");
   Console.WriteLine("Digite 's' para sair");
  Console.WriteLine("Voce pode digitar em qualquer momento '?'  ou 'opçoes' para ver as opçoes");

}


 void inicio()
 {
   Msg();

   char escolha = char.Parse(Console.ReadLine());

   switch(escolha)
   {
    case 'a':
     Main();   
      break;


    case 'b':
     options();
      break;

    case 'c':
     Environment.Exit(0);  
      break;

   }

 }
void Main()
{
  Console.ForegroundColor = ConsoleColor.Blue;
  Console.WriteLine($"Cars Versao {version}");
  Console.ResetColor();
}


