using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var point = PdfTools.GetTextCoordinate("Lombok", @"E:\random.pdf", 1);

            Console.WriteLine($"{point.X},{point.Y}");

            Console.Read();
        }
       
    }
}
