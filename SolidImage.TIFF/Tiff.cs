namespace SolidImage.TIFF;

public class Tiff
{
    public ByteOrder ByteOrder { get; protected internal set; }

    public ushort Identifier { get; protected internal set; }

    public List<TiffSubfile> Subfiles { get; protected internal set; } = [];
}