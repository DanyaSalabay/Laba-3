using System;

namespace Lab3
{
    public class Matrix
    {
        private int[,] _data;
        
        public Matrix(int n, int m)
        {
            _data = new int[n, m];
        }

        public Matrix(int n, int m, bool isFirst)
        {
            _data = new int[n, m];
            if (isFirst)
            {
                Console.WriteLine("Введите матрицу 1:");
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"Элемент [{i},{j}]: ");
                        _data[i, j] = Program.ReadInt();
                    }
                }
            }
        }

        public Matrix(int n, int m, string type)
        {
            _data = new int[n, m];
            if (type == "chess")
            {
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int num = rnd.Next(1, 100);
                        if ((i + j) % 2 == 0) 
                        {
                            if (num % 2 == 0) { num++; } 
                        }
                        else 
                        {
                            if (num % 2 != 0) { num++; } 
                        }
                        _data[i, j] = num;
                    }
                }
            }
        }

        public int Rows 
        { 
            get { return _data.GetLength(0); } 
        }
        
        public int Cols 
        { 
            get { return _data.GetLength(1); } 
        }

        public int[,] Data 
        { 
            get { return _data; } 
        }

        public void Task2()
        {
            int maxDiag = _data[0, 0];
            for (int i = 1; i < Rows; i++)
            {
                if (_data[i, i] > maxDiag) maxDiag =
                    _data[i, i];
            }

            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (_data[i, j] > maxDiag) count++;
                }
            }
            Console.WriteLine($"Элементов больше диагонали:" +
                              $" {count}");
        }

        public static void Task3(int n)
        {
            Matrix a = new Matrix(n, n, "chess");
            Matrix b = new Matrix(n, n, "chess");
            Matrix c = new Matrix(n, n, "chess");
            
            Console.WriteLine("Матрица A:");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Матрица B:");
            Console.WriteLine(b.ToString());
            Console.WriteLine("Матрица C:");
            Console.WriteLine(c.ToString());

            Matrix cT = c.Transpose();
            Console.WriteLine("Матрица C^T:");
            Console.WriteLine(cT.ToString());

            Matrix result = a * cT + b * c;
            
            Console.WriteLine("Результат A*C^T + B*C:");
            Console.WriteLine(result.ToString());
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix res = new Matrix(a.Rows, b.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.Cols; k++)
                    {
                        sum += a.Data[i, k] * b.Data[k, j];
                    }
                    res.Data[i, j] = sum;
                }
            }
            return res;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    res.Data[i, j] =
                        a.Data[i, j] + b.Data[i, j];
                }
            }
            return res;
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(Cols, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result.Data[j, i] = _data[i, j];
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result += _data[i, j].ToString().PadLeft(6);
                }
                result += "\n";
            }
            return result;
        }
    }
}
