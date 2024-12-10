using SolidImage.Tiff.Format.Enums;
using SolidImage.Tiff.Format.Exceptions;

namespace SolidImage.Tiff.Format;

public static class ImageFileDirectoryStandardExtension
{
    public static SubfileType? GetSubfileType(this ImageFileDirectory ifd)
    {
        return (SubfileType?)ifd.GetEntryUInt32(TiffTag.NewSubfileType);
    }

    public static uint GetImageWidth(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt32OrUInt16(TiffTag.ImageWidth) ?? throw new TiffDirectoryEntryFormatException();
    }

    public static uint GetImageHeight(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt32OrUInt16(TiffTag.ImageLength) ?? throw new TiffDirectoryEntryFormatException();
    }

    public static ushort GetBitsPerSample(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTag.BitsPerSample) ?? throw new TiffDirectoryEntryFormatException();
    }

    public static Compression GetCompression(this ImageFileDirectory ifd)
    {
        return (Compression)(ifd.GetEntryUInt16(TiffTag.Compression) ?? throw new TiffDirectoryEntryFormatException());
    }

    public static Photometric? GetPhotometric(this ImageFileDirectory ifd)
    {
        return (Photometric?)ifd.GetEntryUInt16(TiffTag.Photometric);
    }

    public static Threshholding? GetThreshholding(this ImageFileDirectory ifd)
    {
        return (Threshholding?)ifd.GetEntryUInt16(TiffTag.Threshholding);
    }

    public static ushort? GetCellWidth(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTag.CellWidth);
    }

    public static ushort? GetCellHeight(this ImageFileDirectory ifd)
    {
        return ifd.GetEntryUInt16(TiffTag.CellLength);
    }

    public static FillOrder? GetFillOrder(this ImageFileDirectory ifd)
    {
        return (FillOrder?)ifd.GetEntryUInt16(TiffTag.FillOrder);
    }

    public static string? GetDocumentName(this ImageFileDirectory ifd)
    {
        throw new NotImplementedException();
    }

}
