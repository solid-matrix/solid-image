namespace SolidImage.TIFF;

public class DirectoryEntry
{
    public ushort TagCode { get; internal set; }

    public ushort TypeCode { get; internal set; }

    public int TypeSize { get; internal set; }

    public uint Count { get; internal set; }

    public byte[] Data { get; internal set; } = null!;
}