using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pdfFilename = @"E:\random.pdf";
            int pageNumber = 1;
            var point = PdfTools.GetTextCoordinate("{{SIGNHERE}}", pdfFilename , pageNumber);

            Console.WriteLine($"{point.X},{point.Y}");
        }
    }
}