namespace SolidImage.TIFF;

public interface ITagValidator
{
    Exception? Validate(TiffOptions options, ushort tagCode, ushort typeCode, uint count);
}