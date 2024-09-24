using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Dictionary<string, decimal> faturamento = new Dictionary<string, decimal>
        {
            { "SP", 67836.43m },
            { "RJ", 36678.66m },
            { "MG", 29229.88m },
            { "ES", 27165.48m },
            { "Outros", 19849.53m }
        };

        
        decimal total = 0;
        foreach (var valor in faturamento.Values)
        {
            total += valor; 
        }

        
        Console.WriteLine("Percentual de representação por estado:");
        foreach (var estado in faturamento)
        {
            decimal percentual = (estado.Value / total) * 100; 
            Console.WriteLine($"{estado.Key}: {percentual:F2}%"); 
        }
    }
}