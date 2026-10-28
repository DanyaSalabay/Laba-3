using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Lab3
{
    [Serializable]
    public struct Toy
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }

    public class FileTasks
    {
        public static void CreateAndFillFile4(string filename)
        {
            Random rnd = new Random();
            using (BinaryWriter writer = 
                   new BinaryWriter(File.Open(
                       filename, FileMode.Create)))
            {
                for (int i = 0; i < 20; i++)
                {
                    writer.Write(rnd.Next(1, 100));
                }
            }
        }

        public static void Task4(string filename)
        {
            CreateAndFillFile4(filename);
            int count = 0;

            Console.WriteLine("Содержимое файла:");
            using (BinaryReader reader = 
                   new BinaryReader(File.Open(
                       filename, FileMode.Open)))
            {
                while (reader.BaseStream.Position < 
                       reader.BaseStream.Length)
                {
                    int num = reader.ReadInt32();
                    Console.Write(num + " ");
                    
                    if (num % 2 == 0 && (num / 2) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Удвоенных нечетных: {count}");
        }

        public static List<Toy> CreateAndFillToys()
        {
            List<Toy> toys = new List<Toy>();
            
            Toy t1 = new Toy();
            t1.Name = "Кукла";
            t1.Price = 500;
            t1.MinAge = 2;
            t1.MaxAge = 5;
            toys.Add(t1);

            Toy t2 = new Toy();
            t2.Name = "Машинка";
            t2.Price = 300;
            t2.MinAge = 3;
            t2.MaxAge = 6;
            toys.Add(t2);

            Toy t3 = new Toy();
            t3.Name = "Погремушка";
            t3.Price = 150;
            t3.MinAge = 0;
            t3.MaxAge = 1;
            toys.Add(t3);

            return toys;
        }

        public static void Task5(string filename)
        {
            List<Toy> toys = CreateAndFillToys();
            XmlSerializer serializer = 
                new XmlSerializer(typeof(List<Toy>));
            
            try
            {
                using (Stream stream = File.Create(filename))
                {
                    serializer.Serialize(stream, toys);
                }
                Console.WriteLine("Содержимое XML-файла:");
                
                using (StreamReader reader = 
                       new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                using (Stream stream = File.OpenRead(filename))
                {
                    List<Toy> loaded = 
                        (List<Toy>)serializer.Deserialize(stream);
                    decimal minPrice = decimal.MaxValue;
                    string cheapest = "";

                    foreach (Toy t in loaded)
                    {
                        if (t.Price < minPrice)
                        {
                            minPrice = t.Price;
                            cheapest = t.Name;
                        }
                    }
                    Console.WriteLine($"\nСамая дешевая:" +
                                      $" {cheapest}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
        
        public static void CreateAndFillFile6(string filename)
        {
            Random rnd = new Random();
            using (StreamWriter writer = 
                   new StreamWriter(filename))
            {
                for (int i = 0; i < 15; i++)
                {
                    writer.WriteLine(rnd.Next(-50, 50)); 
                }
            }
        }

        public static void Task6(string filename)
        {
            CreateAndFillFile6(filename);
            int min = int.MaxValue;
            int max = int.MinValue;

            Console.WriteLine("Содержимое файла:");
            using (StreamReader reader = 
                   new StreamReader(filename))
            {
                string line = " ";
                while ((line = reader.ReadLine()) != null)
                {
                    Console.Write(line + " "); 
                    int num = 0;
                    if (int.TryParse(line, out num))
                    {
                        if (num < min) { min = num; }
                        if (num > max) { max = num; }
                    }
                }
            }
            Console.WriteLine(); 

            int diff = max - min;
            int result = diff * diff; 

            Console.WriteLine($"Минимальное число: {min}");
            Console.WriteLine($"Максимальное число: {max}");
            Console.WriteLine($"Разность: {diff}");
            Console.WriteLine($"Квадрат разности: {result}");
        }

        public static void CreateAndFillFile7(string filename)
        {
            Random rnd = new Random();
            using (StreamWriter writer = 
                   new StreamWriter(filename))
            {
                for (int i = 0; i < 5; i++)
                {
                    int n1 = rnd.Next(1, 50);
                    int n2 = rnd.Next(1, 50);
                    int n3 = rnd.Next(1, 50);
                    writer.WriteLine($"{n1} {n2} {n3}");
                }
            }
        }

        public static void Task7(string filename)
        {
            CreateAndFillFile7(filename);
            int sum = 0;

            Console.WriteLine("Содержимое файла:");
            using (StreamReader reader = 
                   new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line); 
                    
                    string[] parts = line.Split(
                        new char[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach (string p in parts)
                    {
                        int num = 0;
                        if (int.TryParse(p, out num) 
                            && num % 2 != 0)
                        {
                            sum += num;
                        }
                    }
                }
            }
            Console.WriteLine($"\nСумма нечетных элементов:" +
                              $" {sum}");
        }

        public static void CreateInputFile8(string filename)
        {
            string[] lines = 
            { 
                "Первая строка", 
                "Вторая строка", 
                "", 
                "Третья!" 
            };
            File.WriteAllLines(filename, lines);
        }

        public static void Task8(string inputFile, 
                                string outputFile)
        {
            CreateInputFile8(inputFile);
            string[] allLines = File.ReadAllLines(inputFile);

            Console.WriteLine("Исходный файл:");
            foreach (string line in allLines)
            {
                Console.WriteLine($"'{line}'");
            }

            using (StreamWriter writer = 
                   new StreamWriter(outputFile))
            {
                foreach (string line in allLines)
                {
                    if (line.Length > 0)
                    {
                        char lastChar = line[line.Length - 1];
                        writer.WriteLine(lastChar);
                    }
                    else
                    {
                        writer.WriteLine(); 
                    }
                }
            }

            Console.WriteLine("\nНовый файл:");
            string[] resultLines = 
                File.ReadAllLines(outputFile);
            foreach (string line in resultLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
