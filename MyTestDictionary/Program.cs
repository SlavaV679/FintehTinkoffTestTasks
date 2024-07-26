using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a1 = new A();
            var a2 = new A();
            var a3 = a2;

            var b1 = new B();
            var b2 = new B();

            var int1 = new int();
            var int2 = new int();
            int1 = 1; int2 = 2;

            var dA = new Dictionary<A, object>();
            var dB = new Dictionary<B, object>();
            var dInt = new Dictionary<int, object>();

            dA.Add(a1, "oneA");
            dA.Add(a2, "towA");
            //dA.Add(a3, "threeA");

            dB.Add(b1, "oneB");
            dB.Add(b2, "twoB");

            dInt.Add(int1, "oneB");
            dInt.Add(int2, "twoB");

            Console.WriteLine($"a1: {dA[a1]}");
            Console.WriteLine($"a2: {dA[a2]}");

            Console.WriteLine($"b1: {dB[b1]}");
            Console.WriteLine($"b2: {dB[b2]}");

            // Пример использования Dictionary для хранения информации о студентах
            Dictionary<int, string> studentDictionary = new Dictionary<int, string>();

            // Добавление элементов в словарь
            studentDictionary.Add(1, "Alice");
            studentDictionary.Add(2, "Bob");
            studentDictionary.Add(3, "Charlie");

            // Получение значения по ключу
            string studentName = studentDictionary[2];

            // Проверка наличия ключа в словаре
            bool containsKey = studentDictionary.ContainsKey(3);

            // Изменение значения по ключу
            studentDictionary[1] = "Alicia";

            // Удаление элемента по ключу
            studentDictionary.Remove(2);

            // Вывод результатов
            Console.WriteLine($"Имя студента с ключом 1: {studentDictionary[1]}");
            Console.WriteLine($"Наличие ключа 3: {containsKey}");

            Console.ReadLine();
        }
    }

    public class A { }
    public struct B { }
}
