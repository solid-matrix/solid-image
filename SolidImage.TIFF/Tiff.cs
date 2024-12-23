using SolidBase.BitsOp;

namespace SolidImage.TIFF;

public class Tiff
{
    public ByteOrder ByteOrder { get; protected internal set; } =
        BitConverter.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

    public ushort Identifier { get; set; } = 42;

    public List<TiffImage> Images { get; protected internal set; } = [];

    public TiffOptions Options { get; set; } = TiffOptions.Default;

    internal Tiff() { }

    public static void Encode(Tiff tiff, Stream stream)
    {
        Encode(tiff, stream, TiffOptions.Default);
    }

    public static void Encode(Tiff tiff, Stream stream, TiffOptions options)
    {
        throw new NotImplementedException();
    }

    public static Tiff DecodeDirectories(Stream stream)
    {
        return DecodeDirectories(stream, TiffOptions.Default);
    }

    public static Tiff DecodeDirectories(Stream stream, TiffOptions options)
    {
        var tiff = new Tiff
        {
            ByteOrder = (ByteOrder)((stream.ReadByte() << 8) | stream.ReadByte()),
            Options = options,
        };

        var endianReader = new EndianReaderBase(stream, tiff.ByteOrder switch
        {
            ByteOrder.LittleEndian => IEndianCodec.CreateLittleEndianCodec(),
            ByteOrder.BigEndian => IEndianCodec.CreateBigEndianCodec(),
            _ => throw new NotSupportedException("not supported endian value")
        });

        tiff.Identifier = endianReader.ReadUInt16();

        var nextDirectoryOffset = endianReader.ReadUInt32();

        while (true)
        {
            var image = new TiffImage
            {
                Parent = tiff,
            };

            stream.Seek(nextDirectoryOffset, SeekOrigin.Begin);

            var entryCount = endianReader.ReadUInt16();

            for (int i = 0; i < entryCount; i++)
            {
                var entry = new DirectoryEntry
                {
                    TagCode = endianReader.ReadUInt16(),
                    TypeCode = endianReader.ReadUInt16(),
                    Count = endianReader.ReadUInt32()
                };

                if (!options.TryGetTypeSize(entry.TypeCode, out var typeSize))
                {
                    Console.WriteLine($"type [{entry.TypeCode}] not supported, omitted");
                    continue;
                }

                entry.TypeSize = typeSize;

                var dataLen = (int)(entry.Count * entry.TypeSize);

                entry.Data = new byte[dataLen];

                if (dataLen <= 4)
                {
                    var buffer = new byte[4];
                    stream.ReadExactly(buffer, 0, 4);
                    Array.Copy(buffer, 0, entry.Data, 0, dataLen);
                }
                else
                {
                    var valueOrOffset = endianReader.ReadUInt32();

                    var prev = stream.Position;
                    stream.Seek(valueOrOffset, SeekOrigin.Begin);
                    stream.ReadExactly(entry.Data, 0, dataLen);
                    stream.Seek(prev, SeekOrigin.Begin);
                }

                if (!options.TryGetTagName(entry.TagCode, out _))
                {
                    options.TryGetTypeName(entry.TypeCode, out var typeName);
                    Console.WriteLine($"tag [{entry.TagCode}] with type={typeName} and count={entry.Count} not supported, omitted");
                    continue;
                }

                image.EntryMap.Add(entry.TagCode, entry);
            }

            tiff.Images.Add(image);

            nextDirectoryOffset = endianReader.ReadUInt32();
            if (nextDirectoryOffset == 0) break;
        }

        return tiff;
    }

    public static Tiff Decode(Stream stream)
    {
        return Decode(stream, TiffOptions.Default);
    }

    public static Tiff Decode(Stream stream, TiffOptions options)
    {
        var tiff = DecodeDirectories(stream, options);

        foreach (var image in tiff.Images)
        {
            //image.str
        }

        return tiff;
    }
}