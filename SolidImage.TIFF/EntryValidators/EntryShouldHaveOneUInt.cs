namespace SolidImage.TIFF;

public class EntryShouldHaveOneUInt : IEntryValidator
{
    public Exception? Validate(TiffCodec codec, ushort tagCode, ushort typeCode, uint count)
    {
        if ((typeCode != TiffTypes.UINT16 && typeCode != TiffTypes.UINT32) || count != 1)
            return new ArgumentException(
                $"{codec.GetTagName(tagCode)}[{tagCode}] should have 1 {codec.GetTypeName(TiffTypes.UINT16)} or {codec.GetTypeName(TiffTypes.UINT32)}  value");

        return null;
    }
}