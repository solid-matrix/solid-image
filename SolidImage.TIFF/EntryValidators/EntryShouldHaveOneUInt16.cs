namespace SolidImage.TIFF;

public class EntryShouldHaveOneUInt16 : IEntryValidator
{
    public Exception? Validate(TiffCodec codec, ushort tagCode, ushort typeCode, uint count)
    {
        if (typeCode != TiffTypes.UINT16 || count != 1)
            return new ArgumentException(
                $"{codec.GetTagName(tagCode)} should have 1 {codec.GetTypeName(TiffTypes.UINT16)} value");

        return null;
    }
}