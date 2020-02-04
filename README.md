Get Text Coordinate in PDF file using .Net Core (C#)
-------------------------------

## **How To Use**
```csharp
var pdfFilename = @"PathToYourPDF\random.pdf";
var textToFind = "Lombok";
var pageNumber = 1;
var point = PdfTools.GetTextCoordinate(textToFind, pdfFilename , pageNumber);
Console.WriteLine($"{point.X},{point.Y}");
```

If the text is not found,  ```point.X = point.Y = -1```

## How To Execute
```bash
git clone https://github.com/ronistiawan/get-text-coordinate-from-pdf.git
cd get-text-coordinate-from-pdf/ConsoleApp

dotnet run
```


