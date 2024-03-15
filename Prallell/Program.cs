namespace Prallell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Введите число");
                        int number = int.Parse(Console.ReadLine());
                        int factorial = 1;

                        int numberCount = 0;
                        int sum = 0;
                        Parallel.Invoke(() =>
                        {
                            numberCount = number.ToString().Length;
                        });
                        Parallel.Invoke(() =>
                        {
                            int tempNumber = number;
                            while (tempNumber > 0)
                            {
                                sum += tempNumber % 10;
                                tempNumber /= 10;
                            }
                        });

                        Console.WriteLine($"Сумма {sum}");
                        Console.WriteLine($"Количество цифр {numberCount}");

                        Parallel.For(1, number + 1, i =>
                        {
                            factorial *= i;
                        });
                        Console.WriteLine($"Факторила числа {number} - {factorial}");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Введите число 1");
                        int num1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введиет число 2");
                        int num2 = int.Parse(Console.ReadLine());

                        string fileName = @"D:\5zadanie.txt";

                        using (StreamWriter stream = new StreamWriter(fileName))
                        {
                            Parallel.For(num1, num2, i =>
                            {
                                for (int j = 1; j <= 10; j++)
                                {
                                    stream.WriteLine($"{i} * {j} = {i * j}");

                                }
                                stream.WriteLine();
                            });
                        }
                        Console.WriteLine($"Результат записан в {fileName}");
                    }
                    break;
                case 3:
                    {
                        string filePath = @"D:\4zadanie.txt";
                        List<int> numbers = new List<int>();
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (int.TryParse(line, out var number))
                                {
                                    numbers.Add(number);
                                }
                            }
                        }
                        Parallel.ForEach(numbers, number =>
                        {
                            int factorial = Factorial(number);
                            Console.WriteLine($"Факториал числа {number} = {factorial}");
                        });
                    }
                    break;
                case 4:
                    {


                        string filePath = @"D:\3zadanie.txt";
                        var numbers = File.ReadAllLines(filePath).AsParallel().Select(int.Parse);

                        int max = numbers.AsParallel().Max();
                        int min = numbers.AsParallel().Min();
                        int sum = numbers.AsParallel().Sum();

                        Console.WriteLine($"Максимум -> {max}");
                        Console.WriteLine($"Минимум -> {min}");
                        Console.WriteLine($"Сумма -> {sum}");
                    }
                    break;
            }
        }
        static int Factorial(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}