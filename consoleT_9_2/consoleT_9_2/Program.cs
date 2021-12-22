using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleT_9_2
{
    class Task2
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\file.txt";
        string wPath = AppDomain.CurrentDomain.BaseDirectory + "\\File2.txt";
        string[] strArr;
        public Task2()
        {
            strArr = File.ReadAllLines(path, Encoding.Default);
        }
        public void F()
        {
            for (int i = 0; i < strArr.Length; i++)
            {
                strArr[i] += $" ({strArr[i].Length})";
            }
            Write();
        }
        void Write()
        {
            File.WriteAllLines(wPath, strArr);
        }
        public string Str
        {
            get
            {
                return String.Join('\n'.ToString(), strArr);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task2 o = new Task2();
                Console.WriteLine($"Текст:\n{o.Str}");
                o.F();
                Console.WriteLine($"Измененный текст:\n{o.Str}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
