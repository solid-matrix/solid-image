namespace SolidImage.TiffLib.EntryValidators;

public class EntryShouldHaveOneUInt : IEntryValidator
{
    public Exception? Validate(ushort tagCode, ushort typeCode, uint count)
    {
        if ((typeCode != TiffTypes.UINT16 && typeCode != TiffTypes.UINT32) || count != 1)
            return new ArgumentException($"{TiffCodec.GetTagName(tagCode)}[{tagCode}] should have 1 {TiffCodec.GetTypeName(TiffTypes.UINT16)} or {TiffCodec.GetTypeName(TiffTypes.UINT32)}  value");

        return null;
    }
}
