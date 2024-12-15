using SolidImage.TIFF;

internal class Program
{
    private static void PrintTiff(string path)
    {
        using var file = File.OpenRead(path);

        var tiffCodec = new TiffCodec();

        var tiff = tiffCodec.DecodeOnlyDirectories(file);

        foreach (var ifd in tiff.Subfiles.Select(subfile => subfile.ImageFileDirectory))
        {
            Console.WriteLine($"SubfileType = {ifd.GetSubfileType()}");
            Console.WriteLine($"Size = {ifd.GetImageWidth()} * {ifd.GetImageHeight()}");
            Console.WriteLine($"BitsPerSample = {ifd.GetBitsPerSample()}");
            Console.WriteLine($"Compression = {ifd.GetCompression()}");
            Console.WriteLine($"Photometric = {ifd.GetPhotometric()}");

            Console.WriteLine($"FillOrder = {ifd.GetFillOrder()}");

            Console.WriteLine($"SamplesPerPixel = {ifd.GetSamplesPerPixel()}");

            Console.WriteLine($"RowsPerStrip = {ifd.GetRowsPerStripe()}");

            Console.WriteLine($"XResolution = {ifd.GetXResolution()}");
            Console.WriteLine($"YResolution = {ifd.GetYResolution()}");
            Console.WriteLine($"ResolutionUnit = {ifd.GetResolutionUnit()}");

            Console.WriteLine($"Predictor = {ifd.GetPredictor()}");

            Console.WriteLine($"|StripOffsets| = {ifd.GetStripOffsets()?.Length}");
            Console.WriteLine($"|StripByteCounts| = {ifd.GetStripByteCounts()?.Length}");


            var stripOffsets = ifd.GetStripOffsets() ?? [];
            Console.Write($"StripOffsets[{stripOffsets.Length}] = ");
            foreach (var stripOffset in stripOffsets) Console.Write($"{stripOffset}, ");
            Console.WriteLine();

            var stripByteCounts = ifd.GetStripByteCounts() ?? [];
            Console.Write($"StripByteCounts[{stripByteCounts.Length}] = ");
            foreach (var stripByteCount in stripByteCounts) Console.Write($"{stripByteCount}, ");
            Console.WriteLine();
        }
    }

    private static void Main(string[] args)
    {
        PrintTiff(@"..\..\..\..\..\_Temp\tiff-test\1\spring.tif");
    }
}