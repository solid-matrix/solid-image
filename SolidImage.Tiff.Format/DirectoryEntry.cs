using SolidImage.Tiff.Format.Enums;

namespace SolidImage.Tiff.Format;

public class DirectoryEntry
{
    public TiffTag Tag { get; internal set; }

    public TiffType Type { get; internal set; }

    public uint Count { get; internal set; }

    public byte[] ValueOrOffset { get; internal set; } = default!;

    public byte[]? PointerValue { get; internal set; }


    public long ByteCount => Count * TypeByteCount(Type);

    public bool IsValue => ByteCount <= 4;

    public bool IsOffset => ByteCount > 4;

    public static int TypeByteCount(TiffType type)
    {
        return type switch
        {
            TiffType.UByte => 1,
            TiffType.ASCII => 1,
            TiffType.UShort => 2,
            TiffType.ULong => 4,
            TiffType.URational => 8,
            TiffType.SByte => 1,
            TiffType.Undefined => 1,
            TiffType.SShort => 2,
            TiffType.SLong => 4,
            TiffType.SRational => 8,
            TiffType.Float => 4,
            TiffType.Double => 8,
            _ => throw new NotSupportedException()
        };
    }
}
