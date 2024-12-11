using SolidImage.TiffLib.Enums;

namespace SolidImage.TiffLib;

public static class ImageFileDirectoryExtension
{
    public static SubfileType? GetSubfileType(this ImageFileDirectory ifd)
    {
        return (SubfileType?)ifd.GetEntryUInt32(TiffTags.NewSubfileType);
    }

    public static uint? GetImageWidth(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.ImageWidth) ?? ifd.GetEntryUInt32(TiffTags.ImageWidth);
    }

    public static uint? GetImageHeight(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.ImageLength) ?? ifd.GetEntryUInt32(TiffTags.ImageLength);
    }

    public static ushort? GetBitsPerSample(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.BitsPerSample);
    }

    public static Compression? GetCompression(this ImageFileDirectory ifd)
    {
        return (Compression?)ifd.GetEntryUInt16(TiffTags.Compression);
    }

    public static Photometric? GetPhotometric(this ImageFileDirectory ifd)
    {
        return (Photometric?)ifd.GetEntryUInt16(TiffTags.Photometric);
    }

    public static Threshholding? GetThreshholding(this ImageFileDirectory ifd)
    {
        return (Threshholding?)ifd.GetEntryUInt16(TiffTags.Threshholding);
    }

    public static ushort? GetCellWidth(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.CellWidth);
    }

    public static ushort? GetCellHeight(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.CellLength);
    }

    public static FillOrder? GetFillOrder(this ImageFileDirectory ifd)
    {
        return (FillOrder?)ifd.GetEntryUInt16(TiffTags.FillOrder);
    }

    public static uint[]? GetStripOffsets(this ImageFileDirectory ifd)
    {
        var v16 = ifd.GetEntryManyUInt16(TiffTags.StripOffsets);
        if (!v16.IsEmpty)
        {
            return v16.ToArray().Select(a => (uint)a).ToArray();
        }
        var v32 = ifd.GetEntryManyUInt32(TiffTags.StripOffsets);
        if (!v32.IsEmpty)
        {
            return v32.ToArray();
        }

        return null;
    }

    public static ushort? GetSamplesPerPixel(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.SamplesPerPixel);
    }

    public static uint? GetRowsPerStripe(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTags.RowsPerStrip) ?? ifd.GetEntryUInt32(TiffTags.RowsPerStrip);
    }

    public static uint[]? GetStripByteCounts(this ImageFileDirectory ifd)
    {
        var v16 = ifd.GetEntryManyUInt16(TiffTags.StripByteCounts);
        if (!v16.IsEmpty)
        {
            return v16.ToArray().Select(a => (uint)a).ToArray();
        }
        var v32 = ifd.GetEntryManyUInt32(TiffTags.StripByteCounts);
        if (!v32.IsEmpty)
        {
            return v32.ToArray();
        }

        return null;
    }

    public static decimal? GetXResolution(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryURational(TiffTags.XResolution);
    }

    public static decimal? GetYResolution(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryURational(TiffTags.YResolution);
    }

    public static ResolutionUnit? GetResolutionUnit(this ImageFileDirectory ifd)
    {
        return (ResolutionUnit?)ifd.GetEntryUInt16(TiffTags.ResolutionUnit);
    }

    public static ushort[] GetColorMap(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryManyUInt16(TiffTags.ColorMap).ToArray();
    }

}
