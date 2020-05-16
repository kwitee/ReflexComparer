using ReflexComparer;
using ReflexComparerPerformanceTests.TestsClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ReflexComparerPerformanceTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MeasureIntPropertyClassComparasions();
            Console.ReadLine();
        }

        private static void MeasureIntPropertyClassComparasions()
        {
            var tuples = GenerateRandomIntPropertyClassPairs();

            var value = MeasureComparer(new IntPropertyClassEqualityComparer(), tuples);
            var valueReflection = MeasureComparer(ComparerFactory.CreateRecursiveReflectionComparer<IntPropertyClass>(), tuples);

            Console.WriteLine($"{NumberOfCompares} comparasions. Native comparer: {value} miliseconds, " +
                $"reflection comparer: {valueReflection} miliseconds. ");
        }

        private static long MeasureComparer(
            IEqualityComparer<IntPropertyClass> comparer, ICollection<(IntPropertyClass, IntPropertyClass)> pairs)
        {
            var watch = Stopwatch.StartNew();

            foreach (var pair in pairs)
            {
                comparer.Equals(pair.Item1, pair.Item2);
            }

            return watch.ElapsedMilliseconds;
        }

        private const int MaxRandomNumber = 10;

        private static int GetRandomInt(Random random)
        {
            return random.Next(0, MaxRandomNumber);
        }

        private static IntPropertyClass GetRandomIntPropertyClass(Random random)
        {
            return new IntPropertyClass(GetRandomInt(random));
        }

        private const int NumberOfCompares = 1000000;

        private static ICollection<(IntPropertyClass, IntPropertyClass)> GenerateRandomIntPropertyClassPairs()
        {
            var tuples = new List<(IntPropertyClass, IntPropertyClass)>();
            var random = new Random();

            for (int i = 0; i < NumberOfCompares; i++)
            {
                tuples.Add((GetRandomIntPropertyClass(random), GetRandomIntPropertyClass(random)));
            }

            return tuples;
        }
    }
}