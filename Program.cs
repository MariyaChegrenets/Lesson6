// (1) Задача 39: Напишите программу, которая перевернёт одномерный массив
// (последний элемент будет на первом месте, а первый - на последнем и т.д.)
// [1 2 3 4 5] -> [5 4 3 2 1]
// [6 7 3 6] -> [6 3 7 6]

// (2) Задача 40: Напишите программу, которая принимает на вход три числа
// и проверяет, может ли существовать треугольник со сторонами такой длины.
// Теорема о неравенстве треугольника: каждая сторона треугольника меньше суммы двух других сторон.

// (3) Задача 42: Напишите программу, которая будет преобразовывать десятичное число в двоичное.
// 45 -> 101101
// 3  -> 11
// 2  -> 10

// (4) Задача 44: Не используя рекурсию, выведите первые N чисел Фибоначчи. Первые два числа Фибоначчи: 0 и 1.
// Если N = 5 -> 0 1 1 2 3
// Если N = 3 -> 0 1 1
// Если N = 7 -> 0 1 1 2 3 5 8

// (5) Решение Задачи 44 с помощью массива

// (6) Задача 45: Напишите программу, которая будет создавать копию заданного массива с помощью поэлементного копирования.

Console.Write("Выберите задачу: ");
int n = Convert.ToInt32(Console.ReadLine());
if(n == 1)
    Task39();
else if(n == 2)
    Task40();
else if(n == 3)    
    Task42();
else if(n == 4)
    Task44();
else if(n == 5)
    Fibonacci();
else if(n == 6)
    Task45();

void Task39() // (1)
{
    const int LENGTH = 5;         //задаем длину массива с клавиатуры
    const int LEFT_RANGE = -10;      // задаем интервал для создания рандомных чисел
    const int RIGHT_RANGE = 10;

Console.WriteLine(Reverse(GetArray(LENGTH, LEFT_RANGE, RIGHT_RANGE)));
}

int[] GetArray(int length, int left_range, int right_range) // функция для создания массива
{
    int[] array = new int[length];
    for(int i=0; i< length; i++)
        array[i] = new Random().Next(left_range, right_range +1);
    Console.WriteLine(string.Join(",", array));    
    return array;    
}

string Reverse(int[] array)  // функция переворачивающая/реверсирующая массив
{
    int tmp = 0; // задаем временную переменную
    for(int i=0; i< array.Length / 2; i++)
    {
        tmp = array[i];
        array[i] = array[array.Length-1 -i];
        array[array.Length-1 -i] = tmp;
    }
    return string.Join(",", array);
}

void Task40()  // (2)
{
Console.Write("Введите число 1: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число 2: ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число 3: ");
int c = Convert.ToInt32(Console.ReadLine());

if(a< (b+c) && b< (a+c) && c< (a+b))
    Console.WriteLine("Triangle exists");
else
    Console.WriteLine("Triangle doesn't exist");
}

void Task42()  // (3)
{
    Console.Write("Input number: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(DecimalToBinary(n));
    Recursion(n);
}

string DecimalToBinary(int number)
{
    string output = "";
    while(number>0)
    {
        output += number % 2; // показывает остаток от деления на 2
        number /= 2;          // деление на 2 
    }
    char[] array = output.ToCharArray(); // разбиваем получившуюся строку на массив символов: [0, 0, 1]
    Array.Reverse(array);  // метод переворачивания массива: [1, 0, 0]
    return new String(array);  // конкатенация символов в строку: 100  = string.Join("", array)
}

void Recursion(int n) // решение задачи 42 методом рекурсии
{
    if(n == 0)
        return;
    Recursion(n/2);
    Console.Write(n%2);
}

void Task44()   // ( 4 )
{
    Console.Write("input number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.Write("0 1 ");
    int n1 = 0;
    int n2 = 1;
    int n3 = 0;
    for(int i = 0; i< number-2; i++)
    {
        n3 = n1 + n2;
        n1 = n2;
        n2 = n3;
        Console.Write(n3 +" ");
    }
}

void Fibonacci()   // ( 5 ) решение задачи 44 с помощью массива
{
    Console.Write("Input number: ");
    int length = Convert.ToInt32(Console.ReadLine());
    Console.Write("0 1 ");
    int[] array = new int[length];
    array[0] = 0;
    array[1] = 1;
    for(int i=2; i<array.Length; i++)
    {
        array[i] = array[i-1]+array[i-2];
        Console.Write(array[i]+ " ");
    }   
}

void Task45()  // ( 6 )
{
    Console.Write("Input number: ");
    int length = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[length];  // инициируем массив array с длиной, заданной вручную
    int[] copy = new int[length];   // инициируем массив copy в который сделаем копию массива array, 
                                    // поэтому длины массивой должны быть одинаковыми
    for(int i=0; i<length; i++)
    {
        array[i] = new Random().Next(0,10); // интервал выбрали произвольно
        copy[i] = array[i];
    }
    Console.WriteLine(string.Join(" ", array));
    Console.WriteLine(string.Join(" ", copy));    
}