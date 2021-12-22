using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conosoleT_11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размер матрицы NxN: ");
                MyClass o = new MyClass(int.Parse(Console.ReadLine()));
                o.Input();
                Console.WriteLine(o.Print());
                Console.Write("Введите скаляр для главной диагонали: ");
                o.MainDiag = int.Parse(Console.ReadLine());
                Console.WriteLine($"Результат:\n{o.Print()}");
                Console.WriteLine($"Количество нулей в данной матрице: {o.ZeroCount}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
    class MyClass
    {
        int[,] arr;
        int n;
        public MyClass(int n)
        {
            Random rand = new Random();
            this.n = n;
            arr = new int[n, n];
        }
        public void Input(string str)
        {
            string[] s = str.Split('\n');
            if (s.Length!=arr.Length)
            {
                throw new Exception("Количество строк не соответствует количеству длине массива");
            }
            for (int i=0; i<n; i++)
            {
                string[] s2 = s[i].Split(' ');
                if (s2.Length != n)
                {
                    if (s.Length != arr.Length)
                    {
                        throw new Exception("Количество элементов не соответствует количеству длине массива");
                    }
                }
                for (int j=0; j<n; j++)
                {
                    arr[i, j] = int.Parse(s2[j]);
                }
            }
        }
        public void Input()
        {
            for (int i =0; i<n; i++)
            {
                for (int j =0; j<n; j++)
                {
                    Console.Write($"Введит элемент матрицы [{i}][{j}]: ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public string Print()
        {
            string str = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str += $"{arr[i, j]} ";
                }
                str += '\n';
            }
            return str;
        }
        public int SumI(int i)
        {
            int sum = 0;
            for (int j = 0; j < n; j++) 
            {
                sum += arr[j, i];
            }
            return sum;
        }
        public int ZeroCount
        {
            get
            {
                int count = 0;
                foreach(int a in arr)
                {
                    if (a==0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int MainDiag
        {
            set
            {
                for (int i =0; i<n; i++)
                {
                    arr[i, i] = value;
                }
            }
        }
    }
}
