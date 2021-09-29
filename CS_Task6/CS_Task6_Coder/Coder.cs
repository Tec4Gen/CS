﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Task6_Coder
{
    public class Coder
    {
        private Dictionary<char, int> _aplhabet;

        public int CountAlphabet => _aplhabet.Count();

        public Coder()
        {
            _aplhabet = new Dictionary<char, int>
            {
                {'А', 0 },
                {'Б', 1 },
                {'В', 2 },
                {'Г', 3 },
                {'Д', 4 },
                {'Е', 5 },
                {'Ё', 6 },
                {'Ж', 7 },
                {'З', 8 },
                {'И', 9 },
                {'Й', 10 },
                {'К', 11 },
                {'Л', 12 },
                {'М', 13 },
                {'Н', 14 },
                {'О', 15 },
                {'П', 16 },
                {'Р', 17 },
                {'С', 18 },
                {'Т', 19 },
                {'У', 20 },
                {'Ф', 21 },
                {'Х', 22 },
                {'Ц', 23 },
                {'Ч', 24 },
                {'Ш', 25 },
                {'Щ', 26 },
                {'Ъ', 27 },
                {'Ы', 28 },
                {'Ь', 29 },
                {'Э', 30 },
                {'Ю', 31},
                {'Я', 32 },
                    
                {'а', 33 },
                {'б', 34 },
                {'в', 35 },
                {'г', 36 },
                {'д', 37 },
                {'е', 38 },
                {'ё', 39 },
                {'ж', 40 },
                {'з', 41 },
                {'и', 42 },
                {'й', 43 },
                {'к', 44 },
                {'л', 45 },
                {'м', 46 },
                {'н', 47 },
                {'о', 48 },
                {'п', 49 },
                {'р', 50 },
                {'с', 52 },
                {'т', 53 },
                {'у', 54 },
                {'ф', 55 },
                {'х', 56 },
                {'ц', 57 },
                {'ч', 58 },
                {'ш', 59 },
                {'щ', 60 },
                {'ъ', 61 },
                {'ы', 62 },
                {'ь', 63 },
                {'э', 64 },
                {'ю', 65 },
                
                {'A', 66 },
                {'B', 67 },
                {'C', 68 },
                {'D', 69 },
                {'E', 70 },
                {'F', 71 },
                {'G', 72 },
                {'H', 73 },
                {'I', 74 },
                {'J', 75 },
                {'K', 76 },
                {'L', 77 },
                {'M', 78 },
                {'N', 79 },
                {'O', 80 },
                {'P', 81 },
                {'Q', 82 },
                {'R', 83 },
                {'S', 84 },
                {'T', 85 },
                {'U', 86 },
                {'V', 87 },
                {'W', 88 },
                {'X', 89 },
                {'Y', 90 },
                {'Z', 91 },

                {'a', 92 },
                {'b', 93 },
                {'c', 94 },
                {'d', 95 },
                {'e', 96 },
                {'f', 97 },
                {'g', 98 },
                {'h', 99 },
                {'i', 100 },
                {'j', 101 },
                {'k', 102 },
                {'l', 103 },
                {'m', 104 },
                {'n', 105 },
                {'o', 106 },
                {'p', 107 },
                {'q', 108 },
                {'r', 109 },
                {'s', 110 },
                {'t', 111 },
                {'u', 112 },
                {'v', 113 },
                {'w', 114 },
                {'x', 115 },
                {'y', 116 },
                {'z', 117 },

                {'.', 118 },
                {',', 119 },
                {'!', 120 },
                {'?', 121 },
                {'\'',122 },
                {';', 123 },
                {':', 124 },
                {'<', 125 },
                {'>', 126 },
                {'\\',127 },
                {'/', 128 },
                {' ', 129 },
                {'&', 130 },
                {'$', 131 },
                {'\r', 132 },
                {'\n', 133 },

            };
        }
        public void Run() 
        {
            //Console.WriteLine("Введите название директории которую хотите зашифровать");
            //var path = Console.ReadLine();

            Console.WriteLine("Введите ключ");
            var key = Console.ReadLine();

            Dictionary<string, string> files = GetAllDirectory("Directory");

            string message = GetString(files);

            string stringCode = GetCode(message, key);

            using (var file = new StreamWriter("resultCoder.txt", append: false, Encoding.Unicode))
                file.Write(stringCode);

            //if (Directory.Exists($"../../Directoryy"))
            //{
            //    Directory.Delete("../../Directoryy", recursive: true);
            //}
        }

        private string GetCode(string message, string key)
        {
            var sequenceNumberKey = key
                .Select(k => _aplhabet[k])
                .ToList();

            var sequenceNumberMessage = message
                .Select(k => _aplhabet[k])
                .ToList();

            int countstream = 0;

            var sequenceStream = new List<int>();

            for (int i = 0; i < message.Length; i++)
            {
                sequenceStream.Add(_aplhabet[key[countstream]]);
                countstream++;

                if (countstream == key.Length) 
                    countstream = 0;
            }

            var sequenceValue = new List<int>();

            for (int i = 0; i < sequenceNumberMessage.Count; i++)
            {
                var result = (sequenceNumberMessage[i] + sequenceStream[i]) % CountAlphabet;
                sequenceValue.Add(result);
            }

            var resultMessageCode = sequenceValue.Select(sv => _aplhabet.FirstOrDefault(a => a.Value == sv).Key);

            return GetStringForArray(resultMessageCode);
        }

        private string GetString(Dictionary<string, string> files)
        {
            var result = new StringBuilder();

            foreach (var item in files)
            {
                result.Append($"{item.Key}&{item.Value}$$");
            }

            return result.ToString();
        }

        private Dictionary<string, string> GetAllDirectory(string path)
        {
            var result = Directory.EnumerateFiles($"{path}", "*.txt", SearchOption.AllDirectories)
                .Select(p => new KeyValuePair<string, string>(p, File.ReadAllText(p)))
                .ToDictionary(k => k.Key, val => val.Value);

            return result;
        }

        public string GetStringForArray(IEnumerable<char> sourse)
        {
            var sb = new StringBuilder();
            foreach (var item in sourse)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
