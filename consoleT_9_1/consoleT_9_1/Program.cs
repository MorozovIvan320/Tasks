using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleT_9_1
{
    class Task_1
    {
        string[] str;
        string result = "";
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\task1.bin";
        public Task_1(string str, char a)
        {
            this.str = str.Split(' ');
            result = f(a);
            if (result == "") 
            {
                result = "Нет слов на введенную букву";
            }
            Write();
        }
        string f(char a)
        {
            StringBuilder sBuild = new StringBuilder(String.Empty);
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.Parse(str[i][0].ToString().ToLower()) == a)
                {
                  sBuild.Append(str[i] + " ");
                }
            }
            return sBuild.ToString();
        }
        void Write()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(result);
                writer.Close();
            }
        }
        public string Read()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                string str = reader.ReadString();
                reader.Close();
                return str;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите слова через пробел: ");
                string str = Console.ReadLine();
                Console.Write("Введите символ: ");
                char a = Convert.ToChar(Console.ReadLine());
                Task_1 o = new Task_1(str, a);
                Console.WriteLine("Результат:\n{0}", o.Read());
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
