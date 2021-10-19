using System;
using System.IO;
using System.Text;
using LexicalAnalyzer;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            using var stream = new StreamReader("input.txt");

            var code = stream.ReadToEnd();

            var analyser = new Analyzer();
            analyser.Run(string.Join(Environment.NewLine, code));

            var lexemes = analyser.Lexemes;

            Console.WriteLine("Таблица лексем");
            for (int i = 0; i < lexemes.Count; i++)
            {
                Console.WriteLine($"Индекс: {i}, Символ: {lexemes[i].Class}, Категория: {lexemes[i].Type}, Тип {lexemes[i].Value}");
            }
		}
    }
}
