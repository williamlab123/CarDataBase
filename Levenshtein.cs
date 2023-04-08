using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDataBase
{
    public class Levenshtein
    {
        public static string LevenshteinDistance(string _brand)
        {
           
            string[] marcas = {
                    "Acura",
                    "Alfa Romeo",
                    "Aston Martin",
                    "Audi",
                    "Bentley",
                    "BMW",
                    "Bugatti",
                    "Buick",
                    "Cadillac",
                    "Chevrolet",
                    "Chrysler",
                    "Citroen",
                    "Dodge",
                    "Ferrari",
                    "Fiat",
                    "Ford",
                    "Geely",
                    "Genesis",
                    "GMC",
                    "Honda",
                    "Hyundai",
                    "Infiniti",
                    "Jaguar",
                    "Jeep",
                    "Kia",
                    "Koenigsegg",
                    "Lamborghini",
                    "Land Rover",
                    "Lexus",
                    "Lincoln",
                    "Lotus",
                    "Maserati",
                    "Mazda",
                    "McLaren",
                    "Mercedes-Benz",
                    "Mini",
                    "Mitsubishi",
                    "Nissan",
                    "Pagani",
                    "Peugeot",
                    "Porsche",
                    "Ram",
                    "Renault",
                    "Rolls-Royce",
                    "Saab",
                    "Subaru",
                    "Suzuki",
                    "Tesla",
                    "Toyota",
                    "Volkswagen",
                    "Volvo"
        };


            string palavra = _brand;
            if (!marcas.Contains(palavra))
            {
                int distanciaMaxima = 4;
                string corrigida = null;
                int menorDistancia = int.MaxValue;

                foreach (string marca in marcas)
                {
                    int distancia = DistanciaLevenshtein(palavra, marca);
                    if (distancia <= distanciaMaxima && distancia < menorDistancia)
                    {
                        corrigida = marca;
                        menorDistancia = distancia;
                    }
                }

                if (corrigida != null)
                {
                    
                    
                    Console.Write("Você quis dizer ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.Write(corrigida + " ?");
                    Console.ResetColor();
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if(keyInfo.Key == ConsoleKey.Enter)
                    {
                           return corrigida;
                    }

                    else
                    {
                        
                        return corrigida = null;
                    }

                  
                    
                }
                else
                {
                   
                   return corrigida = null;
                }
            }
            else
            {
             
               return "";
            }

            
        }

        static int DistanciaLevenshtein(string s, string t)
        {
            int[,] d = new int[s.Length + 1, t.Length + 1];

            for (int i = 0; i <= s.Length; i++)
            {
                d[i, 0] = i;
            }

            for (int j = 0; j <= t.Length; j++)
            {
                d[0, j] = j;
            }

            for (int j = 1; j <= t.Length; j++)
            {
                for (int i = 1; i <= s.Length; i++)
                {
                    int custo = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + custo);
                }
            }

            return d[s.Length, t.Length];
        }






    }
}
