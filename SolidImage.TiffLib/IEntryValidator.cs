namespace SolidImage.TiffLib;

public interface IEntryValidator
{
    Exception? Validate(ushort tagCode, ushort typeCode, uint count);
}
