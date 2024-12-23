namespace SolidImage.TIFF;

public static class TiffImageExtension
{
    public static SubfileType? GetsubfileType(this TiffImage image)
    {
        if (image.TryGetEntryUInt32(TiffTags.NewSubfileType, out uint value)) return (SubfileType)value;
        return null;
    }

    public static uint GetImageWidth(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.ImageWidth, out var v16)) return v16;
        if (image.TryGetEntryUInt32(TiffTags.ImageWidth, out var v32)) return v32;
        return default;
    }

    public static uint GetImageHeight(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.ImageLength, out var v16)) return v16;
        if (image.TryGetEntryUInt32(TiffTags.ImageLength, out var v32)) return v32;
        return default;
    }

    public static ReadOnlySpan<ushort> GetBitsPerSample(this TiffImage image)
    {
        if (image.TryGetEntryUInt16Range(TiffTags.BitsPerSample, out var v16s)) return v16s;
        return default;
    }

    public static Compression? GetCompression(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.Compression, out var v)) return (Compression)v;
        return default;
    }

    public static Photometric? GetPhotometric(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.Photometric, out var v)) return (Photometric)v;
        return default;
    }

    public static Threshholding? GetThreshholding(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.Threshholding, out var v)) return (Threshholding)v;
        return default;
    }

    public static ushort GetCellWidth(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.CellWidth, out var v)) return v;
        return default;
    }

    public static ushort GetCellHeight(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.CellLength, out var v)) return v;
        return default;
    }

    public static FillOrder? GetFillOrder(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.FillOrder, out var v)) return (FillOrder)v;
        return default;
    }

    public static string? GetDocumentName(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.DocumentName, out var v)) return v;
        return default;
    }

    public static string? GetImageDescription(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.ImageDescription, out var v)) return v;
        return default;
    }

    public static string? GetMake(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.Make, out var v)) return v;
        return default;
    }

    public static string? GetModel(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.Model, out var v)) return v;
        return default;
    }

    public static ReadOnlySpan<uint> GetStripOffsets(this TiffImage image)
    {
        if (image.TryGetEntryUInt16Or32Range(TiffTags.StripOffsets, out var values)) return values;
        return default;
    }

    // TODO: orientation

    public static ushort GetSamplesPerPixel(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.SamplesPerPixel, out var v)) return v;
        return default;
    }

    public static uint GetRowsPerStrip(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.RowsPerStrip, out var v16)) return v16;
        if (image.TryGetEntryUInt32(TiffTags.RowsPerStrip, out var v32)) return v32;
        return default;
    }

    public static ReadOnlySpan<uint> GetStripByteCounts(this TiffImage image)
    {
        if (image.TryGetEntryUInt16Or32Range(TiffTags.StripByteCounts, out var values)) return values;
        return default;
    }

    // TODO MinSampleValue

    // TODO MaxSampleValue

    public static Rational GetXResolution(this TiffImage image)
    {
        if (image.TryGetEntryRational(TiffTags.XResolution, out var v)) return v;
        return default;
    }

    public static Rational GetYResolution(this TiffImage image)
    {
        if (image.TryGetEntryRational(TiffTags.YResolution, out var v)) return v;
        return default;
    }

    public static PlanarConfiguration? GetPlanarConfiguration(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.PlanarConfiguration, out var v)) return (PlanarConfiguration)v;
        return default;
    }

    // TODO PageName

    // TODO XPosition

    // TODO YPosition

    // TODO FreeOFfsets

    // TODO FreeByteCounts

    // TODO GrayResponseUnit

    // TODO GrayResponseCurve

    // TODO T4Options

    // TODO T6Options

    public static ResolutionUnit? GetResolutionUnit(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.ResolutionUnit, out var v)) return (ResolutionUnit)v;
        return default;
    }

    // TODO PageNumber

    // TODO TransferFunction 

    public static string? GetSoftware(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.Software, out var v)) return v;
        return default;
    }

    public static string? GetDateTime(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.DateTime, out var v)) return v;
        return default;
    }

    public static string? GetArtist(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.Artist, out var v)) return v;
        return default;
    }

    public static string? GetHostComputer(this TiffImage image)
    {
        if (image.TryGetEntryAscii(TiffTags.HostComputer, out var v)) return v;
        return default;
    }

    public static Predictor? GetPredictor(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.Predictor, out var v)) return (Predictor)v;
        return default;
    }

    // TODO WhitePoint

    // TODO PrimaryChromaticcities

    public static ReadOnlySpan<ushort> GetColorMap(this TiffImage image)
    {
        if (image.TryGetEntryUInt16Range(TiffTags.ColorMap, out var v)) return v;
        return default;
    }

    public static uint GetTileWidth(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.TileWidth, out var v16)) return v16;
        if (image.TryGetEntryUInt32(TiffTags.TileWidth, out var v32)) return v32;
        return default;
    }

    public static uint GetTileHeight(this TiffImage image)
    {
        if (image.TryGetEntryUInt16(TiffTags.TileLength, out var v16)) return v16;
        if (image.TryGetEntryUInt32(TiffTags.TileLength, out var v32)) return v32;
        return default;
    }

    public static ReadOnlySpan<uint> GetTileOffsets(this TiffImage image)
    {
        if (image.TryGetEntryUInt16Or32Range(TiffTags.TileOffsets, out var v)) return v;
        return default;
    }

    public static ReadOnlySpan<uint> GetTileByteCounts(this TiffImage image)
    {
        if (image.TryGetEntryUInt16Or32Range(TiffTags.TileByteCounts, out var v)) return v;
        return default;
    }

    // TODO InkSet

    // TODO InkNames

    // TODO NumberOfInks

    // TODO DotRange

    // TODO TargetPrinter

    public static byte GetExtraSamples(this TiffImage image)
    {
        if (image.TryGetEntryUInt8(TiffTags.ExtraSamples, out var v)) return v;
        return default;
    }

    // TODO Sample Format

    // TODO SMinSampleValue

    // TODO SMaxSampleValue

    // TODO TransferRange

    // TODO JPEGProc

    // TODO JPEGInterchangeFormat

    // TODO JPEGInterchangeFormatLngth

    // TODO JPEGRestartInterval

    // TODO JPEGLosslessPredictors

    // TODO JPEGPointTransforms

    // TODO JPEGQTables

    // TODO JPEGDCTables

    // TODO JPEGACTables

    // TODO YCbCrCoefficients

    // TODO YCbCrSubSampling

    // TODO YCbCrPositioning

    // TODO ReferenceBlackWhite

    // TODO Copyright
}
