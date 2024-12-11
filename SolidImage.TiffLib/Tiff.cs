namespace SolidImage.TiffLib;

public class Tiff
{
    public ByteOrder ByteOrder { get; internal protected set; }

    public ushort Identifier { get; internal protected set; }

    public List<ImageFileDirectory> ImageFileDirectories { get; internal protected set; } = default!;
}
