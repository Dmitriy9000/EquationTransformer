using EquationTransformer.EquationProcessor;
using System;
using System.Collections.Generic;
using System.IO;

namespace EquationTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            var transformer = new EquationProcessor.EquationTransformer();

            if (args == null || args.Length != 1)
            {
                Console.WriteLine("Interactive mode. Press Ctrl+C to exit");
                while (true)
                {
                    var line = Console.ReadLine();
                    try
                    {
                        var result = transformer.Tranform(new Equation(line));
                        Console.WriteLine($"{line} => {result.ToString()}");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Unable to transform: {exception.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("File mode:");
                var file = args[0];
                if (!File.Exists(file))
                {
                    Console.WriteLine("Unable to find the file specified: " + file);
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }

                var lines = File.ReadAllLines(file);
                var outputFile = file + ".out";
                var resultSet = new List<string>();
                foreach (var l in lines)
                {
                    try
                    {
                        var e = new Equation(l);
                        resultSet.Add(transformer.Tranform(e).ToString());
                        
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Error: {exception.Message}");
                    }
                }
                File.AppendAllLines(outputFile, resultSet);
                Console.WriteLine($"{lines.Length} lines processed in {outputFile}");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }
        }
    }
}
