using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    public class SecondTask
    {
        private IDictionary<char, char> alphabet;
        private IEnumerable<char> rus;
        private IEnumerable<char> eng;

        public SecondTask()
        {
            alphabet = new Dictionary<char, char>
            {
                { 'а', 'a'},
                { 'В', 'B'},
                { 'С', 'C'},
                { 'с', 'c'},
                { 'Е', 'E'},
                { 'е', 'e'},
                { 'Н', 'H'},
                { 'К', 'K'},
                { 'к', 'k'},
                { 'М', 'M'},
                { 'п', 'n'},
                { 'О', 'O'},
                { 'о', 'o'},
                { 'Р', 'P'},
                { 'р', 'p'},
                { 'Т', 'T'},
                { 'Х', 'X'},
                { 'х', 'x'},
                { 'У', 'Y'},
                { 'у', 'y'},

            };

            rus = alphabet.Keys;

            eng = alphabet.Values;
        }

        public void Coder()
        {
            Console.WriteLine("Введите сообщение");
            var message = Console.ReadLine();
            byte[] messageBytes = Encoding.Unicode.GetBytes(message);

            string[] mesageInBits = messageBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
            var bitsString = GetStringForArray(mesageInBits);

            Console.WriteLine($"Перевод сообщения в биты: {bitsString}");
            Console.WriteLine();
            Console.WriteLine($"Количество бит: {bitsString.Count()}");
            Console.WriteLine("=========================================");

            string text;
            using (var file = new StreamReader("../../SourceText.txt"))
            {
                text = file.ReadToEnd();
            } 

            var codingText = CoderText(text, bitsString);

            using (var file = new StreamWriter("../../CodingText.txt"))
            {
               file.WriteLine(codingText);
            }

            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine("Сообщение было закодировано в файле CodingText.txt");
            Console.WriteLine("=========================================");

        }

        public void Decoder() 
        {
            Console.Write("Введите название фаайла для декодирования: ");
            var decoderFile = Console.ReadLine();

            string text;
            using (var file = new StreamReader($"../../{decoderFile}"))
            {
                text = file.ReadToEnd();
            }

            string message = DecoderMessage(text);
            Console.WriteLine();
            Console.WriteLine($"Декодированное сообщение в виде Бит: {message}");
            Console.WriteLine("=========================================");
            var bytesMessage = BitToBytes(message);
            Console.WriteLine($"Расшифрованное сообщение: {Encoding.Unicode.GetString(bytesMessage.ToArray())}");
             Console.WriteLine("=========================================");

        }


        //Coder
        private string CoderText(string text, string bits)
        {
            var ignorList = new List<char> { ' ', ',', '?', '!', ':', ';', '.' };

            var textBilder = new StringBuilder(text);
            int countText = 0;
            Console.Write("Схожие по начертанию символы которые были использованы для кодирования: ");
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1')
                {
                    for (; countText < textBilder.Length; countText++)
                    {
                        if (!ignorList.Contains(textBilder[countText]) && alphabet.ContainsKey(textBilder[countText]))
                        {
                            Console.Write(textBilder[countText]);
                            textBilder[countText] = alphabet[textBilder[countText]];
                            countText++;
                            break;
                        }
                    }
                }
                else
                {
                    for (; countText < textBilder.Length; countText++)
                    {
                        if (!ignorList.Contains(textBilder[countText]) && alphabet.ContainsKey(textBilder[countText]))
                        {
                            countText++;
                            break;
                        }
                    }
                }
            }
            return textBilder.ToString();
        }


        //Decoder
        private string DecoderMessage(string text)
        {
            var ignorList = new List<char> { ' ', ',', '?', '!', ':', ';', '.' };

            var message = new StringBuilder();
            var tempBit = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (tempBit.Length == 16)
                {
                    message.Append(tempBit);
                    tempBit.Clear();
                }

                if (!ignorList.Contains(text[i]) && eng.Contains(text[i]))
                {
                    tempBit.Append(1);
                }
                else if (!ignorList.Contains(text[i]) && rus.Contains(text[i]))
                {  
                    tempBit.Append(0);
                }

                if (tempBit.ToString() == "000000000000000")
                {
                    break;
                }
            }

            return message.ToString();
        }
        
        private byte[] BitToBytes(string bits)
        {

            byte[] result = Enumerable.Range(0, bits.Length / 8).
                Select(pos => Convert.ToByte(
                    bits.Substring(pos * 8, 8),
                    2)
                ).ToArray();

            List<byte> mahByteArray = new List<byte>();
            for (int i = result.Length - 1; i >= 0; i--)
            {
                mahByteArray.Add(result[i]);
            }

            return mahByteArray.ToArray().Reverse().ToArray();


        }
        //
        public string GetStringForArray(IEnumerable<string> sourse)
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
