namespace SolidImage.TIFF;

public class TiffSubfile
{
    private byte[][] _data = null!;
    public ImageFileDirectory ImageFileDirectory { get; protected internal set; } = null!;
}