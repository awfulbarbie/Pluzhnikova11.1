using System;

namespace lab11._1_console_
{
    class Matrix
    {
        //поля класса
        double[][] DoubleArray;
        int n;
        int m;

        public Matrix(int rows, int cols)       //конструктор массива
        {
            n = rows;
            m = cols;
            DoubleArray = new double[n][];
        }
        
        public void EnterElements()     //заполнение массива
        {
            try
            {
                for (int i = 0; i < n; i++)
                {
                    DoubleArray[i] = new double[n];
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"[{i},{j}] = ");
                        DoubleArray[i][j] = double.Parse(Console.ReadLine());
                    }

                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Ввод некорректных данных!");
                Environment.Exit(0); 
            }

        }
        
        public void PrintMatrix()        //Вывод массива на экран
        {
            for (int i = 0; i < DoubleArray.Length; i++)
            {
                for (int j = 0; j < DoubleArray[i].Length; j++)
                {
                    Console.Write(DoubleArray[i][j] + "\t");
                }
                Console.WriteLine();
            }

        }
        
        public void Sort()      //сортировка массива (отсортировать элементы каждой строки массива в порядке убывания)
        {
            for (var i = 0; i < DoubleArray.Length; ++i)
            {
                Array.Sort(DoubleArray[i]);
                Array.Reverse(DoubleArray[i]);
            }
        }
        
        public int ElementCount        //подсчет количества элементов в массиве (доступно только для чтения)
        {
            get { return n * m; }       //аксессор для чтения внутренней переменной класса
        }
        
        public double ScalarMultiply        //Увеличение на скаляр (доступно только для записи)
        {
            set     //аксессор для записи значения во внутреннее поле класса
            {
                double roundTo = Math.Pow(10, 1);
                for (int i = 0; i < DoubleArray.Length; i++)
                {
                    for (int j = 0; j < DoubleArray[i].Length; j++)
                    {
                        DoubleArray[i][j] = Math.Truncate((DoubleArray[i][j] += value) * roundTo) / roundTo;     //value - неявный параметр, содержащий значение, которое присваивается свойству
                    }

                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int m = 0;
            Console.Write("Введите количество строк: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.Write("Ошибка! Количество строк не может иметь отрицательное или нулевое значение!");
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Неверный формат ввода данных!");
                Environment.Exit(0);
            }

            Console.Write("Введите количество столбцов: ");
            try
            {
                m = Convert.ToInt32(Console.ReadLine());
                if (m <= 0)
                {
                    Console.Write("Ошибка! Количество столбцов не может иметь отрицательное или нулевое значение!");
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Неверный формат ввода данных!");
                Environment.Exit(0);
            }

            Matrix newMatrix = new Matrix(n, m);
            int command = 0;
            do
            {

                Console.Write("\nВыберите команду: \n" +
                        "Введите 1, чтобы заполнить массив\n" +
                        "Введите 2, чтобы вывести элементы массива\n" +
                        "Введите 3, чтобы отсоритровать элементы каждой строки в порядке убывания\n" +
                        "Введите 4, чтобы получить количество элементов в массиве\n" +
                        "Введите 5, чтобы увеличить значение всех элементов массива на скаляр\n");
                Console.WriteLine();
                Console.WriteLine("Введите число от 1 до 5");

                try
                {
                    command = Convert.ToInt32(Console.ReadLine());
                    if (command <= 0 || command > 5)
                    {
                        Console.WriteLine("Ошибка! Введите число от 1 до 5");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка! Неверный ввод данных!");
                }

                Console.WriteLine();

                switch (command)
                {
                    case 1:
                        newMatrix.EnterElements();
                        break;
                    case 2:
                        Console.WriteLine("Массив:");
                        newMatrix.PrintMatrix();
                        break;
                    case 3:
                        Console.WriteLine("Отсортированный массив: ");
                        newMatrix.Sort();
                        newMatrix.PrintMatrix();
                        break;
                    case 4:
                        Console.WriteLine($"Количество элементов в массиве: {newMatrix.ElementCount}");
                        break;
                    case 5:
                        Console.Write("Введите скаляр: ");
                        double scalar = 0;
                        try
                        {
                            scalar = Convert.ToDouble(Console.ReadLine());
                            if (scalar <= 0)
                            {
                                Console.WriteLine("Ошибка! Скаляр не может иметь отрицательное или нулевое значение!");
                                Environment.Exit(0);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка! Неверный формат ввода данных!");
                        }
                        newMatrix.ScalarMultiply = scalar;
                        newMatrix.PrintMatrix();

                        Console.WriteLine("Все элементы увеличены на скаляр");
                        break;

                }
            } while (command != 5);
            Console.WriteLine("Конец программы");
            } 

        }

    }

