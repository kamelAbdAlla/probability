using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of items: ");
            int n = int.Parse(Console.ReadLine());

            int[] values = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter value {i + 1}: ");
                values[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(values);

            // Median
            double median;
            if (n % 2 == 0)
            {
                median = (values[n / 2] + values[n / 2 - 1]) / 2.0;
            }
            else
            {
                median = values[n / 2];
            }
            Console.WriteLine($"Median: {median}");

            // Mode
            int modeFrequency = 0;
            int modeValue = 0;
            foreach (int value in values.Distinct())
            {
                int frequency = values.Count(x => x == value);
                if (frequency > modeFrequency)
                {
                    modeFrequency = frequency;
                    modeValue = value;
                }
            }
            Console.WriteLine($"Mode: {modeValue}");

            // Range
            int range = values.Max() - values.Min();
            Console.WriteLine($"Range: {range}");

            // Quartiles
            int q1 = CalculateQuartile(values, 0.25);
            Console.WriteLine($"First Quartile: {q1}");
            int q3 = CalculateQuartile(values, 0.75);
            Console.WriteLine($"Third Quartile: {q3}");

            // P90
            int p90Index = (int)Math.Ceiling(n * 0.9) - 1;
            int p90 = values[p90Index];
            Console.WriteLine($"P90: {p90}");

            // Interquartile range
            int interquartileRange = q3 - q1;
            Console.WriteLine($"Interquartile range: {interquartileRange}");

            // Outliers
            int lowerOutlierBoundary = (int)(q1 - 1.5 * interquartileRange);
            int upperOutlierBoundary = (int)(q3 + 1.5 * interquartileRange);
            Console.WriteLine($"Outlier boundaries: ({lowerOutlierBoundary}, {upperOutlierBoundary})");

            Console.Write("Enter a value to check for outliers: ");
            int input = int.Parse(Console.ReadLine());
            if (input < lowerOutlierBoundary || input > upperOutlierBoundary)
            {
                Console.WriteLine("The input is an outlier.");
            }
            else
            {
                Console.WriteLine("The input is not an outlier.");
            }
            Console.ReadKey();
        }

        static int CalculateQuartile(int[] values, double percentile)
        {
            int index = (int)Math.Ceiling(values.Length * percentile) - 1;
            if (index < 0)
            {
                return values[0];
            }
            else if (index >= values.Length - 1)
            {
                return values[values.Length - 1];
            }
            else
            {
                double lowerValue = values[index];
                double upperValue = values[index + 1];
                double fraction = values.Length * percentile - index - 1;
                return (int)Math.Round(lowerValue * (1 - fraction) + upperValue * fraction);

            }
            
        }


    }
}
