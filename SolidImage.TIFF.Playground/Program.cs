using SolidImage.TIFF;
using SolidImage.TIFF.JC;

internal class Program
{
    private static void PrintTiffImage(TiffImage tiffImage)
    {
        foreach (var pair in tiffImage.EntryMap)
        {
            var entry = pair.Value;

            if (!tiffImage.Parent.Options.TryGetTagName(entry.TagCode, out var tagName))
            {
                continue;
            }

            if (!tiffImage.Parent.Options.TryGetTypeName(entry.TypeCode, out var typeName))
            {
                continue;
            }

            Console.WriteLine($"[{entry.TagCode,5}]{tagName,-25} [{entry.TypeCode,1}]{typeName,-10}*{entry.Count,6} = {tiffImage.GetEntryPrintString(entry.TagCode)}");
        }
    }

    private static void PrintTiff(string path)
    {
        using var file = File.OpenRead(path);

        var tiffOptions = new TiffOptions()
            .AddJCExtension();

        var tiff = Tiff.DecodeDirectories(file, tiffOptions);

        foreach (var tiffImage in tiff.Images)
        {

        }
    }

    private static void Main(string[] args)
    {
        PrintTiff(@"..\..\..\..\..\_Temp\JCFormats\241212\ok2.tif");
    }
}