using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleT_12
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

                o = o++;
                Console.WriteLine($"Все элементы матрицы увеличены на 1:\n{o.Print()}");
                Console.WriteLine("Матрица квадратная? - {0}", o ? "Да" : "Нет");
                Console.Write("Введите размер для новой матрицы: ");
                MyClass o2 = new MyClass(int.Parse(Console.ReadLine()));
                o2.Input();
                o = o + o2;
                Console.WriteLine("Сложение со старой матрицей:\n{0}", o.Print());
                int[,] arr2 = (int[,])o;
                o2 = (MyClass)arr2;
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
        public int this[int a, int b]
        {
            get
            {
                return arr[a, b];
            }
            set
            {
                arr[a, b] = value;
            }
        }
        public void Input(string str)
        {
            string[] s = str.Split('\n');
            if (s.Length != n)
            {
                throw new Exception("Количество строк не соответствует количеству длине массива");
            }
            for (int i = 0; i < n; i++)
            {
                string[] s2 = s[i].Split(' ');
                if (s2.Length != n)
                {
                    if (s.Length != arr.Length)
                    {
                        throw new Exception("Количество элементов не соответствует длине массива");
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = int.Parse(s2[j]);
                }
            }
        }
        public void Input()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
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
                foreach (int a in arr)
                {
                    if (a == 0)
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
                for (int i = 0; i < n; i++)
                {
                    arr[i, i] = value;
                }
            }
        }
        void Input(int[,] arr)
        {
            this.arr = arr;
        }
        public static MyClass operator ++(MyClass myClass)
        {
            for (int i = 0; i < myClass.n; i++)
            {
                for (int j = 0; j < myClass.n; j++)
                {
                    myClass[i, j]++;
                }
            }
            return myClass;
        }
        public static MyClass operator --(MyClass myClass)
        {
            for (int i = 0; i < myClass.n; i++)
            {
                for (int j = 0; j < myClass.n; j++)
                {
                    myClass[i, j]--;
                }
            }
            return myClass;
        }
        public static bool operator true(MyClass myClass)
        {
            return myClass.arr.GetUpperBound(0) == myClass.arr.GetUpperBound(1);
        }
        public static bool operator false(MyClass myClass)
        {
            return myClass.arr.GetUpperBound(0) != myClass.arr.GetUpperBound(1);
        }
        public static MyClass operator +(MyClass my1, MyClass my2)
        {
            if (my1.n != my2.n)
            {
                throw new Exception("У массивов разная длина");
            }
            MyClass myClass = new MyClass(my1.n);
            for (int i = 0; i < my1.n; i++)
            {
                for (int j = 0; j < my1.n; j++)
                {
                    myClass[i, j] = my1[i, j] + my2[i, j];
                }
            }
            return myClass;
        } 
        public static explicit operator MyClass(int [,]arr)
        {
            MyClass myClass = new MyClass(arr.GetUpperBound(0) - 1);
            myClass.Input(arr);
            return myClass;
        }
        public static explicit operator int[,](MyClass myClass)
        {
            return myClass.arr;
        }
    }
}
