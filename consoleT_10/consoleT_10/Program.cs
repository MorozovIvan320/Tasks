using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleT_10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task10 t = new Task10();
                Console.WriteLine(t.Debug);
                Console.WriteLine($"Информация о файлах:\n{t.FInfo}");
                Console.WriteLine($"Информация о файлах в дирректории ALL:\n{t.GetDirectoryInfo()}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }
    }
    class Task10
    {
        string debug = "";
        string str1 = "Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов";
        string str2 = "Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс";
        string fileInfo = String.Empty;
        public Task10()
        {
            CreateDirectories();
            debug += "1. Создана директория.\n";
            CreateTxt();
            debug += "2. Созданы текстовые файлы.\n";            
            fileInfo = GetFileInfo();
            debug += "3. Получена информация о файлах.\n";
            ReplaceNCopy();
            debug += "4. Файлы перемещены и копированы.\n";
            RenameNDelete();
            debug += "5. Директория переименована, другие удалены.\n";
        }
        public string FInfo
        {
            get
            {
                return fileInfo;
            }
        }
        public string Debug
        {
            get
            {
                return debug;
            }
        }
        
        void CreateDirectories()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Temp");
            directory.CreateSubdirectory(@"K1");
            directory.CreateSubdirectory(@"K2");
        }
        void CreateTxt()
        {
            File.WriteAllText(@"C:\Temp\K1\t1.txt", str1);
            File.WriteAllText(@"C:\Temp\K1\t2.txt", str2);
            string asd = File.ReadAllText(@"C:\Temp\K1\t1.txt") + '\n';
            asd += File.ReadAllText(@"C:\Temp\K1\t2.txt");
            File.WriteAllText(@"C:\Temp\K2\t3.txt", asd);
        }
        string GetFileInfo()
        {
            string res = String.Empty;
            FileInfo fileInfo = new FileInfo(@"C:\Temp\K1\t1.txt");
            res += "Имя первого файла: " + fileInfo.Name + '\n';
            res += "Время создание первого файла: " + fileInfo.CreationTime.ToString() + '\n';
            res += "Размер первого файла: " + fileInfo.Length.ToString() + '\n' + '\n';
            fileInfo = new FileInfo(@"C:\Temp\K1\t2.txt");
            res += "Имя второго файла: " + fileInfo.Name + '\n';
            res += "Время создание второго файла: " + fileInfo.CreationTime.ToString() + '\n';
            res += "Размер второго файла: " + fileInfo.Length.ToString() + '\n' + '\n';
            fileInfo = new FileInfo(@"C:\Temp\K2\t3.txt");
            res += "Имя третьего файла: " + fileInfo.Name + '\n';
            res += "Время создание третьего файла: " + fileInfo.CreationTime.ToString() + '\n';
            res += "Размер третьего файла: " + fileInfo.Length.ToString() + '\n' + '\n';
            return res;
        }
        void ReplaceNCopy()
        {
            File.Move(@"C:\Temp\K1\t2.txt", @"C:\Temp\K2\t2.txt");
            File.Copy(@"C:\Temp\K1\t1.txt", @"C:\Temp\K2\t1.txt");
        }
        void RenameNDelete()
        {
            Directory.Move(@"C:\Temp\K2", @"C:\Temp\All");
            DirectoryInfo directory = new DirectoryInfo(@"C:\Temp\K1");
            directory.Delete(true);
        }
        public string GetDirectoryInfo()
        {
            string res = String.Empty;
            string[] files = Directory.GetFiles(@"C:\Temp\All");
            foreach (string s in files)
            {
                FileInfo fileInfo = new FileInfo(s);
                res += "Имя файла: " + fileInfo.Name + '\n';
                res += "Время создание файла: " + fileInfo.CreationTime.ToString() + '\n';
                res += "Размер файла: " + fileInfo.Length.ToString() + '\n' + '\n';
            }
            return res;
        }
    }

}
