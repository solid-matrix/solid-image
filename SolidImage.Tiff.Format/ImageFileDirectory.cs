using SolidImage.Tiff.Format.Enums;
using SolidImage.Tiff.Format.Exceptions;

namespace SolidImage.Tiff.Format;

public class ImageFileDirectory
{
    public Tiff Parent { get; set; } = default!;

    public Dictionary<TiffTag, DirectoryEntry> EntryMap { get; internal set; } = default!;

    public DirectoryEntry? GetEntry(TiffTag tag)
    {
        if (EntryMap.TryGetValue(tag, out var entry)) return entry;
        return null;
    }

    public ushort? GetEntryUInt16(TiffTag tag)
    {
        if (EntryMap.TryGetValue(tag, out var entry))
        {
            if (entry.Count != 1) throw new TiffDirectoryEntryFormatException();
            if (entry.Type == TiffType.UShort) return Parent._bytesCodec.ReadUInt16(entry.ValueOrOffset);
            throw new TiffDirectoryEntryFormatException();
        }
        return null;
    }

    public void SetEntryUInt16(TiffTag tag, ushort value)
    {
        throw new TiffDirectoryEntryFormatException();
    }

    public uint? GetEntryUInt32(TiffTag tag)
    {
        if (EntryMap.TryGetValue(tag, out var entry))
        {
            if (entry.Count != 1) throw new TiffDirectoryEntryFormatException();
            if (entry.Type == TiffType.ULong) return Parent._bytesCodec.ReadUInt32(entry.ValueOrOffset);
            throw new TiffDirectoryEntryFormatException();
        }
        return null;
    }

    public uint? GetEntryUInt32OrUInt16(TiffTag tag)
    {
        if (EntryMap.TryGetValue(tag, out var entry))
        {
            if (entry.Count != 1) throw new TiffDirectoryEntryFormatException();
            if (entry.Type == TiffType.ULong) return Parent._bytesCodec.ReadUInt32(entry.ValueOrOffset);
            if (entry.Type == TiffType.UShort) return Parent._bytesCodec.ReadUInt16(entry.ValueOrOffset);
            throw new TiffDirectoryEntryFormatException();
        }
        return null;
    }

    public void SetEntryUInt32(TiffTag tag, uint value)
    {
        throw new TiffDirectoryEntryFormatException();
    }
}