

namespace SolidImage.TiffLib.EntryValidators;

public class EntryShouldHaveOneUInt32 : IEntryValidator
{
    public Exception? Validate(ushort tagCode, ushort typeCode, uint count)
    {
        if (typeCode != TiffTypes.UINT32 || count != 1)
            return new ArgumentException($"{TiffCodec.GetTagName(tagCode)} should have 1 {TiffCodec.GetTypeName(TiffTypes.UINT32)} value");

        return null;
    }
}
