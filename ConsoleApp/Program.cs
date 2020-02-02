using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pdfFilename = @"E:\random.pdf";

            var point = PdfTools.GetTextCoordinate("Lombok", pdfFilename , 1);

            Console.WriteLine($"{point.X},{point.Y}");
        }
    }
}