namespace SolidImage.TIFF;

public interface IEntryValidator
{
    Exception? Validate(TiffCodec codec, ushort tagCode, ushort typeCode, uint count);
}