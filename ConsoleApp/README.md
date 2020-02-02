Get Text Coordinate in PDF file
-------------------------------

```csharp
var pdfFilename = @"PathToYourPDF\random.pdf";
var textToFind = "Lombok";
var pageNumber = 1;
var point = PdfTools.GetTextCoordinate(textToFind, pdfFilename , pageNumber);
Console.WriteLine($"{point.X},{point.Y}");
```

If the text is not found,  ```point.X = point.Y = -1```