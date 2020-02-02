using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class PdfTools
    {
        public static Point GetTextCoordinate(string textToFind, string pdfFilename, int pageNumber)
        {
            var textToFound = textToFind.ToCharArray();
            var texts = ExtractText(pdfFilename, pageNumber);

            (var chars, var points) = getAllPoints(texts);

            var position = SearchForChar(textToFound, chars.ToArray());

            if(position == -1) return new Point("-1,-1");

            var X = (points[position].X + points[position + textToFound.Length - 1].X) / 2;
            var Y = points[position].Y;

            return new Point($"{X}{Constants.PointSeparator}{Y}");
        }

        public static (List<char> chars, List<Point> points) getAllPoints(string texts)
        {
            string[] textList = texts.Split(Constants.MainSeparator);
            var chars = new List<char>();
            var points = new List<Point>();

            foreach (var text in textList)
            {
                if (text != "")
                {
                    var pointChar = text.Split(Constants.CharSeparator);
                    chars.Add(pointChar[0].ToCharArray()[0]);
                    points.Add(new Point(pointChar[1]));
                }
            }

            return (chars, points);
        }

        public static string ExtractText(string pdfFilename, int pageNumber)
        {
            PdfReader reader = new PdfReader(pdfFilename);
            MyTextRenderListener listener = new MyTextRenderListener();
            PdfContentStreamProcessor processor = new PdfContentStreamProcessor(listener);
            PdfDictionary pageDic = reader.GetPageN(pageNumber);
            PdfDictionary resourcesDic = pageDic.GetAsDict(PdfName.RESOURCES);
            processor.ProcessContent(ContentByteUtils.GetContentBytesForPage(reader, 1), resourcesDic);
            return listener.Text.ToString();
        }

        public class MyTextRenderListener : IRenderListener
        {
            public StringBuilder Text { get; set; }

            public MyTextRenderListener()
            {
                Text = new StringBuilder();
            }
            public void BeginTextBlock()
            {
                //Text.Append(" < ");
            }
            public void EndTextBlock()
            {
                //Text.AppendLine(">");
            }
            public void RenderImage(ImageRenderInfo renderInfo)
            {
            }
            public void RenderText(TextRenderInfo renderInfo)
            {
                Text.Append(renderInfo.GetText());
                LineSegment segment = renderInfo.GetBaseline();
                Vector start = segment.GetStartPoint();
                Text.Append(Constants.CharSeparator);
                Text.Append(start[Vector.I1]);
                Text.Append(Constants.PointSeparator);
                Text.Append(start[Vector.I2]);
                Text.Append(Constants.MainSeparator);
            }
        }

        public static int SearchForChar(char[] substring, char[] fulltext)
        {
            //all of the start points
            var indices = fulltext.Select((b, i) => b == substring.FirstOrDefault() ? i : -1)
                                  .Where(i => i != -1).ToArray();

            //search each start point
            foreach (var index in indices)
            {
                var found = true;
                int count = 0;
                for (int i = index; i < index + substring.Length; i++)
                {
                    found = true;
                    if (substring[count++] != fulltext[i])
                    {
                        found = false;
                        break;
                    }
                }
                if (found) return index;
            }
            return -1;
        }
    }   
}