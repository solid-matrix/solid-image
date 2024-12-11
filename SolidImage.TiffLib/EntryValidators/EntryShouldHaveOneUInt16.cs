namespace SolidImage.TiffLib.EntryValidators;

public class EntryShouldHaveOneUInt16 : IEntryValidator
{
    public Exception? Validate(ushort tagCode, ushort typeCode, uint count)
    {
        if (typeCode != TiffTypes.UINT16 || count != 1)
            return new ArgumentException($"{TiffCodec.GetTagName(tagCode)} should have 1 {TiffCodec.GetTypeName(TiffTypes.UINT16)} value");

        return null;
    }
}
