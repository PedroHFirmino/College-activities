using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string arquivoJson = "faturamento.json";
        var (menor, maior, diasAcimaMedia) = CalcularFaturamento(arquivoJson);

        Console.WriteLine($"Menor Faturamento: {menor}");
        Console.WriteLine($"Maior Faturamento: {maior}");
        Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
    }

    static (decimal menor, decimal maior, int diasAcimaMedia) CalcularFaturamento(string arquivoJson)
    {
        List<FaturamentoDiario> faturamento;

        try
        {
            faturamento = JsonConvert.DeserializeObject<List<FaturamentoDiario>>(File.ReadAllText(arquivoJson)); // Alterado de Faturamento para FaturamentoDiario
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine($"Erro ao ler o JSON: {ex.Message}");
            return (0, 0, 0); 
        }

        
        var diasComFaturamento = faturamento.Where(f => f.Valor > 0).Select(f => f.Valor).ToList();

        if (!diasComFaturamento.Any())
            return (0, 0, 0); 

        decimal menorFaturamento = diasComFaturamento.Min();
        decimal maiorFaturamento = diasComFaturamento.Max();
        decimal mediaFaturamento = diasComFaturamento.Average();

        
        int diasAcimaMedia = diasComFaturamento.Count(valor => valor > mediaFaturamento);

        return (menorFaturamento, maiorFaturamento, diasAcimaMedia);
    }
}
