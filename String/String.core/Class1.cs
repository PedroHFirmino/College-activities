using System;

class Program
{
    static void Main(string[] args)
    {
      
        string input = "Pedro Henrique Firmino Silva"; 
        string invertedString = InverterString(input);

        Console.WriteLine($"String original: {input}");
        Console.WriteLine($"String invertida: {invertedString}");
    }

    static string InverterString(string str)
    {
        char[] caracteres = new char[str.Length]; 
        int j = 0;

        
        for (int i = str.Length - 1; i >= 0; i--)
        {
            caracteres[j] = str[i]; 
            j++;
        }

        return new string(caracteres); 
    }
}