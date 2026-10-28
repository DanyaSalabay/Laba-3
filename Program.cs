using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n ГЛАВНОЕ МЕНЮ ");
                Console.WriteLine("1. Задание 1 (Три матрицы)");
                Console.WriteLine("2. Задание 2 (Элементы > диагонали)");
                Console.WriteLine("3. Задание 3 (Выражение A*C^T+B*C)");
                Console.WriteLine("4. Задание 4 (Бинарный файл)");
                Console.WriteLine("5. Задание 5 (XML и структуры)");
                Console.WriteLine("6. Задание 6 (Текст: max/min)");
                Console.WriteLine("7. Задание 7 (Текст: сумма)");
                Console.WriteLine("8. Задание 8 (Текст: символы)");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        break;
                    case "2":
                        RunTask2();
                        break;
                    case "3":
                        RunTask3();
                        break;
                    case "4":
                        FileTasks.Task4("t4.bin");
                        break;
                    case "5":
                        FileTasks.Task5("t5.xml");
                        break;
                    case "6":
                        FileTasks.Task6("t6.txt");
                        break;
                    case "7":
                        FileTasks.Task7("t7.txt");
                        break;
                    case "8":
                        FileTasks.Task8("t8_in.txt", "t8_out.txt");
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
        }
        static int ReadDimension(string prompt)
        {
            int res = 0;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out res))
                {
                    Console.WriteLine("Ошибка: введите число.");
                    continue;
                }
                
                if (res < 1)
                {
                    Console.WriteLine("Ошибка: размер > 0.");
                    continue;
                }
                
                return res;
            }
        }

        public static int ReadInt()
        {
            int res = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out res)) return res;
                Console.Write("Ошибка. Введите число: ");
            }
        }
        static void RunTask1()
        {
            int n = ReadDimension("Введите n: ");
            int m = ReadDimension("Введите m: ");

            Matrix mat1 = new Matrix(n, m, true); 
            Console.WriteLine("Матрица 1:\n" + mat1);

            Matrix mat2 = new Matrix(n, n, "chess");
            Console.WriteLine("Матрица 2:\n" + mat2);
        }

        static void RunTask2()
        {
            int n = ReadDimension("Введите n: ");
            Matrix mat = new Matrix(n, n, "chess"); 
            Console.WriteLine("Матрица:\n" + mat);
            mat.Task2();
        }

        static void RunTask3()
        {
            int n = ReadDimension("Введите n: ");
            Matrix.Task3(n);
        }
    }
}
