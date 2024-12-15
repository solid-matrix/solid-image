using System.Runtime.InteropServices;
using System.Text;
using SolidBase.BitsOp;

namespace SolidImage.TIFF;

public class ImageFileDirectory
{
    private readonly IEndianCodec _endianCodec = IEndianCodec.CreateConsistentEndianCodec();
    public Dictionary<ushort, DirectoryEntry> EntryMap { get; internal set; } = [];

    public DirectoryEntry? GetEntry(ushort tagCode)
    {
        return EntryMap.GetValueOrDefault(tagCode);
    }

    public ushort? GetEntryUInt16(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT16)
            return _endianCodec.ReadUInt16(entry.Data);
        return null;
    }


    public uint? GetEntryUInt32(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT32)
            return _endianCodec.ReadUInt32(entry.Data);
        return null;
    }


    public ReadOnlySpan<ushort> GetEntryManyUInt16(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT16)
            return MemoryMarshal.Cast<byte, ushort>(entry.Data);
        return null;
    }

    public ReadOnlySpan<uint> GetEntryManyUInt32(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT32)
            return MemoryMarshal.Cast<byte, uint>(entry.Data);
        return null;
    }

    public decimal? GetEntryURational(ushort tagCode)
    {
        if (!EntryMap.TryGetValue(tagCode, out var entry) || entry.TypeCode != TiffTypes.URATIONAL) return null;

        var a = _endianCodec.ReadUInt32(new ReadOnlySpan<byte>(entry.Data, 0, 4));
        var b = _endianCodec.ReadUInt32(new ReadOnlySpan<byte>(entry.Data, 4, 4));

        return decimal.One * a / b;
    }

    public string? GetEntryUTF8(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) &&
            (entry.TypeCode == TiffTypes.UBYTE ||
             entry.TypeCode == TiffTypes.UNDEFINED ||
             entry.TypeCode == TiffTypes.ASCII))
            return Encoding.UTF8.GetString(entry.Data);

        return null;
    }

    public string? GetEntryASCII(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) &&
            (entry.TypeCode == TiffTypes.UBYTE ||
             entry.TypeCode == TiffTypes.UNDEFINED ||
             entry.TypeCode == TiffTypes.ASCII))
            return Encoding.ASCII.GetString(entry.Data);

        return null;
    }


    public bool TryGetEntry(ushort tagCode, out DirectoryEntry entry)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryValue(ushort tagCode, out object value)
    {
        throw new NotImplementedException();
    }


    public bool TryGetEntryUInt8(ushort tagCode, out byte value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryUInt8Range(ushort tagCode, out ReadOnlySpan<byte> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryInt8(ushort tagCode, out sbyte value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryInt8Range(ushort tagCode, out ReadOnlySpan<sbyte> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryUInt16(ushort tagCode, out ushort value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryUInt16Range(ushort tagCode, out ReadOnlySpan<ushort> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryInt16(ushort tagCode, out short value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryInt16Range(ushort tagCode, out ReadOnlySpan<short> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryUInt32(ushort tagCode, out uint value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryUInt32Range(ushort tagCode, out ReadOnlySpan<uint> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryURational(ushort tagCode, out decimal value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryURationalRange(ushort tagCode, out ReadOnlySpan<decimal> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryRational(ushort tagCode, out decimal value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryRationalRange(ushort tagCode, out ReadOnlySpan<decimal> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntrySingle(ushort tagCode, out float value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntrySingleRange(ushort tagCode, out ReadOnlySpan<float> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryDouble(ushort tagCode, out double value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryDoubleRange(ushort tagCode, out ReadOnlySpan<double> values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryAscii(ushort tagCode, out string value)
    {
        throw new NotImplementedException();
    }

    public bool TryGetEntryUtf8(ushort tagCode, out string value)
    {
        throw new NotImplementedException();
    }
}