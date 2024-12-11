using System.Collections.Immutable;
using System.Text;

namespace SolidImage.TiffLib;

public unsafe class ImageFileDirectory
{
    public Dictionary<ushort, DirectoryEntry> EntryMap { get; internal set; } = default!;

    public DirectoryEntry? GetEntry(ushort tagCode)
    {
        return EntryMap.GetValueOrDefault(tagCode);
    }

    public ushort? GetEntryUInt16(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT16)
            return *((ushort*)(entry.Data));
        else
            return null;
    }

    public uint? GetEntryUInt32(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT32)
            return *((uint*)(entry.Data));
        else
            return null;
    }

    public ReadOnlySpan<ushort> GetEntryManyUInt16(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT16)
            return new ReadOnlySpan<ushort>((void*)entry.Data, (int)entry.Count);
        else
            return null;
    }

    public ReadOnlySpan<uint> GetEntryManyUInt32(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.UINT32)
            return new ReadOnlySpan<uint>((void*)entry.Data, (int)entry.Count);
        return null;
    }

    public decimal? GetEntryURational(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) && entry.TypeCode == TiffTypes.URATIONAL)
            return decimal.One * *((uint*)entry.Data) / *((uint*)entry.Data + 1);
        return null;
    }

    public string? GetEntryUTF8(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) &&
            (entry.TypeCode == TiffTypes.UBYTE ||
            entry.TypeCode == TiffTypes.UNDEFINED ||
            entry.TypeCode == TiffTypes.ASCII))
        {
            return Encoding.UTF8.GetString(new ReadOnlySpan<byte>((void*)entry.Data, (int)entry.Count));
        }

        return null;
    }

    public string? GetEntryASCII(ushort tagCode)
    {
        if (EntryMap.TryGetValue(tagCode, out var entry) &&
            (entry.TypeCode == TiffTypes.UBYTE ||
            entry.TypeCode == TiffTypes.UNDEFINED ||
            entry.TypeCode == TiffTypes.ASCII))
        {
            return Encoding.ASCII.GetString(new ReadOnlySpan<byte>((void*)entry.Data, (int)entry.Count));
        }

        return null;
    }


}