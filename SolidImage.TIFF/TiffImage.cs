using SolidBase.BitsOp;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidImage.TIFF;

public class TiffImage
{
    public Tiff Parent { get; set; } = null!;

    public Dictionary<ushort, DirectoryEntry> EntryMap { get; internal set; } = [];

    internal byte[][] _data = null!;

    internal IEndianCodec EndianCodec => Parent.ByteOrder switch
    {
        ByteOrder.LittleEndian => IEndianCodec.CreateLittleEndianCodec(),
        ByteOrder.BigEndian => IEndianCodec.CreateBigEndianCodec(),
        _ => throw new NotSupportedException("not supported endian value")
    };

    internal TiffImage() { }

    public bool TryGetEntry(ushort tagCode, out DirectoryEntry entry) => EntryMap.TryGetValue(tagCode, out entry!);

    public bool TryGetEntryUInt8(ushort tagCode, out byte value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 1) return false;
        if (entry.Count <= 0) return false;

        value = entry.Data[0];
        return true;
    }

    public bool TryGetEntryUInt8Range(ushort tagCode, out ReadOnlySpan<byte> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 1) return false;

        values = entry.Data;
        return true;
    }

    public bool TryGetEntryInt8(ushort tagCode, out sbyte value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 1) return false;
        if (entry.Count <= 0) return false;

        value = (sbyte)entry.Data[0];
        return true;
    }

    public bool TryGetEntryInt8Range(ushort tagCode, out ReadOnlySpan<sbyte> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 1) return false;

        values = MemoryMarshal.Cast<byte, sbyte>(entry.Data);
        return true;
    }

    public bool TryGetEntryUInt16(ushort tagCode, out ushort value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 2) return false;
        if (entry.Count <= 0) return false;

        value = EndianCodec.ReadUInt16(entry.Data);
        return true;
    }

    public bool TryGetEntryUInt16Range(ushort tagCode, out ReadOnlySpan<ushort> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 2) return false;

        values = EndianCodec.ReadUInt16Range(entry.Data);
        return true;
    }

    public bool TryGetEntryInt16(ushort tagCode, out short value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 2) return false;
        if (entry.Count <= 0) return false;

        value = EndianCodec.ReadInt16(entry.Data);
        return true;
    }

    public bool TryGetEntryInt16Range(ushort tagCode, out ReadOnlySpan<short> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 2) return false;

        values = EndianCodec.ReadInt16Range(entry.Data);
        return true;
    }

    public bool TryGetEntryUInt32(ushort tagCode, out uint value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 4) return false;
        if (entry.Count <= 0) return false;

        value = EndianCodec.ReadUInt32(entry.Data);
        return true;
    }

    public bool TryGetEntryUInt32Range(ushort tagCode, out ReadOnlySpan<uint> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 4) return false;

        values = EndianCodec.ReadUInt32Range(entry.Data);
        return true;
    }

    public bool TryGetEntryInt32(ushort tagCode, out int value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 4) return false;
        if (entry.Count <= 0) return false;

        value = EndianCodec.ReadInt32(entry.Data);
        return true;
    }

    public bool TryGetEntryInt32Range(ushort tagCode, out ReadOnlySpan<int> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 4) return false;

        values = EndianCodec.ReadInt32Range(entry.Data);
        return true;
    }

    public bool TryGetEntryURational(ushort tagCode, out URational value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 8) return false;
        if (entry.Count <= 0) return false;

        var values = EndianCodec.ReadUInt32Range(entry.Data);
        value = new URational
        {
            Numerator = values[0],
            Denominator = values[1],
        };
        return true;
    }

    public bool TryGetEntryURationalRange(ushort tagCode, out ReadOnlySpan<URational> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 8) return false;

        var tmp = EndianCodec.ReadUInt32Range(entry.Data);
        values = MemoryMarshal.Cast<uint, URational>(tmp);
        return true;
    }

    public bool TryGetEntryRational(ushort tagCode, out Rational value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 8) return false;
        if (entry.Count <= 0) return false;

        var values = EndianCodec.ReadInt32Range(entry.Data);
        value = new Rational
        {
            Numerator = values[0],
            Denominator = values[1],
        };
        return true;
    }

    public bool TryGetEntryRationalRange(ushort tagCode, out ReadOnlySpan<Rational> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 8) return false;

        var tmp = EndianCodec.ReadInt32Range(entry.Data);
        values = MemoryMarshal.Cast<int, Rational>(tmp);
        return true;
    }

    public bool TryGetEntrySingle(ushort tagCode, out float value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 4) return false;
        if (entry.Count <= 0) return false;

        value = EndianCodec.ReadSingle(entry.Data);
        return true;
    }

    public bool TryGetEntrySingleRange(ushort tagCode, out ReadOnlySpan<float> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 4) return false;

        values = EndianCodec.ReadSingleRange(entry.Data);
        return true;
    }

    public bool TryGetEntryDouble(ushort tagCode, out double value)
    {
        value = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 8) return false;
        if (entry.Count <= 0) return false;

        value = EndianCodec.ReadDouble(entry.Data);
        return true;
    }

    public bool TryGetEntryDoubleRange(ushort tagCode, out ReadOnlySpan<double> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 8) return false;

        values = EndianCodec.ReadDoubleRange(entry.Data);
        return true;
    }

    public bool TryGetEntryAscii(ushort tagCode, out string value)
    {
        value = default!;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 1) return false;

        if (entry.Count == 0)
            value = string.Empty;
        else
            value = Encoding.ASCII.GetString(entry.Data);

        return true;
    }

    public bool TryGetEntryUtf8(ushort tagCode, out string value)
    {
        value = default!;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;
        if (entry.TypeSize != 1) return false;

        if (entry.Count == 0)
            value = string.Empty;
        else
            value = Encoding.UTF8.GetString(entry.Data);

        return true;
    }

    public bool TryGetEntryUInt16Or32Range(ushort tagCode, out ReadOnlySpan<uint> values)
    {
        values = default;
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return false;

        if (entry.TypeSize == 4) values = EndianCodec.ReadUInt32Range(entry.Data);

        if (entry.TypeSize == 2) values = EndianCodec.ReadUInt16Range(entry.Data).ToArray().Select(v => (uint)v).ToArray();

        return false;
    }

    public string? GetEntryPrintString(ushort tagCode)
    {
        if (!EntryMap.TryGetValue(tagCode, out var entry)) return null;

        if (entry.Count <= 0) return null;

        if (entry.TypeCode == TiffTypes.UBYTE)
        {
            if (!TryGetEntryUInt8Range(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.SBYTE)
        {
            if (!TryGetEntryInt8Range(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.UINT16)
        {
            if (!TryGetEntryUInt16Range(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.SINT16)
        {
            if (!TryGetEntryInt16Range(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.UINT32)
        {
            if (!TryGetEntryUInt32Range(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.SINT32)
        {
            if (!TryGetEntryInt32Range(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.URATIONAL)
        {
            if (!TryGetEntryURationalRange(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.SRATIONAL)
        {
            if (!TryGetEntryRationalRange(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.FLOAT)
        {
            if (!TryGetEntrySingleRange(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.DOUBLE)
        {
            if (!TryGetEntryDoubleRange(tagCode, out var values)) return null;
            return "[" + string.Join(',', values.ToArray().Select(a => a.ToString())) + "]";
        }

        if (entry.TypeCode == TiffTypes.ASCII)
        {
            if (!TryGetEntryAscii(tagCode, out var values)) return null;
            return values;
        }

        if (entry.TypeCode == TiffTypes.UNDEFINED)
        {
            if (!TryGetEntryUtf8(tagCode, out var values)) return null;
            return values;
        }

        return null;
    }
}