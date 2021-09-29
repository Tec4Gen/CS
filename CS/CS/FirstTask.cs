using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    public class FirstTask
    {

        private Dictionary<string, IEnumerable<byte>> fileBytes;
        public FirstTask()
        {
            fileBytes = new Dictionary<string, IEnumerable<byte>>();
        }
        public void Run() 
        {
            Console.WriteLine("Введите название файла с сигнатурой");
            var sig = Console.ReadLine();

            Console.WriteLine("Введите название директории");
            var directory =  Console.ReadLine();

            Console.WriteLine("Укажите смещение");
            int.TryParse(Console.ReadLine(), out var shift);

            var signature = GetSignatureOfFile($"../../{sig}", shift);

            Console.WriteLine(Encoding.UTF8.GetString(signature.Signature.ToArray()));

            GetAllDirectory($"../../{directory}");

            var result = GetAllFilesBySignature(signature.Signature);

            Console.WriteLine($"Количество  файлов в которых присутствует сигнатура: {result.Count()}");
            if (result.Count == 0)
                return;

            foreach (var item in result)
            {
                
                Console.WriteLine($"{item.Key}");
            }

        }
        public SignatureFile GetSignatureOfFile(string fileSignaturePath, int shift) 
        {
            var fileBytes = File.ReadAllBytes(fileSignaturePath);

            var signatureFile = new SignatureFile();

            signatureFile.Signature = new byte[fileBytes.Length];
            //Array.Copy(fileBytes, shift, signatureFile.Signature.ToArray(), 0, signatureFile.SizeSignature);

            signatureFile.Signature = fileBytes
                .Skip(shift)
                .Take(signatureFile.SizeSignature);

            return signatureFile;
        }

        public void GetAllDirectory(string directoryPath)
        {
            fileBytes = Directory.EnumerateFiles(directoryPath, "*.txt", SearchOption.AllDirectories)
                .Select(p => new KeyValuePair<string, IEnumerable<byte>>(p, File.ReadAllBytes(p)))
                .ToDictionary(k=> k.Key, val=> val.Value);
        }

        IDictionary<string, string> GetAllFilesBySignature(IEnumerable<byte> sign) 
        {
            var signature = GetStringForArray(sign);

            var result = fileBytes
                        .Select(p => new KeyValuePair<string, string>(p.Key, GetStringForArray(p.Value)))
                            .Where(kv => kv.Value.Contains(signature))
                            .ToDictionary(p => p.Key, k => k.Value);

            return result;
        }

        public string GetStringForArray(IEnumerable<byte> sourse) 
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
