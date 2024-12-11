using SolidImage.TiffLib;
using SolidImage.TiffLib.JC;

string[] folders = [
    @".\..\..\..\..\..\_Temp\JCFormats\241212",
];

TiffCodecJCExtension.Register();

var paths = folders.Select(folder => Directory.GetFiles(folder, "*.tif*")).SelectMany(path => path);

foreach (var path in paths)
{
    using var file = File.OpenRead(path);

    Console.WriteLine(path);

    var tiff = TiffCodec.Decode(file);

    //Console.WriteLine($"\t Endian = {tiff.ByteOrder}");

    foreach (var ifd in tiff.ImageFileDirectories)
    {
        Console.WriteLine($"\t ----------------------------------------------------------------");

        Console.WriteLine($"\t\t SubfileType = {ifd.GetSubfileType()}");
        Console.WriteLine($"\t\t Size = {ifd.GetImageWidth()} * {ifd.GetImageHeight()}");
        Console.WriteLine($"\t\t BitsPerSample = {ifd.GetBitsPerSample()}");
        Console.WriteLine($"\t\t Compression = {ifd.GetCompression()}");
        Console.WriteLine($"\t\t Photometric = {ifd.GetPhotometric()}");
        Console.WriteLine($"\t\t FillOrder = {ifd.GetFillOrder()}");

        Console.WriteLine($"\t\t |StripOffsets| = {ifd.GetStripOffsets()?.Length}");
        //Console.Write("[");
        //foreach (var offset in ifd.GetStripOffsets() ?? []) Console.Write($"{offset}, ");
        //Console.WriteLine("]");

        Console.WriteLine($"\t\t SamplesPerPixel = {ifd.GetSamplesPerPixel()}");
        Console.WriteLine($"\t\t RowsPerStrip = {ifd.GetRowsPerStripe()}");
        Console.WriteLine($"\t\t |StripByteCounts| = {ifd.GetStripByteCounts()?.Length}");
        Console.WriteLine($"\t\t XResolution = {ifd.GetXResolution()}");
        Console.WriteLine($"\t\t YResolution = {ifd.GetYResolution()}");
        Console.WriteLine($"\t\t ResolutionUnit = {ifd.GetResolutionUnit()}");

        //Console.WriteLine($"\t\t JC1 = {ifd.GetJC1String()}");
        //Console.WriteLine($"\t\t JC2 = {ifd.GetJC2String()}");

        Console.WriteLine($"\t\t |ColorMap| = {ifd.GetColorMap().Length}");

        Console.Write("[");
        foreach (var v in ifd.GetColorMap() ?? []) Console.Write($"{v / 256}, ");
        Console.WriteLine("]");


        //foreach (var pair in ifd.EntryMap)
        //{
        //    var entry = pair.Value;
        //    Console.WriteLine($"\t\t {TiffCodec.GetTagName(entry.TagCode),-28} {TiffCodec.GetTypeName(entry.TypeCode),-12}* {entry.Count,-6} = ");
        //}
    }

    Console.WriteLine();
}