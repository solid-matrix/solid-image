namespace SolidImage.TIFF;

public class TagShouldHaveOneUInt16 : ITagValidator
{
    public Exception? Validate(TiffOptions options, ushort tagCode, ushort typeCode, uint count)
    {
        throw new NotImplementedException();
    }
}