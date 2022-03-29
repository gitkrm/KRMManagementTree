using KRMManagementTree.Controllers;
using System;

namespace KRMManagementTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Example Management Tree");
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine($"{new EmployeeController().DisplayManagementTable()}");

            Console.ReadKey();
        }
    }
}
